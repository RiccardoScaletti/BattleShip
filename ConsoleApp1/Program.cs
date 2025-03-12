using System.Numerics;
using System.Runtime.InteropServices.JavaScript;

namespace Battleship
{
    internal class Program
    {
        static bool aiOn = true;
        static bool stop = false;
        static string? playerModeInput;

        static string? inputX;
        static int inputXInt;
        static string? inputY;
        static int inputYInt;
        static string? inputShipDirection;
        static Random random = new Random();

        static int shots = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start.... \n");
            Console.ReadKey();
            Console.WriteLine("\n");

            Grid aiGrid = new Grid();
            Grid playerGrid = new Grid();
            Player player = new Player(playerGrid);
            Player ai = new Player(aiGrid);

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

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\tAI's Board:");
                aiGrid.DisplayBoard(false);
                ai.AddShip(aiGrid, true);

                Console.WriteLine("\tPlayer Board:");
                playerGrid.DisplayBoard(false);
                ai.AddShip(playerGrid, false);

                //attack management
                player.Attack(aiGrid, false);
                player.shotsFired++;
                if (aiGrid.CheckWin())
                {
                    break;
                }

                ai.Attack(playerGrid, true);
                ai.shotsFired++;
                if (playerGrid.CheckWin())
                {
                    break;
                }
            }
            //Endgame diplay
            Console.Clear();
            Console.WriteLine("\tAI's Board:");
            aiGrid.DisplayBoard(false);

            Console.WriteLine("\tPlayer Board:");
            playerGrid.DisplayBoard(false);
            if (aiGrid.CheckWin())
            {
                Console.WriteLine("You win in " + player.shotsFired + " shots!");
            }
            if (playerGrid.CheckWin())
            {
                Console.WriteLine("AI wins in " + ai.shotsFired + " shots!");
            }
        }
    }
}
