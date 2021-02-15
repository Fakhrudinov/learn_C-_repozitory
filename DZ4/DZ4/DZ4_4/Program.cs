using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ4_4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            * Alexander Fakhrudinov = Александр Фахрудинов
            * asbuka@gmail.com
            * 
            * 4.	(*) Написать программу, вычисляющую число Фибоначчи для заданного значения рекурсивным способом. 
            * 
            * элементы числовой последовательности, в которой первые два числа равны либо 1 и 1, либо 0 и 1, а каждое последующее число равно сумме двух предыдущих чисел
            */

            Console.WriteLine("Урок 4. Практическое задание 4\n");

            Console.WriteLine("Введите значение - индекс последовательности для расчета числа Фибоначчи");
            string userInput = Console.ReadLine();

            if (Int32.TryParse(userInput, out int index))
            {
                int result = GetFibonacci(index);

                Console.WriteLine("Результат: " + result);
            }
            else
            {
                Console.WriteLine("Введенное число не удалось преобразовать в индекс для вычисления последовательности");
            }

            Console.Read();
        }

        private static int GetFibonacci(int index)
        {
            int direction = 0;

            if (index < 0) //вычисление отрицательных чисел Фибоначчи
            {
                direction = -1;
                index = index * -1;
            }
            else if (index == 0)
            {
                Console.WriteLine("Нечего вычислять!");
                return 0;
            }
            else//вычисление положительных
            {
                direction = 1;
            }

            int result = CalculateFibonacci(index, direction, 0);
            return result;
        }

        private static int CalculateFibonacci(int fibonacciIndex, int prevPrev, int prev)
        {
            int result = prev + prevPrev;
            if (fibonacciIndex == 1)//остановка на 1 - т.к. первый шаг у нас всегда есть, 0 отсекается.
            {
                return result;
            }

            result = CalculateFibonacci(--fibonacciIndex, prev, prev + prevPrev);

            return result;
        }
    }
}
