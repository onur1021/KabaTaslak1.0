using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KabaTaslakRendlee1._0
{
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
            InitializeUI();
        }
        private void InitializeUI()
        {
            CustomRoundedButton btncikis = new CustomRoundedButton();
            btncikis.Text = "ÇIKIŞ";
            btncikis.Size = new System.Drawing.Size(120,40);
            btncikis.Location = new System.Drawing.Point(77, 414); // Yükseklik değerini isteğinize göre ayarlayabilirsiniz
            btncikis.BackColor = Color.LightGray; // İstediğiniz bir renk seçebilirsiniz
            btncikis.Click += button1_Click; // Kayıt Yap butonuna tıklama olayı ataması
            Controls.Add(btncikis);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frmbaglantilar fr = new Frmbaglantilar();
            fr.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            FrmProfilDuzenle fr=new FrmProfilDuzenle();
            fr.Email = GlobalVeriler.Email;
            fr.Show();
            this.Hide();
        }

        private async void FrmAyarlar_Load(object sender, EventArgs e)
        {
            await FormAnimation.SlideRight(this, 500); // Mevcut formun kaybolma animasyonunu çalıştırır.
        }
    }
}
