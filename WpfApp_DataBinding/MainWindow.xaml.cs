using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        //public string MyText { get; set; } = "Hello 2022";

        private string myText;

        public string MyText { get => myText; set => OnChanged(out myText, value); }
        private string phone;

        public string Phone { get => phone; set => OnChanged(out phone, value); }
       

        //private string myText;

        //public string MyText
        //{
        //    get 
        //    {
        //        return myText; 
        //    }
        //    set 
        //    { 
        //        myText = value;
        //        OnChanged(out myText, value);
        //        //OnChanged(out myText, value, "MyText");
        //        //PropertyChanged.Invoke(this, new PropertyChangedEventArgs("MyText"));
        //    }
        //}

        private void OnChanged<T>(out T prop, T value,[CallerMemberName] string propName = "")
        {
            prop = value;
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            MyText = "Bye " + random.Next(2015,2022);
            //MessageBox.Show("bye");
            //DataContext = null;
            //DataContext = this;
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
