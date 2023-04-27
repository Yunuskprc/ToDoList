namespace ToDoListApp
{
    partial class GirisEkran
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnGiris = new Button();
            txtbxKAdi = new TextBox();
            txtbxSifre = new TextBox();
            pctrbxKAdi = new PictureBox();
            pctrbxSifre = new PictureBox();
            pictureBox1 = new PictureBox();
            btnKayitEkran = new Button();
            ((System.ComponentModel.ISupportInitialize)pctrbxKAdi).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pctrbxSifre).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // btnGiris
            // 
            btnGiris.BackgroundImage = Properties.Resources.btn_girisyap;
            btnGiris.FlatAppearance.BorderSize = 0;
            btnGiris.FlatStyle = FlatStyle.Flat;
            btnGiris.Location = new Point(695, 383);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(180, 50);
            btnGiris.TabIndex = 0;
            btnGiris.UseVisualStyleBackColor = true;
            btnGiris.Click += btnGiris_Click;
            // 
            // txtbxKAdi
            // 
            txtbxKAdi.BackColor = Color.FromArgb(199, 198, 198);
            txtbxKAdi.BorderStyle = BorderStyle.None;
            txtbxKAdi.ForeColor = Color.DimGray;
            txtbxKAdi.Location = new Point(700, 257);
            txtbxKAdi.Name = "txtbxKAdi";
            txtbxKAdi.Size = new Size(166, 16);
            txtbxKAdi.TabIndex = 1;
            txtbxKAdi.Text = "Kullanıcı Adı:";
            txtbxKAdi.TextAlign = HorizontalAlignment.Center;
            // 
            // txtbxSifre
            // 
            txtbxSifre.BackColor = Color.FromArgb(199, 198, 198);
            txtbxSifre.BorderStyle = BorderStyle.None;
            txtbxSifre.ForeColor = Color.DimGray;
            txtbxSifre.Location = new Point(700, 333);
            txtbxSifre.Name = "txtbxSifre";
            txtbxSifre.PasswordChar = '*';
            txtbxSifre.Size = new Size(166, 16);
            txtbxSifre.TabIndex = 2;
            txtbxSifre.Text = "******";
            txtbxSifre.TextAlign = HorizontalAlignment.Center;
            // 
            // pctrbxKAdi
            // 
            pctrbxKAdi.BackgroundImage = Properties.Resources.rounded_rectangle;
            pctrbxKAdi.Location = new Point(670, 240);
            pctrbxKAdi.Name = "pctrbxKAdi";
            pctrbxKAdi.Size = new Size(225, 50);
            pctrbxKAdi.TabIndex = 3;
            pctrbxKAdi.TabStop = false;
            // 
            // pctrbxSifre
            // 
            pctrbxSifre.BackgroundImage = Properties.Resources.rounded_rectangle;
            pctrbxSifre.Location = new Point(670, 315);
            pctrbxSifre.Name = "pctrbxSifre";
            pctrbxSifre.Size = new Size(225, 50);
            pctrbxSifre.TabIndex = 4;
            pctrbxSifre.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.TurDev_logo;
            pictureBox1.Location = new Point(737, 96);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // btnKayitEkran
            // 
            btnKayitEkran.BackColor = Color.FromArgb(233, 234, 235);
            btnKayitEkran.FlatAppearance.BorderSize = 0;
            btnKayitEkran.FlatStyle = FlatStyle.Flat;
            btnKayitEkran.Font = new Font("Segoe UI Symbol", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnKayitEkran.ForeColor = Color.FromArgb(69, 179, 177);
            btnKayitEkran.Location = new Point(655, 451);
            btnKayitEkran.Name = "btnKayitEkran";
            btnKayitEkran.Size = new Size(251, 28);
            btnKayitEkran.TabIndex = 6;
            btnKayitEkran.Text = "Hesabınız yok mu? Üye olun";
            btnKayitEkran.UseVisualStyleBackColor = false;
            btnKayitEkran.Click += btnKayitEkran_Click;
            // 
            // GirisEkran
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.login_page_background;
            ClientSize = new Size(984, 561);
            Controls.Add(btnKayitEkran);
            Controls.Add(pictureBox1);
            Controls.Add(txtbxSifre);
            Controls.Add(txtbxKAdi);
            Controls.Add(btnGiris);
            Controls.Add(pctrbxKAdi);
            Controls.Add(pctrbxSifre);
            FormBorderStyle = FormBorderStyle.None;
            Name = "GirisEkran";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GirisEkran";
            ((System.ComponentModel.ISupportInitialize)pctrbxKAdi).EndInit();
            ((System.ComponentModel.ISupportInitialize)pctrbxSifre).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnGiris;
        private TextBox txtbxKAdi;
        private TextBox txtbxSifre;
        private PictureBox pctrbxKAdi;
        private PictureBox pctrbxSifre;
        private PictureBox pictureBox1;
        private Button btnKayitEkran;
    }
}