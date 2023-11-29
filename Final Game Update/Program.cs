using System;
using System.Diagnostics;
using System.Net.Security;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading.Tasks.Sources;

class Program
{
    static void Main(string[] args)
    {
        string vert, horiz, movement = "", location = "", treasure = "", hazard = "", hazard1 = "", pa = "Y", randv, randh, random, movementH, movementH1, Direct, A1, A2, A3, B1, B2, B3, C1, C2, C3, key;
        int level = 1, x, y, lives = 3, score, time;
        bool increase, playing;
        char[] charArray, charArray1, charArray2;
        ConsoleKeyInfo keyInfo;
        Console.WriteLine("Instructions ");
        Console.WriteLine("--------------------------------------------");
        Console.Write("-Navigate to the ");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.Write("Treasure ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write("while avoiding barriers and ");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.Write("deadly ghosts ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.WriteLine("which can pass through walls, the treasure, and even each other.");
        Console.WriteLine("");
        Console.WriteLine("-You are given 3 lives total");
        Console.WriteLine("");
        Console.WriteLine("-Each time you lose a life, you restart the current level");
        Console.WriteLine("");
        Console.WriteLine("-If you lose all 3 lives, you will be forced to start over");
        Console.WriteLine("");
        Console.ForegroundColor = ConsoleColor.DarkGreen;
        Console.Write("-Score ");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("is calculated by speed and lives remaining");
        Console.WriteLine("");
        Console.WriteLine("Press Enter to see map key");
        Console.ReadLine();
        Console.Clear();
        Console.WriteLine("KEY");
        Console.WriteLine("---------------------------------------------------");
        Console.WriteLine("X - You");
        Console.WriteLine("/ - Barrier");
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("* - Treasure");
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("! - Deadly Ghosts");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("");
        Console.WriteLine("Press enter when you think you're ready");
        Console.ReadLine();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        //constants
        Random res = new Random();
        vert = "123.ToString())";
        horiz = "abc";
        random = "";
        do
        {
            //Level 1 additions
            if (level >= 1)
            {
                //player starting random
                x = res.Next(3);
                y = res.Next(3);
                randv = random + vert[x];
                randh = random + horiz[y];
                location = randh.ToUpper() + randv;

                //treasure starting random
                do
                {
                    x = res.Next(3);
                    y = res.Next(3);
                    randv = random + vert[x];
                    randh = random + horiz[y];
                    treasure = randh.ToUpper() + randv;
                } while (treasure == location);
            }

            //Level 3 additions
            if (level >= 3)
            {
                do
                {
                    x = res.Next(3);
                    y = res.Next(3);
                    randv = random + vert[x];
                    randh = random + horiz[y];
                    hazard = randh.ToUpper() + randv;
                } while (hazard == location || hazard == treasure);
        }

            //Level 4 additions
            if (level >= 4)
            {

                do
                {
                    x = res.Next(3);
                    y = res.Next(3);
                    randv = random + vert[x];
                    randh = random + horiz[y];
                    hazard1 = randh.ToUpper() + randv;
                } while (hazard1 == location || hazard1 == hazard || hazard1 == treasure);
            }

            //Playing game
            increase = false;
            playing = true;
            while (playing == true)
            {
                Console.Clear();
                Console.WriteLine("level: " + level);
                Console.WriteLine("Remaining Lives: " + lives);
                charArray = location.ToCharArray();
                charArray1 = hazard.ToCharArray();
                charArray2 = hazard1.ToCharArray();
                if (treasure == "A1")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    A1 = "*";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (hazard == "A1" || hazard1 == "A1")
                {
                    A1 = "!";
                }
                else if (location == "A1")
                {
                    A1 = "X";
                }
                else
                {
                    A1 = "_";
                }
                if (treasure == "A2")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    A2 = "*";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (hazard == "A2" || hazard1 == "A2")
                {
                    A2 = "!";
                }
                else if (location == "A2")
                {
                    A2 = "X";
                }
                else
                {
                    A2 = "_";
                }
                if (treasure == "A3")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    A3 = "*";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (hazard == "A3" || hazard1 == "A3")
                {
                    A3 = "!";
                }
                else if (location == "A3")
                {
                    A3 = "X";
                }
                else
                {
                    A3 = "_";
                }
                if (treasure == "C1")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    C1 = "*";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (hazard == "C1" || hazard1 == "C1")
                {
                    C1 = "!";
                }
                else if (location == "C1")
                {
                    C1 = "X";
                }
                else
                {
                    C1 = "_";
                }
                if (treasure == "C2")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    C2 = "*";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (hazard == "C2" || hazard1 == "C2")
                {
                    C2 = "!";
                }
                else if (location == "C2")
                {
                    C2 = "X";
                }
                else
                {
                    C2 = "_";
                }
                if (treasure == "C3")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    C3 = "*";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (hazard == "C3" || hazard1 == "C3")
                {
                    C3 = "!";
                }
                else if (location == "C3")
                {
                    C3 = "X";
                }
                else
                {
                    C3 = "_";
                }
                if (treasure == "B1")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    B1 = "*";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (hazard == "B1" || hazard1 == "B1")
                {
                    B1 = "!";
                }
                else if (location == "B1")
                {
                    B1 = "X";
                }
                else
                {
                    B1 = "_";
                }
                if (treasure == "B2")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    B2 = "*";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (hazard == "B2" || hazard1 == "B2")
                {
                    B2 = "!";
                }
                else if (location == "B2")
                {
                    B2 = "X";
                }
                else
                {
                    B2 = "_";
                }
                if (treasure == "B3")
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    B3 = "*";
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (hazard == "B3" || hazard1 == "B3")
                {
                    B3 = "!";
                }
                else if (location == "B3")
                {
                    B3 = "X";
                }
                else
                {
                    B3 = "_";
                }

                //Level 1
                if (level != 2 && level != 5)
                {
                    //map layout
                    Console.WriteLine(" --------- --------- --------- ");
                    Console.WriteLine("|         |         |         |");
                    Console.WriteLine("|    " + A1 + "    |    " + A2 + "    |    " + A3 + "    |");
                    Console.WriteLine("|         |         |         |");
                    Console.WriteLine("|--------- --------- ---------");
                    Console.WriteLine("|         |         |         |");
                    Console.WriteLine("|    " + B1 + "    |    " + B2 + "    |    " + B3 + "    |");
                    Console.WriteLine("|         |         |         |");
                    Console.WriteLine(" --------- --------- ---------");
                    Console.WriteLine("|         |         |         |");
                    Console.WriteLine("|    " + C1 + "    |    " + C2 + "    |    " + C3 + "    |");
                    Console.WriteLine("|         |         |         |");
                    Console.WriteLine(" --------- --------- ---------");
                    //movement
                    //arrow key input
                    keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            movement = "UP";
                            PerformEnter();
                            break;
                        case ConsoleKey.DownArrow:
                            movement = "DOWN";
                            PerformEnter();
                            break;
                        case ConsoleKey.LeftArrow:
                            movement = "LEFT";
                            PerformEnter();
                            break;
                        case ConsoleKey.RightArrow:
                            movement = "RIGHT";
                            PerformEnter();
                            break;
                    }
                    static void PerformEnter()
                    {
                        Console.Write("\r\n"); // Send a carriage return (Enter key)
                    }
                    if (movement == "UP")
                    {
                        if (charArray[0] == 'A')
                        {
                            Console.WriteLine("You've hit a wall. Try again.");
                        }
                        else if (charArray[0] == 'B')
                        {
                            charArray[0] = 'A';
                        }

                        else if (charArray[0] == 'C')
                        {
                            charArray[0] = 'B';
                        }
                    }
                    else if (movement == "DOWN")
                    {
                        if (charArray[0] == 'A')
                        {
                            charArray[0] = 'B';
                        }
                        else if (charArray[0] == 'B')
                        {
                            charArray[0] = 'C';
                        }

                        else if (charArray[0] == 'C')
                        {
                            Console.WriteLine("You've hit a wall. Try again.");
                        }
                    }
                    else if (movement == "RIGHT")
                    {
                        if (charArray[1] == '1')
                        {
                            charArray[1] = '2';
                        }
                        else if (charArray[1] == '2')
                        {
                            charArray[1] = '3';
                        }

                        else if (charArray[1] == '3')
                        {
                            Console.WriteLine("You've hit a wall. Try again.");
                        }
                    }
                    else if (movement == "LEFT")
                    {
                        if (charArray[1] == '1')
                        {
                            Console.WriteLine("You've hit a wall. Try again.");
                        }
                        else if (charArray[1] == '2')
                        {
                            charArray[1] = '1';
                        }

                        else if (charArray[1] == '3')
                        {
                            charArray[1] = '2';
                        }
                    }
                    location = new string(charArray);
                }

                //Level 2
                if (level == 2)
                {
                    //map layout
                    Console.WriteLine(" --------- --------- --------- ");
                    Console.WriteLine("|         /         |         |");
                    Console.WriteLine("|    " + A1 + "    /    " + A2 + "    |    " + A3 + "    |");
                    Console.WriteLine("|         /         |         |");
                    Console.WriteLine("|--------- ///////// ---------");
                    Console.WriteLine("|         |         |         |");
                    Console.WriteLine("|    " + B1 + "    |    " + B2 + "    |    " + B3 + "    |");
                    Console.WriteLine("|         |         |         |");
                    Console.WriteLine(" --------- --------- /////////");
                    Console.WriteLine("|         /         |         |");
                    Console.WriteLine("|    " + C1 + "    /    " + C2 + "    |    " + C3 + "    |");
                    Console.WriteLine("|         /         |         |");
                    Console.WriteLine(" --------- --------- ---------");
                    //arrow key input
                    keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            movement = "UP";
                            PerformEnter();
                            break;
                        case ConsoleKey.DownArrow:
                            movement = "DOWN";
                            PerformEnter();
                            break;
                        case ConsoleKey.LeftArrow:
                            movement = "left";
                            PerformEnter();
                            break;
                        case ConsoleKey.RightArrow:
                            movement = "right";
                            PerformEnter();
                            break;
                    }
                    static void PerformEnter()
                    {
                        Console.Write("\r\n"); // Send a carriage return (Enter key)
                    }
                    //player movement up and down
                    if (movement.ToUpper() == "UP")
                    {
                        if (charArray[0] == 'A' || location == "B2" || location == "C3")
                        {
                            Console.WriteLine("You've hit a wall. Try again.");
                        }
                        else if (charArray[0] == 'B')
                        {
                            charArray[0] = 'A';
                        }

                        else if (charArray[0] == 'C')
                        {
                            charArray[0] = 'B';
                        }
                    }
                    else if (movement.ToUpper() == "DOWN")
                    {
                        if (charArray[0] == 'C' || location == "A2" || location == "B3")
                        {
                            Console.WriteLine("You've hit a wall. Try again.");
                        }
                        else if (charArray[0] == 'A')
                        {
                            charArray[0] = 'B';
                        }
                        else if (charArray[0] == 'B')
                        {
                            charArray[0] = 'C';
                        }
                    }

                    //player movement Right and Left
                    else if (movement.ToUpper() == "RIGHT")
                    {
                        if (charArray[1] == '3' || location == "A1" || location == "C1")
                        {
                            Console.WriteLine("You've hit a wall. Try again.");
                        }
                        else if (charArray[1] == '1')
                        {
                            charArray[1] = '2';
                        }
                        else if (charArray[1] == '2')
                        {
                            charArray[1] = '3';
                        }
                    }
                    else if (movement.ToUpper() == "LEFT")
                    {
                        if (charArray[1] == '1' || location == "A2" || location == "C2")
                        {
                            Console.WriteLine("You've hit a wall. Try again.");
                        }
                        else if (charArray[1] == '2')
                        {
                            charArray[1] = '1';
                        }

                        else if (charArray[1] == '3')
                        {
                            charArray[1] = '2';
                        }
                    }
                    location = new string(charArray);
                }

                //Level 3
                if (level >= 3)
                {
                    //First hazard movement
                    Direct = "1234.ToString";
                    int z = res.Next(4);
                    movementH = random + Direct[z];

                    if (movementH.ToUpper() == "1")
                    {
                        if (charArray1[0] == 'A')
                        {
                        }
                        else if (charArray1[0] == 'B')
                        {
                            charArray1[0] = 'A';
                        }

                        else if (charArray1[0] == 'C')
                        {
                            charArray1[0] = 'B';
                        }
                    }
                    else if (movementH.ToUpper() == "2")
                    {
                        if (charArray1[0] == 'A')
                        {
                            charArray1[0] = 'B';
                        }
                        else if (charArray1[0] == 'B')
                        {
                            charArray1[0] = 'C';
                        }
                    }
                    //Right and Left
                    else if (movementH.ToUpper() == "3")
                    {
                        if (charArray1[1] == '1')
                        {
                            charArray1[1] = '2';
                        }
                        else if (charArray1[1] == '2')
                        {
                            charArray1[1] = '3';
                        }

                    }
                    else if (movementH.ToUpper() == "4")
                    {
                        if (charArray1[1] == '2')
                        {
                            charArray1[1] = '1';
                        }

                        else if (charArray1[1] == '3')
                        {
                            charArray1[1] = '2';
                        }
                    }
                    hazard = new string(charArray1);
                }

                //Level 4
                if (level >= 4)
                {
                    //second hazard movement
                    string Direct1 = "1234.ToString";
                    int u = res.Next(4);
                    movementH1 = random + Direct1[u];
                    if (movementH1.ToUpper() == "1")
                    {
                        if (charArray2[0] == 'A')
                        {
                        }
                        else if (charArray2[0] == 'B')
                        {
                            charArray2[0] = 'A';
                        }

                        else if (charArray2[0] == 'C')
                        {
                            charArray2[0] = 'B';
                        }
                    }
                    else if (movementH1.ToUpper() == "2")
                    {
                        if (charArray2[0] == 'A')
                        {
                            charArray2[0] = 'B';
                        }
                        else if (charArray2[0] == 'B')
                        {
                            charArray2[0] = 'C';
                        }
                    }
                    //Right and Left
                    else if (movementH1.ToUpper() == "3")
                    {
                        if (charArray2[1] == '1')
                        {
                            charArray2[1] = '2';
                        }
                        else if (charArray2[1] == '2')
                        {
                            charArray2[1] = '3';
                        }

                    }
                    else if (movementH1.ToUpper() == "4")
                    {
                        if (charArray2[1] == '2')
                        {
                            charArray2[1] = '1';
                        }

                        else if (charArray2[1] == '3')
                        {
                            charArray2[1] = '2';
                        }
                    }
                    hazard1 = new string(charArray2);
                }

                //Level 5
                if (level == 5)
                {
                    //map layout
                    Console.WriteLine(" --------- --------- --------- ");
                    Console.WriteLine("|         /         /         |");
                    Console.WriteLine("|    " + A1 + "    /    " + A2 + "    /    " + A3 + "    |");
                    Console.WriteLine("|         /         /         |");
                    Console.WriteLine("|--------- --------- ---------");
                    Console.WriteLine("|         |         |         |");
                    Console.WriteLine("|    " + B1 + "    |    " + B2 + "    |    " + B3 + "    |");
                    Console.WriteLine("|         |         |         |");
                    Console.WriteLine(" --------- --------- /////////");
                    Console.WriteLine("|         |         |         |");
                    Console.WriteLine("|    " + C1 + "    |    " + C2 + "    |    " + C3 + "    |");
                    Console.WriteLine("|         |         |         |");
                    Console.WriteLine(" --------- --------- ---------");
                    //movement
                    //arrow key input
                    keyInfo = Console.ReadKey(true);
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            movement = "UP";
                            PerformEnter();
                            break;
                        case ConsoleKey.DownArrow:
                            movement = "DOWN";
                            PerformEnter();
                            break;
                        case ConsoleKey.LeftArrow:
                            movement = "left";
                            PerformEnter();
                            break;
                        case ConsoleKey.RightArrow:
                            movement = "right";
                            PerformEnter();
                            break;
                    }
                    static void PerformEnter()
                    {
                        Console.Write("\r\n"); // Send a carriage return (Enter key)
                    }
                    if (movement.ToUpper() == "UP")
                    {
                        if (charArray[0] == 'A' || location == "C3")
                        {
                            Console.WriteLine("You've hit a wall. Try again.");
                        }
                        else if (charArray[0] == 'B')
                        {
                            charArray[0] = 'A';
                        }

                        else if (charArray[0] == 'C')
                        {
                            charArray[0] = 'B';
                        }
                    }
                    else if (movement.ToUpper() == "DOWN")
                    {
                        if (charArray[0] == 'C' || location == "B3")
                        {
                            Console.WriteLine("You've hit a wall. Try again.");
                        }
                        else if (charArray[0] == 'A')
                        {
                            charArray[0] = 'B';
                        }
                        else if (charArray[0] == 'B')
                        {
                            charArray[0] = 'C';
                        }
                    }

                    //player movement Right and Left
                    else if (movement.ToUpper() == "RIGHT")
                    {
                        if (charArray[1] == '3' || location == "A1" || location == "A2")
                        {
                            Console.WriteLine("You've hit a wall. Try again.");
                        }
                        else if (charArray[1] == '1')
                        {
                            charArray[1] = '2';
                        }
                        else if (charArray[1] == '2')
                        {
                            charArray[1] = '3';
                        }
                    }
                    else if (movement.ToUpper() == "LEFT")
                    {
                        if (charArray[1] == '1' || location == "A2" || location == "A3")
                        {
                            Console.WriteLine("You've hit a wall. Try again.");
                        }
                        else if (charArray[1] == '2')
                        {
                            charArray[1] = '1';
                        }

                        else if (charArray[1] == '3')
                        {
                            charArray[1] = '2';
                        }
                    }
                    location = new string(charArray);
                }

                //Lose Conditions
                if (location == hazard || location == hazard1)
                {
                    lives -= 1;
                    if (lives > 0)
                    {
                        Console.WriteLine("You lost 1 life");
                        Console.WriteLine("Remaining: " + lives);
                        Console.WriteLine("Press enter to continue");
                        Console.ReadLine();
                        increase = true;
                        playing = false;
                    }
                    else
                    {
                        Console.WriteLine("You have 0 lives remaining, You lose.");
                        Console.WriteLine("Play again? Y/N");
                        pa = Console.ReadLine();
                        if (pa.ToUpper() == "Y")
                        {
                            hazard = "";
                            hazard1 = "";
                            increase = true;
                            level = 1;
                            lives = 3;
                        }
                        else if (pa.ToUpper() == "N")
                        {
                            Console.WriteLine("Thanks for playing!");
                            Environment.Exit(0);
                        }
                    }
                }

                //Win Condition
                else if (treasure == location)
                {
                    if (level < 5)
                    {
                        level++;
                        Console.WriteLine("Congratulations, you move on to level " + level);
                        increase = true;
                        playing = false;
                    }
                    else
                    {
                        stopwatch.Stop();
                        time = (int)stopwatch.Elapsed.TotalSeconds;
                        score = 7000 + 1000 * lives - 100 * time;
                        Console.WriteLine("YOU WIN!!!");
                        Console.WriteLine("Your score was " + score);
                        Console.WriteLine("Play again? Y/N");
                        pa = Console.ReadLine();
                        if (pa.ToUpper() == "Y")
                        {
                            hazard = "";
                            hazard1 = "";
                            increase = true;
                            level = 1;
                            lives = 3;
                        }
                        else if (pa.ToUpper() == "N")
                        {
                            Console.WriteLine("Thanks for playing!");
                            Environment.Exit(0);
                        }
                    }
                }
        }
        } while (increase == true);
    }
}