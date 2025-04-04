﻿using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Battleship
{
    internal class Player
    {
        private Random rand;
        private bool[] shipCheck = new bool[Grid.nOfShipToPlace];
        private ShipType currentShipType;
        public int nShipsPlaced = 0;
        public int shotsFired = 0;

        public Player(Grid grid)
        {
            rand = new Random();
            for (int i = 0; i < shipCheck.Length; i++)
            {
                shipCheck[i] = false;
            }
        }
        public void AddShip(Grid grid, bool ai)
        {
            if (ai)
            {
                if (!Program.onlyPatrolsOption)
                {
                    int currentShipType = 0;
                    while (nShipsPlaced < Grid.nOfShipToPlace)
                    {
                        ShipType aiShiptype = (ShipType)currentShipType;
                        Ship aiShip = new Ship(aiShiptype);

                        //row will be passed as a string to place the ship
                        char randomLetter = (char)('A' + rand.Next(0, 10));
                        string aiShipRow = randomLetter.ToString();

                        //row is gonna be directly an Int
                        int aiShipCol = rand.Next(0, 10);

                        Directions dir;
                        int rndDir = rand.Next(0, 2);
                        if (rndDir == 0)
                        {
                            dir = Directions.Vertical;
                        }
                        else
                        {
                            dir = Directions.Horizontal;
                        }

                        grid.PlaceShip(aiShip, aiShipRow, aiShipCol, dir, true);

                        if (grid.shipPlaced)
                        {
                            nShipsPlaced++;
                            currentShipType++;
                            //Console.WriteLine("ai ship at " + aiShipx + aiShipy + " direction: " + dir);
                        }

                    }
                }
                else
                {
                    int currentShipType = 4;
                    while (nShipsPlaced < Grid.nOfShipToPlace)
                    {
                        ShipType aiShiptype = (ShipType)currentShipType;
                        Ship aiShip = new Ship(aiShiptype);

                        //row will be passed as a string to place the ship
                        char randomLetter = (char)('A' + rand.Next(0, 10));
                        string aiShipRow = randomLetter.ToString();

                        //row is gonna be directly an Int
                        int aiShipCol = rand.Next(0, 10);

                        Directions dir;
                        int rndDir = rand.Next(0, 2);
                        if (rndDir == 0)
                        {
                            dir = Directions.Vertical;
                        }
                        else
                        {
                            dir = Directions.Horizontal;
                        }

                        grid.PlaceShip(aiShip, aiShipRow, aiShipCol, dir, true);

                        if (grid.shipPlaced)
                        {
                            nShipsPlaced++;
                            //Console.WriteLine("ai ship at " + aiShipx + aiShipy + " direction: " + dir);
                        }

                    }
                }
                
            }
            else //if it's a player
            {
                ShipType playerShiptype;
                Console.WriteLine("\nLet's place ship n: " + (nShipsPlaced + 1));
                string? playerShipTypeInput;
                int playerShipTypeInt = 4;
                bool isValid;
                if (!Program.onlyPatrolsOption)
                {
                    Console.WriteLine("What type of ship?\n 0 = Carrier (5 tiles), 1 = Battleship (4 tiles), 2 = Destroyer (3 tiles), 3 = Submarine (3 tiles), 4 = Patrol Boat(2 tiles)");
                    playerShipTypeInput = Console.ReadLine();
                    isValid = Int32.TryParse(playerShipTypeInput, out int tempInt);
                    playerShipTypeInt = tempInt;
                    if (!isValid || playerShipTypeInt < 0 || playerShipTypeInt > 4)
                    {
                        Console.WriteLine("Wrong ship input, try again:");
                        return;
                    }
                    else
                    {
                        playerShiptype = (ShipType)playerShipTypeInt;
                    }

                    if ((CheckShipPlaced(playerShiptype))) //if ship is already placed...
                    {
                        return;
                    }
                }
                else
                {
                    Console.WriteLine("Only Patrol Boats!");
                    playerShiptype = ShipType.PatrolBoat;
                }

                Console.WriteLine("insert row");
                string? inputRow = Console.ReadLine();
                int row = LetterToRow(inputRow);
                if (row == -1)
                {
                    return;
                }

                Console.WriteLine("insert column");
                string? inputCol = Console.ReadLine();
                int inputColInt;
                isValid = int.TryParse(inputCol, out inputColInt);
                if (!isValid)
                {
                    Console.WriteLine("Input is not a number, try again...");
                    return;
                }
                else if (!Grid.BoundsCheck(inputColInt))
                {
                    return;
                }

                Console.WriteLine("insert direction: V or H?");
                string? inputShipDirection = Console.ReadLine().ToUpper();
                Directions dir;

                if (inputShipDirection.Trim() == "V")
                {
                    dir = Directions.Vertical;
                }
                else if (inputShipDirection.Trim() == "H")
                {
                    dir = Directions.Horizontal;
                }
                else
                {
                    dir = Directions.None;
                    Console.WriteLine("Error, wrong input for direction.\n");
                    return;
                }

                Ship playerShip = new Ship(playerShiptype);
                grid.PlaceShip(playerShip, inputRow, inputColInt, dir, false);
                if (grid.shipPlaced)
                {
                    nShipsPlaced++;
                    if (!Program.onlyPatrolsOption)
                    {
                        shipCheck[playerShipTypeInt] = true; //ship is successfully placed
                    }
                    Console.Clear();
                }
            }
        }
        public void Attack(Grid enemyGrid, bool ai)
        {
            bool hasShot = false;

            if (ai)
            {
                while (!hasShot)
                {
                    int row = rand.Next(0, 10);
                    int col = rand.Next(0, 10);

                    if (enemyGrid.board[row][col] == '~')
                    {
                        enemyGrid.board[row][col] = 'O';
                        hasShot = true;
                    }
                    else if (enemyGrid.board[row][col] == 'S')
                    {
                        enemyGrid.board[row][col] = 'X';
                        enemyGrid.hitsTaken++;
                        hasShot = true;
                    }
                    else
                    {
                        //Already shot
                        hasShot = false;
                    }
                }
            }
            else
            {
                while (!hasShot)
                {
                    string? inputTargetRow;
                    string? inputTargetCol;
                    int row;
                    int col;

                    Console.WriteLine("\nTime to attack!");
                    Console.WriteLine("insert row");
                    inputTargetRow = Console.ReadLine();
                    //bool isValid = Int32.TryParse(inputTargetRow, out row);
                    row = LetterToRow(inputTargetRow);
                    if (row == -1)
                    {
                        continue;
                    }

                    Console.WriteLine("insert column");
                    inputTargetCol = Console.ReadLine();
                    bool isValid = int.TryParse(inputTargetCol, out col);
                    if (!isValid)
                    {
                        Console.WriteLine("Input is a letter, try again...");
                        continue;
                    }
                    else if (!Grid.BoundsCheck(col))
                    {
                        continue;
                    }

                    if (enemyGrid.board[row][col] == '~')
                    {
                        enemyGrid.board[row][col] = 'O';
                        hasShot = true;
                    }
                    else if (enemyGrid.board[row][col] == 'S')
                    {
                        enemyGrid.board[row][col] = 'X';
                        enemyGrid.hitsTaken++;
                        hasShot = true;
                    }
                    else
                    {
                        Console.WriteLine("Already shot in that postion, try again:");
                        hasShot = false;
                    }
                }
            }
        }

        private bool CheckShipPlaced(ShipType type)
        {
            int value = (int)type;
            if (!shipCheck[value])
            {
                return false;//return that ship was not placed yet
            }
            else
            {
                Console.WriteLine("ship already placed!");
                return true;
            }
        }

        public static int LetterToRow(string letter)
        {
            char rowLetter = char.ToUpper(letter[0]);

            // A = 65 --> 65-65 = 0. B = 66...
            int rowIndex = rowLetter - 'A';

            if (!Grid.BoundsCheck(rowIndex))
            {
                return -1;
            }

            return rowIndex;
        }

        
    }
}
