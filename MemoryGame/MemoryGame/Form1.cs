using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MemoryGame.Properties;

namespace MemoryGame
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        List<Igrac> lista = new List<Igrac>();
        private void button1_Click(object sender, EventArgs e)
        {
           
                string imeIgraca = textBox1.Text;
               
                if (radioButton1.Checked)
                {
                    Form2 druga = new Form2();
                    druga.ShowDialog();
                    bool rezu = druga.rezultat;
                    Napredni igracN = new Napredni(imeIgraca, "tesko",rezu);
                    lista.Add(igracN);
                }
                if (radioButton2.Checked)
                {
                    Form3 treca = new Form3();
                    treca.ShowDialog();
                    bool rezu = treca.rezultat;
                    Pocetnik igracP = new Pocetnik(imeIgraca, "lako", rezu);
                    lista.Add(igracP);
                }
            
            if(radioButton1.Checked==false && radioButton2.Checked==false) 
            {
                MessageBox.Show("Odaberite razinu");
               
            }
            textBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ForeColor = Color.DarkRed;
            BackColor = Color.Beige;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            listBox1.Items.Clear();
            foreach (Igrac i in lista)
            {
                if (i.Rezultat == true)
                {
                    listBox1.Items.Add(string.Format( "Ime:{0}\tRazina:{1}\tRezultat:pobjeda\n",i.Ime ,i.Razina));
                }
                if (i.Rezultat == false)
                {
                    listBox1.Items.Add(string.Format( "Ime:{0}\tRazina:{1}\tRezultat:poraz\n",i.Ime ,i.Razina));
                }
            }
        }
       
    }
}
