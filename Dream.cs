﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace dream
{
    public class Dream
    {
        private char[,] maze;
        private int r, g, b, y, startRow, startColumn, endRow, endColumn;
        private Dictionary<int[], Node> nodes = new Dictionary<int[], Node>();
        private Dictionary<int, Path> paths = new Dictionary<int, Path>();
        public char[,] Maze
        {
            get { return maze; }
            set { maze = value; } 
        }
        public int R
        {
            get { return r; }
            set { r = value; }
        }
        public int G
        {
            get { return g; }
            set { g = value; }
        }
        public int B
        {
            get { return b; }
            set { b = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int StartRow
        {
            get { return startRow; }
            set { startRow = value; }
        }
        public int StartColumn
        {
            get { return startColumn; }
            set { startColumn = value; }
        }
        public int EndRow
        {
            get { return endRow; }
            set { endRow = value; }
        }
        public int EndColumn
        {
            get { return endColumn; }
            set { endColumn = value; }
        }
        public Dictionary<int[], Node> Nodes
        {
            get { return nodes; }
            set { nodes = value; }
        }
        public Dictionary<int, Path> Paths
        {
            get { return paths; }
            set { paths = value; }
        }
        public Dream() { Input(); }
        public Dream(char[,] maze) { Maze = maze; }
        // Вывести лабиринт
        public void PrintMaze()
        {
            for (int row = 0; row < Maze.GetUpperBound(0) + 1; row++)
            {
                for (int column = 0; column < Maze.GetUpperBound(1) + 1; column++)
                {
                    if (Maze[row, column] == 'X')
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else if (Maze[row, column] == 'R')
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
                    Console.Write($"{Maze[row, column]} ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (row == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"  R: {R}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"  G: {G}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"  B: {B}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"  Y: {Y}");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
            }
        }
        // Вывести лабиринт с выделенным элементом
        public void PrintMaze(int row_index, int column_index)
        {
            for (int row = 0; row < Maze.GetUpperBound(0) + 1; row++)
            {
                for (int column = 0; column < Maze.GetUpperBound(1) + 1; column++)
                {
                    if (row == row_index && column == column_index)
                    {
                        if (Maze[row, column] == 'X')
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGray;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else if (Maze[row, column] == 'R')
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
                        else
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                    }
                    else
                    {
                        if (Maze[row, column] == 'X')
                        {
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                        }
                        else if (Maze[row, column] == 'R')
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
                    }
                    Console.Write($"{Maze[row, column]} ");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                if (row == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"  R: {R}");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"  G: {G}");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"  B: {B}");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write($"  Y: {Y}");
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
            }
        }
        public void Input()
        {
            int row, column;
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
                string trim_sides = "";
                bool space_written = false;
                foreach (char character in sides)
                {
                    if (character == ' ')
                    {
                        if (!space_written)
                        {
                            trim_sides += character;
                            space_written = true;
                        }
                    }
                    else
                    {
                        trim_sides += character;
                        space_written = false;
                    }
                }
                string[] split_sides = trim_sides.Split(' ');
                if (split_sides.Length != 2)
                {
                    Console.WriteLine("Ошибка ввода! Попробуйте ещё раз");
                    continue;
                }
                row = int.Parse(split_sides[0]);
                column = int.Parse(split_sides[1]);
                if (row <= 2 || column <= 2 || row == 3 && column == 3)
                {
                    Console.WriteLine("Ошибка ввода! Недопустимая размерность лабиринта");
                    Console.WriteLine("Примечание. Лабиринт окружается стенами");
                    continue;
                }
                Maze = new char[(int.Parse(split_sides[0])), (int.Parse(split_sides[1]))];
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
                string trim_keys = "";
                bool space_written = false;
                foreach (char character in keys)
                {
                    if (character == ' ')
                    {
                        if (!space_written)
                        {
                            trim_keys += character;
                            space_written = true;
                        }
                    }
                    else
                    {
                        trim_keys += character;
                        space_written = false;
                    }
                }
                string[] split_keys = trim_keys.Split(' ');
                if (split_keys.Length != 4)
                {
                    Console.WriteLine("Ошибка ввода! Попробуйте ещё раз");
                    continue;
                }
                R = int.Parse(split_keys[0]);
                G = int.Parse(split_keys[1]);
                B = int.Parse(split_keys[2]);
                Y = int.Parse(split_keys[3]);
                if (R < 0 || G < 0 || B < 0 || Y < 0)
                {
                    Console.WriteLine("Ошибка ввода! Стоимость ключа не может быть отрицательной");
                    continue;
                }
                break;
            }
            Console.Clear();
            // Заполнение лабиринта точками
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    Maze[i, j] = '.';
                }
            }

            // Считывание лабиринта
            bool s = false, e = false; // Есть ли в лабиринте начальная точка и выход
            for (int i = 0; i < row; i++)
            {
                Maze[i, 0] = 'X';
                Maze[i, column - 1] = 'X';
            }
            for (int i = 0; i < column; i++)
            {
                Maze[0, i] = 'X';
                Maze[row - 1, i] = 'X';
            }
            Console.CursorVisible = false;
            int rowIndex = 1, columnIndex = 1;
            char value;
            bool error_walls = true, error_se = true;
            ConsoleKeyInfo key;
            while (error_walls || error_se)
            {
                Console.WriteLine("Заполните лабиринт.");
                Console.WriteLine("Используйте кнопки стрелочки, чтобы перемещаться по элементам лабиринта.");
                Console.WriteLine("Чтобы очистить элемент, нажмите Backspace");
                Console.WriteLine("Чтобы закончить заполнение, нажмите Enter.");
                Console.WriteLine("R – красная дверь");
                Console.WriteLine("G – зелёная дверь");
                Console.WriteLine("B – синяя дверь");
                Console.WriteLine("Y – жёлтая дверь");
                Console.WriteLine("S – начальная позиция");
                Console.WriteLine("X – стена");
                Console.WriteLine("E – выход");
                Console.WriteLine(". (точка) – свободный элемент (коридор)");
                if (error_walls) Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ВАЖНО! Лабиринт должен быть окружён стенами");
                Console.ForegroundColor = ConsoleColor.White;
                if (error_se) Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ВАЖНО! В лабиринте обязательно должны присутствовать начальная позиция и выход\n\n");
                Console.ForegroundColor = ConsoleColor.White;
                PrintMaze(rowIndex, columnIndex);
                key = Console.ReadKey(true);
                value = Char.ToUpper(key.KeyChar);
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
                else if (rowIndex != 0 && rowIndex != row - 1 &&
                         columnIndex != 0 && columnIndex != column - 1)
                {
                    if (key.Key == ConsoleKey.Backspace || key.Key == ConsoleKey.Delete)
                    {
                        Maze[rowIndex, columnIndex] = '.';
                    }
                    else if ((key.Key == ConsoleKey.S ||
                             key.Key == ConsoleKey.E ||
                             key.Key == ConsoleKey.R ||
                             key.Key == ConsoleKey.Y ||
                             key.Key == ConsoleKey.X ||
                             key.Key == ConsoleKey.B ||
                             value == '.' ||
                             key.Key == ConsoleKey.G) &&
                             key.Modifiers == 0 ||
                             key.Modifiers == ConsoleModifiers.Shift)
                    {
                        if (value == 'E')
                        {
                            if (Maze[rowIndex, columnIndex] == 'S') s = false;
                            if (!e)
                            {
                                Maze[rowIndex, columnIndex] = value;
                                e = true;
                                EndRow = rowIndex; EndColumn = columnIndex;
                            }
                        }
                        else if (value == 'S')
                        {
                            if (Maze[rowIndex, columnIndex] == 'E') e = false;
                            if (!s)
                            {
                                Maze[rowIndex, columnIndex] = value;
                                s = true;
                                StartRow = rowIndex; StartColumn = columnIndex;
                            }
                        }
                        else
                        {
                            if (Maze[rowIndex, columnIndex] == 'S') s = false;
                            else if (Maze[rowIndex, columnIndex] == 'E') e = false;
                            Maze[rowIndex, columnIndex] = value;
                        }
                    }
                    else if (key.Key == ConsoleKey.Enter)
                    {
                        error_se = !s || !e;
                        error_walls = false;
                        for (int i = 0; i < row; i++)
                        {
                            if (Maze[i, 0] != 'X' || Maze[i, column - 1] != 'X')
                            {
                                error_walls = true;
                                break;
                            }
                        }
                        if (!error_walls)
                        {
                            for (int i = 0; i < column; i++)
                            {
                                if (Maze[0, i] != 'X' || Maze[row - 1, i] != 'X')
                                {
                                    error_walls = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                Console.Clear();
            }
        }

        public bool Contains(Dictionary<int[], Node> dict, int[] target)
        {
            int[][] keys = dict.Keys.ToArray();
            bool found = false;
            foreach (int[] key in keys)
            {
                found = true;
                if (key.Length == target.Length)
                {
                    for (int i = 0; i < target.Length; i++)
                    {
                        if (key[i] != target[i])
                        {
                            found = false;
                            break;
                        }
                    }
                }
                if (found) break;
            }
            return found;
        }

        public int[] GetKey(Dictionary<int[], Node> dict, int[] target)
        {
            int[][] keys = dict.Keys.ToArray();
            bool notFound;
            foreach (int[] key in keys)
            {
                notFound = false;
                if (key.Length == target.Length)
                {
                    for (int i = 0; i < target.Length; i++)
                    {
                        if (key[i] != target[i])
                        {
                            notFound = true;
                            break;
                        }
                    }
                }
                if (!notFound)
                {
                    target = key;
                    break;
                }
            }
            return target;
        }

        public void ScanNodes()
        {
            for (int i = 1; i < Maze.GetUpperBound(0); i++)
            {
                for (int j = 1; j < Maze.GetUpperBound(1); j++)
                {
                    char value = Maze[i, j];
                    char u = Maze[i - 1, j];
                    char d = Maze[i + 1, j];
                    char l = Maze[i, j - 1];
                    char r = Maze[i, j + 1];
                    char ul = Maze[i - 1, j - 1];
                    char ur = Maze[i - 1, j + 1];
                    char dl = Maze[i + 1, j - 1];
                    char dr = Maze[i + 1, j + 1];
                    if (value == 'X') continue;
                    else
                    {
                        if ((l == 'X' && r == 'X' && u != 'X' && d != 'X' ||
                             l != 'X' && r != 'X' && u == 'X' && d == 'X' ||
                             value == '.' && l != 'X' && r != 'X' && u != 'X' && ul != 'X' && ur != 'X' && StartColumn != j && EndColumn != j ||
                             value == '.' && l != 'X' && r != 'X' && d != 'X' && dl != 'X' && dr != 'X' && StartColumn != j && EndColumn != j ||
                             value == '.' && l != 'X' && u != 'X' && d != 'X' && dl != 'X' && ul != 'X' && StartRow != i && EndRow != i ||
                             value == '.' && r != 'X' && u != 'X' && d != 'X' && dr != 'X' && ur != 'X' && StartRow != i && EndRow != i) &&
                            value != 'S' && value != 'E')
                        {
                            continue;
                        }
                        else
                        {
                            Node node = new Node(i, j, value);
                            bool passedRed = false, 
                                 passedGreen = false, 
                                 passedBlue = false, 
                                 passedYellow = false;
                            value = Maze[i, j - 1];
                            for (int left = j - 1; left >= 0 && value != 'X'; left--)
                            {
                                value = Maze[i, left];
                                int[] key = new int[] { i, left };

                                if (value == 'R') passedRed = true;
                                if (value == 'G') passedGreen = true;
                                if (value == 'B') passedBlue = true;
                                if (value == 'Y') passedYellow = true;

                                if (Contains(Nodes, key))
                                {
                                    key = GetKey(Nodes, key);
                                    Nodes.TryGetValue(key, out Node neighbor);
                                    node.Colors[node.NeighborsCount++] = Convert.ToInt32(passedRed)    * 0b1000 + 
                                                                         Convert.ToInt32(passedGreen)  * 0b0100 + 
                                                                         Convert.ToInt32(passedBlue)   * 0b0010 +
                                                                         Convert.ToInt32(passedYellow) * 0b0001;

                                    neighbor.Colors[neighbor.NeighborsCount++] = Convert.ToInt32(passedRed)    * 0b1000 +
                                                                                 Convert.ToInt32(passedGreen)  * 0b0100 +
                                                                                 Convert.ToInt32(passedBlue)   * 0b0010 +
                                                                                 Convert.ToInt32(passedYellow) * 0b0001;
                                    neighbor.AddNeighbor(node);
                                    node.AddNeighbor(neighbor);
                                    break;
                                }
                            }

                            passedRed = false;
                            passedGreen = false;
                            passedBlue = false;
                            passedYellow = false;
                            value = Maze[i - 1, j];
                            for (int up = i - 1; up >= 0 && value != 'X'; up--)
                            {
                                value = Maze[up, j];
                                int[] key = new int[] { up, j };

                                if (value == 'R') passedRed = true;
                                if (value == 'G') passedGreen = true;
                                if (value == 'B') passedBlue = true;
                                if (value == 'Y') passedYellow = true;

                                if (Contains(Nodes, key))
                                {
                                    key = GetKey(Nodes, key);
                                    Nodes.TryGetValue(key, out Node neighbor);
                                    node.Colors[node.NeighborsCount++] = Convert.ToInt32(passedRed) * 0b1000 +
                                                                         Convert.ToInt32(passedGreen) * 0b0100 +
                                                                         Convert.ToInt32(passedBlue) * 0b0010 +
                                                                         Convert.ToInt32(passedYellow) * 0b0001;

                                    neighbor.Colors[neighbor.NeighborsCount++] = Convert.ToInt32(passedRed) * 0b1000 +
                                                                                 Convert.ToInt32(passedGreen) * 0b0100 +
                                                                                 Convert.ToInt32(passedBlue) * 0b0010 +
                                                                                 Convert.ToInt32(passedYellow) * 0b0001;
                                    neighbor.AddNeighbor(node);
                                    node.AddNeighbor(neighbor);
                                    break;
                                }
                            }
                            Nodes.Add(new int[] { i, j }, node);
                        }
                    }
                }
            }
        }

        public void ScanPaths()
        {
            Stack<Node> stack = new Stack<Node>();
            Stack<HashSet<Node>> visited = new Stack<HashSet<Node>>();
            foreach (Node node in Nodes.Values)
            {
                if (node.IsStart)
                {
                    stack.Push(node);
                    visited.Push(new HashSet<Node>());
                    visited.Peek().Add(node);
                    break;
                }
            }
            while (stack.Count > 0)
            {
                Node node = stack.Peek();
                HashSet<Node> actualVisited = visited.Peek();
                if (node.IsEnd)
                {
                    Path path = new Path();
                    path.Way = stack.ToArray();
                    Paths.Add(Paths.Count, path);
                    stack.Pop();
                    visited.Pop();
                    node.PassedEnd = true;
                    continue;
                }

                bool hasNeighbors = false;
                foreach (Node neighbor in node.Neighbors)
                {
                    if (!actualVisited.Contains(neighbor) && (!neighbor.IsEnd || !node.PassedEnd))
                    {
                        stack.Push(neighbor);
                        actualVisited.Add(neighbor);
                        var visitedArr = actualVisited.ToArray();
                        var newVisited = new HashSet<Node>();
                        foreach (Node v in visitedArr)
                        {
                            newVisited.Add(v);
                        }
                        visited.Push(newVisited);
                        hasNeighbors = true;
                        break;
                    }
                }
                if (!hasNeighbors)
                {
                    stack.Pop();
                    visited.Pop();
                }
            }
        }

        public void PathsColorization()
        {
            foreach (Path path in Paths.Values.ToArray())
            {
                for (int i = 0; i < path.Way.Length - 1; i++)
                {
                    Node node = path.Way[i];
                    char value = Maze[node.Row, node.Column];
                    int colors = node.Colors[node.GetNeighborPosition(path.Way[i + 1])];
                    if ((colors & 0b1000) == 0b1000 || value == 'R') 
                        path.Red = true;
                    if ((colors & 0b0100) == 0b0100 || value == 'G') 
                        path.Green = true;
                    if ((colors & 0b0010) == 0b0010 || value == 'B') 
                        path.Blue = true;
                    if ((colors & 0b0001) == 0b0001 || value == 'Y') 
                        path.Yellow = true;
                }
            }
        }

        public static void Main()
        {
            var petya = new Dream();
            petya.ScanNodes();
            petya.ScanPaths();
            petya.PathsColorization();
            if (petya.Paths.Count == 0)
            {
                petya.PrintMaze();
                Console.WriteLine("\nSleep");
                Console.ReadKey(true);
                Environment.Exit(0);
            }
            Path first = petya.Paths[0];
            int min = Convert.ToInt32(first.Red) * petya.R + 
                      Convert.ToInt32(first.Green) * petya.G +
                      Convert.ToInt32(first.Blue) * petya.B +
                      Convert.ToInt32(first.Yellow) * petya.Y;
            for (int i = 1; i < petya.Paths.Count; i++)
            {
                Path path = petya.Paths[i];
                int cost = Convert.ToInt32(path.Red) * petya.R +
                           Convert.ToInt32(path.Green) * petya.G +
                           Convert.ToInt32(path.Blue) * petya.B +
                           Convert.ToInt32(path.Yellow) * petya.Y;
                if (cost < min) min = cost;
            }
            petya.PrintMaze();
            Console.WriteLine($"\nСамый дешёвый путь стоит: {min}");
            Console.ReadKey(true);
            Environment.Exit(0);
        }
    }

    public class Node
    {
        public Node(int r, int c)
        {
            Row = r;
            Column = c;
        }
        public Node(int r, int c, char p)
        {
            Row = r;
            Column = c;
            if (p == 'S') IsStart = true;
            else if (p == 'E') IsEnd = true;
        }
        public bool Equals(Node node)
        {
            bool c1 = IsStart == node.IsStart;
            bool c2 = IsEnd == node.IsEnd;
            bool c3 = Row == node.Row;
            bool c4 = Column == node.Column;
            bool c5 = Neighbors.Count == node.Neighbors.Count;
            bool cr = Colors[0] == node.Colors[0];
            bool cg = Colors[1] == node.Colors[1];
            bool cb = Colors[2] == node.Colors[2];
            bool cy = Colors[3] == node.Colors[3];
            return c1 && c2 && c3 && c4 && c5 && cr && cg && cb && cy;
        }
        public int GetNeighborPosition (Node node)
        {
            int position = 0;
            foreach (Node neighbor in Neighbors)
            {
                if (neighbor == node) { break; }
                position++;
            }
            return position;
        }
        private bool isStart = false;
        private bool isEnd = false;
        private bool passedEnd = false;
        private HashSet<Node> neighbors = new HashSet<Node>();
        private int neighborsCount = 0;
        private int[] colors = new int[4] { 0b0000, 0b0000, 0b0000, 0b0000 };
        /*  
         *  0b0000
         *    ^^^^
         *    |||└- Yellow
         *    ||└- Blue
         *    |└- Green
         *    └- Red
        */
        private int row, column;
        public int Row
        {
            get { return row; }
            set { row = value; }
        }
        public int Column
        {
            get { return column; }
            set { column = value; }
        }
        public HashSet<Node> Neighbors 
        { 
            get { return neighbors; }
            set { neighbors = value; }
        }
        public bool IsStart
        {
            get { return isStart; }
            set { isStart = value; }
        }
        public bool IsEnd
        {
            get { return isEnd; }
            set { isEnd = value; }
        }

        public bool PassedEnd
        {
            get { return passedEnd; }
            set { passedEnd = value; }
        }
        public int NeighborsCount
        {
            get { return neighborsCount; }
            set { neighborsCount = value; }
        }
        public int[] Colors
        {
            get { return colors; }
            set { colors = value; }
        }
        public void AddNeighbor(Node node) => Neighbors.Add(node);
    }

    public class Path
    {
        public Path() { }
        public Path(Node[] _way)
        {
            Way = _way;
        }
        public Path(Node[] _way, bool _passedRed, bool _passedBlue, bool _passedGreen, bool _passedYellow)
        {
            Way = _way;
            Red = _passedRed;
            Blue = _passedBlue;
            Green = _passedGreen;
            Yellow = _passedYellow;
        }

        private Node[] way;
        private bool passedRed = false, passedBlue = false, passedGreen = false, passedYellow = false;
        public Node[] Way
        {
            get { return way; }
            set { way = value; }
        }
        public bool Red
        {
            get { return passedRed; }
            set { passedRed = value; }
        }
        public bool Blue
        {
            get { return passedBlue; }
            set { passedBlue = value; }
        }
        public bool Green
        {
            get { return passedGreen; }
            set { passedGreen = value; }
        }
        public bool Yellow
        {
            get { return passedYellow; }
            set { passedYellow = value; }
        }
    }
}