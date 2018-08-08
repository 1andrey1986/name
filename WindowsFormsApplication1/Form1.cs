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
    public partial class Form1 : Form

    {

        datenBank db = new datenBank();
        Form2 forma2 = new Form2();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
        //    button1. = Color.Aqua;

            this.Hide();
            forma2.ShowDialog();
            this.Show();
            label1.Focus();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            db.delNames();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
