using System;
using System.Diagnostics;

namespace DZ5_4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            * Fakhrudinov Alexander = Фахрудинов Александр
            * asbuka@gmail.com
            *
            * Написать консольное приложение Task Manager, которое выводит на экран запущенные процессы и позволяет завершить указанный процесс.
            * Предусмотреть возможность завершения процессов с помощью указания его ID или имени процесса.
            */

            ShowProcessesList("", false);

            Console.Read();
        }

        private static void ShowUserActionRequest()
        {
            Console.WriteLine("\nВведите строку для поиска определенных процессов или id, или пустой ввод для вывода списка всех процессов");
            Console.WriteLine("Введите '-kill имя_процесса' или '-kill id_процесса' для попытки завершить процесс");
            string userInput = Console.ReadLine();

            if (userInput.Length > 6 && userInput.ToLower().Substring(0, 5).Equals("-kill"))
            {
                ShowProcessesList(userInput.Substring(6), true);
            }
            else
            {
                ShowProcessesList(userInput, false);
            }
        }

        /// <summary>
        /// Показать список процессов, отфильтрованных по маске search. flag true запускает протокол остановки процессов
        /// </summary>
        /// <param name="search"></param>
        /// <param name="flag"></param>
        private static void ShowProcessesList(string search, bool flag)
        {
            Console.WriteLine("\n");

            search = search.Trim().ToLower();

            Process[] processes = Process.GetProcesses();

            //если это задача kill 
            if (flag)
            {
                Console.WriteLine("Следующие процессы будут остановлены:");
                Console.ForegroundColor = ConsoleColor.Red;
            }

            //показываем или останавливаем процессы
            ShowOrKillProc(processes, search, false);           

            //если это задача kill 
            if (flag)
            {
                Console.ResetColor();

                //подтверждение остановки всех процессов
                KillConfirmation(processes, search);
            }
            else
            {
                ShowUserActionRequest();
            }
        }

        private static void ShowOrKillProc(Process[] processes, string search, bool killThis)
        {
            if(!killThis)
                ShowProcessesListHeader();

            int coincided = 0; // счетчик совпавших строк

            foreach (Process proc in processes)
            {
                if (proc.ProcessName.ToLower().ToString().Contains(search) || proc.Id.ToString().Contains(search))
                {
                    coincided++;

                    if (killThis)//останавливаем процессы
                    {
                        try
                        {
                            proc.Kill();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Не удалось остановить {proc.Id} {proc.ProcessName}, ошибка {ex.Message}");
                        }
                    }
                    else // показываем процессы
                    {
                        //id процесса
                        Console.Write(proc.Id.ToString().PadLeft(7));

                        //имя процесса, не длиннее 40 символов
                        if (proc.ProcessName.Length > 40)
                        {
                            Console.Write($" {proc.ProcessName.ToString().Substring(0, 37)}" + "...");
                        }
                        else
                        {
                            Console.Write($" {proc.ProcessName.ToString().PadRight(40)}");
                        }

                        //память под процесс
                        Console.Write(proc.PagedSystemMemorySize.ToString().PadLeft(15));

                        //Время запуска процесса, если возможно получить
                        try
                        {
                            Console.Write($"{proc.StartTime.ToString("yyyy.MM.dd HH:mm:ss").PadLeft(21)}");
                        }
                        catch (Exception)
                        {
                            Console.Write(" не доступно".PadLeft(21));
                        }
                        Console.WriteLine();
                    }
                }                
            }

            if (coincided == 0)
                Console.WriteLine($"Не найдено процессов, соответствующих запросу '{search}'.");
        }

        private static void KillConfirmation(Process[] processes, string search)
        {
            Console.WriteLine("Вы уверены, что все эти процессы надо остановить?\n" +
                " - Введите '-Y' для остановки процессов. Case sensitive! Регистр важен!\n" +
                " - Введите '-N' для прекращения задачи остановки процессов. Case sensitive! Регистр важен!\n" +
                " - Или любые другие символы как уточняющий запрос для поиска процессов, которые надо остановить.");
            string confirm = Console.ReadLine();

            if (confirm.Equals("-Y"))
            {
                ShowOrKillProc(processes, search, true);

                ShowUserActionRequest();
            }
            else if (confirm.Equals("-N"))
            {
                ShowUserActionRequest();
            }
            else
            {
                ShowProcessesList(confirm, true);
            }
        }

        private static void ShowProcessesListHeader()
        {
            Console.WriteLine("ID".PadLeft(7) + " Process Name".PadRight(41) + "MemorySize".PadLeft(15) + "Start Data Time".PadLeft(21));
        }
    }
}