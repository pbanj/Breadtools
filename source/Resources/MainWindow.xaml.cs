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

using MessagePack;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Reflection;

namespace Bread_Tools
{
    public partial class MainWindow : Window
    {
        List<dynamic> windowPages;

        private readonly SettingsWindow settingsWindow;

        private string highLightColor = "#CFCFCF";
        private string unHighLightColor = "#E6E6E6";

        private string WINDOWS_TERMINAL_PATH = @"C:\Users\{0}\AppData\Local\Microsoft\WindowsApps\wt.exe";
        private string USERNAME = Environment.UserName;

        public MainWindow()
        {
            InitializeComponent();

            MessagePackSerializer.DefaultOptions = MessagePack.Resolvers.ContractlessStandardResolverAllowPrivate.Options;

            try
            {
                Settings.CreateSettings();

                if (Settings.HasSettings())
                    Settings.LoadSettings();

                Settings.DebugStruct<Resources.Types.SettingsTools.Settings>(Settings.Data.settings);

                this.windowPages = new List<dynamic>()
                {
                    new GeneralPage(),
                    new CommandPage(),
                    new PowerPage(),
                    new PCSettingsPage()
                };
            }
            catch (Exception e)
            {
                File.WriteAllText("traceback.txt", e.Message);
            }

            Settings.SaveSettings();

            this.settingsWindow = new SettingsWindow();

            // Open General by default
            StackPanel which = this.MainPanel.Children.OfType<StackPanel>().First();
            this.ShowGeneralPage(which, null);

            this.LoadWindowsTerminalStuff();

            this.UninstallToolsButton.IsEnabled = WinRegistry.AreComponentsInstalled();
        }

        private void LoadWindowsTerminalStuff()
        {
            // WINDOWS TERMINAL

            if (!File.Exists(string.Format(WINDOWS_TERMINAL_PATH, USERNAME)))
                this.windowPages[1].IsEnabled = false;

            // WINDOWS SUBSYSTEM FOR LINUX

            string [] output;

            try
            {
                // Find default WSL distro
                if (!this.windowPages[1].IsEnabled)
                    return;

                using (Process process = new Process())
                {
                    process.StartInfo.FileName = "wsl";
                    process.StartInfo.Arguments = "--list";

                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;

                    process.Start();

                    StreamReader reader = process.StandardOutput;
                    
                    output = reader.ReadToEnd().Trim().Replace("\n", "").Split(':');
                    process.WaitForExit();
                };

                string distro;
                foreach (string item in output)
                {
                    StringBuilder builder = new StringBuilder();

                    foreach (char c in item)
                    {
                        if (c > 0)
                            builder.Append(c);
                    }

                    if ((distro = builder.ToString()).Contains("Default"))
                    {
                        WinRegistry.WSL_DISTRO_NAME = distro.Substring(0, distro.IndexOf("(")).Trim();
                        Console.WriteLine($"Distro: '{WinRegistry.WSL_DISTRO_NAME}'");
                        break;
                    }
                }
            }
            catch (Exception)
            {
                (this.windowPages[1] as CommandPage).Elements[0].IsEnabled = false;
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
            foreach (var page in this.windowPages)
                page.SaveElements();

            Settings.SaveSettings();

            WinRegistry.WriteToRegistry();

            this.UninstallToolsButton.IsEnabled = WinRegistry.AreComponentsInstalled();
        }

        private void UninstallTools(object sender, MouseButtonEventArgs e)
        {
            WinRegistry.RemoveRegistryData();

            this.UninstallToolsButton.IsEnabled = WinRegistry.AreComponentsInstalled();

            foreach (var page in this.windowPages)
                page.RefreshPage();
        }

        private void MainWindow1_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show($"Thanks for using the Bread Tools installation GUI. Have a fucked day, {USERNAME}.", "Bread Tools", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}