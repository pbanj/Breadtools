using Bread_Tools.Resources;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Bread_Tools
{
    public partial class GeneralPage : Page
    {
        private Settings.General general;
        private List<UIElement> elements;

        public GeneralPage()
        {
            InitializeComponent();

            if (Settings.HasSettings())
                this.general = Settings.Data.general;
            else
                this.general = new Settings.General();

            this.elements = new List<UIElement>()
            {
                this.HiddenFilesFolders,
                this.OpenRegedit,
                this.RestartExplorer,
                this.ShowFileExtensions,
                this.PositionTop,
                this.PositionBottom
            };

            Settings.LoadUISettings<Settings.General>(this.elements, this.general);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Do you want to save changes?";
            string caption = "Bread Tools";

            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            Settings.SaveUISettings<Settings.General>(this.elements, this.general);

            if (result == MessageBoxResult.Yes)
            {
                Settings.Data.general = this.general;
                Settings.SaveSettings();
            }
        }
    }
}