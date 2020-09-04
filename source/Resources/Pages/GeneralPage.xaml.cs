using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using Types = Bread_Tools.Resources.Types;
using Bread_Tools.Resources;

namespace Bread_Tools
{
    public partial class GeneralPage : Page
    {
        private Types.GeneralTools.Settings settings;
        private List<UIElement> elements;

        public List<UIElement> Elements => elements;

        public GeneralPage()
        {
            InitializeComponent();

            this.settings = Settings.Data.general;

            this.elements = new List<UIElement>()
            {
                this.HiddenFilesFolders,
                this.OpenRegedit,
                this.RestartExplorer,
                this.ShowFileExtensions,
                this.PositionTop,
                this.PositionBottom
            };

            Settings.LoadUISettings<Types.GeneralTools.Settings>(this.elements, this.settings);
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Do you want to save changes?";
            string caption = "Bread Tools";

            MessageBoxButton button = MessageBoxButton.YesNoCancel;
            MessageBoxImage icon = MessageBoxImage.Warning;

            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            Settings.SaveUISettings<Types.GeneralTools.Settings>(this.elements, this.settings);

            if (result == MessageBoxResult.Yes)
            {
                Settings.Data.general = this.settings;
                Settings.SaveSettings();
            }
        }
    }
}