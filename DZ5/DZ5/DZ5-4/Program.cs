
using System;
using System.IO;

namespace DZ5_4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Alerxander Fakhrudinov = Александр Фахрудинов
             * asbuka@gmail.com
             * 4.  (*) Сохранить дерево каталогов и файлов по заданному пути в текстовый файл — с рекурсией и без.
             */

            Console.WriteLine("Урок 5. Практическое занятие 4");

            string path = @"c:\Program Files\Common Files\";// c этого места выводим дерево каталогов и файлов
            string resultFile = "tree.txt";

            Console.WriteLine("\nДерево Каталогов/файлов для пути \n" + path);
            Console.WriteLine();

            // уберем последний '\' если он есть
            if (path[path.Length - 1].Equals('\\'))
            {
                path = path.Substring(0, path.Length - 1);
            }

            //последний элемент - имя стартовой папки и ее размер
            string[] pathArr = path.Split('\\');
            string text = pathArr.GetValue(path.Split('\\').Length - 1).ToString();
            int ignored = path.Length - text.Length;// начальное значение для вычисления отступа
            
            //вывод первого элемента
            Console.WriteLine(text);
            File.WriteAllText(resultFile, text + "\n");

            GetListOfFilesDirs(path, ignored, resultFile);

            Console.Read();
        }

        private static void GetListOfFilesDirs(string path, int ignored, string resultFile)
        {
            //формируем ветки дерева
            string treeBranch = "";
            foreach (char ch in path.Substring(ignored))
            {
                if (ch != '\\')
                {
                    treeBranch += " ";
                }
                else
                {
                    treeBranch += "|";
                }
            }
            treeBranch += "+";

            //выводим папки
            string[] entries = Directory.GetDirectories(path);
            foreach (string dir in entries)
            {
                WriteLine(dir, treeBranch, resultFile);

                GetListOfFilesDirs(dir, ignored, resultFile);
            }

            //выводим файлы
            string[] entriesFiles = Directory.GetFiles(path);
            foreach (string file in entriesFiles)
            {
                WriteLine(file, treeBranch, resultFile);
            }
        }

        private static void WriteLine(string strLine, string treeBranch, string resultFile)
        {
            string[] dirToConsole = strLine.Split('\\');
            string text = dirToConsole.GetValue(strLine.Split('\\').Length - 1).ToString();

            Console.WriteLine(treeBranch + text);
            File.AppendAllText(resultFile, treeBranch + text + "\n");
        }
    }
}