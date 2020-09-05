using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using YamlDotNet.Serialization;

namespace Bread_Tools.Resources
{
    static class WinRegistry
    {
        private static readonly string REGEDIT_INFO = "Resources/RegistryData.yaml";

        struct Regedit
        {
            public Types.GeneralTools.Registry[]  general;
            public Types.SettingsTools.Registry[] settings;
        };

        static IDeserializer deserializer = new DeserializerBuilder().Build();
        static Regedit REGEDIT = deserializer.Deserialize<Regedit>(File.ReadAllText(REGEDIT_INFO));

        private static string CURRENT_DIRECTORY = Directory.GetCurrentDirectory();

        private static string ROOT_TOOLS_PATH = @"Directory\Background\shell\Tools";
        private static string EXTENDED_CMD_KEY = @"\Directory\ContextMenus\Tools";
        private static string ROOT_TOOLS_ICON = CURRENT_DIRECTORY +  @"\Resources\Icons\tools.ico";
        
        static List<string> ROOT_NODES = new List<string>()
        {
            @"Directory\ContextMenus\Tools",
            @"Directory\ContextMenus\Tools\settings\shell",
            @"Directory\ContextMenus\Tools\shell",
            @"Directory\ContextMenus\Tools\winterm\shell",
            @"Directory\ContextMenus\Tools\shell\6Settings",
            @"Directory\ContextMenus\Tools\shell\2sterm"
        };

        private static void ApplyGeneralRegistryInformation(RegistryKey mainKey, dynamic registryData)
        {
            // Set the Icon
            string icon = registryData.icon;
            if (icon.EndsWith(".ico"))
                icon = CURRENT_DIRECTORY + icon;

            mainKey.SetValue("icon", icon);

            // Set the (Default) value
            mainKey.SetValue("", registryData.text);
        }

        private static void ApplyRegistryChanges(string name)
        {
            Console.WriteLine(name);
            switch (name)
            {
                case "general":
                {
                    /* Thanks, I hate it too */
                    foreach (var registryData in REGEDIT.general)
                    {
                        RegistryKey mainKey = Registry.ClassesRoot.CreateSubKey(registryData.path, true);

                        ApplyGeneralRegistryInformation(mainKey, registryData);

                        // Set if this needs Admin rights
                        if (registryData.needsAdmin)
                            mainKey.SetValue("HasUAShield", "");

                        // Set the command to run
                        RegistryKey commandKey = mainKey.CreateSubKey("command", true);

                        string command = registryData.command;

                        // If the command is a script, prepend the current directory
                        if (command.Contains(".vbs"))
                            command = CURRENT_DIRECTORY + registryData.command;

                        commandKey.SetValue("", command);

                        mainKey.Close();
                        commandKey.Close();
                    }

                    break;
                }
                case "settings":
                {
                    foreach (var registryData in REGEDIT.settings)
                    {
                        RegistryKey mainKey = Registry.ClassesRoot.CreateSubKey(registryData.path, true);
                        ApplyGeneralRegistryInformation(mainKey, registryData);

                        mainKey.SetValue("SettingsURI", registryData.uri);

                        RegistryKey commandKey = mainKey.CreateSubKey("command", true);
                        commandKey.SetValue("DelegateExecute", registryData.command);

                        mainKey.Close();
                        commandKey.Close();
                    }
                    break;
                }
                default:
                    break;
            }
        }

        private static void  UninstallToolsMenu()
        {
            if (Registry.ClassesRoot.OpenSubKey(ROOT_TOOLS_PATH) == null)
                return;

            Registry.ClassesRoot.DeleteSubKeyTree(ROOT_TOOLS_PATH);
            Registry.ClassesRoot.DeleteSubKeyTree(ROOT_NODES[0]);
        }

        private static void CreateRootNode(string keyName)
        {
            if (Registry.ClassesRoot.OpenSubKey(keyName) != null)
                return;

            RegistryKey key = Registry.ClassesRoot.CreateSubKey(keyName, true);

            /* Gross, but meh */
            if (keyName.Contains("6Settings"))
            {
                key.SetValue("", "Settings");

                key.SetValue("icon", CURRENT_DIRECTORY + "/Resources/Icons/settings.ico");
                key.SetValue("ExtendedSubCommandsKey", @"Directory\ContextMenus\Tools\settings");
            }
            else if (keyName.Contains("2sterm"))
            {
                key.SetValue("", "Command Line");

                key.SetValue("icon", CURRENT_DIRECTORY + "/Resources/Icons/terminal.ico");
                key.SetValue("ExtendedSubCommandsKey", @"Directory\ContextMenus\Tools\winterm");
            }

            key.Close();
        }

        public static void WriteToRegistry()
        {
            if (Registry.ClassesRoot.OpenSubKey(ROOT_TOOLS_PATH) == null)
            {
                RegistryKey TOOLS_ROOT = Registry.ClassesRoot.CreateSubKey(ROOT_TOOLS_PATH, true);

                TOOLS_ROOT.SetValue("ExtendedSubCommandsKey", EXTENDED_CMD_KEY);
                TOOLS_ROOT.SetValue("Icon", ROOT_TOOLS_ICON);
                TOOLS_ROOT.Close();
            }

            foreach (string item in ROOT_NODES)
                CreateRootNode(item);

            FieldInfo[] info = typeof(Regedit).GetFields();

            foreach (var item in info)
                ApplyRegistryChanges(item.Name);
        }
    }
}
