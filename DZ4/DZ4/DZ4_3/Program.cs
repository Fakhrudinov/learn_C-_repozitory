using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ4_3
{
    class Program
    {
        enum Seasons : byte
        {
            Winter,
            Spring,
            Summer,
            Autumn
        }

        enum SeasonsRussian : byte
        {
            Зима,
            Весна,
            Лето,
            Осень
        }

        enum Months : byte
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December = 12
        }

        static void Main(string[] args)
        {
            /*
            * Alexander Fakhrudinov = Александр Фахрудинов
            * asbuka@gmail.com
            * 
            * 3.	Написать метод по определению времени года. На вход подаётся число – порядковый номер месяца. 
            * На выходе — значение из перечисления (enum) — Winter, Spring, Summer, Autumn. 
            * Написать метод, принимающий на вход значение из этого перечисления и возвращающий название времени года (зима, весна, лето, осень). 
            * Используя эти методы, ввести с клавиатуры номер месяца и вывести название времени года. 
            * Если введено некорректное число, вывести в консоль текст «Ошибка: введите число от 1 до 12».
            */

            Console.WriteLine("Урок 4. Практическое задание 3");

            while (true)
            {
                string userInput = "0";
                userInput = RequestMonthNumber();
                if (userInput.Length < 1)
                {
                    break;
                }
            }
            Console.Read();
        }

        private static string RequestMonthNumber()
        {
            Console.WriteLine("\nВведите номер месяца - число от 1 до 12. Для выхода из программы введите 'пустое' значение");
            string userInput = Console.ReadLine();

            if (Byte.TryParse(userInput, out byte monthNumber))
            {
                if (monthNumber >= 1 && monthNumber <= 12)
                {
                    GetSeasonFromMonthNumber(monthNumber);
                }
                else
                {
                    ShowError();
                }
            }
            else if (userInput.Length < 1)
            {
                Console.WriteLine("Завершение работы.");
                return userInput;
            }
            else
            {
                ShowError();
            }

            return userInput;
        }

        private static void ShowError()
        {
            Console.WriteLine("Ошибка: введите число от 1 до 12");
            RequestMonthNumber();
        }

        private static void GetSeasonFromMonthNumber(byte monthNumber)
        {
            /*
            * На вход подаётся число – порядковый номер месяца. 
            * На выходе — значение из перечисления(enum) — Winter, Spring, Summer, Autumn.
            */

            byte seasonResult =13;//не число месяца.

            switch ((Months)monthNumber)
            {
                case Months.December:
                case Months.January:
                case Months.February:
                    seasonResult = (byte)Seasons.Winter;
                    break;

                case Months.March:
                case Months.April:
                case Months.May:
                    seasonResult = (byte)Seasons.Spring;
                    break;

                case Months.June:
                case Months.July:
                case Months.August:
                    seasonResult = (byte)Seasons.Summer;
                    break;

                case Months.September:
                case Months.October:
                case Months.November:
                    seasonResult = (byte)Seasons.Autumn;
                    break;
            }

            //Написать метод, принимающий на вход значение из этого перечисления и возвращающий название времени года(зима, весна, лето, осень).
            string seasonName = GetRussianSeasonName(seasonResult);
            Console.WriteLine("Месяц входит в сезон " + seasonName);
        }

        private static string GetRussianSeasonName(byte seasonResult)
        {
            string seasonRus = "";

            switch ((Seasons)seasonResult)
            {
                case Seasons.Winter:
                    seasonRus = SeasonsRussian.Зима.ToString();
                    break;

                case Seasons.Spring:
                    seasonRus = SeasonsRussian.Весна.ToString();
                    break;

                case Seasons.Summer:
                    seasonRus = SeasonsRussian.Лето.ToString();
                    break;

                case Seasons.Autumn:
                    seasonRus = SeasonsRussian.Осень.ToString();
                    break;
            }

            return seasonRus;
        }
    }
}
