using System;
using System.IO;
using YamlDotNet.Serialization;

namespace Bread_Tools.Resources
{
    static class Registry
    {
        private static readonly string REGEDIT_INFO = "Resources/RegistryData.yaml";

        struct Regedit
        {
            public Types.GeneralTools.Registry[]  general;
            public Types.SettingsTools.Registry[] settings;
        };

        static IDeserializer deserializer = new DeserializerBuilder().Build();
        static Regedit REGEDIT = deserializer.Deserialize<Regedit>(File.ReadAllText(REGEDIT_INFO));

        public static void WriteToRegistry()
        {
            Console.WriteLine(REGEDIT);
        }
    }
}
