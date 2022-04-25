using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class KullanıcıGiris : Form
    {
        public KullanıcıGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-IM113RBU;Initial Catalog=Ogrenci;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Boş kayıt yapılamaz");
            }
            else
            {
                baglanti.Open();
                string users;
                string password;
                users = textBox1.Text;
                password = textBox2.Text;
                SqlCommand komut = new SqlCommand("select * from KullanıcıGiris where KullancıAd='" + users + "'", baglanti);
                SqlDataReader oku = komut.ExecuteReader();
                if (oku.Read())
                {
                    MessageBox.Show("Bu kullanıcı adı kullanılıyor lütfen  başka kullanıcı adı seçin");
                }
                else
                {
                    oku.Close();
                    SqlCommand ekle = new SqlCommand("insert into KullanıcıGiris(KullancıAd,sifre) values('" + users + "','" + password + "')", baglanti);
                    ekle.ExecuteNonQuery();
                    MessageBox.Show("Kayıt oldunuz.....");
                    button1.Visible = true;
                }
                baglanti.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string users;
            string password;
            users = textBox1.Text;
            password = textBox2.Text;

            SqlCommand komut = new SqlCommand("select * from KullanıcıGiris where KullancıAd='" + users + "' and Sifre='" + password + "'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                MessageBox.Show("Hoşgeldiniz" + " " + users);
                Form1 frm = new Form1();
                frm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre..");
                button1.Visible = false;
                button2.Visible = true;
            }
            baglanti.Close();
        }
    }
}
