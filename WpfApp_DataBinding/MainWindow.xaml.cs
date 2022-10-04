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

namespace WpfApp_DataBinding
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

        //private void textBoxInput_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    textBlockOutput.Text = textBoxInput.Text;
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //   var brush = Resources["myColor"] as SolidColorBrush;
        //    Random random = new Random();
        //    brush.Color = Color.FromRgb(byte.Parse(random.Next(0,255).ToString()), byte.Parse(random.Next(0, 255).ToString()), byte.Parse(random.Next(0, 255).ToString()));
        //}
    }
}
