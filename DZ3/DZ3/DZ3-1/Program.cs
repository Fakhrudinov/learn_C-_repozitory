using System;

namespace DZ3_1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Alexander Fakhrudinov = Александр Фахрудинов
             * asbuka@gmail.com
             * 
             * 1.Написать программу, выводящую элементы двухмерного массива по диагонали.
             */

            Console.WriteLine("Урок 3. Практическое задание 1\n");

            //создать массив 10*10
            int[,] arrayTwoDimension = new int[21, 6];
            
            //наполнить его последовательностью чисел
            int fill = 1;

            for (int x = 0; x < arrayTwoDimension.GetLength(0); x++)
            {
                for (int y = 0; y < arrayTwoDimension.GetLength(1); y++)
                {
                    arrayTwoDimension[x,y] = fill++;
                }
            }

            string str = ""; //для форматирования строки при выводе
            bool direction = true;//направление диагонали
            int counterY = 0;//счетчик по диагонали
            
            //выводим по диагонали. Если ряд Y короче - разворачиваем в другую сторону
            for (int x = 0; x < arrayTwoDimension.GetLength(0); x++)
            {
                Console.WriteLine(str + arrayTwoDimension[x, counterY]);

                if (counterY == arrayTwoDimension.GetLength(1)-1)
                {
                    direction = false;
                }

                if (counterY == 0)
                {
                    direction = true;
                }

                if (direction)
                {
                    counterY++;
                    str = str + "  ";
                }
                else
                {
                    counterY--;
                    str = str.Substring(0, str.Length - 2);
                }              
            }

            Console.Read();
        }
    }
}
