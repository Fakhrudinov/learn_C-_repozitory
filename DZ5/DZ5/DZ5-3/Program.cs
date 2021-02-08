using System;
using System.IO;

namespace DZ5_3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Alerxander Fakhrudinov = Александр Фахрудинов
             * asbuka@gmail.com
             * 3.Ввести с клавиатуры произвольный набор чисел(0...255) и записать их в бинарный файл.
             */
            Console.WriteLine("Урок 5. Практическое занятие 3");
            Console.WriteLine("Введите произвольный набор чисел (0...255) через пробел, я запишу их в бинарный файл.");

            string fileName = "file_" + DateTime.Now.ToString("yyyy_MMM_dd__hh_mm_ss") + ".bin";//имя файла

            string dataFromConsole = Console.ReadLine();

            byte [] digits = ParseDataToArray(dataFromConsole);// выбран размер переменной byte из за условия (0...255)

            if (digits.Length > 0)
            {
                //запишем
                File.WriteAllBytes(fileName, digits);

                //посмотрим как оно выглядит
                Console.WriteLine($"Данные в файле {fileName}: " + File.ReadAllText(fileName));
            }
            else
            {
                Console.WriteLine("Нет распознанных чисел в диапазоне 0...255 для записис в файл");
            }

            Console.Read();
        }

        private static byte[] ParseDataToArray(string dataFromConsole)
        {
            int counter = 0;
            string unRecognized = "";

            dataFromConsole.Trim();
            string[] arrayStr = dataFromConsole.Split(' ');

            //задаю размер массива с распознанными числами
            foreach (string str in arrayStr)
            {
                if (Byte.TryParse(str, out byte z))
                {
                    counter++;
                }
                else// собираю нераспознанные значения
                {
                    unRecognized = unRecognized + str + " ";
                }
            }

            // вывожу пользователю нераспознанные значения
            if (unRecognized.Length > 0)
            {
                Console.WriteLine("Следующие значения не удалось распознать: " + unRecognized);
            }
                        
            byte[] convertedData = new byte[counter];

            counter = 0;
            //fill new byte array
            for (int i = 0; i < arrayStr.Length; i++)
            {
                if (Byte.TryParse(arrayStr[i], out byte z))
                {
                    convertedData[counter] = z;
                    counter++;
                }
            }

            return convertedData;
        }
    }
}
