using System;
using System.Collections.Generic;

namespace Battleship
{
    enum ShipType
    {
       
        Carrier, 
        Battleship, 
        Destroyer, 
        Submarine, 
        PatrolBoat,
        None
    }
    internal class Ship
    {
        public int Length;
        public List<(int, int)> ShipPosition;
        public int hits;

        public Ship(ShipType type)
        {
            switch (type)
            {
                case ShipType.Carrier:
                    Length = 5;
                    break;
                case ShipType.Battleship:
                    Length = 4;
                    break;
                case ShipType.Destroyer:
                    Length = 3;
                    break;
                case ShipType.Submarine:
                    Length = 3;
                    break;
                case ShipType.PatrolBoat:
                    Length = 2;
                    break;
                default:
                    Console.WriteLine("Error, incorrect type of ship");
                    break;
            }
            ShipPosition = new List<(int, int)>();
            hits = 0;   
        }
    }
}
