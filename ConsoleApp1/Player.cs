using System;
using System.Collections.Generic;

namespace Battleship
{
    internal class Player
    {
        private Random rand;
        public int shotsFired = 0;

        public Player(Grid grid)
        {
            rand = new Random();
        }

        public void AddShip(Grid grid, bool ai)
        {
            if (ai)
            {
                while (!grid.shipPlaced)
                {
                    Ship aiShip = new Ship();
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
                    Console.WriteLine("ai ship at " + aiShipx + aiShipy + " direction: " + dir);
                }
            }
            else 
            {
                while (!grid.shipPlaced)
                {
                    Console.WriteLine("Let's place ships!\n");

                    Console.WriteLine("insert x");
                    string? inputX = Console.ReadLine();
                    int inputXInt;
                    int.TryParse(inputX, out inputXInt);

                    Console.WriteLine("insert y");
                    string? inputY = Console.ReadLine();
                    int inputYInt;
                    int.TryParse(inputY, out inputYInt);

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
                    }
                    Ship playerShip = new Ship();
                    grid.PlaceShip(playerShip, inputXInt, inputYInt, dirP);
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
                int x;
                int y;

                Console.WriteLine("Time to attack!\n");
                Console.WriteLine("insert x");
                inputTargetX = Console.ReadLine();
                int.TryParse(inputTargetX, out x);
                if (x < 0 || x > 10)
                {
                    Console.WriteLine("coordinate out of bounds, try again");
                    continue;
                }

                Console.WriteLine("insert y");
                inputTargetY = Console.ReadLine();
                int.TryParse(inputTargetY, out y);
                if (y < 0 || y > 10)
                {
                    Console.WriteLine("coordinate out of bounds, try again");
                    continue;
                }

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
        }
    }
}
