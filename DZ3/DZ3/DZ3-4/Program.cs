using System;

namespace DZ3_4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Alexander Fakhrudinov = Александр Фахрудинов
             * asbuka@gmail.com
             * 
             * 4.  * «Морской бой» — вывести на экран массив 10х10, состоящий из символов X и O, где Х — элементы кораблей, а О — свободные клетки.
             */

            //Создать массив 10/10
            //наполнить его нулями
            int[,] battleField = new int[10,10];
            for (int x = 0; x < battleField.GetLength(0); x++)
            {
                for (int y = 0; y < battleField.GetLength(1); y++)
                {
                    battleField[x, y] = 0;
                }
            }

            //создать массив кораблей int 
            //длинна(от 1 до 4), направление(0=horizontal/1=vertical), начальная точка по оси х, начальная точка по оси у
            //в координатах игры! т.е. от 1 до 10
            int[,] ships = 
            {
                {4, 1, 9, 7},
                {3, 0, 1, 2},
                {3, 1, 7, 4},
                {2, 1, 6, 1},
                {2, 0, 9, 3},
                {2, 1, 2, 9},
                {1, 0, 5, 4},
                {1, 0, 2, 7},
                {1, 0, 7, 9},
                {1, 0, 5, 10}
            };

            //наполнить массив кораблями
            //2 типа - горизонтальный, вертикальный
            for (int x = 0; x < ships.GetLength(0); x++)
            {
                //горизонтальные
                if (ships[x, 1] == 0)
                {
                    int movePoint = ships[x, 2] - 1;
                    for (int i = 1;  i <= ships[x, 0]; i++)
                    {
                        battleField[ships[x, 3] - 1, movePoint++] = 1;
                    }
                }
                
                //вертикальные
                if (ships[x, 1] == 1)
                {
                    int movePoint = ships[x, 3] - 1;
                    for (int i = 1; i <= ships[x, 0]; i++)
                    {
                        battleField[movePoint++, ships[x, 2] - 1] = 1;
                    }
                }
            }
            string actionResult = "";
            ShowBattleField(battleField, actionResult);


            Console.Read();
        }

        private static void ShowBattleField(int[,] battleField, string actionResult)
        {

            Console.WriteLine("Урок 3. Практическое задание 4\n");
            Console.WriteLine("   Морской бой\n");

            string xAxis = "ABCDEFGHIJ";

            //вывести  массив
            Console.WriteLine("   " + xAxis); // здесь добавляем вывод оси X сверху
            for (int x = 0; x < battleField.GetLength(0); x++)
            {
                Console.Write(((x + 1) + " ").PadLeft(3));// здесь добавляем вывод оси Y слева
                for (int y = 0; y < battleField.GetLength(1); y++)
                {
                    if (battleField[x, y] == 1)//выводить Х на месте корабля. 
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("X");
                        Console.ResetColor();
                    }
                    else if (battleField[x, y] == 0)//выводить 0 на месте, где нет корабля и события выстрела
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.Write("O");
                        Console.ResetColor();
                    }
                    else if (battleField[x, y] == 3)//выводить чёрный 0 на месте, где был промах
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.Write("O");
                        Console.ResetColor();
                    }
                    else if (battleField[x, y] == 4)//выводить красный Х на месте, где было попадание
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("X");
                        Console.ResetColor();
                    }
                }
                Console.Write((" " + (x + 1)).PadRight(3));// здесь добавляем вывод оси Y справа
                Console.WriteLine();
            }
            Console.WriteLine("   " + xAxis); // здесь добавляем вывод оси X снизу


            //ожидать ввода пользователя с коорд выстрела - на фиксированной строке
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(actionResult);
            Console.ResetColor();
            Console.WriteLine($"Введите координаты в формате XY, например {xAxis[0]}2 или {xAxis[xAxis.Length-1]}10");
            string userInput = Console.ReadLine().ToUpper();

            int coordinateY = -1;
            int coordinateX = -1;
            if (userInput.Length >=2)
            {
                coordinateX = xAxis.IndexOf(userInput[0]);

                if (Int32.TryParse(userInput.Substring(1), out coordinateY))
                {
                    coordinateY--;

                    if ((coordinateX >= 0 && coordinateX <= 9) && (coordinateY >= 0 && coordinateY <= 9))
                    {
                        //читаем что в массиве
                        int target = battleField[coordinateY, coordinateX];
                        //если 0
                        if (target == 0)
                        {
                            actionResult = "Мимо!";
                            battleField[coordinateY, coordinateX] = 3;
                        }
                        if (target == 1)
                        {
                            actionResult = "Попал!";
                            battleField[coordinateY, coordinateX] = 4;
                        }
                        if (target == 3 || target == 4)
                        {
                            actionResult = "Сюда уже стреляли. Целься лучше!";
                        }
                    }
                    else
                    {
                        actionResult = "Координаты некорректны!";
                    }
                }
            }
            else
            {
                actionResult = "Координаты некорректны!!";
            }

            Console.Clear();
            ShowBattleField(battleField, actionResult);
        }
    }
}
