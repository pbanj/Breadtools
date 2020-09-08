using System;
using System.IO;
using System.Reflection;
using System.Windows.Controls;

using MessagePack;
using Toggle = ToggleSwitch.ToggleSwitch;

namespace Bread_Tools.Resources
{
    /*
    ** I wanted to use MsgPack-CSharp but it isn't working
    ** Temporarily using YAMLDotNet
    */

    internal static class Settings
    {
        private static readonly string APPDATA_DIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string SAVE_DIRECTORY = APPDATA_DIRECTORY + "/Bread Tools";
        private static readonly string SAVE_FILE = SAVE_DIRECTORY + "/Settings";

        public struct Info
        {
            public Types.GeneralTools.Settings  general;
            public Types.CommandTools.Settings  command;
            public Types.PowerTools.Settings    power;
            public Types.SettingsTools.Settings settings;

            public Types.Global.Settings        globals;
        };

        public static Info Data = new Info()
        {
            general = new Types.GeneralTools.Settings(),
            command = new Types.CommandTools.Settings(),
            power = new Types.PowerTools.Settings(),
            settings = new Types.SettingsTools.Settings(),
            globals = new Types.Global.Settings()
        };

        public static void LoadUISettings<T>(object sender, dynamic structValue)
        {
            string name = "";

            dynamic element;
            if (sender is Toggle)
            {
                element = (sender as Toggle);
                name = element.Name;
            }
            else if (sender is ComboBox)
            {
                element = (sender as ComboBox);
                name = element.Name;
            }

            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (property.Name == name || name.Contains(property.Name))
                {
                    if (sender is Toggle)
                        (sender as Toggle).IsOn = (bool)property.GetValue(structValue);
                    else if (sender is ComboBox)
                        (sender as ComboBox).SelectedIndex = (int)property.GetValue(structValue);
                }
            }
        }

        public static void DebugStruct<T>(dynamic structValue)
        {
            var fields = typeof(T).GetProperties();

            foreach (var field in fields)
                Console.WriteLine(field.Name + ": " + field.GetValue(structValue));
        }

        public static dynamic GetValue<T>(string name, dynamic value)
        {
            var fields = typeof(T).GetProperties();
            dynamic ret = false;

            foreach (var field in fields)
            {
                if (field.Name == name)
                {
                    ret = field.GetValue(value);
                    break;
                }
            }

            return ret;
        }

        public static void SaveUISettings<T>(object sender, dynamic structValue)
        {
            string name = "";

            dynamic element;
            dynamic value = false;

            if (sender is Toggle)
            {
                element = (sender as Toggle);
                value = element.IsOn;
                name = element.Name;
            }
            else if (sender is ComboBox)
            {
                element = (sender as ComboBox);
                value = element.SelectedIndex;
                name = element.Name;
            }

            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                if (property.Name == name || name.Contains(property.Name))
                {
                    if (value is bool boolean)
                        property.SetValue(structValue, boolean);
                    else if (value is int number)
                        property.SetValue(structValue, number);
                }
            }
        }

        public static bool HasSettings()
        {
            if (!Directory.Exists(SAVE_DIRECTORY))
                Directory.CreateDirectory(SAVE_DIRECTORY);

            return File.Exists(SAVE_FILE);
        }

        public static void LoadSettings()
            => Data = MessagePackSerializer.Deserialize<Info>(File.ReadAllBytes(SAVE_FILE));


        public static void SaveSettings()
        {
            File.WriteAllBytes(SAVE_FILE, MessagePackSerializer.Serialize(Data, MessagePack.Resolvers.ContractlessStandardResolverAllowPrivate.Options));
            DebugStruct<Types.PowerTools.Settings>(Data.power);
        }
    }
}