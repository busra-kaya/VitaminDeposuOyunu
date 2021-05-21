using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VitaminDeposuOyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int sure = 60; 
        int vitaminA = 0;
        int vitaminC =0;
        int pureToplam = 0;
        int suToplam = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            Zamanlayıcı.Stop();

            KatiMeyveSikacagiBtn.Enabled = false;
            SiviMeyveSikacagiBtn.Enabled = false;

        }

        List<IMeyveler> meyveler = new List<IMeyveler>()
        {
            new Meyveler(54,5, Image.FromFile("elma.png")),
            new Meyveler(25,5, Image.FromFile("armut.png")),
            new Meyveler(12,60, Image.FromFile("cilek.png")),
            new Meyveler(3,44, Image.FromFile("greyfurt.png")),
            new Meyveler(681,26, Image.FromFile("mandalina.png")),
            new Meyveler(225,45, Image.FromFile("portakal.png")),
        };

        private void Zamanlayıcı_Tick(object sender, EventArgs e)
        {

            if (sure >= 0) 
            {
                Zamanlayıcı.Interval = 1000;
                int sayac = sure--;
                KalanSureLabel.Text = sayac.ToString();
            }

            else
            {
                KatiMeyveSikacagiBtn.Enabled = false;
                SiviMeyveSikacagiBtn.Enabled = false;                
            }

            if (sure == 0)
            {
                MessageBox.Show("Süreniz dolmuştur. Tekrar oynamak için YENİ OYUN butonuna tıklayınız.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }

        private void YeniOyunBtn_Click(object sender, EventArgs e)
        {
            KatiMeyveSikacagiList.Items.Clear();
            SiviMeyveSikacagiList.Items.Clear();
            MeyvePuresiList.Items.Clear();
            MeyveSuyuList.Items.Clear();
            AVitaminiList.Items.Clear();
            CVitaminiList.Items.Clear();

            AVitaminiGramLabel.Text = Convert.ToString(vitaminA);
            CVitaminiGramLabel.Text = Convert.ToString(vitaminC);

            sure = 60;
            pureToplam = 0;
            suToplam = 0;
            vitaminA = 0;
            vitaminC = 0;

            MeyvePuresiGramLabel.Text = Convert.ToString("");
            MeyveSuyuGramLabel.Text = Convert.ToString("");
            AVitaminiGramLabel.Text = Convert.ToString("");
            CVitaminiGramLabel.Text = Convert.ToString("");

            Zamanlayıcı.Start();

            YeniOyunBtn.Enabled = true;
            KatiMeyveSikacagiBtn.Enabled = true;
            SiviMeyveSikacagiBtn.Enabled = true;

            var rand = new Random();
            ResimlerPictureBox.Image = meyveler[rand.Next(0, 6)].Image;

            

        }

        private void KatiMeyveSikacagiBtn_Click(object sender, EventArgs e)
        {
            var rand = new Random();

             if (ResimlerPictureBox.Image == meyveler[0].Image)
             {
                ResimlerPictureBox.Image = meyveler[rand.Next(0, 6)].Image;

                AVitaminiList.Items.Add("Elma : 54 ");
                CVitaminiList.Items.Add("Elma : 5 ");
                vitaminA += meyveler[0].AVitamini;
                vitaminC += meyveler[0].CVitamini;

                AVitaminiGramLabel.Text = vitaminA.ToString();
                CVitaminiGramLabel.Text = vitaminC.ToString();

                Elma elma = new Elma();
                elma.AgirlikYaz = rand.Next(70, 120);
                elma.VerimYaz = rand.Next(80, 95);
                elma.PureHesaplaElma = elma.AgirlikYaz * elma.VerimYaz / 100;
                elma.SuHesaplaElma = elma.AgirlikYaz - elma.PureHesaplaElma;


                KatiMeyveSikacagiList.Items.Add("Elma (" + elma.AgirlikYaz + " gr)" + " (%" + elma.VerimYaz + " verim)");
                MeyvePuresiList.Items.Add("Elma püresi : "  + elma.PureHesaplaElma + "gr") ;
                MeyveSuyuList.Items.Add("Elma suyu : " + elma.SuHesaplaElma + "gr");

                pureToplam += elma.PureHesaplaElma;
                suToplam += elma.SuHesaplaElma;

                MeyvePuresiGramLabel.Text = Convert.ToString(pureToplam) + "gr";
                MeyveSuyuGramLabel.Text = Convert.ToString(suToplam) + "gr";


            }
            else if (ResimlerPictureBox.Image == meyveler[1].Image)
            {
                ResimlerPictureBox.Image = meyveler[rand.Next(0, 6)].Image;

                AVitaminiList.Items.Add("Armut : 25 ");
                CVitaminiList.Items.Add("Armut : 5 ");
                vitaminA += meyveler[1].AVitamini;
                vitaminC += meyveler[1].CVitamini;

                AVitaminiGramLabel.Text = vitaminA.ToString();
                CVitaminiGramLabel.Text = vitaminC.ToString();

                Armut armut = new Armut();
                armut.AgirlikYaz = rand.Next(70, 120);
                armut.VerimYaz = rand.Next(80, 95);
                armut.PureHesaplaArmut = armut.AgirlikYaz * armut.VerimYaz / 100;
                armut.SuHesaplaArmut = armut.AgirlikYaz - armut.PureHesaplaArmut;


                KatiMeyveSikacagiList.Items.Add("Armut (" + armut.AgirlikYaz + " gr)" + " (%" + armut.VerimYaz + " verim)");
                MeyvePuresiList.Items.Add("Armut püresi : " + armut.PureHesaplaArmut + "gr");
                MeyveSuyuList.Items.Add("Armut suyu : " + armut.SuHesaplaArmut + "gr");

                pureToplam += armut.PureHesaplaArmut;
                suToplam += armut.SuHesaplaArmut;

                MeyvePuresiGramLabel.Text = Convert.ToString(pureToplam) + "gr";
                MeyveSuyuGramLabel.Text = Convert.ToString(suToplam) + "gr";


            }
            else if (ResimlerPictureBox.Image == meyveler[2].Image)
            {
              
                ResimlerPictureBox.Image = meyveler[rand.Next(0, 6)].Image;

                AVitaminiList.Items.Add("Çilek : 12 ");
                CVitaminiList.Items.Add("Çilek : 60 ");
                vitaminA += meyveler[2].AVitamini;
                vitaminC += meyveler[2].CVitamini;

                AVitaminiGramLabel.Text = vitaminA.ToString();
                CVitaminiGramLabel.Text = vitaminC.ToString();

                Cilek cilek = new Cilek();
                cilek.AgirlikYaz = rand.Next(70, 120);
                cilek.VerimYaz = rand.Next(80, 95);
                cilek.PureHesaplaCilek = cilek.AgirlikYaz * cilek.VerimYaz / 100;
                cilek.SuHesaplaCilek = cilek.AgirlikYaz - cilek.PureHesaplaCilek;


                KatiMeyveSikacagiList.Items.Add("Çilek (" + cilek.AgirlikYaz + " gr)" + " (%" + cilek.VerimYaz + " verim)");
                MeyvePuresiList.Items.Add("Çilek püresi : " + cilek.PureHesaplaCilek + "gr");
                MeyveSuyuList.Items.Add("Çilek suyu : " + cilek.SuHesaplaCilek + "gr");


                pureToplam += cilek.PureHesaplaCilek;
                suToplam += cilek.SuHesaplaCilek;

                MeyvePuresiGramLabel.Text = Convert.ToString(pureToplam) + "gr";
                MeyveSuyuGramLabel.Text = Convert.ToString(suToplam) + "gr";


            }

        }

        private void SiviMeyveSikacagiBtn_Click(object sender, EventArgs e)
        {
            var rand = new Random();

            if (ResimlerPictureBox.Image == meyveler[3].Image)
            {
                ResimlerPictureBox.Image = meyveler[rand.Next(0, 6)].Image;

                AVitaminiList.Items.Add("Greyfurt : 3 ");
                CVitaminiList.Items.Add("Greyfurt : 44 ");
                vitaminA += meyveler[3].AVitamini;
                vitaminC += meyveler[3].CVitamini;

                AVitaminiGramLabel.Text = vitaminA.ToString();
                CVitaminiGramLabel.Text = vitaminC.ToString();

                Greyfurt greyfurt = new Greyfurt();
                greyfurt.AgirlikYaz = rand.Next(70, 120);
                greyfurt.VerimYaz= rand.Next(30, 70); 
                greyfurt.SuHesaplaGreyfurt = greyfurt.AgirlikYaz * greyfurt.VerimYaz / 100;
                greyfurt.PureHesaplaGreyfurt = greyfurt.AgirlikYaz - greyfurt.SuHesaplaGreyfurt;

                SiviMeyveSikacagiList.Items.Add("Greyfurt (" + greyfurt.AgirlikYaz + " gr)" + " (%" + greyfurt.VerimYaz + " verim)");
                MeyveSuyuList.Items.Add("Greyfurt suyu : " + greyfurt.SuHesaplaGreyfurt + "gr");
                MeyvePuresiList.Items.Add("Greyfurt püresi : " + greyfurt.PureHesaplaGreyfurt + "gr");

                suToplam += greyfurt.SuHesaplaGreyfurt;
                pureToplam += greyfurt.PureHesaplaGreyfurt;
                MeyveSuyuGramLabel.Text = Convert.ToString(suToplam) + "gr";
                MeyvePuresiGramLabel.Text = Convert.ToString(pureToplam) + "gr";


            }
            else if (ResimlerPictureBox.Image == meyveler[4].Image)
            {
                ResimlerPictureBox.Image = meyveler[rand.Next(0, 6)].Image;

                AVitaminiList.Items.Add("Mandalina : 681 ");
                CVitaminiList.Items.Add("Mandalina : 26 ");
                vitaminA += meyveler[4].AVitamini;
                vitaminC += meyveler[4].CVitamini;

                AVitaminiGramLabel.Text = vitaminA.ToString();
                CVitaminiGramLabel.Text = vitaminC.ToString();

                Mandalina mandalina = new Mandalina();
                mandalina.AgirlikYaz = rand.Next(70, 120);
                mandalina.VerimYaz = rand.Next(30, 70);
                mandalina.SuHesaplaMandalina = mandalina.AgirlikYaz * mandalina.VerimYaz / 100;
                mandalina.PureHesaplaMandalina = mandalina.AgirlikYaz - mandalina.SuHesaplaMandalina;

                SiviMeyveSikacagiList.Items.Add("Mandalina (" + mandalina.AgirlikYaz + " gr)" + " (%" + mandalina.VerimYaz + " verim)");
                MeyveSuyuList.Items.Add("Mandalina suyu : " + mandalina.SuHesaplaMandalina + "gr");
                MeyvePuresiList.Items.Add("Mandalina püresi : " + mandalina.PureHesaplaMandalina + "gr");


                suToplam += mandalina.SuHesaplaMandalina;
                pureToplam += mandalina.PureHesaplaMandalina;

                MeyveSuyuGramLabel.Text = Convert.ToString(suToplam) + "gr";
                MeyvePuresiGramLabel.Text = Convert.ToString(pureToplam) + "gr";

            }
            else if (ResimlerPictureBox.Image == meyveler[5].Image)
            {
                ResimlerPictureBox.Image = meyveler[rand.Next(0, 6)].Image;

                AVitaminiList.Items.Add("Portakal : 225 ");
                CVitaminiList.Items.Add("Portakal : 45 ");
                vitaminA += meyveler[5].AVitamini;
                vitaminC += meyveler[5].CVitamini;

                AVitaminiGramLabel.Text = vitaminA.ToString();
                CVitaminiGramLabel.Text = vitaminC.ToString();

                Portakal portakal = new Portakal();
                portakal.AgirlikYaz = rand.Next(70, 120);
                portakal.VerimYaz = rand.Next(30, 70);
                portakal.SuHesaplaPortakal = portakal.AgirlikYaz * portakal.VerimYaz / 100;
                portakal.PureHesaplaPortakal = portakal.AgirlikYaz - portakal.SuHesaplaPortakal;


                SiviMeyveSikacagiList.Items.Add("Portakal (" + portakal.AgirlikYaz + " gr)" + " (%" + portakal.VerimYaz + " verim)");
                MeyveSuyuList.Items.Add("Portakal suyu : " + portakal.SuHesaplaPortakal + "gr");
                MeyvePuresiList.Items.Add("Portakal püresi : " + portakal.PureHesaplaPortakal + "gr");


                suToplam += portakal.SuHesaplaPortakal;
                pureToplam += portakal.PureHesaplaPortakal;

                MeyveSuyuGramLabel.Text = Convert.ToString(suToplam) +"gr";
                MeyvePuresiGramLabel.Text = Convert.ToString(pureToplam) + "gr";

            }

        }
            
        private void OyunuSonlandirBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
