using System.Reflection.Emit;

namespace Bread_Tools.Resources.Types
{
    namespace GeneralTools
    {
        /*
        ** Settings are booleans
        ** Each variable name must match their toggle switch
        ** in the respective XAML layout
        */
        public class Settings
        {
            public bool HiddenFilesFolders { get; set; }
            public bool OpenRegedit        { get; set; }
            public bool RestartExplorer    { get; set; }
            public bool ShowFileExtensions { get; set; }

            public int Position { get; set; }
        };

        /*
        ** Registry values are mixed things
        ** Though these need to be arrays
        ** because multiple registry things per namesapce
        */
        public struct Registry
        {
            public string text;
            public string name;
            public string path;
            public string icon;
            public string command;

            public bool needsAdmin;
        }
    }

    namespace PowerTools
    {
        public class Settings
        {
            public bool Hibernate  { get; set; }
            public bool Lock       { get; set; }
            public bool Restart    { get; set; }
            public bool ShutDown   { get; set; }
            public bool Sleep      { get; set; }
            public bool SwitchUser { get; set; }

            public int position { get; set; }
        }

        public struct Registry
        { }
    }

    namespace CommandTools
    {
        public class Settings
        {
            public bool OpenWSLHere                { get; set; }
            public bool OpenCommandPromptHere      { get; set; }
            public bool OpenAdminCommandPromptHere { get; set; }
            public bool OpenPowerShellHere         { get; set; }
            public bool OpenAdminPowerShellHere    { get; set; }

            public int Position { get; set; }
        }

        public struct Registry
        { }
    }

    namespace SettingsTools
    {
        public class Settings
        {
            public bool MainSettings    { get; set; }
            public bool NetworkInternet { get; set; }
            public bool AboutThisPC     { get; set; }
            public bool WindowsUpdate   { get; set; }

            public int Position { get; set; }
        }

        public struct Registry
        {
            public string text;
            public string name;
            public string uri;
            public string icon;
            public string path;
            public string command;
        }
    }

    namespace Global
    {
        public class Settings
        {
            public string IconTheme { get; set; }

            public int Position { get; set; }
        }
    }
}
