using EntityLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KabaTaslakRendlee1._0
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
            
        }
      
        private void btnGirisYap_Click(object sender, EventArgs e)
        {
            
            string email = txtemail.Text;
            string girilenSifre = TxtSifre.Text; // Kullanıcının girdiği şifre
            LogicKullanici logic = new LogicKullanici();
            DataTable result = logic.LLKullaniciGiris(email, girilenSifre);

            if (result.Rows.Count > 0)
            {
                GlobalVeriler.Email = email;
                FrmAnaSayfa fr = new FrmAnaSayfa();
                fr.Text = txtemail.Text;
                fr.Show();
                this.Hide();
            }
            else
            {
                // Giriş başarısız, hatalı şifre
                MessageBox.Show("Yanlış şifre girdiniz. Lütfen tekrar deneyin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      

        private void txtemail_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
        }

        private void TxtSifre_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Frmbaglantilar fr = new Frmbaglantilar();
            fr.Show();
            this.Hide();
        }
    }
}
