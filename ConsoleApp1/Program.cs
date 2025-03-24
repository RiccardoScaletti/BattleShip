

namespace Battleship
{
    internal class Program
    {
        static bool aiOn = true;
        static bool stop = false;
        static string? playerMenuInput;
        static int playerMenuInputInt;

        static bool enterPressed = false;
        static bool resetInputIsValid = false;
        static bool reset = true;

        static void Main(string[] args)
        {
            Console.WriteLine("   ___    _  ____________  ___  ___  _ _______ \r\n  / o.) .' \\/_  _/_  _/ / / _/,' _/ /// / / o |\r\n / o \\ / o / / /  / // /_/ _/_\\ `. / ` / / _,' \r\n/___,'/_n_/ /_/  /_//___/___/___,'/_n_/_/_/    ");
            while (reset) 
            {
                while (!enterPressed)
                {
                    Console.WriteLine("Press Enter to start.... \n");
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    if (keyInfo.Key != ConsoleKey.Enter)
                    {
                        Console.WriteLine("Error, press enter!");
                    }
                    else
                    {
                        enterPressed = true;
                    }
                    Console.WriteLine("\n");
                }

                do
                {
                    Console.WriteLine("MAIN MENU: \n 0 = Play against CPU \n 1 = Play against player \n 2 = Options Menu");
                    playerMenuInput = Console.ReadLine();
                    bool isValid = Int32.TryParse(playerMenuInput, out playerMenuInputInt);

                    if (!isValid)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        continue;
                    }
                    else
                    {
                        switch (playerMenuInputInt)
                        {
                            case 0:
                                //setup pve
                                aiOn = true;
                                stop = true;
                                break;
                            case 1:
                                //setup pvp
                                aiOn = false;
                                stop = true;
                                break;
                            case 2:
                                Console.WriteLine("options....");
                                break;
                            default:
                                Console.WriteLine("Wrong input, try again...\n");
                                break;
                        }
                    }
                } while (!stop);

                if (aiOn)
                {

                    Grid aiGrid = new Grid();
                    Grid playerGrid = new Grid();
                    Player player = new Player(playerGrid);
                    Player ai = new Player(aiGrid);

                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("    --AI's Board--");
                        aiGrid.DisplayBoard(true);
                        ai.AddShip(aiGrid, true); //player.AddShip --> grid.PlaceShip --> ship()

                        Console.WriteLine("    --Player Board--");
                        while (player.nShipsPlaced < 5)
                        {
                            Console.WriteLine("    !Player ships!");
                            playerGrid.DisplayBoard(false);
                            player.AddShip(playerGrid, false);
                        }
                        playerGrid.DisplayBoard(false);

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
                    Console.WriteLine("    --AI's Board--");
                    aiGrid.DisplayBoard(false);

                    Console.WriteLine("    --Player Board--");
                    playerGrid.DisplayBoard(false);
                    if (aiGrid.CheckWin())
                    {
                        Console.WriteLine("You win in " + player.shotsFired + " shots!");
                    }
                    if (playerGrid.CheckWin())
                    {
                        Console.WriteLine("AI wins in " + ai.shotsFired + " shots!");
                    }
                    CheckReset();
                }
                else
                {
                    Grid playerGrid = new Grid();
                    Grid player2Grid = new Grid();
                    Player player = new Player(playerGrid);
                    Player player2 = new Player(player2Grid);
                    bool turn = false;
                    bool playersReady = false;

                    while (true)
                    {
                        Console.Clear();

                        //Boards management
                        //P1
                        Console.WriteLine("    --Player 1 Board:--");
                        while (player.nShipsPlaced < 5)
                        {
                            playerGrid.DisplayBoard(false);
                            player.AddShip(playerGrid, false); //player.AddShip --> grid.PlaceShip --> ship()
                        }
                        if (playersReady)
                        {
                            playerGrid.DisplayBoard(true);
                        }

                        //P2
                        Console.WriteLine("    --Player 2 Board:--");
                        while (player2.nShipsPlaced < 5)
                        {
                            player2Grid.DisplayBoard(false);
                            player2.AddShip(player2Grid, false);
                        }
                        playersReady = true;
                        player2Grid.DisplayBoard(true);

                        //Attack management
                        turn = PlayersTurnManager(turn);
                        if (turn)
                        {
                            Console.WriteLine("    --P1 turn!-");
                            player.Attack(player2Grid, false);
                            player.shotsFired++;
                            if (player2Grid.CheckWin())
                            {
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("    --P2 turn!--");
                            player2.Attack(playerGrid, false);
                            player2.shotsFired++;
                            if (playerGrid.CheckWin())
                            {
                                break;
                            }
                        }
                    }

                    //Endgame diplay & conditions
                    Console.Clear();
                    Console.WriteLine("\tPlayer 1 Board:");
                    playerGrid.DisplayBoard(true);

                    Console.WriteLine("\tPlayer 2 Board:");
                    player2Grid.DisplayBoard(true);
                    if (playerGrid.CheckWin())
                    {
                        Console.WriteLine("P1 wins in " + player.shotsFired + " shots!");
                    }
                    if (player2Grid.CheckWin())
                    {
                        Console.WriteLine("P2 wins in " + player2.shotsFired + " shots!");
                    }
                    CheckReset();
                }
            }
           
        }
        static bool PlayersTurnManager(bool turn)
        {
            if (turn) 
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        static void CheckReset()
        {
            resetInputIsValid = false;
            while (!resetInputIsValid)
            {
                Console.WriteLine("Do you want to reset the game?\n 0 = Yes, 1 = Quit");
                string resetInputString = Console.ReadLine();
                int resetInputInt = Int32.Parse(resetInputString);
                if (resetInputInt == 0)
                {
                    resetInputIsValid = true;
                    reset = true;
                }
                else if(resetInputInt == 1)
                {
                    resetInputIsValid = true;
                    reset = false;
                }
                else
                {
                    Console.WriteLine("Wrong input, try again");
                    resetInputIsValid = false;
                }
                Console.WriteLine("\n");
            }
        }
    }
}
