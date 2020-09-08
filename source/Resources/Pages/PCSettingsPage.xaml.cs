using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Bread_Tools.Resources.Pages
{
    /// <summary>
    /// Interaction logic for PCSettings.xaml
    /// </summary>
    public partial class PCSettingsPage : Page
    {
        public PCSettingsPage()
        {
            InitializeComponent();

            this.MainSettings.Loaded += this.LoadField ;
            this.NetworkInternet.Loaded += this.LoadField;
            this.AboutThisPC.Loaded += this.LoadField;
            this.WindowsUpdate.Loaded += this.LoadField;

            ////////////////////

            this.MainSettings.Switched += this.SaveField;
            this.NetworkInternet.Switched += this.SaveField;
            this.AboutThisPC.Switched += this.SaveField;
            this.WindowsUpdate.Switched += this.SaveField;
        }

        public void SaveElements()
        {
            List<UIElement> elements = new List<UIElement>() { this.MainSettings, this.NetworkInternet, this.AboutThisPC, this.WindowsUpdate };

            foreach (UIElement element in elements)
                this.SaveField(element, null);
        }
        private void SaveField(object sender, EventArgs e)
            => Settings.SaveUISettings<Types.GeneralTools.Settings>(sender, Settings.Data.general);

        private void LoadField(object sender, EventArgs e)
            => Settings.LoadUISettings<Types.GeneralTools.Settings>(sender, Settings.Data.general);

        private void SaveButton_Click(object sender, RoutedEventArgs e)
            => Settings.SaveSettings();
    }
}