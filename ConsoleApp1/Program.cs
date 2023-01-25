using System;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Настраиваемый HEALTHBAR
            bool isOpen = true;
            int health = 0, maxHealth = 10;
            int mana = 0, maxMana = 10;

            while (isOpen)
            {
                DrawBar(health, maxHealth, ConsoleColor.Green, 0, '|');
                DrawBar(mana, maxMana, ConsoleColor.Blue, 1);

                Console.SetCursorPosition(0, 5);
                Console.Write("Что бы выйти, введите:\nХП: 0(nool)\nМана: 0\nВведите число на которе именить ХП: ");
                health += Convert.ToInt32(Console.ReadLine());
                Console.Write("Введите число на которе именить Ману: ");
                mana += Convert.ToInt32(Console.ReadLine());
                if (health == 0)
                {
                    isOpen = false;
                }
                Console.ReadKey();
                Console.Clear();
            }
            #endregion

            #region PACMAN на минималках. (без использования ООП)
            Console.CursorVisible = false;
            char[,] map = ReadMap("map.txt");
            ConsoleKeyInfo pressedKey;
            int pacmanX = 1;
            int pacmanY = 1;

            int score = 0;

            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
                DrawMap(map);

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.SetCursorPosition(pacmanX, pacmanY);
                Console.Write("@");

                Console.ForegroundColor= ConsoleColor.Green;
                Console.SetCursorPosition(45, 0);
                Console.Write($"Score: {score}");

                pressedKey = Console.ReadKey();
                HandleInput(pressedKey, ref pacmanX, ref pacmanY, map, ref score);
            }
            #endregion

        }

        static void DrawBar(int value, int maxValue, ConsoleColor color, int position, char symbol = '/')
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            string bar = "";

            for (int i = 0; i < value; i++)
            {
                bar += symbol;
            }
            Console.SetCursorPosition(0, position);
            Console.Write("[");
            Console.BackgroundColor = color;
            Console.Write(bar);
            Console.BackgroundColor = defaultColor;

            bar = "";

            for (int i = value; i < maxValue; i++)
            {
                bar += " ";
            }
            Console.Write(bar + "]");
        }//Функция для управления HEALTHBAR

        private static char[,] ReadMap(string path)
        {
            string[] file = File.ReadAllLines("map.txt");

            char[,] map = new char[GetMaxLenghtOfLines(file), file.Length];

            for(int x = 0; x < map.GetLength(0); x++)
            {
                for(int y = 0; y < map.GetLength(1); y++)
                {
                    map[x, y] = file[y][x];
                }
            }
            return map;
        }//считываем карту из файла

        private static int GetMaxLenghtOfLines(string[] lines)
        {
            int maxLength = lines[0].Length;

            foreach(var line in lines)
            {
                if(line.Length > maxLength)
                {
                    maxLength = line.Length;
                }
            }
            return maxLength;
        }

        private static void DrawMap(char[,] map)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.Write(map[x, y]);
                }
                Console.Write("\n");
            }
        }//рисуем карту


        //управление pacman и система зачисления очков
        private static void HandleInput(ConsoleKeyInfo pressedKey, ref int pacmanX, ref int pacmanY, char[,] map, ref int score)
        {
            int[] direction = GetDirection(pressedKey);

            int nextPacmanPositionX = pacmanX + direction[0];
            int nextPacmanPositionY = pacmanY + direction[1];

            char nextCell = map[nextPacmanPositionX, nextPacmanPositionY];

            if (nextCell == ' ' || nextCell == '.')
            {
                pacmanX = nextPacmanPositionX;
                pacmanY = nextPacmanPositionY;
                if(nextCell == '.')
                {
                    score++;
                    map[nextPacmanPositionX, nextPacmanPositionY] = ' ';
                }
            }
        }
        private static int[] GetDirection(ConsoleKeyInfo pressedKey)
        {
            int[] direction = { 0, 0 };

            if (pressedKey.Key == ConsoleKey.UpArrow)
            {
                direction[1] = -1;
            }
            else if (pressedKey.Key == ConsoleKey.DownArrow)
            {
                direction[1] = 1;
            }
            else if (pressedKey.Key == ConsoleKey.LeftArrow)
            {
                direction[0] = -1;
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow)
            {
                direction[0] = 1;
            }

            return direction;
        }
    }
}
