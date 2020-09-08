using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace Bread_Tools.Resources.Pages
{
    /// <summary>
    /// Interaction logic for PowerPage.xaml
    /// </summary>
    public partial class PowerPage : Page
    {
        public PowerPage()
        {
            InitializeComponent();

            this.Hibernate.Loaded += this.LoadField;
            this.Lock.Loaded += this.LoadField;
            this.Restart.Loaded += this.LoadField;
            this.ShutDown.Loaded += this.LoadField;
            this.Sleep.Loaded += this.LoadField;
            this.SwitchUser.Loaded += this.LoadField;
            this.LogOff.Loaded += this.LoadField;
            this.RestartWithBootOptions.Loaded += this.LoadField;

            this.Position.Loaded += this.LoadField;

            ////////////////////
            
            this.Hibernate.Switched += this.SaveField;
            this.Lock.Switched += this.SaveField;
            this.Restart.Switched += this.SaveField;
            this.ShutDown.Switched += this.SaveField;
            this.Sleep.Switched += this.SaveField;
            this.SwitchUser.Switched += this.SaveField;
            this.LogOff.Switched += this.SaveField;
            this.RestartWithBootOptions.Switched += this.SaveField;

            this.Position.SelectionChanged += this.SaveField;
        }

        private void SaveField(object sender, EventArgs e)
            => Settings.SaveUISettings<Types.PowerTools.Settings>(sender, Settings.Data.power);

        private void LoadField(object sender, EventArgs e)
            => Settings.LoadUISettings<Types.PowerTools.Settings>(sender, Settings.Data.power);

        private void SaveButton_Click(object sender, RoutedEventArgs e)
            => Settings.SaveSettings();

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
}