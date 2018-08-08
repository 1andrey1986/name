using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        string player;
        forma3 form3 = new forma3();
        //private MySqlConnection dbConnection;
        public string namell { get; set; }
        datenBank db = new datenBank();
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //    if (db.namePrufen(textBox1.Text) == 0)
            //    {
            //db.saveUser(textBox1.Text);

            string namell = textBox1.Text;
               

                this.Hide();
                form3.namell = textBox1.Text;

                form3.ShowDialog();
                this.Show();
            //}
            //if(db.namePrufen(textBox1.Text)>=2)
            //{
            //    db.delNam(textBox1.Text);
            //    //db.saveUser(textBox1.Text);

            //    this.Hide();
            //    form3.namell = textBox1.Text;

            //    form3.ShowDialog();
            //    this.Show();

        }
        //    else MessageBox.Show("Name exestiert bereit");
        //    textBox1.Text = "";
        //}

       
    }
}