using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Ship
    {
        public string Name;
        public int Length;
        public List<(int, int)> ShipPosition;
        public int hits;

        //public Ship(string name, int length)
        //{
        //    Name = name;
        //    Length = length;
        //    ShipPosition = new List<(int, int)>();
        //    hits = 0;
        //}

        public Ship(string name)
        {
            Name = name;

            if (name == "ShortShip")
            {
                Length = 3;
            }
            else if(name == "LongShip")
            {
                Length = 5;
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
