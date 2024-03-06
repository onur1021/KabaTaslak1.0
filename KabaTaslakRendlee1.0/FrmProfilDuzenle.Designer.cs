namespace KabaTaslakRendlee1._0
{
    partial class FrmProfilDuzenle
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProfilDuzenle));
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtSifre = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.LABELAD = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MskTelefon = new System.Windows.Forms.MaskedTextBox();
            this.txtemail = new System.Windows.Forms.TextBox();
            this.rchtxtaciklama = new System.Windows.Forms.RichTextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureProfil = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.labelProfil = new System.Windows.Forms.Label();
            this.labelBegeniler = new System.Windows.Forms.Label();
            this.labelEslesmeler = new System.Windows.Forms.Label();
            this.labelKaydirma = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.labelyas = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfil)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Enabled = false;
            this.btnGuncelle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGuncelle.Location = new System.Drawing.Point(20, 403);
            this.btnGuncelle.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(171, 40);
            this.btnGuncelle.TabIndex = 20;
            this.btnGuncelle.Text = "GÜNCELLE";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Visible = false;
            this.btnGuncelle.Click += new System.EventHandler(this.BtnGuncelle_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 347);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 18);
            this.label6.TabIndex = 52;
            this.label6.Text = "Şifre:";
            // 
            // TxtSifre
            // 
            this.TxtSifre.Location = new System.Drawing.Point(21, 370);
            this.TxtSifre.Name = "TxtSifre";
            this.TxtSifre.Size = new System.Drawing.Size(172, 24);
            this.TxtSifre.TabIndex = 2;
            this.TxtSifre.Text = "3333";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 18);
            this.label5.TabIndex = 51;
            this.label5.Text = "Email:.";
            // 
            // LABELAD
            // 
            this.LABELAD.AutoSize = true;
            this.LABELAD.Font = new System.Drawing.Font("Georgia", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LABELAD.Location = new System.Drawing.Point(66, 110);
            this.LABELAD.Name = "LABELAD";
            this.LABELAD.Size = new System.Drawing.Size(57, 23);
            this.LABELAD.TabIndex = 48;
            this.LABELAD.Text = "Adım";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 18);
            this.label4.TabIndex = 50;
            this.label4.Text = "Telefon:";
            // 
            // MskTelefon
            // 
            this.MskTelefon.Enabled = false;
            this.MskTelefon.Location = new System.Drawing.Point(19, 274);
            this.MskTelefon.Name = "MskTelefon";
            this.MskTelefon.Size = new System.Drawing.Size(172, 24);
            this.MskTelefon.TabIndex = 45;
            this.MskTelefon.Text = "5154562659";
            // 
            // txtemail
            // 
            this.txtemail.Enabled = false;
            this.txtemail.Location = new System.Drawing.Point(19, 324);
            this.txtemail.Name = "txtemail";
            this.txtemail.Size = new System.Drawing.Size(172, 24);
            this.txtemail.TabIndex = 53;
            this.txtemail.Text = "abdul@gmail.com";
            // 
            // rchtxtaciklama
            // 
            this.rchtxtaciklama.Location = new System.Drawing.Point(20, 149);
            this.rchtxtaciklama.Name = "rchtxtaciklama";
            this.rchtxtaciklama.Size = new System.Drawing.Size(244, 95);
            this.rchtxtaciklama.TabIndex = 1;
            this.rchtxtaciklama.Text = "";
            this.rchtxtaciklama.Click += new System.EventHandler(this.rchtxtaciklama_Click);
            this.rchtxtaciklama.TextChanged += new System.EventHandler(this.rchtxtaciklama_TextChanged);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(228, 6);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(41, 34);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 68;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // pictureProfil
            // 
            this.pictureProfil.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureProfil.Location = new System.Drawing.Point(64, 9);
            this.pictureProfil.Name = "pictureProfil";
            this.pictureProfil.Size = new System.Drawing.Size(138, 97);
            this.pictureProfil.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureProfil.TabIndex = 67;
            this.pictureProfil.TabStop = false;
            this.pictureProfil.Click += new System.EventHandler(this.pictureProfil_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox8);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.pictureBox6);
            this.panel2.Controls.Add(this.pictureBox7);
            this.panel2.Location = new System.Drawing.Point(2, 464);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(265, 49);
            this.panel2.TabIndex = 70;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(213, 7);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(41, 34);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 7;
            this.pictureBox8.TabStop = false;
            this.pictureBox8.Click += new System.EventHandler(this.pictureBox8_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(10, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 34);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(81, 6);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(41, 34);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 5;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(147, 7);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(41, 34);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 6;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.pictureBox7_Click);
            // 
            // labelProfil
            // 
            this.labelProfil.AutoSize = true;
            this.labelProfil.BackColor = System.Drawing.Color.LightGray;
            this.labelProfil.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelProfil.Location = new System.Drawing.Point(214, 446);
            this.labelProfil.Name = "labelProfil";
            this.labelProfil.Size = new System.Drawing.Size(41, 18);
            this.labelProfil.TabIndex = 74;
            this.labelProfil.Text = "Profil";
            // 
            // labelBegeniler
            // 
            this.labelBegeniler.AutoSize = true;
            this.labelBegeniler.BackColor = System.Drawing.Color.LightGray;
            this.labelBegeniler.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelBegeniler.Location = new System.Drawing.Point(136, 446);
            this.labelBegeniler.Name = "labelBegeniler";
            this.labelBegeniler.Size = new System.Drawing.Size(65, 18);
            this.labelBegeniler.TabIndex = 73;
            this.labelBegeniler.Text = "Beğeniler";
            // 
            // labelEslesmeler
            // 
            this.labelEslesmeler.AutoSize = true;
            this.labelEslesmeler.BackColor = System.Drawing.Color.LightGray;
            this.labelEslesmeler.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelEslesmeler.Location = new System.Drawing.Point(66, 445);
            this.labelEslesmeler.Name = "labelEslesmeler";
            this.labelEslesmeler.Size = new System.Drawing.Size(72, 18);
            this.labelEslesmeler.TabIndex = 72;
            this.labelEslesmeler.Text = "Eşleşmeler";
            // 
            // labelKaydirma
            // 
            this.labelKaydirma.AutoSize = true;
            this.labelKaydirma.BackColor = System.Drawing.Color.LightGray;
            this.labelKaydirma.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelKaydirma.Location = new System.Drawing.Point(12, 446);
            this.labelKaydirma.Name = "labelKaydirma";
            this.labelKaydirma.Size = new System.Drawing.Size(186, 18);
            this.labelKaydirma.TabIndex = 71;
            this.labelKaydirma.Text = "Rendlee Profillerini Görüntüle";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 18);
            this.label9.TabIndex = 75;
            this.label9.Text = "old";
            // 
            // labelyas
            // 
            this.labelyas.AutoSize = true;
            this.labelyas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelyas.Location = new System.Drawing.Point(129, 112);
            this.labelyas.Name = "labelyas";
            this.labelyas.Size = new System.Drawing.Size(53, 20);
            this.labelyas.TabIndex = 76;
            this.labelyas.Text = "Yaşım";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(23, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 18);
            this.label1.TabIndex = 77;
            this.label1.Text = "Kendinizden bahsedin:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(136)))), ((int)(((byte)(145)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 17);
            this.label2.TabIndex = 78;
            this.label2.Text = "Boşlukları Doldurunuz";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label2.Visible = false;
            // 
            // FrmProfilDuzenle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(136)))), ((int)(((byte)(145)))));
            this.ClientSize = new System.Drawing.Size(271, 517);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelyas);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.labelProfil);
            this.Controls.Add(this.labelBegeniler);
            this.Controls.Add(this.labelEslesmeler);
            this.Controls.Add(this.labelKaydirma);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureProfil);
            this.Controls.Add(this.rchtxtaciklama);
            this.Controls.Add(this.txtemail);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.TxtSifre);
            this.Controls.Add(this.MskTelefon);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.LABELAD);
            this.Controls.Add(this.btnGuncelle);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmProfilDuzenle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmProfilDuzenle_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureProfil)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtSifre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label LABELAD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox MskTelefon;
        private System.Windows.Forms.TextBox txtemail;
        private System.Windows.Forms.RichTextBox rchtxtaciklama;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureProfil;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.Label labelProfil;
        private System.Windows.Forms.Label labelBegeniler;
        private System.Windows.Forms.Label labelEslesmeler;
        private System.Windows.Forms.Label labelKaydirma;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label labelyas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

