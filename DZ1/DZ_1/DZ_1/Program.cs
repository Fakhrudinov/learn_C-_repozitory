using System;

namespace DZ_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Alexander Fakhrudinov = Александр Фахрудинов
             * asbuka@gmail.com
             * 
             * Практическое задание 1
             * Написать программу, выводящую в консоль текст: «Привет, %имя пользователя%, сегодня %дата%». 
             * Имя пользователя сохранить из консоли в промежуточную переменную. 
             * Поставить точку останова и посмотреть значение этой переменной в режиме отладки. 
             * Запустить исполняемый файл через системный терминал.
             * 
             */

            DateTime today = DateTime.Now;

            Console.Clear();
            Console.WriteLine("Практическое задание 1\n");

            Console.WriteLine("Введите ваше имя пользователя:");
            string name = Console.ReadLine();

            Console.WriteLine($"Привет, {name}, сегодня " + today.ToString("D"));

            Console.ReadKey();
        }
    }
}
