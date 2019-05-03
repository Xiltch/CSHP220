using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Homework_4
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

        private static readonly Regex _partialValidZipCode = new Regex(@"^([0-9]{1,5}(\-[0-9]{0,4})?|([A-Z]?[0-9]?){0,3})$"); //regex that matches disallowed text
        private static readonly Regex _fullValidZipCode = new Regex(@"^([0-9]{5}(\-[0-9]{4})?|([A-Z][0-9]){3})$"); //regex that matches disallowed text

        private static bool IsZipCodeAllowed(string text)
        {
            return _partialValidZipCode.IsMatch(text);
        }

        private void UxZipCode_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = true;

            if (e.Source is TextBox textbox)
            {
                string testValue = textbox.Text + e.Text;
                e.Handled = !IsZipCodeAllowed(testValue);
            }
            
        }

        private void UxZipCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox textbox)
            {
                uxSubmit.IsEnabled = _fullValidZipCode.IsMatch(textbox.Text);
            }
        }
    }
}
