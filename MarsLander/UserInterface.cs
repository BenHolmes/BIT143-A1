using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsLander
{
    class UserInterface
    {
        public void PrintGreeting()
        {
            Console.WriteLine("Welcome to the Mars Lander game!");
        }

        public void PrintLocation( MarsLander lander)
        {
            int height;
            if (lander.getHeight() <= 1000)
            {
                height = 1000;
            }
            else
            {
                height = lander.getHeight();
            }

            for (int i = 0; i < lander.getHeight(); i++)
            {
                if (height < 0)
                {
                    break;
                }
                else if (height / 100 == lander.getHeight() / 100)
                {
                    Console.WriteLine("{0}m: *", height);
                    height -= 100;
                }
                else
                {
                    Console.WriteLine("{0}m: ", height);
                    height -= 100;
                }
            }
            Console.WriteLine();
        }

        public void PrintLanderInfo( MarsLander lander)
        {
            Console.WriteLine("Exact height: {0} meters", lander.getHeight());
            Console.WriteLine("Current (downward) speed: {0} meters/second", lander.getSpeed());
            Console.WriteLine("Fuel points left: {0}", lander.getFuel());
            Console.WriteLine();
        }

        public int GetFuelToBurn(MarsLander lander)
        {
            bool errorDone = true;
            string szInput;
            int userNum;

            while (errorDone == true)
            {
                Console.WriteLine("How many points of fuel would you like to burn?");
                szInput = Console.ReadLine();
                Int32.TryParse(szInput, out userNum);

                if (Int32.TryParse(szInput, out userNum) == true)
                {
                    if (userNum < 0)
                    {
                        Console.WriteLine("You can't burn less than 0 points of fuel!");
                        Console.WriteLine();
                        Console.WriteLine("Just as a reminder, here's where the lander is: ");
                        PrintLanderInfo(lander);
                        continue;
                    }
                    else if (userNum > lander.getFuel())
                    {
                        Console.WriteLine("You don't have {0} points of fuel!", userNum);
                        Console.WriteLine();
                        Console.WriteLine("Just as a reminder, here's where the lander is: ");
                        PrintLanderInfo(lander);
                        continue;
                    }
                    else
                    {
                        errorDone = false;
                        return userNum;
                    }
                        
                }
                else
                {
                    Console.WriteLine("You need to type a whole number of fuel points to burn!");
                    Console.WriteLine();
                    Console.WriteLine("Just as a reminder, here's where the lander is: ");
                    PrintLanderInfo(lander);
                    continue;
                }
            }
            return -1;// yeah?
        }

        public void PrintEndOfGameResult(MarsLander ml, int maxSpeed)
        {
            int finalSpeed = ml.getSpeed();

            if (finalSpeed <= maxSpeed)
            {
                Console.WriteLine("Congratulations!! You've successfully landed your Mars Lander, without crashing!!!");
            }
            else
                Console.WriteLine("The maximum speed for a safe landing is {0}; your lander's current speed is {1} /n You have crashed the lander into the surface of Mars, killing everyone on board,/n costing NASA millions of dollars, and setting the space program back by decades!", maxSpeed, finalSpeed);

            Console.WriteLine("Here's the height/speed info for you:");
            PrintHistory(ml.GetHistory());
        }
        
        public void PrintHistory(MarsLanderHistory mlh)
        {
            Console.WriteLine("Round #\t\tHeight (in m)\t\tSpeed (downwards, in m/s)");
            for (int i = 0; i < mlh.NumberOfRounds(); i++)
            {
                Console.WriteLine("{0}\t\t{1}\t\t{2}", i, mlh.getHeight(i), mlh.getSpeed(i));
            }
        }
    }
}
