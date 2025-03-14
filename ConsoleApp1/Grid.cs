﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    enum Directions
    {
        None,
        Horizontal,
        Vertical
    }
    internal class Grid
    {
        
        public char[][] board;
        public List<Ship> Ships;
        public bool shipPlaced = false;

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
                    if (hideShips && displayChar == 'S')
                    {
                        displayChar = '~';
                    }

                    //color manager
                    switch (displayChar)
                    {
                        default:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case 'S':
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case 'X':
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case 'O':
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                    }
                    Console.Write(displayChar + " ");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }

        public void PlaceShip(Ship ship, int x, int y, Directions dir)
        {
            shipPlaced = false;
            List<(int, int)> tempCoordinates = new List<(int, int)>();
            bool stop = false;

            while (!shipPlaced) 
            {
                if ((dir == Directions.Vertical && x + ship.Length > 10) || (dir == Directions.Horizontal && y + ship.Length > 10))
                {
                    Console.WriteLine("Ship does not fit in the given direction.\n");
                    return;
                }

                for (int i = 0; i < ship.Length; i++)
                {
                    if (!BoundsCheck(x) || !BoundsCheck(y))
                    {
                        stop = true;
                        return;
                    }
                    if (board[x][y] == 'S')
                    {
                        Console.WriteLine("Ship overlaps with another ship.\n");
                        stop = true;
                        return;
                    }
                    tempCoordinates.Add((x, y));

                    if (dir == Directions.Vertical)
                    {
                        x++;
                    }
                    else if (dir == Directions.Horizontal)
                    {
                        y++;
                    }
                }
                if (!stop)
                {
                    foreach (var coord in tempCoordinates)
                    {
                        board[coord.Item1][coord.Item2] = 'S';
                    }

                    ship.ShipPosition.AddRange(tempCoordinates);
                    Ships.Add(ship);
                    shipPlaced = true;
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

        static public bool BoundsCheck(int coordinate)
        {
            if ((coordinate < 0) || (coordinate > 10))
            {
                Console.WriteLine("Coordinate out of bounds, try again: \n");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
