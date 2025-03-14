using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace Battleship
{
    internal class Player
    {
        private Random rand;
        private bool[] shipCheck = new bool[5];
        private ShipType currentShipType;
        private int nShipsPlaced = 0;

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
                while (nShipsPlaced < 5)
                {
                    int value = rand.Next(0,5);
                    ShipType aiShiptype = (ShipType)value;
                    Ship aiShip = new Ship(aiShiptype);

                    int aiShipx = rand.Next(0, 10);
                    int aiShipy = rand.Next(0, 10);
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

                    grid.PlaceShip(aiShip, aiShipx, aiShipy, dir);

                    if (grid.shipPlaced)
                    {
                        nShipsPlaced++;
                        Console.WriteLine("ai ship at " + aiShipx + aiShipy + " direction: " + dir);
                    }
                    
                }
            }
            else 
            {
                while (nShipsPlaced < 1)
                {
                    Console.WriteLine("Let's place ships!\n");
                    Console.WriteLine("What type of ship?\n 0 = Carrier, 1 = Battleship, 2 = Cruiser, 3 = Submarine, 4 = Destroyer");
                    string playerShipTypeInput = Console.ReadLine();

                    Console.WriteLine("insert row");
                    string? inputRow = Console.ReadLine();
                    int inputRowInt;
                    int.TryParse(inputRow, out inputRowInt);
                   
                    if (!Grid.BoundsCheck(inputRowInt))
                    {
                        continue;
                    }

                    Console.WriteLine("insert column");
                    string? inputCol = Console.ReadLine();
                    int inputColInt;
                    int.TryParse(inputCol, out inputColInt);
                    if (!Grid.BoundsCheck(inputColInt))
                    {
                        continue;
                    }

                    Console.WriteLine("insert direction: V or H?");
                    string? inputShipDirection = Console.ReadLine();
                    Directions dirP;

                    if (inputShipDirection.Trim() == "V")
                    {
                        dirP = Directions.Vertical;
                    }
                    else if (inputShipDirection.Trim() == "H")
                    {
                        dirP = Directions.Horizontal;
                    }
                    else
                    {
                        dirP = Directions.None;
                        Console.WriteLine("Error, wrong input for direction.\n");
                        continue;
                    }

                    Ship playerShip = new Ship(currentShipType);
                    grid.PlaceShip(playerShip, inputRowInt, inputColInt, dirP);
                    if (grid.shipPlaced)
                    {
                        Int32.TryParse(playerShipTypeInput, out int value);
                        switch (value)
                        {
                            default:
                                Console.WriteLine("Error while assigning ship type");
                                currentShipType = ShipType.None;
                                break;
                            case 0:
                                if (CheckShipPlaced(value)) { continue; }
                                break;
                            case 1:
                                if (CheckShipPlaced(value)) { continue; }
                                break;
                            case 2:
                                if (CheckShipPlaced(value)) { continue; }
                                break;
                            case 3:
                                if (CheckShipPlaced(value)) { continue; }
                                break;
                            case 4:
                                if (CheckShipPlaced(value)) { continue; }
                                break;
                        }
                        nShipsPlaced++;
                    }
                }
            }
        }

        public void Attack(Grid enemyGrid, bool ai)
        {
            bool hasShot = false;
            if (ai) 
            {
                int x = rand.Next(0, 10);
                int y = rand.Next(0, 10);
                Ship enemyShip = enemyGrid.Ships[0];

                if (enemyGrid.board[x][y] == '~')
                {
                    enemyGrid.board[x][y] = 'O';
                    hasShot = true;
                }
                else
                {
                    enemyGrid.board[x][y] = 'X';
                    enemyShip.hits++;
                    hasShot = true;
                }
            }
            while (!hasShot) 
            {
                string? inputTargetX;
                string? inputTargetY;
                int row;
                int col;

                Console.WriteLine("Time to attack!\n");
                Console.WriteLine("insert row");
                inputTargetX = Console.ReadLine();
                int.TryParse(inputTargetX, out row);
                if (!Grid.BoundsCheck(row))
                {
                    continue;
                }

                Console.WriteLine("insert column");
                inputTargetY = Console.ReadLine();
                int.TryParse(inputTargetY, out col);
                if (!Grid.BoundsCheck(col))
                {
                    continue;
                }

                Ship enemyShip = enemyGrid.Ships[0];

                if (enemyGrid.board[row][col] == '~')
                {
                    enemyGrid.board[row][col] = 'O';
                    hasShot = true;
                }
                else if (enemyGrid.board[row][col] == 'O')
                {
                    hasShot = true;
                }
                else
                {
                    enemyGrid.board[row][col] = 'X';
                    enemyShip.hits++;
                    hasShot = true;
                }
            }
        }

        private bool CheckShipPlaced(int value)
        {
            ShipType playerShiptype = (ShipType)value;
            currentShipType = playerShiptype;
            if (!shipCheck[value])
            {
                shipCheck[value] = true; //this ship is now placed
                return false;//return that ship was not placed yet
            }
            else
            {
                Console.WriteLine("ship already placed!");
                return true;
            }
            
        }
    }
}
