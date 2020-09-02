using Bread_Tools.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using Toggle = ToggleSwitch.ToggleSwitch;

namespace Bread_Tools
{
    public partial class GeneralPage : Page
    {
        Settings.General general = new Settings.General();

        public GeneralPage()
            => InitializeComponent();
        

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Do you want to save changes?";
            string caption = "Bread Tools";

            //MessageBoxButton button = MessageBoxButton.YesNoCancel;
            //MessageBoxImage icon = MessageBoxImage.Warning;

            //MessageBox.Show(messageBoxText, caption, button, icon);

            foreach (var x in this.DataGrid.Children.OfType<Grid>())
            {
                foreach (var y in x.Children.OfType<StackPanel>())
                {
                    foreach (UIElement item in y.Children)
                    {
                        foreach (var field in typeof(Settings.General).GetFields())
                        {
                            object boxed = this.general;
                            if (item is Toggle && (item as Toggle).Name == field.Name)
                                field.SetValue(boxed, (item as Toggle).IsOn);
                            else if (item is RadioButton)
                            {
                                RadioButton radio = (item as RadioButton);

                                if (radio.IsChecked == true && field.Name == "position")
                                    field.SetValue(boxed, radio.Content.ToString());
                            }
                                
                            this.general = (Settings.General)boxed;
                        }
                    }
                }
            }

            Settings.Data.general = this.general;
            foreach (var field in typeof(Settings.General).GetFields())
                Console.WriteLine(field.GetValue(Settings.Data.general));
        }
    }
}
