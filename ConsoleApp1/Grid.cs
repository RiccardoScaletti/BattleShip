using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    enum Directions
    {
        Horizontal,
        Vertical
    }
    internal class Grid
    {
        char[][] board;
        public List<Ship> Ships;

        public Grid()
        {
            board = new char[10][];
            Ships = new List<Ship>();
            for (int i = 0; i < board.Length; i++)
            {
                board[i] = new char[board.Length];
            }

            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board.Length; col++)
                {
                    board[row][col] = '~';
                }
            }
        }
       
        public void DisplayBoard(bool hideShips)
        {
            string startLetter = "ABCDEFGHIJ";
            for (int i = 0; i < board.Length; i++)
            {
                if (i == 0)
                {
                    Console.WriteLine("  0 1 2 3 4 5 6 7 8 9");
                }
                for (int j = 0; j < board.Length; j++)
                {
                    if (j == 0)
                    {
                        Console.Write(startLetter[i] + " ");
                    }

                    char displayChar = board[i][j];
                    if (hideShips)
                    {
                        displayChar = '~';
                    }

                    //color manager
                    if (displayChar == '~')
                    {
                        Console.ForegroundColor = ConsoleColor.Blue; 
                    }
                    else if (displayChar == 'S')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else if (displayChar == 'X')
                    {
                        Console.ForegroundColor = ConsoleColor.Red; 
                    }
                    else if (displayChar == 'O')
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write(displayChar + " ");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        public void PlaceShip(Ship ship, int x, int y, Directions dir)
        {
            bool placed = false;
            List<(int, int)> tempCoordinates = new List<(int, int)>();
            while (!placed) 
            {
                for (int i = 0; i < ship.Length; i++)
                {
                    if (dir == Directions.Vertical)
                    {
                        x += 1;
                    }
                    else if (dir == Directions.Horizontal)
                    {
                        y += 1;
                    }
                    if (x >= 10 || y >= 10 || board[x][y] != '~')
                    {
                        Console.WriteLine("Impossible to place Ship at given coordinates, check again...");
                        return;
                    }

                    tempCoordinates.Add((x, y));
                    foreach (var coord in tempCoordinates)
                    {
                        board[coord.Item1][coord.Item2] = 'S';
                    }
                }
            }
        }

        public bool CheckWin()
        {
            foreach (var ship in Ships)
            {
                if (!ship.IsSunk()) return false;
            }
            return true;
        }
    }
}
