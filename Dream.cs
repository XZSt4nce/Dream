
using System;

namespace dream
{
    internal class Dream
    {
        public char[,] Maze { get; set; } // Лабиринт

        public char[,] Cheapest { get; set; } // Самый дешёвый путь

        public int R { get; set; } // Стоимость красного ключа

        public int G { get; set; } // Стоимость зелёного ключа

        public int B { get; set; } // Стоимость синего ключа

        public int Y { get; set; } // Стоимость жёлтого ключа

        public void PrintMaze()
        {
            for (int row = 0; row < Maze.GetUpperBound(0) + 1; row++)
            {
                for (int column = 0; column < Maze.GetUpperBound(1) + 1; column++)
                {
                    if (Maze[row, column] == 'R')
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else if (Maze[row, column] == 'G')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (Maze[row, column] == 'B')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                    else if (Maze[row, column] == 'Y')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else if (Maze[row, column] == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    Console.Write($"{Maze[row, column]} ");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
        }
        public void PrintMaze(int rowIndex, int columnIndex)
        {
            for (int row = 0; row < Maze.GetUpperBound(0) + 1; row++)
            {
                for (int column = 0; column < Maze.GetUpperBound(1) + 1; column++)
                {
                    if (row == rowIndex && column == columnIndex)
                    {
                        if (Maze[row, column] == 'R')
                        {
                            Console.BackgroundColor = ConsoleColor.Red;
                        }
                        else if (Maze[row, column] == 'G')
                        {
                            Console.BackgroundColor = ConsoleColor.Green;
                        }
                        else if (Maze[row, column] == 'B')
                        {
                            Console.BackgroundColor = ConsoleColor.Blue;
                        }
                        else if (Maze[row, column] == 'Y')
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else if (Maze[row, column] == 'X')
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGray;
                            Console.BackgroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        Console.Write($"{Maze[row, column]} ");
                    }
                    else
                    {
                        if (Maze[row, column] == 'R')
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                        }
                        else if (Maze[row, column] == 'G')
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                        }
                        else if (Maze[row, column] == 'B')
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                        }
                        else if (Maze[row, column] == 'Y')
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                        }
                        else if (Maze[row, column] == 'X')
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.BackgroundColor = ConsoleColor.White;
                        }
                        Console.Write($"{Maze[row, column]} ");
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine();
            }
        }
        public void Input()
        {
            bool s = false, e = false; // Есть ли в лабиринте начальная точка и выход
            // Считывание сторон лабиринта
            while (true)
            {
                string sides = "";
                try
                {
                    Console.WriteLine("Введите стороны лабиринта (пример ввода: 4 5):");
                    sides = Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("Ошибка ввода! Попробуйте ещё раз");
                }
                sides = sides.Trim();
                string trimSides = "";
                bool spaceWritten = false;
                foreach (char character in sides)
                {
                    if (character == ' ')
                    {
                        if (!spaceWritten)
                        {
                            trimSides += character;
                            spaceWritten = true;
                        }
                    }
                    else
                    {
                        trimSides += character;
                        spaceWritten = false;
                    }
                }
                string[] splitSides = trimSides.Split(' ');
                if (splitSides.Length != 2)
                {
                    Console.WriteLine("Ошибка ввода! Попробуйте ещё раз");
                    continue;
                }
                Maze = new char[(int.Parse(splitSides[0])), (int.Parse(splitSides[1]))];
                break;
            }

            // Считывание стоимости ключей
            while (true)
            {
                string keys = "";
                try
                {
                    Console.WriteLine("Введите стоимости ключей R G B Y (пример ввода: 1 1 1 1):");
                    keys = Console.ReadLine();
                }
                catch
                {
                    Console.WriteLine("Ошибка ввода! Попробуйте ещё раз");
                }
                keys = keys.Trim();
                string trimKeys = "";
                bool spaceWritten = false;
                foreach (char character in keys)
                {
                    if (character == ' ')
                    {
                        if (!spaceWritten)
                        {
                            trimKeys += character;
                            spaceWritten = true;
                        }
                    }
                    else
                    {
                        trimKeys += character;
                        spaceWritten = false;
                    }
                }
                string[] splitKeys = trimKeys.Split(' ');
                if (splitKeys.Length != 4)
                {
                    Console.WriteLine("Ошибка ввода! Попробуйте ещё раз");
                    continue;
                }
                R = int.Parse(splitKeys[0]);
                G = int.Parse(splitKeys[1]);
                B = int.Parse(splitKeys[2]);
                Y = int.Parse(splitKeys[3]);
                break;
            }
            Console.Clear();
            // Заполнение лабиринта точками
            for (int i = 0; i < Maze.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < Maze.GetUpperBound(1) + 1; j++)
                {
                    Maze[i, j] = '.';
                }
            }

            // Считывание лабиринта
            int row = Maze.GetUpperBound(0) + 1, column = Maze.GetUpperBound(1) + 1;
            Console.CursorVisible = false;
            int rowIndex = 0, columnIndex = 0;
            ConsoleKeyInfo key = new ConsoleKeyInfo();
            while (key.Key != ConsoleKey.Enter)
            {
                Console.WriteLine("Заполните лабиринт.");
                Console.WriteLine("Используйте кнопки стрелочки, чтобы перемещаться по элементам лабиринта.");
                Console.WriteLine("Чтобы очистить элемент, нажмите Backspace");
                Console.WriteLine("Чтобы закончить заполнение, нажмите Enter.");
                Console.WriteLine("R – красная дверь");
                Console.WriteLine("G – зелёная дверь");
                Console.WriteLine("B – синяя дверь");
                Console.WriteLine("Y – жёлтая дверь");
                Console.WriteLine("S – начальная позиция (только 1)");
                Console.WriteLine("X – стена");
                Console.WriteLine("E – выход (только 1)");
                Console.WriteLine(". (точка) – свободный элемент (коридор)\n\n");
                PrintMaze(rowIndex, columnIndex);
                key = Console.ReadKey(true);
                var value = Char.ToUpper(key.KeyChar);
                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (rowIndex != 0) rowIndex--;
                    else rowIndex = row - 1;
                }
                else if (key.Key == ConsoleKey.DownArrow)
                {
                    if (rowIndex != row - 1) rowIndex++;
                    else rowIndex = 0;
                }
                else if (key.Key == ConsoleKey.RightArrow)
                {
                    if (columnIndex != column - 1) columnIndex++;
                    else columnIndex = 0;
                }
                else if (key.Key == ConsoleKey.LeftArrow)
                {
                    if (columnIndex != 0) columnIndex--;
                    else columnIndex = column - 1;
                }
                else if (key.Key == ConsoleKey.Backspace)
                {
                    if (Maze[rowIndex, columnIndex] == 'E') e = false;
                    else if (Maze[rowIndex, columnIndex] == 'S') s = false;
                    Maze[rowIndex, columnIndex] = '.';
                }
                else if (value == 'S' ||
                         value == 'E' ||
                         value == 'R' ||
                         value == 'Y' ||
                         value == 'X' ||
                         value == 'B' ||
                         value == '.' ||
                         value == 'G')
                {
                    if (value == 'E')
                    {
                        if (Maze[rowIndex, columnIndex] == 'S') s = false;
                        if (!e)
                        {
                            Maze[rowIndex, columnIndex] = value;
                            e = true;
                        }
                    }
                    else if (value == 'S')
                    {
                        if (Maze[rowIndex, columnIndex] == 'E') e = false;
                        if (!s)
                        {
                            Maze[rowIndex, columnIndex] = value;
                            s = true;
                        }
                    }
                    else
                    {
                        if (Maze[rowIndex, columnIndex] == 'S') s = false;
                        else if (Maze[rowIndex, columnIndex] == 'E') e = false;
                        Maze[rowIndex, columnIndex] = value;
                    }
                }
                Console.Clear();
            }
        }

        public void Search()
        {
            int[][] path = new int[Maze.GetUpperBound(0)][];
            for (int i = 0; i < Maze.GetUpperBound(0); i++)
            {
                path[i] = new int[Maze.GetUpperBound(1)];
            }
            int cost = 0;
            bool found_exit = false;

        }
        public static void Main()
        {
            var petya = new Dream();
            petya.Input();

            Console.ReadKey();
        }
    }
}