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
        string[][] grid = new string[11][];

        Grid()
        {

        }
        public void InitializeGrid()
        {
            for (int i = 0; i < grid.Length; i++)
            {
                grid[i] = new string[grid.Length];
            }

            grid[0][0] = "0";

            for (int i = 1; i < grid.Length; i++)
            {
                grid[0][i] = i.ToString();
                grid[i][0] = i.ToString();
            }

            for (int row = 1; row < grid.Length; row++)
            {
                for (int col = 1; col < grid.Length; col++)
                {
                    grid[row][col] = "";
                }
            }
        }

        public void FillGrid()
        {
            for (int row = 1; row < grid.Length; row++)
            {
                for (int col = 1; col < grid.Length; col++)
                {
                    if (grid[row][col] == "")
                    {
                        grid[row][col] = ('~').ToString();
                    }
                }
            }
        }

        public void DisplayGrid()
        { 
            for (int row = 0; row < grid.Length; row++)
            {
                for (int col = 0; col < grid.Length; col++)
                {
                    Console.Write(grid[row][col].PadRight(3));
                }
                Console.WriteLine();
            }
        }

        public void PlaveShip(int x, int y)
        {

        }
    }
}
