using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            * Alexander Fakhrudinov = Александр Фахрудинов
            * asbuka@gmail.com
            * 
            * 1.	Написать метод GetFullName(string firstName, string lastName, string patronymic), принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО. 
            * Используя метод, написать программу, выводящую в консоль 3–4 разных ФИО.
            */

            Console.WriteLine("Урок 4. Практическое задание 1\n");

            //задаю массив имен
            string[,] userName =
            {
                {"Иванов", "Иван", "Иванович" },
                {"Петров", "Петр", "Петрович" },
                {"Сидоров", "Сидор", "Сидорович" },
                {"Васечкин", "Василий", "Васильевич" }
            };

            //Читаю массив и вызываю метод объединения имени
            for (int i = 0; i < userName.GetLength(0); i++)
            {
                string lastName = userName[i, 0];
                string firstName = userName[i, 1];
                string patronymic = userName[i, 2];

                //принимающий на вход ФИО в разных аргументах и возвращающий объединённую строку с ФИО. 
                string fullName = GetFullName(firstName, lastName, patronymic);
                Console.WriteLine(fullName);
            }

            Console.Read();
        }

        private static string GetFullName(string firstName, string lastName, string patronymic)
        {
            string fullName = lastName + " " + firstName + " " + patronymic;
            return fullName;
        }
    }
}
