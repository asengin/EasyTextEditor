using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyTextEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBox.Focus();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string fontName = ((sender as ComboBox).SelectedItem as string);
            if (textBox != null)
                textBox.FontFamily = new FontFamily(fontName);
        }

        private void ComboBox_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            double fontSize = Convert.ToDouble(((sender as ComboBox).SelectedItem));
            if (textBox != null)
                textBox.FontSize = fontSize;
        }

        private void ToggleToBold(object sender, RoutedEventArgs e)
        {
            //textBox.FontWeight = textBox.FontWeight == FontWeights.Normal ? FontWeights.Bold : FontWeights.Normal;
            if (textBox.FontWeight == FontWeights.Normal)
                textBox.FontWeight = FontWeights.Bold;
            else
                textBox.FontWeight = FontWeights.Normal;
        }

        private void ToggleToItalic(object sender, RoutedEventArgs e)
        {
            if (textBox.FontStyle == FontStyles.Normal)
                textBox.FontStyle = FontStyles.Italic;
            else
                textBox.FontStyle = FontStyles.Normal;
        }

        private void ToggleToUnderline(object sender, RoutedEventArgs e)
        {
            if (textBox.TextDecorations.Count == 0)
                textBox.TextDecorations.Add(TextDecorations.Underline);
            else
                textBox.TextDecorations.RemoveAt(0);
        }

        private void ToggleToBlack(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
                textBox.Foreground = Brushes.Black;
        }

        private void ToggleToRed(object sender, RoutedEventArgs e)
        {
            if (textBox != null)
                textBox.Foreground = Brushes.Red;
        }

        private void OpenExecuted(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (openFile.ShowDialog() == true)
                textBox.Text = File.ReadAllText(openFile.FileName);
        }

        private void SaveExecuted(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
            if (saveFile.ShowDialog() == true)
                File.WriteAllText(saveFile.FileName, textBox.Text);
        }

        private void CloseExecuted(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void theme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Application.Current.Resources.MergedDictionaries.Clear();
            Uri themes = new Uri(theme.SelectedIndex == 0 ? "ThemesLight.xaml" : "ThemesDark.xaml", UriKind.Relative);
            ResourceDictionary themeDict = Application.LoadComponent(themes) as ResourceDictionary;
            Application.Current.Resources.MergedDictionaries.Add(themeDict);
        }
    }
}
