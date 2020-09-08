using Bread_Tools.Resources;
using Bread_Tools.Resources.Pages;
using System;
using System.Linq;
using System.Security.Principal;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

using System.IO;

using MessagePack;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bread_Tools
{
    public partial class MainWindow : Window
    {
        List<Page> windowPages = new List<Page>()
        {
            new GeneralPage(),
            new CommandPage(),
            new PowerPage(),
            new PCSettingsPage()
        };

        private readonly SettingsWindow settingsWindow;

        private string highLightColor = "#CFCFCF";
        private string unHighLightColor = "#E6E6E6";

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

            MessagePackSerializer.DefaultOptions = MessagePack.Resolvers.ContractlessStandardResolverAllowPrivate.Options;

            if (Settings.HasSettings())
                Settings.LoadSettings();

            Settings.SaveSettings();

            this.settingsWindow = new SettingsWindow();

            // Open General by default
            StackPanel which = this.MainPanel.Children.OfType<StackPanel>().First();
            this.ShowGeneralPage(which, null);

            this.LoadWindowsTerminalStuff();
        }

        private void LoadWindowsTerminalStuff()
        {
            // WINDOWS TERMINAL

            try
            {
                Process windowsTerm = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        FileName = "wsl",
                        Arguments = "--list"
                    }
                };

                windowsTerm.Start();
                windowsTerm.StandardOutput.ReadToEnd();

                windowsTerm.WaitForExit();
                windowsTerm.Close();
            }
            catch (Exception)
            {
                // Not installed, disable Command stuff
                this.windowPages[1].IsEnabled = false;
            }

            // WINDOWS SUBSYSTEM FOR LINUX

            try
            {
                // Find default WSL distro
                if (!this.windowPages[1].IsEnabled)
                    return;

                Process p = new Process()
                {
                    StartInfo = new ProcessStartInfo()
                    {
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        FileName = "wsl",
                        Arguments = "--list"
                    }
                };

                p.Start();
                p.StandardOutput.ReadToEnd();
                p.WaitForExit();
                p.Close();
            }
            catch (Exception)
            {
                // TO DO: disable WSL stuff
            }
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
            this.PageContent.Content = this.windowPages[0];
            this.SelectPanelItem(sender, e);
        }

        private void ShowCommandPage(object sender, MouseButtonEventArgs e)
        {
            this.PageContent.Content = this.windowPages[1];
            this.SelectPanelItem(sender, e);
        }

        private void ShowPowerPage(object sender, MouseButtonEventArgs e)
        {
            this.PageContent.Content = this.windowPages[2];
            this.SelectPanelItem(sender, e);
        }

        private void ShowPCSettingsPage(object sender, MouseButtonEventArgs e)
        {
            this.PageContent.Content = this.windowPages[3];
            this.SelectPanelItem(sender, e);
        }

        private void ShowGlobalConfig(object sender, MouseButtonEventArgs e)
        {
            this.settingsWindow.Owner = this;
            this.settingsWindow.ShowDialog();
        }

        private void ApplySettings(object sender, MouseButtonEventArgs e)
        {
            //Settings.SaveSettings();
            WinRegistry.WriteToRegistry();
        }
    }
}