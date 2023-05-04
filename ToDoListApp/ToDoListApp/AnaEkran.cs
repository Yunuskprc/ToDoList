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

namespace ToDoListApp
{
    public partial class AnaEkran : Form
    {
        public AnaEkran()
        {
            InitializeComponent();
        }

        string[] aylar = { "Ocak", "Subat", "Mart", "Nisan", "Mayis", "Haziran", "Temmuz", "Agustos", "Eylul", "Ekim", "Kasim", "Aralik" };
        int anlikAy = 0;
        int secilenGun = 0;

        private void AnaEkran_Load(object sender, EventArgs e)
        {
            cmbbxSehir.Text = "İstanbul";
            Sifirla();
            anlikAy = DateTime.Now.Month;
            label8.Text = AyDondur(anlikAy);
            TakvimDuzenle();
        }

        /// <summary>
        /// Takvimde Sonraki Aya geçiş için kullanılır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMonthNext_Click(object sender, EventArgs e)
        {
            if (anlikAy != 12)
            {
                Sifirla();
                anlikAy++;
                label8.Text = AyDondur(anlikAy);
                TakvimDuzenle();
            }
        }

        /// <summary>
        /// Tabloda Önceki aya geçmek için kullanılır.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMonthBack_Click(object sender, EventArgs e)
        {
            if (anlikAy != 1)
            {
                Sifirla();
                anlikAy--;
                label8.Text = AyDondur(anlikAy);
                TakvimDuzenle();
            }
        }

        private void btnCloseTodo_Click(object sender, EventArgs e)
        {
            pnlAddToDo.Visible = false;
            GunlukGorevListeleme(secilenGun, anlikAy);
            txtbxSaat.Text = string.Empty;
            txtbxgörev.Text = string.Empty;
            // buradan sonra pnl3 ün kodları olmalı
        }

        /// <summary>
        /// Seçilen güne ait görev ekleme butonu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTodo_Click(object sender, EventArgs e)
        {
            bool kontrol = true;
            string str = txtbxSaat.Text;
            int saatKontrol, dakikaKontrol;
            

            if (txtbxSaat.Text.Length == 5)
            {

                for (int i = 0; i < 5; i++)
                {
                    if (i == 2)
                    {
                        if (str[i] != '.')
                        {
                            kontrol = false;
                            break;
                        }
                    }
                    else
                    {
                        if (str[i] == '0' || str[i] == '1' || str[i] == '2' || str[i] == '3' || str[i] == '4' || str[i] == '5' || str[i] == '6' || str[i] == '7' || str[i] == '8' || str[i] == '9')
                        {

                        }
                        else
                        {
                            kontrol = false;
                            break;
                        }
                    }
                }
            }
            else
                kontrol = false;


            if (kontrol)
            {
                saatKontrol = Int16.Parse(str[0].ToString()) * 10 + Int16.Parse(str[1].ToString());
                dakikaKontrol = Int16.Parse(str[3].ToString()) * 10 + Int16.Parse(str[4].ToString());

                // saat ve dakika değerleri doğru girilmiş mi kontrol ediliyor.
                if (saatKontrol <= 24 && dakikaKontrol <= 60)
                {
                    int dakika = 0, saat = 0;
                    // saattextbox ını saat ve dakika int e çevirme
                    
                    if (txtbxSaat.Text[0] == '0')
                    {
                        saat = Int16.Parse(txtbxSaat.Text[1].ToString());
                        if (txtbxSaat.Text[3] == '0')
                            dakika = Int16.Parse(txtbxSaat.Text[4].ToString());
                        else
                            dakika = Int16.Parse(txtbxSaat.Text[3].ToString()) * 10 + Int16.Parse(txtbxSaat.Text[4].ToString());
                    }
                    else
                    {
                        saat = Int16.Parse(txtbxSaat.Text[0].ToString()) * 10 + Int16.Parse(txtbxSaat.Text[1].ToString());
                        if (txtbxSaat.Text[3] == '0')
                            dakika = Int16.Parse(txtbxSaat.Text[4].ToString());
                        else
                            dakika = Int16.Parse(txtbxSaat.Text[3].ToString()) * 10 + Int16.Parse(txtbxSaat.Text[4].ToString());
                    }


                    SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Calendar;Trusted_Connection=True;");
                    SqlCommand sqlCommand = new SqlCommand("insert into ToDo (ay,gün,saat,dakika,görev) values ('" + anlikAy + "','" + secilenGun + "','" + saat + "','" + dakika + "','" + txtbxgörev.Text + "')", conn);
                    conn.Open();
                    sqlCommand.ExecuteNonQuery();
                    conn.Close();
                    pnlAddToDo.Visible = false;
                    GunlukGorevListeleme(secilenGun, anlikAy);

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("update " + aylar[anlikAy - 1] + " set tip=@tip where gunNo=@gün", conn);
                    cmd.Parameters.AddWithValue("@tip", 1);
                    cmd.Parameters.AddWithValue("@gün", secilenGun);
                    cmd.ExecuteNonQuery();
                    conn.Close();


                }
                else
                {
                    MessageBox.Show("Hatalı Veri Girişi Tekrar Deneyin");
                }

                
            }
            else
                MessageBox.Show("Hatalı Veri Girişi Tekrar Deneyin");
        }

        /// <summary>
        /// Seçilen şehire göre Anlık hava durumu bilgisini ayarlar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbbxSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            pctbxHavaDurumu.Visible = true;
            lblHavaDurumu.Visible = true;
            lblDerece.Visible = true;
            pctbxHavaDurumu.Image = null;
            weather nesneW = new weather();
            lblDerece.Text = nesneW.Derece(cmbbxSehir.Text, "https://api.openweathermap.org/data/2.5/weather?q=" + cmbbxSehir.Text + "&mode=xml&lang=tr&units=metric&appid=ee724f154bf1f447a19184aaf85b1f92");
            lblHavaDurumu.Text = nesneW.HavaTipi(cmbbxSehir.Text, "https://api.openweathermap.org/data/2.5/weather?q=" + cmbbxSehir.Text + "&mode=xml&lang=tr&units=metric&appid=ee724f154bf1f447a19184aaf85b1f92");
            pctbxHavaDurumu.Image = nesneW.HavaTipiResmiDondur(cmbbxSehir.Text, "https://api.openweathermap.org/data/2.5/weather?q=" + cmbbxSehir.Text + "&mode=xml&lang=tr&units=metric&appid=ee724f154bf1f447a19184aaf85b1f92");


            if (lblHavaDurumu.Text.Length > 10)
                lblHavaDurumu.Location = new Point(74, 226);
            else
                lblHavaDurumu.Location = new Point(125, 226);
        }






        /// <summary>
        /// ay değişimi sonrası buttonları başlangıç pozisyonuna göre ayarlar.
        /// </summary>
        private void Sifirla()
        {
            Button[] btnList = {button1,button2,button3,button4,button5,button6,button7,button8,button9,button10,
            button11,button12,button13,button14,button15,button16,button17,button18,button19,button20,button21,
            button22,button23,button24,button25,button26,button27,button28,button29,button30,button31,button32,
            button33,button34,button35,button36,button37,button38,button39,button40,button41,button42};
            for (int i = 0; i < btnList.Length; i++)
            {
                btnList[i].Visible = false;
                btnList[i].Text = null;
            }
        }

        /// <summary>
        /// Takvim Oluşturur ve Özel Günleri Belirtir
        /// </summary>
        private void TakvimDuzenle()
        {
            //1.aşama seçilen aya ait günleri bastırır.
            string sorgu = "";
            Button[] btnList = {button1,button2,button3,button4,button5,button6,button7,button8,button9,button10,
            button11,button12,button13,button14,button15,button16,button17,button18,button19,button20,button21,
            button22,button23,button24,button25,button26,button27,button28,button29,button30,button31,button32,
            button33,button34,button35,button36,button37,button38,button39,button40,button41,button42};
            int gunNo = 0, gunAdi = 0, tip = 0; // veritabanındaki sütunların değerlerini tutarlar.
            int ilkGun = 0; // 2.aşama için kullanılır.
            int sonGun = 0; // 3.aşama için kullanılır.
            int i = 0;
            SqlConnection con = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Calendar;Trusted_Connection=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT *FROM " + aylar[anlikAy - 1], con);
            SqlDataReader rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                gunNo = Int16.Parse(rd["gunNo"].ToString());
                gunAdi = Int16.Parse(rd["gunAdi"].ToString());
                tip = Int16.Parse(rd["tip"].ToString());

                if (i == 0) // ilk gün için ilgli butonu bulur ve değerleri atar.
                {
                    btnList[gunAdi - 1].Visible = true;
                    btnList[gunAdi - 1].Text = gunNo.ToString();
                    btnList[gunAdi - 1].Enabled = true;
                    btnList[gunAdi - 1].ForeColor = Color.Black;
                    i = gunAdi;
                    ilkGun = gunAdi - 1;
                    DayBackGroundImage(tip, btnList, gunAdi - 1);
                }
                else // kalan günler için sırayla butonları doldurur.
                {
                    btnList[i - 1].Visible = true;
                    btnList[i - 1].Enabled = true;
                    btnList[i - 1].Text = gunNo.ToString();
                    btnList[i - 1].ForeColor = Color.Black;
                    sonGun = i - 1;
                    DayBackGroundImage(tip, btnList, i - 1);
                }
                i++;
            }
            con.Close();
            cmd.Dispose();
            rd.Close();





            //2.aşama seçilen ay öncesindeki günleri ekrana bastırır.
            con.Open();
            int count = 0; // tablodaki satır sayısını tutar

            // if-else in amacı şubat ayına gelindiğinde ocak ayı için doğru formatta sql sorgusu hazırlmak
            if (anlikAy == 1)
                sorgu = "SELECT COUNT(*) FROM " + aylar[anlikAy - 1];
            else
                sorgu = "SELECT COUNT(*) FROM " + aylar[anlikAy - 2];


            SqlCommand cmd2 = new SqlCommand(sorgu, con);
            count = (int)cmd2.ExecuteScalar();

            // if-else in amacı şubat ayına gelindiğinde ocak ayı için doğru formatta sql sorgusu hazırlmak
            if (anlikAy == 1)
                sorgu = "SELECT *FROM " + aylar[anlikAy - 1];
            else
                sorgu = "SELECT *FROM " + aylar[anlikAy - 2];


            cmd = new SqlCommand(sorgu, con);
            rd = cmd.ExecuteReader();
            int s1;
            i = 0;
            while (rd.Read())
            {
                s1 = Int16.Parse(rd["gunNo"].ToString());
                if (s1 > (count - ilkGun))
                {
                    btnList[i].Visible = true;
                    btnList[i].Text = rd["gunNo"].ToString();
                    btnList[i].ForeColor = System.Drawing.Color.FromArgb(192, 192, 192);
                    btnList[i].Enabled = false;
                    i++;
                }
                s1++;
            }
            con.Close();
            cmd2.Dispose();
            cmd.Dispose();
            rd.Close();





            con.Open();
            bool kontrol = false;

            // if else in amacı kasım ayına gelindiğinde düzgün formatta command stringi oluşturmaktır.
            if (anlikAy == 12)
                sorgu = "SELECT *FROM " + aylar[anlikAy - 1];
            else
                sorgu = "SELECT *FROM " + aylar[anlikAy];

            i = 1;
            cmd = new SqlCommand(sorgu, con);
            rd = cmd.ExecuteReader();

            // eğer son satır boşsa boş kalması için kontrol yapılıyor
            if (button35.Visible == false)
                kontrol = true;

            while (rd.Read())
            {

                if (kontrol)
                {
                    if (sonGun + i >= 35)
                        break;
                    if (btnList[i].Text != null)
                    {
                        btnList[sonGun + i].Visible = true;
                        btnList[sonGun + i].Text = rd["gunNo"].ToString();
                        btnList[sonGun + i].ForeColor = System.Drawing.Color.FromArgb(192, 192, 192);
                        btnList[sonGun + i].Enabled = false;
                    }
                    i++;
                }
                else
                {
                    if (sonGun + i >= 42)
                        break;
                    //35.butonun dolu olup 36.cının boş olduğu senaryoda boşuna son satırı doldurmak için kontrol yapılıyor
                    if (button36.Visible == false)
                        break;
                    if (btnList[i].Text != null)
                    {
                        btnList[sonGun + i].Visible = true;
                        btnList[sonGun + i].Text = rd["gunNo"].ToString();
                        btnList[sonGun + i].ForeColor = System.Drawing.Color.FromArgb(192, 192, 192);
                        btnList[sonGun + i].Enabled = false;
                    }
                    i++;
                }
            }
            con.Close();
        }

        /// <summary>
        /// Datetime.now.Month değişkenini string olarak geri döndürür.
        /// </summary>
        /// <returns></returns>
        private string AyDondur(int sayi)
        {
            string str = "";
            for (int i = 0; i < 12; i++)
            {
                if (i + 1 == anlikAy)
                {
                    str = aylar[i];
                    break;
                }
            }

            return str;
        }

        /// <summary>
        /// takvimdeki özel günler için günlerin resimleri değiştirir
        /// </summary>
        /// <param name="tip">Özel gün türünü tutar</param>
        /// <param name="btnlist"></param>
        /// <param name="i">Hangi butonun resmini değiştireceğini saklar</param>
        private void DayBackGroundImage(int tip, Button[] btnList, int i)
        {
            switch (tip)
            {
                case 1:
                    btnList[i].BackgroundImage = ToDoListApp.Properties.Resources.ButtonTask40px;
                    break;

                case 2:
                    btnList[i].BackgroundImage = ToDoListApp.Properties.Resources.ButtonHolidayNational40px;
                    break;

                case 3:
                    btnList[i].BackgroundImage = ToDoListApp.Properties.Resources.ButtonHoliday40px;
                    break;

                default:
                    btnList[i].BackgroundImage = null;
                    break;
            }
        }

        /// <summary>
        /// Seçilen güne ait görev varsa o güne ait görevleri ilgili panelde gösterir
        /// </summary>
        /// <param name="gun">secilen gün</param>
        /// <param name="ay">secilen ay</param>
        private void GunlukGorevListeleme(int gun, int ay)
        {
            // lbldakikalisti döngüde düzeltmek lazım
            lblpnl3tarih.Text = gun.ToString() + "." + ay + ".2023";
            Label[] lblSaatList = { lblPnl3Saat1, lblPnl3Saat2, lblPnl3Saat3, lblPnl3Saat4, lblPnl3Saat5, lblPnl3Saat6, lblPnl3Saat7 };
            Label[] lblGorevList = { lblPnl3Gorev1, lblPnl3Gorev2, lblPnl3Gorev3, lblPnl3Gorev4, lblPnl3Gorev5, lblPnl3Gorev6, lblPnl3Gorev7 };
            Label[] lblDakikaList = { lblPnl3Dakika1, lblPnl3Dakika2, lblPnl3Dakika3, lblPnl3Dakika4, lblPnl3Dakika5, lblPnl3Dakika6, lblPnl3Dakika7 };
            int i = 0;
            SqlConnection conn = new SqlConnection("Server=localhost\\SQLEXPRESS;Database=Calendar;Trusted_Connection=True;");
            SqlCommand sqlCommand = new SqlCommand("SELECT *FROM ToDo WHERE ay=" + ay + " AND gün=" + gun + " ORDER BY saat,dakika ASC", conn);
            conn.Open();
            SqlDataReader rd = sqlCommand.ExecuteReader();
            while (rd.Read())
            {
                lblSaatList[i].Visible = true;
                lblSaatList[i].Text = rd["saat"].ToString();
                lblGorevList[i].Visible = true;
                lblGorevList[i].Text = rd["görev"].ToString();
                lblDakikaList[i].Visible = true;
                lblDakikaList[i].Text = "." + rd["dakika"].ToString();
                i++;
            }
            conn.Close();
        }

        /// <summary>
        /// Seçilen gün için yapılacak eylemleri yapan metottur
        /// </summary>
        /// <param name="ay"></param>
        private void ButtonCode(int ay)
        {
            Label[] lblSaatList = { lblPnl3Saat1, lblPnl3Saat2, lblPnl3Saat3, lblPnl3Saat4, lblPnl3Saat5, lblPnl3Saat6, lblPnl3Saat7 };
            Label[] lblGorevList = { lblPnl3Gorev1, lblPnl3Gorev2, lblPnl3Gorev3, lblPnl3Gorev4, lblPnl3Gorev5, lblPnl3Gorev6, lblPnl3Gorev7 };
            Label[] lblDakikaList = { lblPnl3Dakika1, lblPnl3Dakika2, lblPnl3Dakika3, lblPnl3Dakika4, lblPnl3Dakika5, lblPnl3Dakika6, lblPnl3Dakika7 };
            for (int i = 0; i < 7; i++)
            {
                lblSaatList[i].Text = "";
                lblGorevList[i].Text = "";
                lblDakikaList[i].Text = "";
            }
            pnl3ToDoList.Visible = true;
            txtbxgörev.Text = "";
            txtbxSaat.Text = "";
            lblpnl2Ay.Text = AyDondur(ay);
            lblpnl2Gun.Text = secilenGun.ToString();
            pnlAddToDo.Visible = true;
        }





        private void button28_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button28.Text);
            ButtonCode(anlikAy);
        }

        private void button37_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button37.Text);
            ButtonCode(anlikAy);
        }

        private void button38_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button38.Text);
            ButtonCode(anlikAy);
        }

        private void button39_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button39.Text);
            ButtonCode(anlikAy);
        }

        private void button40_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button40.Text);
            ButtonCode(anlikAy);
        }

        private void button41_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button41.Text);
            ButtonCode(anlikAy);
        }

        private void button42_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button42.Text);
            ButtonCode(anlikAy);
        }

        private void button29_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button29.Text);
            ButtonCode(anlikAy);
        }

        private void button30_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button30.Text);
            ButtonCode(anlikAy);
        }

        private void button31_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button31.Text);
            ButtonCode(anlikAy);
        }

        private void button32_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button32.Text);
            ButtonCode(anlikAy);
        }

        private void button33_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button33.Text);
            ButtonCode(anlikAy);
        }

        private void button34_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button34.Text);
            ButtonCode(anlikAy);
        }

        private void button35_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button35.Text);
            ButtonCode(anlikAy);
        }

        private void button22_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button22.Text);
            ButtonCode(anlikAy);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button23.Text);
            ButtonCode(anlikAy);
        }

        private void button24_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button24.Text);
            ButtonCode(anlikAy);
        }

        private void button25_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button25.Text);
            ButtonCode(anlikAy);
        }

        private void button26_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button26.Text);
            ButtonCode(anlikAy);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button27.Text);
            ButtonCode(anlikAy);
        }

        private void button36_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button36.Text);
            ButtonCode(anlikAy);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button15.Text);
            ButtonCode(anlikAy);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button16.Text);
            ButtonCode(anlikAy);
        }

        private void button17_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button17.Text);
            ButtonCode(anlikAy);
        }

        private void button18_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button18.Text);
            ButtonCode(anlikAy);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button19.Text);
            ButtonCode(anlikAy);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button20.Text);
            ButtonCode(anlikAy);
        }

        private void button21_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button21.Text);
            ButtonCode(anlikAy);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button8.Text);
            ButtonCode(anlikAy);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button9.Text);
            ButtonCode(anlikAy);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button10.Text);
            ButtonCode(anlikAy);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button11.Text);
            ButtonCode(anlikAy);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button12.Text);
            ButtonCode(anlikAy);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button13.Text);
            ButtonCode(anlikAy);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button14.Text);
            ButtonCode(anlikAy);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button7.Text);
            ButtonCode(anlikAy);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button6.Text);
            ButtonCode(anlikAy);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button5.Text);
            ButtonCode(anlikAy);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button4.Text);
            ButtonCode(anlikAy);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button3.Text);
            ButtonCode(anlikAy);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button2.Text);
            ButtonCode(anlikAy);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            secilenGun = Int16.Parse(button1.Text);
            ButtonCode(anlikAy);
        }


    }
}
