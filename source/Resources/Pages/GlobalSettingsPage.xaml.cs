using System;
using System.Windows;
using System.Windows.Controls;

namespace Bread_Tools.Resources.Pages
{
    public partial class GlobalSettingsPage : Page
    {
        public GlobalSettingsPage()
        {
            InitializeComponent();

            this.Theme.Loaded += this.LoadField;
            this.Position.Loaded += this.LoadField;

            this.Theme.SelectionChanged += this.SaveField;
            this.Position.SelectionChanged += this.SaveField;
        }

        private void SaveField(object sender, EventArgs e)
            => Settings.SaveUISettings<Types.Global.Settings>(sender, Settings.Data.globals);

        private void LoadField(object sender, EventArgs e)
            => Settings.LoadUISettings<Types.Global.Settings>(sender, Settings.Data.globals);

        private void SaveButton_Click(object sender, RoutedEventArgs e)
            => Settings.SaveSettings();
    }
}
