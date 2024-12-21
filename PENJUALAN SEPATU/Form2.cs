using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PENJUALAN_SEPATU
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Username atau Password tidak boleh kosong");
            else
    if (textBox1.Text == "admin" && textBox2.Text == "12345")
            {
                Form1 F1 = new Form1();
                F1.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Username atau Password salah");
        }
    }
}
