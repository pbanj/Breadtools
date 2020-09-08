using System;
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

            this.Position.Loaded += this.LoadField;

            ////////////////////
            
            this.Hibernate.Switched += this.SaveField;
            this.Lock.Switched += this.SaveField;
            this.Restart.Switched += this.SaveField;
            this.ShutDown.Switched += this.SaveField;
            this.Sleep.Switched += this.SaveField;
            this.SwitchUser.Switched += this.SaveField;

            this.Position.SelectionChanged += this.SaveField;
        }

        private void SaveField(object sender, EventArgs e)
            => Settings.SaveUISettings<Types.CommandTools.Settings>(sender, Settings.Data.command);

        private void LoadField(object sender, EventArgs e)
            => Settings.LoadUISettings<Types.CommandTools.Settings>(sender, Settings.Data.command);

        private void SaveButton_Click(object sender, RoutedEventArgs e)
            => Settings.SaveSettings();
    }
}