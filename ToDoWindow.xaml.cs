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
using System.Windows.Shapes;

namespace GutKaz14
{
    /// <summary>
    /// Логика взаимодействия для ToDoWindow.xaml
    /// </summary>
    public partial class ToDoWindow : Window
    {
        public ToDoWindow()
        {
            InitializeComponent();
            descriptionToDo.Text = "Описания нет";
            dateToDo.SelectedDate = DateTime.Today; ;
        }

        public static RoutedCommand AddNewToDo = new RoutedCommand();

        private void buttonAdd_Click(object sender, ExecutedRoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleToDo.Text))
            {
                MessageBox.Show("Нельзя оставить пустое поле!", "Ошибка");
                return;
            }

            var own = (Owner as MainWindow);
            MainWindow.toDoList.Add(new ToDo
            (
                false,
                titleToDo.Text,
                (DateTime)dateToDo.SelectedDate,
                descriptionToDo.Text
            ));

            titleToDo.Text = String.Empty;
            dateToDo.SelectedDate = DateTime.Today;
            descriptionToDo.Text = "Описания нет";

            own.listToDo.ItemsSource = null;
            own.listToDo.ItemsSource = MainWindow.toDoList;
            own.EndToDo();
            this.Close();
        }
    }
}
