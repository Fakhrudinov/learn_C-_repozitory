using System;

namespace DZ3_3
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Alexander Fakhrudinov = Александр Фахрудинов
             * asbuka@gmail.com
             * 
             * 3.Написать программу, выводящую введенную пользователем строку в обратном порядке(olleH вместо Hello).
             */

            //воспользоваться выводом строки как массива.

            Console.WriteLine("Урок 3. Практическое задание 3\n");

            Console.WriteLine("Пожалуйста введите любой текст. Я отображу его в обратном порядке.");
            string str = Console.ReadLine();

            if (str.Length > 1)
            {
                Console.WriteLine("Хорошо, в обратном порядке это будет:");
                for (int i = str.Length-1; i >= 0; i--)
                {
                    Console.Write(str[i]);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Маловато ввели. Я надеялся на большее... Тут нечего показывать в обратном порядке.");
            }
            Console.Read();
        }
    }
}
