using Bread_Tools.Resources;
using Bread_Tools.Resources.Pages;
using MessagePack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Bread_Tools
{
    public partial class MainWindow : Window
    {
        private GeneralPage general;
        private CommandPage command;
        private PowerPage power;
        private PCSettingsPage pcSettings;

        private string highLightColor = "#CFCFCF";
        private string unHighLightColor = "#E6E6E6";

        private static string APPDATA_DIRECTORY = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static string SAVE_DIRECTORY = APPDATA_DIRECTORY + "/Bread Tools";
        private static string SAVE_FILE = SAVE_DIRECTORY + "/Settings";

        private static string USERNAME = Environment.UserName;

        Dictionary<string, bool> settings = new Dictionary<string, bool>()
        {

        };

        public static bool IsAdministrator()
        {
            using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
            {
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
        }

        public MainWindow()
        {
            InitializeComponent();

            if (!Directory.Exists(SAVE_DIRECTORY))
                Directory.CreateDirectory(SAVE_DIRECTORY);

            if (!File.Exists(SAVE_FILE))
            {
                var bin = MessagePackSerializer.Serialize(Settings.Data);
                File.WriteAllBytes(SAVE_FILE, bin);
            }

            this.general = new GeneralPage();
            this.command = new CommandPage();

            this.power = new PowerPage();
            this.pcSettings = new PCSettingsPage();

            StackPanel which = this.MainPanel.Children.OfType<StackPanel>().First();
            this.ShowGeneralPage(which, null);
        }

        private SolidColorBrush GetBrushColor(string color)
        {
            SolidColorBrush brush = (SolidColorBrush)(new BrushConverter().ConvertFrom(color));
            return brush;
        }

        private void HoverPanel(object sender, EventArgs e)
        {
            StackPanel panel = sender as StackPanel;
            panel.Background = this.GetBrushColor(this.highLightColor);

            this.Cursor = Cursors.Hand;
        }

        private void UnHoverPanel(object sender, EventArgs e)
        {
            StackPanel panel = sender as StackPanel;
            panel.Background = this.GetBrushColor(this.unHighLightColor);

            this.Cursor = Cursors.Arrow;
        }

        private void DeSelectPanelItem(object sender)
        {
            StackPanel panel = sender as StackPanel;

            Label label = panel.Children.OfType<Label>().First();
            label.FontWeight = FontWeights.Normal;

            try
            {
                Rectangle rect = panel.Children.OfType<Rectangle>().First();

                rect.Fill = Brushes.Transparent;
            }
            catch (Exception)
            { }
        }

        private void SelectPanelItem(object sender, EventArgs e)
        {
            StackPanel panel = sender as StackPanel;

            Label label = panel.Children.OfType<Label>().First();

            if (label.FontWeight == FontWeights.Bold)
                return;

            foreach (var child in this.MainPanel.Children)
                this.DeSelectPanelItem(child);

            label.FontWeight = FontWeights.Bold;

            Rectangle rect = panel.Children.OfType<Rectangle>().First();

            rect.Fill = Brushes.DeepSkyBlue;

        }

        private void ShowGeneralPage(object sender, MouseButtonEventArgs e)
        {
            this.PageContent.Content = this.general;
            this.SelectPanelItem(sender, e);
        }

        private void ShowCommandPage(object sender, MouseButtonEventArgs e)
        {
            this.PageContent.Content = this.command;
            this.SelectPanelItem(sender, e);
        }

        private void ShowPowerPage(object sender, MouseButtonEventArgs e)
        {
            this.PageContent.Content = this.power;
            this.SelectPanelItem(sender, e);
        }

        private void ShowPCSettingsPage(object sender, MouseButtonEventArgs e)
        {
            this.PageContent.Content = this.pcSettings;
            this.SelectPanelItem(sender, e);
        }

        private void ApplySettings(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
