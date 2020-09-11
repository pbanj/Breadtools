using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Bread_Tools.Resources.Pages
{
    public partial class CommandPage : Page
    {
        List<UIElement> elements;
        public List<UIElement> Elements => this.elements;

        public CommandPage()
        {
            InitializeComponent();

            this.OpenWSLHere.Loaded += this.LoadField;
            this.OpenCommandPromptHere.Loaded += this.LoadField;
            this.OpenPowerShellHere.Loaded += this.LoadField;

            ////////////////////

            this.OpenWSLHere.Switched += this.SaveField;
            this.OpenCommandPromptHere.Switched += this.SaveField;
            this.OpenPowerShellHere.Switched += this.SaveField;

            Settings.Data.command.OpenAdminCommandPromptHere = this.OpenCommandPromptHere.IsOn;
            Settings.Data.command.OpenAdminPowerShellHere = this.OpenPowerShellHere.IsOn;

            this.elements = new List<UIElement>()
            {
                this.OpenWSLHere,
                this.OpenCommandPromptHere,
                this.OpenPowerShellHere
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

        private void OpenCommandPromptHere_Click(object sender, RoutedEventArgs e)
            => Settings.Data.command.OpenAdminCommandPromptHere = this.OpenCommandPromptHere.IsOn;

        private void OpenPowerShellHere_Click(object sender, RoutedEventArgs e)
            => Settings.Data.command.OpenAdminPowerShellHere = this.OpenPowerShellHere.IsOn;

        private void SaveField(object sender, EventArgs e)
            => Settings.SaveUISettings<Types.CommandTools.Settings>(sender, Settings.Data.command);

        private void LoadField(object sender, EventArgs e)
            => Settings.LoadUISettings<Types.CommandTools.Settings>(sender, Settings.Data.command);

        private void SaveButton_Click(object sender, RoutedEventArgs e)
            => Settings.SaveSettings();
    }
}