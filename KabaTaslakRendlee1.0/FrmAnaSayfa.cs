using DataAccessLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace KabaTaslakRendlee1._0
{
    public partial class FrmAnaSayfa : Form
    {

        private BegeniLogic begeniLogic;


        public string Email { get; set; }

        private PictureBoxInteraction pictureBoxInteraction2;
        private PictureBoxInteraction pictureBoxInteraction6;
        private PictureBoxInteraction pictureBoxInteraction7;
        private PictureBoxInteraction pictureBoxInteraction8;

       

        public FrmAnaSayfa()
        {
            InitializeComponent();
            // PictureBoxInteraction nesnelerini oluşturun ve PictureBox ile Label nesnelerini geçirin
            pictureBoxInteraction2 = new PictureBoxInteraction(pictureBox2, labelKaydirma);
            pictureBoxInteraction6 = new PictureBoxInteraction(pictureBox6, labelEslesmeler);
            pictureBoxInteraction7 = new PictureBoxInteraction(pictureBox7, labelBegeniler);
            pictureBoxInteraction8 = new PictureBoxInteraction(pictureBox8, labelProfil);
            BegeniLogic begeniLogic = new BegeniLogic();
           
        }

       


        // FrmAnaSayfa formundan email değerini almak için özellik

        private async void  pictureBox8_Click(object sender, EventArgs e)
        {
            
            FrmProfilDuzenle fr = new FrmProfilDuzenle();
            fr.Email = GlobalVeriler.Email;
            fr.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Kontrol edilecek formun tipine uygun bir koleksiyon oluşturun.
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is FrmAnaSayfa)
                {
                    // Form zaten açıksa, bu formu yeniden açmak yerine odaklayın.
                    frm.Focus();
                    return;
                }
            }

            // Form daha önce açılmamışsa yeni bir örneğini oluşturun.
            FrmAnaSayfa fr = new FrmAnaSayfa();
            fr.Email = GlobalVeriler.Email;
            fr.Show();
            this.Hide();
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            
           
            string email = GlobalVeriler.Email;
            labelKaydirma.Visible = false;
            labelBegeniler.Visible = false;
            labelEslesmeler.Visible = false;
            labelProfil.Visible = false;
        }
       

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmMesajlar fr = new FrmMesajlar();
            fr.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FrmBegeniler fr = new FrmBegeniler();
           
            fr.Show();
            this.Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            try
            {
              
                string begenenEmail = GlobalVeriler.Email; // Beğenen kullanıcının e-postası
                string begenilenEmail = "abdul@gmail.com"; // Beğenilen kullanıcının e-postası
                DateTime zaman = DateTime.Now;

                BegeniLogic begeniLogic = new BegeniLogic();
                bool beğenmeSonuc = begeniLogic.BegeniYap(begenenEmail, begenilenEmail, zaman);

                if (beğenmeSonuc)
                {
                    // Beğenme işlemi başarılıysa kullanıcıya geri bildirim verin
                    MessageBox.Show("Kişiyi beğendiniz!");
                }
                else
                {
                    // Beğenme işlemi başarısızsa hata mesajı gösterin
                    MessageBox.Show("Bir hata oluştu. Lütfen tekrar deneyin.");
                }
            }
           
            catch (Exception ex)
            {
                // Diğer hatalar için genel hata mesajı
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private async Task SlideLeftAsync()
        {
            int originalLeft = panel1.Left;
            int targetLeft = -panel1.Width;

            for (int i = 0; i <= panel1.Width; i += 10)
            {
                panel1.Left = originalLeft - i;
                await Task.Delay(10);
            }

            panel1.Left = targetLeft;

            // Profil resmini değiştirin veya güncelleyin
            try
            {
                BegeniLogic begeniLogic = new BegeniLogic();
                byte[] imageBytes = begeniLogic.GetProfilFotografi();

                if (imageBytes != null && imageBytes.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        panel1.BackgroundImage = Image.FromStream(ms);
                        panel1.BackgroundImageLayout = ImageLayout.Stretch; // Resmi PictureBox'a sığdırın
                    }
                }
                else
                {
                    // E-posta adresine ait resim bulunamadı veya bir hata oluştu.
                    MessageBox.Show("Resim bulunamadı veya bir hata oluştu.");
                }
            }
            catch (Exception ex)
            {
                // Hata işleme kodları burada
                MessageBox.Show("Hata: " + ex.ToString());
            }

            // Profil resmini kaydırılan konuma geri getirin
            panel1.Left = originalLeft;
        }


        private async void pictureBox4_Click(object sender, EventArgs e)
        {
            await SlideLeftAsync();
        }
    }
}
