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

namespace GirisUygulamasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Denemeler;Integrated Security=True");

        private void btn_Giris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from KullaniciGirisUygulamasi where KullaniciAdi='"+txt_KullaniciAdi.Text+"' and Sifre='"+txt_Sifre.Text+"'", baglanti);
            SqlDataReader oku=komut.ExecuteReader();
            if (oku.Read())
            {
                Form2 form = new Form2();
                form.Show();
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış!!!");
            }
            baglanti.Close();
        }
    }
}
