using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GutKaz14
{
    class SaveFiles
    {
        static public void SaveToDoListInTxt(string filePath)
        {

            StringBuilder stringBuilder = new StringBuilder();

            foreach (ToDo toDo in MainWindow.toDoList)
            {
                if (toDo.Doing == true)
                {
                    stringBuilder.AppendLine($"{"✓ " + toDo.Title}\n");
                }
                else
                {
                    stringBuilder.AppendLine($"{toDo.Title}\n");
                }

                stringBuilder.AppendLine($"{toDo.Description}\n");
                stringBuilder.AppendLine($"{toDo.DateAndTime.ToString("dd.MM.yyyy")}\n");
            }

            File.WriteAllText(filePath, stringBuilder.ToString());
        }

        static public void SaveToDoListInJson()
        {
            string directory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Files");
            string filePath = System.IO.Path.Combine(directory, "saved_list.json");
            string json = JsonSerializer.Serialize(MainWindow.toDoList);

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            File.WriteAllText(filePath, json);
        }

        static public void LoadToDoListFromJson()
        {
            string directory = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Files", "saved_list.json");

            if (!File.Exists(directory))
            {
                SaveToDoListInJson();
            }
            else
            {
                string json = File.ReadAllText(directory);
                MainWindow.toDoList = JsonSerializer.Deserialize<List<ToDo>>(json);
            }
        }
    }
}
