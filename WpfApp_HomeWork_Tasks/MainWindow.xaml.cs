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
using WpfApp_HomeWork_Tasks.Models;

namespace WpfApp_HomeWork_Tasks
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string taskName;
        private string newtaskName;
        private string taskDescription;
        private string newtaskDescription;
        private string taskDate;
        private string newtaskDate;
        private bool taskDone;
        private ObservableCollection<MyTask> myTasks;
        public string TaskName { get => taskName; set => OnChanged(out taskName, value); }
        public string NewTaskName { get => newtaskName; set => OnChanged(out newtaskName, value); }
        public string TaskDescription { get => taskDescription; set => OnChanged(out taskDescription, value); }
        public string NewTaskDescription { get => newtaskDescription; set => OnChanged(out newtaskDescription, value); }
        public string TaskDate { get => taskDate; set => OnChanged(out taskDate, value); }
        public string NewTaskDate { get => newtaskDate; set => OnChanged(out newtaskDate, value); }
        public ObservableCollection<MyTask> MyTasks { get => myTasks; set => OnChanged(out myTasks, value); }
        public bool TaskDone { get => taskDone; set => OnChanged(out taskDone, value); }
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

            if (!string.IsNullOrWhiteSpace(taskName))
            {
                MyTask task = new MyTask()
                {
                    Description = TaskDescription,
                    Name = TaskName,
                    Date = TaskDate,
                    Done = TaskDone
                };
                myTasks.Add(task);
                TaskDescription = string.Empty;
                TaskName = string.Empty;
                TaskDate = string.Empty;
                TaskDone = false;
                if (check.IsChecked == true)
                {
                    task.Done = true;
                    task.Date = "Выполнено";
                }
            }
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
                MyTasks.RemoveAt(listBox.SelectedIndex);
            else MessageBox.Show("Задача для удаления не выброна");
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                MyTask task = new MyTask()
                {
                    Name = TaskName,
                    Description = TaskDescription,
                    Date = TaskDate
                };
                myTasks.Insert(listBox.SelectedIndex, task);
                TaskDescription = string.Empty;
                TaskName = string.Empty;
                TaskDate = string.Empty;
                TaskDone = false;
                if (check.IsChecked == true)
                {
                    task.Done = true;
                    task.Date = "Выполнено";
                }
                MyTasks.RemoveAt(listBox.SelectedIndex);
            }
        }
    }
}
