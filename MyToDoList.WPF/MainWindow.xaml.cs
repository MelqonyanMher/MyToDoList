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

namespace MyToDoList.WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            if( listBoxToDoListBox.Height <300)
                       listBoxToDoListBox.Height += 51;

            listBoxToDoListBox.Items.Add(new TaskItam(textBoxAddTask.Text));
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            
            listBoxToDoListBox.Items.Remove(listBoxToDoListBox.SelectedItem);
         
        }
    }
}
