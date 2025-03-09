namespace Battleship
{
    internal class Program
    {
        static bool aiOn = false;
        static bool stop = false;
        static string? playerModeInput;
        static void Main(string[] args)
        {
            Grid playerGrid = new Grid();
            Grid enemyGrid = new Grid();

            Console.WriteLine("Press any key to start.... \n");
            Console.ReadKey();
            Console.WriteLine("\n");
            //do
            //{
            //    Console.WriteLine("do You want to play against AI or Player? \n A = Ai, P = player");
            //    playerModeInput = Console.ReadLine();
            //    if (playerModeInput == "A")
            //    {
            //        aiOn = true;
            //        stop = true;
            //    }
            //    else if (playerModeInput == "P")
            //    {
            //        aiOn = false;
            //        stop = true;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Wrong input, try again...\n");
            //    }
            //}while(!stop);

            DiplayBoard(playerGrid, enemyGrid);

        }

        static void DiplayBoard(Grid pg, Grid eg)
        {
            Console.WriteLine("\tPlayer Grid");
            eg.InitializeGrid();
            eg.FillGrid();
            eg.DisplayGrid();

            Console.WriteLine("\tEnemy Grid");
            pg.InitializeGrid();
            pg.FillGrid();
            pg.DisplayGrid();
        }
    }
}
