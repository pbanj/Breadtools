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
        private static readonly string REGEDIT_INFO  = "Resources/Registry/Descendants.yaml";
        private static readonly string REGEDIT_ROOTS = "Resources/Registry/RootNodes.yaml"

        private static string USERNAME = Environment.UserName;

        struct Regedit
        {
            public Types.GeneralTools.Registry[]  general;
            public Types.SettingsTools.Registry[] settings;
            public Types.CommandTools.Registry[]  command;
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
            switch (name)
            {
                case "general":
                {
                    /* Thanks, I hate it too */
                    foreach (var registryData in REGEDIT.general)
                    {
                        if (Settings.GetValue<Types.GeneralTools.Settings>(registryData.name, Settings.Data.general) == false)
                            continue;

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
                        {
                            if (registryData.needsAdmin)
                                command = $"explorer /root,{CURRENT_DIRECTORY + registryData.command}";
                            else
                                command = CURRENT_DIRECTORY + registryData.command;
                        }

                        commandKey.SetValue("", command);

                        mainKey.Close();
                        commandKey.Close();
                    }

                    break;
                }
                case "command":
                {
                    foreach (var registryData in REGEDIT.command)
                    {
                        if (Settings.GetValue<Types.CommandTools.Settings>(registryData.name, Settings.Data.command) == false)
                            continue;

                        RegistryKey mainKey = Registry.ClassesRoot.CreateSubKey(registryData.path, true);

                        ApplyGeneralRegistryInformation(mainKey, registryData);

                        RegistryKey commandKey = mainKey.CreateSubKey("command", true);

                        if (registryData.command.Contains(".vbs"))
                        {
                            string[] split = registryData.command.Split(',');

                            commandKey.SetValue("", $"wscript.exe {CURRENT_DIRECTORY + split[0]} {split[1]} {split[2]} {split[3]}");
                        }
                        else
                            commandKey.SetValue("", registryData.command);

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
            if (Registry.ClassesRoot.OpenSubKey(keyName) == null)
                return;

            RegistryKey key = Registry.ClassesRoot.CreateSubKey(keyName, true);

            /* Gross, but meh */
            if (keyName.Contains("6Settings"))
            {
                key.SetValue("", "Settings");

                key.SetValue("Icon", CURRENT_DIRECTORY + "/Resources/Icons/Settings/settings.ico");
                key.SetValue("ExtendedSubCommandsKey", @"Directory\ContextMenus\Tools\settings");

                string position = (Settings.Data.settings.Position == 1) ? "top" : "bottom";

                if (Settings.Data.settings.Position != 0)
                    key.SetValue("Position", position);
               
            }
            else if (keyName.Contains("2sterm"))
            {
                key.SetValue("", "Command Line");

                key.SetValue("Icon", CURRENT_DIRECTORY + "/Resources/Icons/Command/terminal.ico");
                key.SetValue("ExtendedSubCommandsKey", @"Directory\ContextMenus\Tools\winterm");

                string position = (Settings.Data.command.Position == 1) ? "top" : "bottom";

                if (Settings.Data.settings.Position != 0)
                    key.SetValue("Position", position);
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

                string position = (Settings.Data.globals.Position == 1) ? "top" : "bottom";

                if (Settings.Data.settings.Position != 0)
                    TOOLS_ROOT.SetValue("Position", position);

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
