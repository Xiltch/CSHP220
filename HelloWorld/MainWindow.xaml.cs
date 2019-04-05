using System;
using System.Collections.Generic;
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

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // add additional click handler to log to the console when the submit button is clicked
            uxSubmit.Click += (object sender, RoutedEventArgs e) => { Console.WriteLine("Button Clicked"); };

            WindowState = WindowState.Maximized;
        }

        private void UxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password: " + uxPassword.Password);
        }
    }
}
