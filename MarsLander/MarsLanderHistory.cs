using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MarsLander
{
    class MarsLanderHistory
    {
        RoundInfo[] rounds = new RoundInfo[10];
        int numRounds = 0;

        // Clone is provided to you; it'll create a copy of the current history
        // Look for opportunities to use it elsewhere.
        public MarsLanderHistory Clone()
        {
            MarsLanderHistory copy = new MarsLanderHistory();

            copy.rounds = new RoundInfo[rounds.Length];
            copy.numRounds = numRounds;
            for (int i = 0; i < copy.numRounds; i++)
                copy.rounds[i] = rounds[i];

            return copy;
        }

        public void AddRound(int height, int speed)
        {
            if (numRounds > rounds.Length - 1)
            {
                RoundInfo[] extArr = new RoundInfo[rounds.Length + 20];

                for (int i = 0; i < rounds.Length; i++)
                {
                    extArr[i] = rounds[i]; 
                }
                rounds = extArr;
            }
            rounds[numRounds] = new RoundInfo(height, speed);
            numRounds++;
        }

        public int getHeight(int nRound)
        {
            return rounds[nRound].GetHeight();
        }
        public int getSpeed(int nRound)
        {
            return rounds[nRound].GetSpeed();
        }

        public int NumberOfRounds()
        {
            return numRounds;
        }
    }

    // This is provided to you; you shouldn't need to add anything to it, but
    // if you want to you are welcome to do so
    class RoundInfo
    {
        private int height;
        private int speed;

        #region Accessors
        public int GetHeight()
        {
            return height;
        }
        public void SetHeight(int newValue)
        {
            height = newValue;
        }

        public int GetSpeed()
        {
            return speed;
        }
        public void SetSpeed(int newValue)
        {
            speed = newValue;
        }
        #endregion Accessors

        public RoundInfo(int h, int s)
        {
            height = h;
            speed = s;
        }
    }
}
