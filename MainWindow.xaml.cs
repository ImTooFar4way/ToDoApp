using GutKaz14;
using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Text.Json;

namespace GutKaz14
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<ToDo> toDoList = new List<ToDo>();
        public MainWindow()
        {
            InitializeComponent();
            SaveFiles.LoadToDoListFromJson();
            listToDo.ItemsSource = toDoList;
            EndToDo();
        }
        public void EndToDo()
        {
            progressToDO.Minimum = 0;
            progressToDO.Maximum = toDoList.Count;

            int value = 0;
            foreach (ToDo toDo in toDoList)
            {
                if (toDo.Doing == true)
                {
                    value += 1;
                }
            }

            progressTitleToDo.Text = value.ToString() + '/' + toDoList.Count.ToString();
            progressToDO.Value = value;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

            ToDo toDo = (sender as Button).DataContext as ToDo;
            MessageBoxResult delete = MessageBox.Show("Вы уверены, что хотите удалить дело?", "Удаление дела", MessageBoxButton.YesNo);
            if (delete == MessageBoxResult.Yes)
            {
                toDoList.Remove(toDo);
                listToDo.ItemsSource = null;
                listToDo.ItemsSource = toDoList;
            }
            EndToDo();
            SaveFiles.SaveToDoListInJson();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            ToDoWindow toDoWindow = new ToDoWindow();
            toDoWindow.Owner = this;
            toDoWindow.ShowDialog();
            EndToDo();
            SaveFiles.SaveToDoListInJson();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (listToDo.SelectedItem != null)
            {
                (listToDo.SelectedItem as ToDo).Doing = false;
            }
            EndToDo();
            SaveFiles.SaveToDoListInJson();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            EndToDo();
            SaveFiles.SaveToDoListInJson();
        }


        private void SaveTxtFile(object sender, ExecutedRoutedEventArgs e)
        {
            if (toDoList.Count == 0)
            {
                MessageBox.Show("В списке нет дел", "", MessageBoxButton.OK);
                return;
            }
            else
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.InitialDirectory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Files");
                saveFile.Filter = "Text file (*.txt)|*.txt|JSON file (*.json)|*.json ";
                saveFile.Title = "Сохранение списка дел";
                saveFile.FileName = "saved_list.txt";
                saveFile.OverwritePrompt = true;

                if (saveFile.ShowDialog() == true && saveFile.FilterIndex == 1)
                {
                    SaveFiles.SaveToDoListInTxt(saveFile.FileName);
                }
                else
                {
                    SaveFiles.SaveToDoListInJson();
                }
            }

        }
        private void Delete_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ToDo toDo = listToDo.SelectedItem as ToDo;
            if (toDoList != null)
            {
                MessageBoxResult delete= MessageBox.Show("Вы уверены, что хотите удалить дело?", "Удаление дела",
                    MessageBoxButton.YesNo);

                if (delete == MessageBoxResult.Yes)
                {
                    toDoList.Remove(toDo);
                    listToDo.ItemsSource = null;
                    listToDo.ItemsSource = toDoList;
                }
            }
            EndToDo();
            SaveFiles.SaveToDoListInJson();
        }
    }
}
