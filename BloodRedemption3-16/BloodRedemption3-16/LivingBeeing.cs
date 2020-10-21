using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Drawing;

namespace BloodRedemption3_16
{
    // What's common  between Steve and a monster ? 
    // Well... They both breath and don't look friendly... So they are living beeings ? No ?
    partial class LivingBeeing
    {
        protected bool canFight = true;
        protected string imagePath;

        protected int fateDiceResult;

        public int GetFateDiceNumber()
        {
            return this.fateDiceResult;
        }

        public void SetFateDiceNumber(int number)
        {
            this.fateDiceResult = number;
        }

        public bool GetFightingStatus()
        {
            return this.canFight;
        }

        public string GetImage()
        {
            return this.imagePath;
        }

    }
}
