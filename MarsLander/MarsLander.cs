using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsLander
{
    class MarsLander
    {
        // positive speed == speed towards Mars (DOWNWARD)

        private MarsLanderHistory mlh = new MarsLanderHistory();

        private int fuel;
        private int height;
        private int speed;

        // you'll need to add data fields & methods so that the rest of the program
        // can use the various properties of the lander (such as height, speed, etc)

        public MarsLander()
        {
            fuel = 500;
            height = 1000;
            speed = 100;
        }

        public void setSpeed(int nS)
        {
            speed = nS;
        }
        public int getSpeed()
        {
            return speed;
        }
        public void setFuel(int nF)
        {
            fuel = nF;
        }
        public int getFuel()
        {
            return fuel;
        }
        public void setHeight(int nH)
        {
            if (nH <= 0)
            {
                height = 0;
            }
            else
            {
                height = nH;
            } 
             
        }
        public int getHeight()
        {
            return height;
        }

        public void reduceFuel(int burnAmt)
        {
            if (burnAmt <= 500 && burnAmt >= 0)
            {
                fuel -= burnAmt;
            }
            else
                Console.WriteLine("feul burn error");
        }

        public int calcNewSpeedHeight(int input)
        {
            mlh.AddRound(height, speed);

            int newSpeed;
            newSpeed = getSpeed() + 50 - input;

            setSpeed(newSpeed);
            reduceFuel(input);
            setHeight(getHeight() - getSpeed());

            
            return newSpeed;
        }

        public MarsLanderHistory GetHistory()
        {
            return mlh;
        }
    }
}
