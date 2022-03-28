using System;
using System.Windows;
using System.Windows.Media;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.Win32;

namespace Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            textBox.Background = new SolidColorBrush(backgroundColorPicker.SelectedColor.Value);
            textBox.Foreground = new SolidColorBrush(foregroundColorPicker.SelectedColor.Value);
            if(double.TryParse(fontSizeValue.Text, out double fontSize))
            {
                textBox.FontSize = fontSize;
            }
            FontFamily fontFamily = new(fontFamilyValue.Text);
            textBox.FontFamily = fontFamily;

            //SaveSettingsToConfig();
            SaveSettingsToRegistr();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //LoadSettingsFromConfig();
            LoadSettingsFromRegister();
        }
        private void SaveSettingsToRegistr()
        {
            RegistryKey key = Registry.CurrentUser;
            RegistryKey subKey = key.OpenSubKey("Software", true);
            RegistryKey subSubKey = subKey.CreateSubKey("CyberBionicHW034Task4");

            subSubKey.SetValue("backgroundColor", backgroundColorPicker.SelectedColor.Value.ToString());
            subSubKey.SetValue("foregroundColor", foregroundColorPicker.SelectedColor.Value.ToString());
            subSubKey.SetValue("fontSize", textBox.FontSize);
            subSubKey.SetValue("fontFamily", textBox.FontFamily.ToString());
        }
        private void LoadSettingsFromRegister()
        {
            RegistryKey key = Registry.CurrentUser;
            RegistryKey subKey = key.OpenSubKey("Software\\CyberBionicHW034Task4");
            
            textBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(subKey.GetValue("backgroundColor") as string));
            textBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(subKey.GetValue("foregroundColor") as string));
            textBox.FontSize = Convert.ToDouble(subKey.GetValue("fontSize"));
            FontFamily fontFamily = new(subKey.GetValue("fontFamily") as string);
            textBox.FontFamily = fontFamily;
        }
        private void SaveSettingsToConfig()
        {
            var appSettings = ConfigurationManager.AppSettings;
            appSettings["backgroundColor"] = backgroundColorPicker.SelectedColor.Value.ToString();
            appSettings["foregroundColor"] = foregroundColorPicker.SelectedColor.Value.ToString();
            appSettings["fontSize"] = textBox.FontSize.ToString();
            appSettings["fontFamily"] = textBox.FontFamily.FamilyNames.ToString();
        }
        private void LoadSettingsFromConfig()
        {
            var appSettings = ConfigurationManager.AppSettings;
            textBox.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(appSettings["backgroundColor"]));
            textBox.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString(appSettings["foregroundColor"]));
            textBox.FontSize = Convert.ToDouble(appSettings["fontSize"]);
            FontFamily fontFamily = new(appSettings["fontFamily"]);
            textBox.FontFamily = fontFamily;
        }
    }
}
