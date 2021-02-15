using System;
using System.IO;
using System.Text.Json;

namespace DZ5_5
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Alerxander Fakhrudinov = Александр Фахрудинов
             * asbuka@gmail.com
             * 5.  (*) Список задач(ToDo-list):
             * ●	написать приложение для ввода списка задач;
             * ●	задачу описать классом ToDo с полями Title и IsDone;
             * ●	на старте, если есть файл tasks.json / xml / bin(выбрать формат), загрузить из него массив имеющихся задач и вывести их на экран;
             * ●	если задача выполнена, вывести перед её названием строку «[x]»;
             * ●	вывести порядковый номер для каждой задачи;
             * ●	при вводе пользователем порядкового номера задачи отметить задачу с этим порядковым номером как выполненную;
             * ●	записать актуальный массив задач в файл tasks.json / xml / bin.
             */

            string dataFile = "tasks.json";
            string inputError = "";

            ToDo[] tasks = LoadInitialData(dataFile);// запросим данные

            ShowTask(tasks, dataFile, inputError);

            Console.Read();
        }

        private static string RequestUserToTaskComplete(ToDo[] tasks, string dataFile, string inputError)
        {            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(inputError); // отображение предыдущей ошибки ввода
            Console.ResetColor();
            
            Console.WriteLine("Введите номер завершенной задачи:");
            string completed = Console.ReadLine();

            if (uint.TryParse(completed, out uint result))
            {
                result--;// приводим отображаемый клиенту номер к отсчету от 0

                if (result >= 0 && result < tasks.Length)
                {
                    if (tasks[result].IsDone)
                    {
                        inputError = $"Задача '{result}' уже отмечена, как решенная.";
                    }
                    else
                    {
                        inputError = "";
                        tasks[result].IsDone = true;

                        SaveDataToFile(tasks, dataFile);
                    }
                }
                else
                {
                    inputError = $"Введенный номер '{++result}' не удалось соотнести с задачей.";
                }
            }
            else
            {
                inputError = $"Номер '{completed}' не распознан. Повторите ввод.";
            }

            return inputError;
        }

        private static void SaveDataToFile(ToDo[] tasks, string dataFile)
        {
            string json = JsonSerializer.Serialize(tasks);
            File.WriteAllText(dataFile, json);

            /*
             * это построчная запись json задач в файл. Заменена на запись массивом.
             * 
            //Удалим старый файл с данными.
            File.Delete(dataFile);

            for (int i = 0; i < tasks.Length; i++)
            {
                string json = JsonSerializer.Serialize(tasks[i]) + "\n";
                File.AppendAllText(dataFile, json);
            }
            */
        }

        private static void ShowTask(ToDo[] tasks, string dataFile, string inputError)
        {
            Console.Clear();
            Console.WriteLine("Урок 5. Практическое занятие 5");
            Console.WriteLine("Список задач:");

            for (int i = 0; i < tasks.Length; i++)
            {
                string isDone = (tasks[i].IsDone) ? "x" : " ";

                if (tasks[i].IsDone)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                Console.WriteLine($"{(i+1).ToString().PadLeft(3)} [{isDone}] {tasks[i].Title}");

                Console.ResetColor();
            }

            inputError = RequestUserToTaskComplete(tasks, dataFile, inputError);
            ShowTask(tasks, dataFile, inputError);
        }

        private static ToDo[] LoadInitialData(string dataFile)
        {
            ToDo[] tasks = new ToDo[12];// размер для данных по умолчанию

            if (File.Exists(dataFile)) // загружаем данные из файла
            {
                string jsonFileData = File.ReadAllText(dataFile);
                tasks = JsonSerializer.Deserialize<ToDo[]>(jsonFileData);

                /*
                 * Это построчное добавление в массив из файла
                 * 
                string[] jsonFileData = File.ReadAllLines("tasks.json");

                tasks = new ToDo[jsonFileData.Length]; // размер для данных из файла

                for (int i = 0; i < jsonFileData.Length; i++)
                {
                    tasks[i] = JsonSerializer.Deserialize<ToDo>(jsonFileData[i]);
                }
                */
            }
            else // данные по умолчанию
            {
                tasks[0] = new ToDo("Сходить в магазин", false);
                tasks[1] = new ToDo("Позвонить Васе Пупкину", false);
                tasks[2] = new ToDo("Сделать домашку 5-1", true);
                tasks[3] = new ToDo("Сделать домашку 5-2", true);
                tasks[4] = new ToDo("Сделать домашку 5-3", true);
                tasks[5] = new ToDo("Сделать домашку 5-4", false);
                tasks[6] = new ToDo("Сделать домашку 5-5", true);
                tasks[7] = new ToDo("Почитать учебник", false);
                tasks[8] = new ToDo("Погладить кошку", false);
                tasks[9] = new ToDo("Погладить кошку еще раз", false);
                tasks[10] = new ToDo("Покормить кошку", false);
                tasks[11] = new ToDo("Спать", false);
            }

            return tasks;
        }
    }
}
