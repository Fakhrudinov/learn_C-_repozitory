using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ4_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            * Alexander Fakhrudinov = Александр Фахрудинов
            * asbuka@gmail.com
            * 
            * 2.	Написать программу, принимающую на вход строку — набор чисел, разделенных пробелом, и возвращающую число — сумму всех чисел в строке. 
            * Ввести данные с клавиатуры и вывести результат на экран.
            */

            Console.WriteLine("Урок 4. Практическое задание 2\n");

            Console.WriteLine("Введите набор чисел, разделенных пробелом.");
            string userInput = Console.ReadLine();

            //уберем возможные пробелы в начале и в конце
            userInput = userInput.Trim();

            //исправим разделители дробных
            userInput = userInput.Replace('.',',');

            //перенесем данные в массив
            string[] dataArray = userInput.Split(' ');

            Console.WriteLine("Попробуем получить сумму всех чисел.");
            double summ = 0;
            
            bool haveFails = false;//если есть ошибки парсинга - выведем непонятные значения отдельной строкой
            string failParse = "";

            for (int i = 0; i < dataArray.Length; i++)
            {
                Console.Write(dataArray[i]);

                if (Double.TryParse(dataArray[i], out double result))
                {
                    summ = summ + result;
                }
                else
                {
                    failParse = failParse + " " + dataArray[i];
                    haveFails = true;
                }


                if (i < dataArray.Length - 1)//добавляем + или =
                {
                    Console.Write(" + ");
                }
                else
                {
                    Console.Write(" = " + summ);//результат сложения
                }
            }
            Console.WriteLine();

            if (haveFails)
            {
                Console.WriteLine("Не удалось конвертировать в числа следующие значения:" + failParse);
            }

            Console.Read();
        }
    }
}
