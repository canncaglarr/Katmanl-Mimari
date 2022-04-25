using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                BLL.BLL P = new BLL.BLL();
                dataGridView1.DataSource = P.GetPersons();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.BLL getir = new BLL.BLL();
                dataGridView1.DataSource=getir.GetPersons(int.Parse(textBox1.Text));
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.BLL ekle = new BLL.BLL();
                dataGridView1.DataSource = ekle.Kayıt(textBox1.Text,textBox2.Text, textBox3.Text,textBox4.Text);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.BLL guncelle = new BLL.BLL();
                dataGridView1.DataSource = guncelle.guncel(int.Parse(textBox5.Text), textBox1.Text, textBox2.Text,textBox3.Text);
 
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["OgrenciAd"].Value.ToString();
                textBox2.Text = row.Cells["OgrenciSoyad"].Value.ToString();
                textBox3.Text = row.Cells["OgrenciNo"].Value.ToString();
                textBox4.Text = row.Cells["Ogrencitel"].Value.ToString();
                textBox5.Text = row.Cells["OgrenciId"].Value.ToString();
               
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.BLL sil = new BLL.BLL();
                dataGridView1.DataSource = sil.sil(int.Parse(textBox5.Text));

            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
