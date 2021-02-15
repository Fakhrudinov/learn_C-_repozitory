using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2_Task1
{
    class Program
    {
        /* 
         * Alexander Fakhrudinov = Александр Фахрудинов
         * asbuka@gmail.com
         * 
         * Практическое задание 2 - действия 1,2,5
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
         * В DZ2_Task1 будут решены задачи 1,2,5.
         */


        static void Main(string[] args)
        {
            Console.WriteLine("Практическое задание 2 - действия 1,2,5\n");

            // запросить минимальную температуру
            Console.WriteLine("Пожалуйста, введите минимальную температуру за прошедшие сутки. \nВводите только числа, знак минус, если нужен разделитель - запятую.");
            string minTemperature = Console.ReadLine();
            minTemperature = minTemperature.Trim().Replace('.',',');

            double minValue;
            if (!Double.TryParse(minTemperature, out minValue))
            {
                Console.WriteLine($"К сожалению, не удалось распознать введенное значение {minTemperature}, программа будет завершена.");
                Console.Read();
                return;
            }

            // запросить максимальную температуру
            Console.WriteLine("\nПожалуйста, введите максимальную температуру за прошедшие сутки. \nВводите только числа, если нужен разделитель - запятую, знак минус");
            string maxTemperature = Console.ReadLine();
            maxTemperature = maxTemperature.Trim().Replace('.', ',');

            double maxValue;
            if (!Double.TryParse(maxTemperature, out maxValue))
            {
                Console.WriteLine($"К сожалению, не удалось распознать введенное значение {maxTemperature}, программа будет завершена.");
                Console.Read();
                return;
            }

            if (maxValue < minValue)
            {
                Console.WriteLine($"Введенные вами данные, возможно, некорректны. Макимальная температура {maxValue} не может быть меньше минимальной {minValue}.");
            }

            // вывести среднюю температуру
            double averageTemperature = (maxValue + minValue) / 2;
            Console.WriteLine("Спасибо. Средняя суточная температура равна " + averageTemperature);

            // запросить порядковый номер месяца.
            Console.WriteLine("\nПожалуйста, введите порядковый номер месяца");
            string month = Console.ReadLine();
            
            // вывести название месяца
            int monthInt;
            if (!Int32.TryParse(month, out monthInt))
            {
                Console.WriteLine($"К сожалению, не удалось распознать введенное значение {month}, программа будет завершена.");
                Console.Read();
                return;
            }

            if (monthInt > 12 || monthInt < 1)
            {
                Console.WriteLine("Месяца с таким номером не существует!");
                Console.Read();
                return;
            }

            DateTime date = new DateTime(2021, monthInt, 1);
            Console.WriteLine($"Вы ввели {month}, этот месяц - {date.ToString("MMMM")}.");

            // если месяц = зима и если средняя темп > 0 
            //  вывести сообщение «Дождливая зима»
            bool winter = false;
            switch (monthInt)
            {
                case 12:
                case 1:
                case 2:
                    winter = true;
                    break;                
            }

            if (winter && averageTemperature > 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Дождливая зима");
            }

            Console.Read();
        }
    }
}
