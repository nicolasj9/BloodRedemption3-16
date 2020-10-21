using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodRedemption3_16
{
    //It's just a dice... That decides belligerents' fate.
    //I hope the Gamble's God and the Might are with you.
    class FateDice
    {
        private Random randomFace = new Random();

        public FateDice()
        {
        }

        public int GetFateDiceResult()
        {
            
            return randomFace.Next(1, 7);
        }



    }
}
