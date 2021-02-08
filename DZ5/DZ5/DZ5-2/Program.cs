using System;
using System.IO;

namespace DZ5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Alerxander Fakhrudinov = Александр Фахрудинов
             * asbuka@gmail.com
             * 2.Написать программу, которая при старте дописывает текущее время в файл «startup.txt».
             */
            Console.WriteLine("Урок 5. Практическое занятие 2");

            string fileName = "startup.txt";
            File.AppendAllText(fileName, "AddTime_" + DateTime.Now.ToString("hh:mm:ss") + "\n");

            ShowFileContent(fileName);

            Console.Read();
        }

        private static void ShowFileContent(string fileName)
        {
            if (File.Exists(fileName))
            {
                Console.WriteLine("Содержимое файла:");

                string [] fileLines = File.ReadAllLines(fileName);
                foreach (string str in fileLines)
                {
                    Console.WriteLine(str);
                }
            }
            else
            {
                Console.WriteLine("Ошибка! Файл не найден.");
            }
        }
    }
}
