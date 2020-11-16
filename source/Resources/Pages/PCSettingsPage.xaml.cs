using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Bread_Tools.Resources.Pages
{
    public partial class PCSettingsPage : Page
    {
        List<UIElement> elements;

        public PCSettingsPage()
        {
            InitializeComponent();

            this.MainSettings.Loaded += this.LoadField;
            this.NetworkInternet.Loaded += this.LoadField;
            this.AboutThisPC.Loaded += this.LoadField;
            this.WindowsUpdate.Loaded += this.LoadField;

            ////////////////////

            this.MainSettings.Switched += this.SaveField;
            this.NetworkInternet.Switched += this.SaveField;
            this.AboutThisPC.Switched += this.SaveField;
            this.WindowsUpdate.Switched += this.SaveField;

            this.elements = new List<UIElement>()
            { 
                this.MainSettings, this.NetworkInternet, 
                this.AboutThisPC,  this.WindowsUpdate 
            };
        }

        public void SaveElements()
        {
            foreach (UIElement element in this.elements)
                this.SaveField(element, null);
        }

        public void RefreshPage()
        {
            foreach (UIElement element in this.elements)
                this.LoadField(element, null);
        }

        private void SaveField(object sender, EventArgs e)
            => Settings.SaveUISettings<Types.SettingsTools.Settings>(sender, Settings.Data.settings);

        private void LoadField(object sender, EventArgs e)
            => Settings.LoadUISettings<Types.SettingsTools.Settings>(sender, Settings.Data.settings);

        private void SaveButton_Click(object sender, RoutedEventArgs e)
            => Settings.SaveSettings();
    }
}