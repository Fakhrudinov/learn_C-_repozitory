using System;
using System.Diagnostics;
using System.Text;

namespace DZ7
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Fakhrudinov Alexander == Фахрудинов Александр
             * asbuka@gmail.com
             * 
             * Написать любое приложение, 
             * произвести его сборку с помощью MSBuild, 
             * осуществить декомпиляцию с помощью dotPeek, 
             * внести правки в программный код и пересобрать приложение.
             */

            string str = "";
            Stopwatch sw = new Stopwatch();
            sw.Restart();
            for (int i = 0; i < 30000; i++)
            {
                str += Guid.NewGuid();
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds); //12842

            StringBuilder stringBuilder = new StringBuilder();
            sw.Restart();
            for (int i = 0; i < 30_000; i++)
            {
                stringBuilder.Append(Guid.NewGuid());
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds); //14

            Console.Read();
        }
    }
}
