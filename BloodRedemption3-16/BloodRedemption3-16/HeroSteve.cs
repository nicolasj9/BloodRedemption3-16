using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Drawing;

namespace BloodRedemption3_16
{
    
    class HeroSteve : LivingBeeing
    {
        private int healthPoints;
        private FateDice fateDice;


        public HeroSteve()
        {
            this.healthPoints = int.Parse(ConfigurationManager.AppSettings["steveHP"]);
            this.imagePath = ConfigurationManager.AppSettings["steveIMG"];
            this.fateDice = new FateDice();

        }

        /*public void UseShield ()
        {
            this.shield = true;
        }

        public void DisableShield()
        {
            this.shield = false;
        }*/

        public void TearApart(Monster livingBeeing)
        {
            livingBeeing.GetKilled();
        }


        public void SetHeroDamages(int damages, System.Windows.Forms.RichTextBox richTextBox, System.Windows.Forms.Label lHero)
        {
            int diceBuffer = this.fateDice.GetFateDiceResult();
            lHero.Text = diceBuffer.ToString();
            if (diceBuffer > 2)
            {

                this.healthPoints -= damages;
                richTextBox.AppendText("Merde ! Steve s'est pris un coup. Juste une égratinure." + "\r\n");

                if (this.healthPoints <= int.Parse(ConfigurationManager.AppSettings["zeroHP"]))
                {
                    canFight = false;
                    richTextBox.AppendText("Steve est un peu KO, il va boire un truc plus fort, il revient." + "\r\n");
                }
            }
            else
            {
                richTextBox.AppendText("Steve a pu parer l'attaque avec une de ses canettes de bière." + "\r\n" + "Le temps d'en prendre une autre, c'est parti." + "\r\n");
            }


        }

        public int getHP()
        {
            return this.healthPoints;
        }

    }
}
