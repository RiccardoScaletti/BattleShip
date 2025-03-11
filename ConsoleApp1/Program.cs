using System.Numerics;
using System.Runtime.InteropServices.JavaScript;

namespace Battleship
{
    internal class Program
    {
        static bool aiOn = false;
        static bool stop = false;
        static string? playerModeInput;

        static string inputX;
        static int inputXInt;
        static string inputY;
        static int inputYInt;
        static string inputShipName;

        static void Main(string[] args)
        {
            Console.WriteLine("Press any key to start.... \n");
            Console.ReadKey();
            Console.WriteLine("\n");

            Grid aiGrid = new Grid();
            Grid playerGrid = new Grid();
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

                Console.WriteLine("\tPlayer Board:");
                playerGrid.DisplayBoard(false);
                Console.WriteLine("Let's place ships!\n");
                Console.WriteLine("inter name of the ship\n");
                inputShipName = Console.ReadLine();
                Console.WriteLine("inter x\n");
                inputX = Console.ReadLine();
                inputXInt = int.Parse(inputX);
                Console.WriteLine("inser y\n");
                inputY = Console.ReadLine();
                inputYInt = int.Parse(inputY);
                //player.Attack(aiGrid);

                //shots++;
                if (aiGrid.CheckWin())
                {
                    //Console.WriteLine("You win in " + shots + " shots!");
                    break;
                }
                //ai.Attack(playerGrid);
                if (playerGrid.CheckWin())
                {
                    Console.WriteLine("AI wins!");
                    break;
                }
            }


        }
    }
}
