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
using System.Security.Cryptography;

namespace ToDoListApp
{
    public partial class GirisEkran : Form
    {
        public GirisEkran()
        {
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            String kullaniciAdi = txtbxKAdi.Text;
            String sifre = ComputeSha256Hash(txtbxSifre.Text);

            String sorgu = "SELECT *FROM Users where KullaniciAdi='" + kullaniciAdi + "' AND Sifre='" + sifre + "'";

            SqlConnection conn = new SqlConnection("Server = localhost\\SQLEXPRESS;Database=Calendar;Trusted_Connection=True;");
            SqlCommand cmd = new SqlCommand(sorgu, conn);

            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.Read())
            {
                MessageBox.Show("Giriş Basarılı..");
                KayitEkran nKayitEkran = new KayitEkran();
                nKayitEkran.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı bilgiler tekrar deneyiniz");
            }
            conn.Close();
        }

        static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256
            using (SHA256 sha256Hash = SHA256.Create())
            {
                //ComputeHash - returns byte array
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                //Convert byte array to a string
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private void btnKayitEkran_Click(object sender, EventArgs e)
        {
            KayitEkran nKayitEkran = new KayitEkran();
            nKayitEkran.Show();
            this.Hide();
        }
    }
}
