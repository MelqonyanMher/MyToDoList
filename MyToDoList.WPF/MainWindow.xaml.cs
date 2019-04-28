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
using MyToDoList.Library;
namespace MyToDoList.WPF
{
   
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ToDoTaskList _taskList;
        private ToDoListMeneger _todoMeneger;
        public MainWindow()
        {
            InitializeComponent();
            _taskList = new ToDoTaskList();
            _todoMeneger = new ToDoListMeneger();
            _todoMeneger.CreateDBAndTAbleIfNotExist();
            _taskList = _todoMeneger.ReadFromBase(_taskList);
            for(int i= 0; i < _taskList.Count;i++)
            {
                if (listBoxToDoListBox.Height < 250)
                {
                    listBoxToDoListBox.Height += 51;
                }
                listBoxToDoListBox.Items.Add(new TaskItam(_taskList[i].Value,_taskList[i].Completed));
            }
            
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if (listBoxToDoListBox.Height < 250)
            {
                listBoxToDoListBox.Height += 51;
            }

            _taskList.Add(this.textBoxAddTask.Text);
            _todoMeneger.AddTaskInTable(_taskList[textBoxAddTask.Text]);
            listBoxToDoListBox.Items.Add(new TaskItam(textBoxAddTask.Text,false));
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            TaskItam ti =(TaskItam) listBoxToDoListBox.SelectedItem;
            listBoxToDoListBox.Items.Remove(ti);
            _taskList.Remove(ti.labelTask.Content.ToString());
            _todoMeneger.RemoveTaskFromTable(_taskList[ti.labelTask.Content.ToString()]);

        }

        private void btnDeleteCampleated_Click(object sender, RoutedEventArgs e)
        {
            var itm = listBoxToDoListBox.Items;
            for (int i = 0; i < itm.Count; i++)
            {
                TaskItam ti = (itm.GetItemAt(i) as TaskItam);
                 
                if ((bool)((ti).checkBoxCompleated.IsChecked))
                {
                    listBoxToDoListBox.Items.Remove(ti);
                    _taskList.Compleat(ti.labelTask.Content.ToString());
                    i--;
                }
            }
            _taskList.RemoveAll(true);
        }
        
    }
}
