using Bread_Tools.Resources;
using Bread_Tools.Resources.Pages;
using MessagePack;
using System;
using System.Linq;
using System.Security.Principal;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

using Types = Bread_Tools.Resources.Types;

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

        private static string USERNAME = Environment.UserName;

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

            MessagePackSerializer.DefaultOptions = MessagePack.Resolvers.ContractlessStandardResolver.Options;

            if (Settings.HasSettings())
                Settings.LoadSettings();

            Settings.SaveSettings();

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

            var rect = panel.Children.OfType<Rectangle>().FirstOrDefault();

            if (rect != null)
                rect.Fill = Brushes.Transparent;
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

        private void ShowGlobalConfig(object sender, MouseButtonEventArgs e)
        {

        }

        private void ApplySettings(object sender, MouseButtonEventArgs e)
        {
            //Settings.SaveSettings();
            WinRegistry.WriteToRegistry();
        }
    }
}