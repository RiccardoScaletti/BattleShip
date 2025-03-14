using System;
using System.Collections.Generic;

namespace Battleship
{
    enum ShipType
    {
       
        Carrier, 
        Battleship, 
        Cruiser, 
        Submarine, 
        Destroyer,
        None
    }
    //Carrier(occupies 5 spaces), Battleship(4), Cruiser(3), Submarine(3), and Destroyer(2)
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
                case ShipType.Cruiser:
                    Length = 3;
                    break;
                case ShipType.Submarine:
                    Length = 3;
                    break;
                case ShipType.Destroyer:
                    Length = 2;
                    break;
                default:
                    Console.WriteLine("Error, incorrect type of ship");
                    break;
            }
            ShipPosition = new List<(int, int)>();
            hits = 0;   
        }

        public bool IsSunk()
        {
            return hits >= Length;
        }
    }
}
