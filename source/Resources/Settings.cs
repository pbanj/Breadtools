using MessagePack;

namespace Bread_Tools.Resources
{
    static class Settings
    {
        public struct General
        {
            public bool HiddenFilesFolders;
            public bool OpenRegedit;
            public bool RestartExplorer;
            public bool ShowFileExtensions;

            public string position;
        };

        public struct Info
        {
            public General general;
        };

        public static Info Data = new Info();
    }
}
