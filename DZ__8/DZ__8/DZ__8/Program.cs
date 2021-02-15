using System;


namespace DZ__8
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Alerxander Fakhrudinov = Александр Фахрудинов
             * asbuka@gmail.com
             * 
             * Создать консольное приложение, которое при старте выводит приветствие, записанное в настройках приложения (application-scope). 
             * Запросить у пользователя имя, возраст и род деятельности, а затем сохранить данные в настройках. 
             * При следующем запуске отобразить эти сведения. 
             * Задать приложению версию и описание.
             * 
             */

            Console.WriteLine("Практическое занятие 8.\nНастройки приложения на .Net Framework");
            Console.WriteLine("версия: " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString());

            Console.WriteLine(Properties.Settings.Default.greetingOnStart);



            bool isChanged = false;
            if (string.IsNullOrEmpty(Properties.Settings.Default.userName))
            {
                Console.WriteLine("Пожалуйста, введите Ваше имя");
                Properties.Settings.Default.userName = Console.ReadLine();
                isChanged = true;
            }
            else
            {
                Console.WriteLine("Сохраненное в настройках имя: " + Properties.Settings.Default.userName);
            }

            if (string.IsNullOrEmpty(Properties.Settings.Default.userAge))
            {
                Console.WriteLine("Пожалуйста, введите Ваш возраст");
                Properties.Settings.Default.userAge = Console.ReadLine();
                isChanged = true;
            }
            else
            {
                Console.WriteLine("Сохраненный в настройках возраст: " + Properties.Settings.Default.userAge);
            }

            if (string.IsNullOrEmpty(Properties.Settings.Default.userJob))
            {
                Console.WriteLine("Пожалуйста, введите Ваш род деятельности");
                Properties.Settings.Default.userJob = Console.ReadLine();
                isChanged = true;
            }
            else
            {
                Console.WriteLine("Сохраненный в настройках род деятельности: " + Properties.Settings.Default.userJob);
            }

            /*
            else
            {
                Console.WriteLine("Снова ты, " + Properties.Settings.Default.userName);                
            }*/

            if (isChanged)
                Properties.Settings.Default.Save();


            Console.Read();
        }
    }
}

