using System;

namespace DZ3_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Alexander Fakhrudinov = Александр Фахрудинов
             * asbuka@gmail.com
             * 
             * 2.Написать программу — телефонный справочник — создать двумерный массив 5 * 2, хранящий список телефонных контактов: 
             * первый элемент хранит имя контакта, второй — номер телефона/ e - mail.
             * 
             */

            Console.WriteLine("Урок 3. Практическое задание 2\n");
            Console.WriteLine("Телефонный справочник:");
            //Создадим массив
            //сразу с данными справочника
            string[,] contactsData = {
                { "Вася", "+7 916 100 1112233 / 100@site.com"},
                { "Петя", "+7 916 101 1112234 / 101102@site.com"},
                { "Ася", "+7 916 102 1111111 / 102@site.com"},
                { "Саша", "+7 916 103 2234233 / 103100@site.com"},
                { "Жимсулбек Ветанаш Кырымпулаевич", "+7 916 104 1112233 / 104@site.com"} };

            ShowAllContacts(contactsData, "");

            ShowCommandMenu(contactsData);

            Console.Read();
        }

        private static void ShowCommandMenu(string[,] contactsData)
        {
            String search = "";
            Console.WriteLine("\nЧто будем делать?");
            Console.WriteLine(" - Что-то найти справочнике - введите искомое.");
            Console.WriteLine(" - Снова вывести весь справочник - нажмите клавишу 'Enter'");
            Console.WriteLine(" - Отредактировать контактную информацию - введите слово 'Edit'");

            search = Console.ReadLine();
            ShowAllContacts(contactsData, search);
        }

        private static void ShowAllContacts(string[,] contactsData, string search)
        {
            if (search.ToLower().Equals("edit"))
            {
                GetDataForEdit(contactsData);

                ShowCommandMenu(contactsData);
            }

            Console.WriteLine("Результаты запроса:");
            for (int i = 0; i < contactsData.GetLength(0); i++)
            {
                if ((contactsData[i, 0] + contactsData[i, 1]).ToLower().Contains(search.ToLower()))
                {
                    StringOutput(contactsData, i);
                }
            }

            ShowCommandMenu(contactsData);
        }

        private static void GetDataForEdit(string[,] contactsData)
        {
            Console.WriteLine("Введите номер строки, которую будем редактировать или Enter для отмены.");
            string rowNumber = Console.ReadLine();

            int i = -1;
            if (Int32.TryParse(rowNumber.Substring(0), out i))
            {
                i--;
                if (i >= 0 && i <= contactsData.GetLength(0))
                {
                    Console.WriteLine($"Редактируемая строка {i + 1}:");
                    StringOutput(contactsData, i);

                    Console.WriteLine("Введите Новое имя контакта или Enter для отмены.");
                    string newName = CheckStringLenght(contactsData);

                    Console.WriteLine("Введите Новый номер телефона или Enter для отмены.");
                    string newPhone = CheckStringLenght(contactsData);

                    Console.WriteLine("Введите Новый адрес почты или Enter для отмены.");
                    string newEmail = CheckStringLenght(contactsData);

                    //запишем новые данные
                    contactsData[i, 0] = newName;
                    contactsData[i, 1] = newPhone + " / " + newEmail;

                    //выведем на консоль новые данные.
                    Console.WriteLine($"Контакт изменен, строка {i + 1}:");
                    StringOutput(contactsData, i);

                }
                else
                {
                    Console.WriteLine("Такого контакта нет!");
                    GetDataForEdit(contactsData);
                }
            }
            else
            {
                Console.WriteLine("Такого контакта нет!");
                GetDataForEdit(contactsData);
            }
        }

        private static void StringOutput(string[,] contactsData, int i)
        {
            Console.Write(i + 1 + ". ");
            Console.Write(contactsData[i, 0].PadRight(35));
            Console.Write(contactsData[i, 1]);
            Console.WriteLine();
        }

        private static string CheckStringLenght(string[,] contactsData)
        {
            string str = Console.ReadLine();
            if (str.Length < 1)
            {
                ShowCommandMenu(contactsData);
            }

            return str;
        }
    }
}
