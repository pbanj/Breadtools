using Bread_Tools.Resources.Types;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows;
using YamlDotNet.Serialization;

namespace Bread_Tools.Resources
{
    static class WinRegistry
    {
        private static readonly string REGEDIT_INFO  = "Resources/Registry/Descendants.yaml";
        private static readonly string REGEDIT_ROOTS = "Resources/Registry/RootNodes.yaml";

        struct Regedit
        {
            public Types.GeneralTools.Registry[] general;
            public Types.SettingsTools.Registry[] settings;
            public Types.CommandTools.Registry[] command;
            public Types.PowerTools.Registry[] power;
        };

        struct Nodes
        {
            public RootNodes[] nodes;
        }

        static readonly IDeserializer deserializer = new DeserializerBuilder().Build();

        static Regedit REGEDIT = deserializer.Deserialize<Regedit>(File.ReadAllText(REGEDIT_INFO));
        static Nodes RootNodes = deserializer.Deserialize<Nodes>(File.ReadAllText(REGEDIT_ROOTS));

        private static string CURRENT_DIRECTORY = Directory.GetCurrentDirectory();

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
                case "power":
                {
                    foreach (var registryData in REGEDIT.power)
                    {
                        if (Settings.GetValue<Types.PowerTools.Settings>(registryData.name, Settings.Data.power) == false)
                            continue;

                        RegistryKey mainKey = Registry.ClassesRoot.CreateSubKey(registryData.path, true);

                        ApplyGeneralRegistryInformation(mainKey, registryData);

                        RegistryKey commandKey = mainKey.CreateSubKey("command", true);
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

        public static void RemoveRegistryData()
        {
            if (Registry.ClassesRoot.OpenSubKey(RootNodes.nodes[0].path) == null)
                return;

            MessageBoxResult result = MessageBox.Show("This will remove all Bread Tools components. Continue?", "Bread Tools", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result != MessageBoxResult.Yes)
                return;

            Registry.ClassesRoot.DeleteSubKeyTree(RootNodes.nodes[1].path);
            Registry.ClassesRoot.DeleteSubKey(RootNodes.nodes[0].path);

            Settings.CreateSettings();
        }

        private static bool ShouldCreateSection(string text)
        {
            bool result = false;

            switch (text)
            {
                case "Command Line":
                {
                    result = typeof(Types.CommandTools.Settings).GetProperties().Any(x => 
                        (bool)x.GetValue(Settings.Data.command) != false);
                    break;
                }
                case "Windows Settings":
                {
                    result = typeof(Types.SettingsTools.Settings).GetProperties().Any(x =>
                        (bool)x.GetValue(Settings.Data.settings) != false);
                    break;
                }
                case "Power":
                {
                    result = typeof(Types.PowerTools.Settings).GetProperties().Any(x =>
                        (bool)x.GetValue(Settings.Data.power) != false);
                    break;
                }
                default:
                    break;
            }

            Console.Write(text + ":" + result);

            return result;
        }

        public static void WriteToRegistry()
        {
            foreach (var nodeData in RootNodes.nodes)
            {
                RegistryKey mainKey = Registry.ClassesRoot.CreateSubKey(nodeData.path, true);

                if (!string.IsNullOrEmpty(nodeData.shell))
                {
                    RegistryKey shellKey = Registry.ClassesRoot.CreateSubKey(nodeData.shell, true);

                    if (!string.IsNullOrEmpty(nodeData.text))
                        shellKey.SetValue("", nodeData.text);

                    if (!string.IsNullOrEmpty(nodeData.icon))
                        shellKey.SetValue("Icon", CURRENT_DIRECTORY + nodeData.icon);

                    if (!string.IsNullOrEmpty(nodeData.subcommand))
                        shellKey.SetValue("ExtendedSubCommandsKey", nodeData.subcommand);

                    shellKey.Close();
                }
                else
                {
                    string position = Settings.Data.globals.Position == 2 ? "top" : (Settings.Data.globals.Position == 3 ? "bottom" : "");

                    if (!string.IsNullOrEmpty(position))
                        mainKey.SetValue("Position", position);

                }

                mainKey.Close();
            }

            FieldInfo[] info = typeof(Regedit).GetFields();

            foreach (var item in info)
                ApplyRegistryChanges(item.Name);
        }
    }
}
