using System;
using System.IO;

namespace DZ5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Alerxander Fakhrudinov = Александр Фахрудинов
             * asbuka@gmail.com
             * 1.Ввести с клавиатуры произвольный набор данных и сохранить его в текстовый файл.
             */
            Console.WriteLine("Урок 5. Практическое занятие 1");
            Console.WriteLine("Введите данные для записи их в файл.");

            string textToFile = Console.ReadLine();

            SaveDataInTextFile(textToFile);

            Console.Read();
        }

        private static void SaveDataInTextFile(string textToFile)
        {
            string fileName = "file_" + DateTime.Now.ToString("yyyy_MMM_dd__hh_mm_ss") + ".txt";

            File.WriteAllText(fileName, textToFile);

            CheckDataInFile(fileName, textToFile);
        }

        private static void CheckDataInFile(string fileName, string textToFile)
        {
            //читаем файл, сверяем данные, выводим статус.
            if (File.Exists(fileName))
            {
                string readFromFile = File.ReadAllText(fileName);
                if (readFromFile.Equals(textToFile))
                {
                    Console.WriteLine("Запись в файл выполнена успешно.");
                    Console.WriteLine("Файл с данными расположен по пути \n" + Path.GetFullPath(fileName));
                }
                else
                {
                    Console.WriteLine("Ошибка! Содержимое файла не совпадает с введенным из консоли.");
                }
            }
            else
            {
                Console.WriteLine("Ошибка! Файл не найден.");
            }
        }
    }
}
