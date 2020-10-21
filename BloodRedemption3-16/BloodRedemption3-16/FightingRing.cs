using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BloodRedemption3_16
{
    public partial class Form1 : Form
    {
        string deadImgPath = ConfigurationManager.AppSettings["nukeIMG"];
        private int pointCount = int.Parse(ConfigurationManager.AppSettings["zeroHP"]);
        private int roundCounter = 1;
        private int killCount = int.Parse(ConfigurationManager.AppSettings["zeroHP"]);
        string[] randomTalk = {"Amenez donc un médecin, que je le bute aussi.",
                               "C'est comme ça qu'on se fait tuer au travail, blaireau.",
                               "L'école est finie.",
                               "Burp... My name is Stone Cold... Burp"};

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_ClickAsync(object sender, EventArgs e)
        {
            HeroSteve steve = new HeroSteve();
            FightGoesOnScreenConfiguration();
            bool steveStatus = steve.GetFightingStatus();

            await ShowPictureBox(this.pictureBox1, steve.GetImage());

            while (steveStatus)
            {
                richTextBox1.AppendText("\r\n" + "ROUND" + roundCounter + "\r\n");

                Monster opponent = SelectOpponent();
                while (opponent.GetFightingStatus() && steveStatus)
                {
                    //but : appuyer sur espace pour lancer l'action
                    await RoundStart(steve, opponent);
                }
                roundCounter++;
                label7.Text = "Maccabés 'made by' Steve :  " + killCount;
            }
            EndOfFightOnScreenConfiguration();
            this.button1.Show();

        }



        private void FightGoesOnScreenConfiguration()
        {


            this.label1.Text = "Steve";
            this.label1.Show();
            this.label2.Show();
            this.label3.Show();
            this.label4.Show();
            this.label5.Show();
            this.label6.Show();
            this.label7.Show();
            label7.Text = "Maccabés 'made by' Steve :  " + killCount;
            this.label4.Text = pointCount + " points";

            richTextBox1.Clear();
            this.richTextBox1.Show();

            this.button1.Hide();
            this.WindowState = FormWindowState.Maximized;
        }

        private async void EndOfFightOnScreenConfiguration()
        {
            this.label1.Hide();
            this.label2.Hide();
            this.label3.Hide();
            this.label4.Hide();
            this.label5.Hide();
            this.label6.Hide();
            await ShowPictureBox(pictureBox1, deadImgPath);
        }




        private async Task RoundStart(HeroSteve steve, Monster monster)
        {
            FateDice dice = new FateDice();
            label8.Hide();

            steve.SetFateDiceNumber(dice.GetFateDiceResult());
            label5.Text = "Score du dé : " + steve.GetFateDiceNumber().ToString();
            monster.SetFateDiceNumber(dice.GetFateDiceResult());
            label6.Text = "Score du dé : " + monster.GetFateDiceNumber().ToString();


            await ShowPictureBox(this.pictureBox2, monster.GetImage());
            this.label2.Text = monster.GetName();
            await Task.Delay(3000);

            if (steve.GetFateDiceNumber() >= monster.GetFateDiceNumber())
            {
                steve.TearApart(monster);
                await ShowPictureBox(this.pictureBox2, deadImgPath);
                richTextBox1.AppendText("Steve Austin a tué " + monster.GetName() + "\r\n");
                pointCount += monster.GetKillPoints();
                killCount++;
                RandomTalk();

            }
            else
            {
                richTextBox1.AppendText("Aille ! Steve austin a raté son attaque !!" + "\r\n");
                monster.Attack(steve, this.richTextBox1, this.label5, this.label6);
            }

            this.label3.Text = steve.getHP().ToString() + " HP";
            this.label4.Text = pointCount + " points";



        }

        private Monster SelectOpponent()
        {
            Random whichMonster = new Random();

            if (whichMonster.Next(1, 5) == 4)
            {
                return new HardMonster();
            }
            else
            {
                return new Monster();
            }
        }


        private async Task ShowPictureBox(PictureBox pictureBox, string imagePath)
        {
            pictureBox.Show();
            pictureBox.ImageLocation = imagePath;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            await Task.Delay(10);

        }

        private void RandomTalk()
        {
            Random rdnTalk = new Random();

            if (rdnTalk.Next(1,100) > 75)
            {
                label8.Show();
                label8.Text = randomTalk[rdnTalk.Next(0, 4)];
            }
        }
    }
}

