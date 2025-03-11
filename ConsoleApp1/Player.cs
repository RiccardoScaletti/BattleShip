using System;
using System.Collections.Generic;

namespace Battleship
{
    internal class Player
    {
        private Grid grid;
        private Random rand;

        public Player()
        {
            grid = new Grid();
            rand = new Random();
            //PlaceShips();
        }
    }
}
