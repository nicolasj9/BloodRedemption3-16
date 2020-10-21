using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodRedemption3_16
{
    class HardMonster : Monster
    {
        private FateDice FateDice = new FateDice();

        public HardMonster()
        {
            this.killPoint = int.Parse(ConfigurationManager.AppSettings["hardMonsterKP"]);
            this.imagePath = ConfigurationManager.AppSettings["dioIMG"];
            this.name = ConfigurationManager.AppSettings["hardName"];
        }


        public new void Attack (HeroSteve steve, System.Windows.Forms.RichTextBox richTextBox, System.Windows.Forms.Label lHero, System.Windows.Forms.Label lMonster)
        {
            steve.SetHeroDamages(this.attackPoints, richTextBox, lHero);
            int diceScore = this.FateDice.GetFateDiceResult();
            lMonster.Text = diceScore.ToString();
            if (diceScore < 6)
            {
                richTextBox.AppendText("MUDA MUDA MUDA MUDA MUDA MUDA MUDA (attaque magique)" + "\r\n");
                MagicAttack(steve, diceScore, richTextBox, lHero);
            }
        }

        private void MagicAttack(HeroSteve livingBeeing, int diceNumber, System.Windows.Forms.RichTextBox richTextBox, System.Windows.Forms.Label lHero)
        {
                livingBeeing.SetHeroDamages(this.attackPoints * diceNumber, richTextBox, lHero);
        }
    }
}
