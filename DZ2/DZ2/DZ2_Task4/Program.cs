using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2_Task4
{
    class Program
    {

        /* 
         * Alexander Fakhrudinov = Александр Фахрудинов
         * asbuka@gmail.com
         * 
         * Практическое задание 2 - действие 6
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
         * В DZ2_Task4 будут решена задачи 6.
         */


        static void Main(string[] args)
        {
            Console.WriteLine("Практическое задание 2 - действие 6\n");
            // 6.   (*) Для полного закрепления битовых масок, попытайтесь создать универсальную структуру расписания недели, к примеру, чтобы описать работу какого либо офиса. 
            //Явный пример - офис номер 1 работает со вторника до пятницы, офис номер 2 работает с понедельника до воскресенья.

            //предположим будет входящий звонок сотруднику Пупкину в дату callDateTime
            //если суббота/воскресенье, то обрабатываем маску workHoursWeekEnd
            //если другое - то workHours
            //смотрим, попадает ли на рабочее время, получаем результат - ответит на звонок или нет.

            //маска рабочих дней
            int workDays = 0b_1111100;

            //маска рабочих часов
            //                        0    4    8   12   16   20
            int workHours =        0b_0000_0000_1111_0111_1000_0000;//в будни
            int workHoursWeekEnd = 0b_0000_0000_0000_0000_0000_1100;//в выходные

            //дата и время звонка
            DateTime callDateTime = new DateTime(2021, 1, 21, 14, 30, 05);

            Console.WriteLine("Входящий звонок Васе Пупкину на рабочий телефон в " + callDateTime.ToString("dddd, H:mm"));

            //дата
            int userCallDay = 0b_0000000;
            switch (callDateTime.ToString("dddd").ToLower())
            {
                case "понедельник":
                    userCallDay = 0b_1000000;
                    break;
                case "вторник":
                    userCallDay = 0b_0100000;
                    break;
                case "среда":
                    userCallDay = 0b_0010000;
                    break;
                case "четверг":
                    userCallDay = 0b_0001000;
                    break;
                case "пятница":
                    userCallDay = 0b_0000100;
                    break;
                case "суббота":
                    userCallDay = 0b_0000010;
                    break;
                case "воскресенье":
                    userCallDay = 0b_0000001;
                    break;
            }

            //время
            int callTime = Int32.Parse(callDateTime.ToString("H:mm").Split(':').First());

            string zero = "00000000000000000000000";//23 символа, т.к "1" дописываю сам в callTimeToString
            string callTimeToString = zero.Substring(0, callTime) + "1" + zero.Substring(0, zero.Length - callTime);
            //16=0000 0000 0000 0000 1000 0000
            //23=0000 0000 0000 0000 0000 0001
            //13=0000 0000 0000 0100 0000 0000


            int isWorkDay = userCallDay | workDays; // используем ИЛИ, т.к. нам надо любое пересечение
            if (workDays == isWorkDay)
            {
                Console.WriteLine(callDateTime.ToString("dddd") + " - это рабочий день. Проверим время звонка:"); 

                int isWorkHour = Convert.ToInt32(callTimeToString, 2) | workHours;
                if (workHours == isWorkHour)
                {
                    Console.WriteLine(callDateTime.ToString("H:mm") + " - Это рабочее время.");
                }
                else
                {
                    Console.WriteLine(callDateTime.ToString("H:mm") + " - Это нерабочее время. Никто не ответит.");
                }
            }
            else
            {
                Console.WriteLine(callDateTime.ToString("dddd") + " - это выходной. Но вдруг у Пупкина есть рабочие часы?");

                int isWorkHour = Convert.ToInt32(callTimeToString, 2) | workHoursWeekEnd;
                if (workHoursWeekEnd == isWorkHour)
                {
                    Console.WriteLine(callDateTime.ToString("H:mm") + " - Вам повезло. Это рабочее время, Вася дежурит по выходным");
                }
                else
                {
                    Console.WriteLine(callDateTime.ToString("H:mm") + " - Это нерабочее время. Никто не ответит.");
                }
            }

            Console.Read();
        }
    }
}
