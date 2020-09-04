namespace Bread_Tools.Resources.Types
{
    namespace GeneralTools
    {
        /*
        ** Settings are booleans
        ** Each variable name must match their toggle switch
        ** in the respective XAML layout
        */
        public struct Settings
        {
            public bool HiddenFilesFolders;
            public bool OpenRegedit;
            public bool RestartExplorer;
            public bool ShowFileExtensions;

            public string position;
        };

        /*
        ** Registry values are mixed things
        ** Though these need to be arrays
        ** because multiple registry things per namesapce
        */
        public struct Registry
        {
            public string text;
            public string icon;
            public string command;

            public bool needsAdmin;
        }
    }

    namespace PowerTools
    {
        public struct Settings
        {
            public bool Hibernate;
            public bool Lock;
            public bool Restart;
            public bool ShutDown;
            public bool Sleep;
            public bool SwitchUser;

            public string position;
        }

        public struct Registry
        { }
    }

    namespace CommandTools
    {
        public struct Settings
        {
            public bool OpenWSLHere;
            public bool OpenCommandPromptHere;
            public bool OpenAdminCommandPromptHere;
            public bool OpenPowerShellHere;
            public bool OpenAdminPowerShellHere;

            public string position;
        }

        public struct Registry
        { }
    }

    namespace SettingsTools
    {
        public struct Settings
        {
            public bool MainSettings;
            public bool NetworkInternet;
            public bool AboutThisPC;
            public bool WindowsUpdate;

            public string position;
        }

        public struct Registry
        { }
    }
}
