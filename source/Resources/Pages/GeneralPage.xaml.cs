using System;
using System.Windows;
using System.Windows.Controls;

namespace Bread_Tools.Resources.Pages
{
    public partial class GeneralPage : Page
    {
        public GeneralPage()
        {
            InitializeComponent();

            this.HiddenFilesFolders.Loaded += this.LoadField;
            this.OpenRegedit.Loaded += this.LoadField;
            this.ShowFileExtensions.Loaded += this.LoadField;
            this.RestartExplorer.Loaded += this.LoadField;

            this.Position.Loaded += this.LoadField;

            ////////////////////

            this.HiddenFilesFolders.Switched += this.SaveField;
            this.OpenRegedit.Switched += this.SaveField;
            this.ShowFileExtensions.Switched += this.SaveField;
            this.RestartExplorer.Switched += this.SaveField;

            this.Position.SelectionChanged += this.SaveField;
        }

        private void SaveField(object sender, EventArgs e)
            => Settings.SaveUISettings<Types.GeneralTools.Settings>(sender, Settings.Data.general);

        private void LoadField(object sender, EventArgs e)
            => Settings.LoadUISettings<Types.GeneralTools.Settings>(sender, Settings.Data.general);

        private void SaveButton_Click(object sender, RoutedEventArgs e)
            => Settings.SaveSettings();
    }
}