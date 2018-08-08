using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class forma3 : Form
    {                                               
        List<land> liLa = new List<land>();
        List<score> liSc = new List<score>();               // reservieren Platz fur unsere listen und variablen
        List<Button> liBu1 = new List<Button>();   
        List<Button> liBu2 = new List<Button>();
        List<Button> liBu3 = new List<Button>();

        List<int> r = new List<int>();
        int count;
        int score;
        public string namell { get; set; }  // Spieler Name

        datenBank db = new datenBank();
        
        public forma3()
        {
            InitializeComponent();
            db.dbOeffnen();
            liLa = db.giblisteland();
            liSc = db.showScore();
            liBu1.Add(button1); liBu1.Add(button2); liBu1.Add(button3); liBu1.Add(button4);  
            liBu2.Add(button7); liBu2.Add(button8); liBu2.Add(button9); liBu2.Add(button10);
            liBu3.Add(button5); liBu3.Add(button12);
            liBu3.Add(button13); liBu3.Add(button14);

        }

        private void tabPage3_Click(object sender, EventArgs e)
        {




        }
        public List<int> rand() // nimmt 4 Zahlen fur eine Spiel Runde,wird funfte datenstaz generieren,der richtig sein soll,
                                // von zweite list werden Elemente von erste liste abgezogen
        {
            Random r = new Random();
            int i;
            List<int> li = new List<int>(); List<int> ri = new List<int>(); 
            for (i = 0; i < liLa.Count - 1; i++) { li.Add(i); }
            for (i = 0; i < 4; i++)
            {

                int a = r.Next(0, li.Count - 1);
                ri.Add(a);
                li.Remove(a);
            }
            ri.Add(r.Next(0, 3));
            return ri;


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

   

        private void button5_Click(object sender, EventArgs e)
        {
            //string ru = "ua";
            //pictureBox1.Image = Image.FromFile($"flags-normal\\{ru}.png");

            count++;
            if (r[4] == 0) { MessageBox.Show(" Sie haben recht"); score++; }
            else { MessageBox.Show(" Leider falsch"); }
            button15_Click(sender, e);
            label21.Text = count.ToString();
            label22.Text = score.ToString();


        }

        private void button6_Click(object sender, EventArgs e) //neueRunde,10 versuche
        {
            int letzte;
            for(int t = 0; liBu1.Count()-1>=t;t++ )
            {
                liBu1[t].Show();
                   }

            if (count <  10)
            {
                button6.Hide();
                r = rand();
                textBox1.Text = liLa[r[r[4]]].laender;
                button1.Text = liLa[r[0]].staedte;
                button2.Text = liLa[r[1]].staedte;
                button3.Text = liLa[r[2]].staedte;
                button4.Text = liLa[r[3]].staedte;
            }
            else
            {
                MessageBox.Show("Sie haben keine zuge mehr");
                db.saveScore(score, namell);
                for (int t = 0; liBu1.Count() - 1 >= t; t++)
                {
                    liBu1[t].Hide();
                }
                letzte = score;
                label27.Text = letzte.ToString();
              
                score = 0;
                count = 0;
                button6.Show();
                button6.Text = "neue Spiel";
            }



            //if (liBu[t].Text == textBox1.Text)
            //{ MessageBox.Show(" Sie haben recht"); }
            //else { MessageBox.Show("antwort ist falsch"); }




        }

        private void button1_Click(object sender, EventArgs e) //Mogliche antwort
        {
            count++;
            if (r[4] == 0) { MessageBox.Show(" Sie haben recht"); score++; }
            else { MessageBox.Show(" Leider falsch"); }
            button6_Click(sender, e);
            label4.Text = count.ToString();
            label6.Text = score.ToString();

        }

        private void button2_Click(object sender, EventArgs e) //Mogliche antwort
        {
            count++;
            if (r[4] == 1) { MessageBox.Show(" Sie haben recht"); score++; }
            else { MessageBox.Show(" Leider falsch"); }
            button6_Click(sender, e);
            label4.Text = count.ToString();
            label6.Text = score.ToString();
        }

        private void button3_Click(object sender, EventArgs e) //Mogliche antwort
        {
            count++;
            if (r[4] ==2) { MessageBox.Show(" Sie haben recht"); score++; }
            else { MessageBox.Show(" Leider falsch"); }
            button6_Click(sender, e);
            label4.Text = count.ToString();
            label6.Text = score.ToString();
        }

        private void button4_Click(object sender, EventArgs e) //Mogliche antwort
        {
            count++;
            if (r[4] == 3) { MessageBox.Show(" Sie haben recht"); score++; }
            else { MessageBox.Show(" Leider falsch"); }
            button6_Click(sender, e);
            label4.Text = count.ToString();
            label6.Text = score.ToString();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void forma3_Load(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            int letzte;
            for (int t = 0; liBu2.Count() - 1 >= t; t++)
            {
                liBu2[t].Show();
            }

            if (count < 10)
            {
                button11.Hide();
                r = rand();                             // Random wert fur int r geben
             label8.Text = liLa[r[r[4]]].staedte;
                button7.Text = liLa[r[0]].laender;
                button8.Text = liLa[r[1]].laender;
                button9.Text = liLa[r[2]].laender;
                button10.Text = liLa[r[3]].laender;
            }
            else
            {
                MessageBox.Show("Sie haben keine zuge mehr");
            
                db.saveScore(score, namell);
                for (int t = 0; liBu2.Count() - 1 >= t; t++)
                {
                    liBu2[t].Hide();
                }
                letzte = score;
                label31.Text = letzte.ToString();

                score = 0;
                count = 0;
                button11.Show();
                button11.Text = "neue Spiel starten";
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            count++;
            if (r[4] == 0) { MessageBox.Show(" Sie haben recht"); score++; }
            else { MessageBox.Show(" Leider falsch"); }
            button11_Click(sender, e);
            label10.Text = count.ToString();
            label12.Text = score.ToString();
           
        }

        private void button8_Click(object sender, EventArgs e)
        {
            count++;
            if (r[4] == 1) { MessageBox.Show(" Sie haben recht"); score++; }
            else { MessageBox.Show(" Leider falsch"); }
       button11_Click(sender, e);
            label10.Text = count.ToString();
            label12.Text = score.ToString();
          
        }

        private void button9_Click(object sender, EventArgs e)
        {
            count++;
            if (r[4] == 2) { MessageBox.Show(" Sie haben recht"); score++; }
            else { MessageBox.Show(" Leider falsch"); }
            button11_Click(sender, e);
            label10.Text = count.ToString();
            label12.Text = score.ToString();
            
        }

        private void button10_Click(object sender, EventArgs e)
        {
            count++;
            if (r[4] == 3) { MessageBox.Show(" Sie haben recht"); score++; }
            else { MessageBox.Show(" Leider falsch"); }
            button11_Click(sender, e);
            label10.Text = count.ToString();
            label12.Text = score.ToString();
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }
        private Image picGib(string g) // liefert Flagg fur gegebene Land
        {
            //string ru = "ua";
            pictureBox1.Image = Image.FromFile($"flags-normal\\{g}.png"); //pfad zu datei mit Flaggs
            return pictureBox1.Image;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            count++;
            if (r[4] == 1) { MessageBox.Show(" Sie haben recht"); score++; }
            else { MessageBox.Show(" Leider falsch"); }
            button15_Click(sender, e);
            label21.Text = count.ToString();
            label22.Text = score.ToString();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            count++;
            if (r[4] == 2) { MessageBox.Show(" Sie haben recht"); score++; }
            else { MessageBox.Show(" Leider falsch"); }
            button15_Click(sender, e);
            label21.Text = count.ToString();
            label22.Text = score.ToString();

        }

        private void button14_Click(object sender, EventArgs e)
        {
            count++;
            if (r[4] == 3) { MessageBox.Show(" Sie haben recht"); score++; }
            else { MessageBox.Show(" Leider falsch "); }
            button15_Click(sender, e);
            label21.Text = count.ToString();
            label22.Text = score.ToString();

        }

        private void button15_Click(object sender, EventArgs e)
        {
            int letzte;
           
                for (int t = 0; liBu3.Count() - 1 >= t; t++)
                {
                    liBu3[t].Show();
                }
                if (count < 10)
                {
                    button15.Hide();
                    r = rand();
                    picGib(liLa[r[r[4]]].flagg
                        );
                    //label8.Text = liLa[r[r[4]]].laender;
                    button5.Text = liLa[r[0]].laender;
                    button12.Text = liLa[r[1]].laender;
                    button13.Text = liLa[r[2]].laender;
                    button14.Text = liLa[r[3]].laender;
                }
                else
                {
                    MessageBox.Show("Sie haben keine zuge mehr");
                    db.saveScore(score, namell);
                letzte = score;
                label29.Text = letzte.ToString();
                score = 0;
                    count = 0;
                    for (int t = 0; liBu3.Count() - 1 >= t; t++)
                    {
                        liBu3[t].Hide();
                    }
               
                   
                    button15.Show();
                    button15.Text = "neue Spiel starten";
                }
            }
           
        

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.Hide();

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)  // zeigt listBox mit beste Ergebnisse
        {

            foreach (score s in liSc)                             //fuhllt list box ein
            {
                listBox1.Items.Add("nikName: " + s.name + "    score: " + s.scr);
            }
        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }
    }
}



        


    

