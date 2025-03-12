using System;
using System.Collections.Generic;

namespace Battleship
{
    internal class Ship
    {
        public int Length;
        public List<(int, int)> ShipPosition;
        public int hits;

        public Ship()
        {
            Length = 3;
            ShipPosition = new List<(int, int)>();
            hits = 0;   
        }

        public bool IsSunk()
        {
            return hits >= Length;
        }
    }
}
