using System;

namespace DZ2_Task2
{
    class Program
    {
        /* 
         * Alexander Fakhrudinov = Александр Фахрудинов
         * asbuka@gmail.com
         * 
         * Практическое задание 2 - действие 3
         * 
         * SUMMARY on solution:
         * Подготовить 4 проекта, которые будут выполнять следующие действия:
         * 1.	Запросить у пользователя минимальную и максимальную температуру за сутки и вывести среднесуточную температуру.
         * 2.	Запросить у пользователя порядковый номер текущего месяца и вывести его название.
         * 3.	Определить, является ли введённое пользователем число чётным.
         * 4.	Для полного закрепления понимания простых типов найдите любой чек, либо фотографию этого чека в интернете и схематично нарисуйте его в консоли, 
         *      только за место динамических, по вашему мнению, данных (это может быть дата, название магазина, сумма покупок) подставляйте переменные, 
         *      которые были заранее заготовлены до вывода на консоль.
         * 5.	(*) Если пользователь указал месяц из зимнего периода, а средняя температура > 0, вывести сообщение «Дождливая зима».
         * 6.	(*) Для полного закрепления битовых масок, попытайтесь создать универсальную структуру расписания недели, к примеру, чтобы описать работу какого либо офиса. 
         *      Явный пример - офис номер 1 работает со вторника до пятницы, офис номер 2 работает с понедельника до воскресенья.
         *      
         * В DZ2_Task2 будут решена задача 3.
         */

        static void Main(string[] args)
        {
            Console.WriteLine("Практическое задание 2 - действие 3\n Способ 1.");

            // Определить, является ли введённое пользователем число чётным.
            Console.WriteLine("Пожалуйста, введите число.");
            string userDigit = Console.ReadLine();
            string userDigitCleaned = userDigit.Trim().Replace(".", "");//убираем знак, тем самым получая целое число
            userDigitCleaned = userDigitCleaned.Replace(",", "");

            int digit;
            if (!Int32.TryParse(userDigitCleaned, out digit))
            {
                Console.WriteLine($"К сожалению, не удалось распознать введенное значение {userDigit}, программа будет завершена.");
                Console.Read();
                return;
            }

            Console.Write("Введенное число " + userDigit);
            //если % > 0 то нечетное
            if (digit % 2 > 0)
            {
                Console.Write(" нечётное.");
            }
            else
            {
                Console.Write(" чётное.");
            }
            Console.WriteLine("\n");


            Console.WriteLine("Практическое задание 2 - действие 3 \n Способ 2.");

            // Определить, является ли введённое пользователем число чётным. Способ 2 switch
            Console.WriteLine("Пожалуйста, введите число.");
            userDigit = Console.ReadLine();
            userDigitCleaned = userDigit.Trim().Replace(".", "");//убираем знак, тем самым получая целое число
            userDigitCleaned = userDigitCleaned.Replace(",", "");

            if (userDigitCleaned.Length > 1)// фактически для понимания чет/нечет нас интересует только последняя цифра в числе.
            {
                userDigitCleaned = userDigitCleaned.Substring(userDigitCleaned.Length - 1);
            }

            if (!Int32.TryParse(userDigitCleaned, out digit))
            {
                Console.WriteLine($"К сожалению, не удалось распознать введенное значение {userDigit}, программа будет завершена.");
                Console.Read();
                return;
            }

            string flagEven = "";
            switch (digit)
            {
                case 0:
                case 2:
                case 4:
                case 6:
                case 8:
                    flagEven = "чётное";
                    break;
                case 1:
                case 3:
                case 5:
                case 7:
                case 9:
                    flagEven = "нечётное";
                    break;
            }

            Console.Write($"Введенное число {userDigit} {flagEven}");
            Console.Read();
        }
    }
}
