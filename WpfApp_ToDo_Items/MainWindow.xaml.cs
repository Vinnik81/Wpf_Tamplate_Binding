using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WpfApp_ToDo_Items.Models;

namespace WpfApp_ToDo_Items
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
       
        private string taskName;
        private string taskDescription;
        private bool taskDone;
        private DateTime taskDeadline = DateTime.Now;
        private ObservableCollection<MyTask> myTasks;
        public string TaskName { get => taskName; set => OnChanged(out taskName, value);}
        public string TaskDescription { get => taskDescription; set => OnChanged(out taskDescription, value);}
        public bool TaskDone { get => taskDone; set => OnChanged(out taskDone, value);}
        public DateTime TaskDeadline { get => taskDeadline; set => OnChanged(out taskDeadline, value);}
        public ObservableCollection<MyTask> MyTasks { get => myTasks; set => OnChanged(out myTasks, value);}

       

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            MyTasks = new ObservableCollection<MyTask>();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void OnChanged<T>(out T prop, T value, [CallerMemberName] string propName = "")
        {
            prop = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            //  if (taskName != null && taskName != String.Empty && !taskName.All(x => x == ' '))  //  100 false/true
            //  if (taskName != null && taskName != String.Empty || taskName.Any(x => x != ' '))  // 9 stop false/true

            if (!string.IsNullOrWhiteSpace(taskName) && !string.IsNullOrWhiteSpace(taskDescription))
            {
                MyTask task = new MyTask()
                {
                    Description = TaskDescription,
                    Name = TaskName,
                    Deadline = TaskDeadline,
                    IsDone = TaskDone
                };
                myTasks.Add(task);
                TaskDescription = string.Empty;
                TaskName = string.Empty;
                TaskDone = false;
                TaskDeadline = DateTime.Now;
            }
            else MessageBox.Show("Не заполнены поля");
            
            
        }
    }
}
