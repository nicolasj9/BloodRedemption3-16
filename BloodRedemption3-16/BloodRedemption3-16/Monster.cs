using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Drawing;

namespace BloodRedemption3_16
{
    class Monster : LivingBeeing
    {
        protected int attackPoints;
        protected int killPoint;
        protected string name;

        public Monster()
        {
            this.attackPoints = int.Parse(ConfigurationManager.AppSettings["attackPoints"]);
            this.killPoint = int.Parse(ConfigurationManager.AppSettings["monsterKP"]);
            this.imagePath = ConfigurationManager.AppSettings["zombieIMG"];
            this.name = ConfigurationManager.AppSettings["easyName"];
        }

        public void GetKilled()
        {
            this.canFight = false;
        }

        public int GetKillPoints()
        {
            return this.killPoint;
        }

        public int GetAttackPoints()
        {
            return this.attackPoints;
        }

        public string GetName()
        {
            return this.name;
        }

        public void Attack(HeroSteve steve, System.Windows.Forms.RichTextBox richTextBox, System.Windows.Forms.Label hero, System.Windows.Forms.Label badguy)
        {
            steve.SetHeroDamages(this.attackPoints, richTextBox, hero);
        }
    }
}
