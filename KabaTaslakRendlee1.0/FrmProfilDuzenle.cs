using DataAccessLayer;
using EntityLayer;
using LogicLayer;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Globalization;

namespace KabaTaslakRendlee1._0
{
    public partial class FrmProfilDuzenle : Form
    {
        private bool isResimGuncellendi = false;
        

        private PictureBoxInteraction pictureBoxInteraction1;
        private PictureBoxInteraction pictureBoxInteraction6;
        private PictureBoxInteraction pictureBoxInteraction7;
        private PictureBoxInteraction pictureBoxInteraction8;


        // Timer nesnesini başlatın (Form yüklenirken bir kez oluşturun)
        private Timer timer1 = new Timer();

        public FrmProfilDuzenle()
        {
            InitializeComponent();
            InitializeUI();
            // PictureBoxInteraction nesnelerini oluşturun ve PictureBox ile Label nesnelerini geçirin
            pictureBoxInteraction1 = new PictureBoxInteraction(pictureBox1, labelKaydirma);
            pictureBoxInteraction6 = new PictureBoxInteraction(pictureBox6, labelEslesmeler);
            pictureBoxInteraction7 = new PictureBoxInteraction(pictureBox7, labelBegeniler);
            pictureBoxInteraction8 = new PictureBoxInteraction(pictureBox8, labelProfil);

            // Timer'ı yapılandır
            timer1.Tick += Timer1_Tick;
            timer1.Interval = 1000;

        }
        private void InitializeUI()
        {
            CustomRoundedButton btnGuncelle = new CustomRoundedButton();
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.Size = new System.Drawing.Size(171, 40);
            btnGuncelle.Location = new System.Drawing.Point(20,403); // Yükseklik değerini isteğinize göre ayarlayabilirsiniz
            btnGuncelle.BackColor = Color.LightGray; // İstediğiniz bir renk seçebilirsiniz
            btnGuncelle.Click += BtnGuncelle_Click; // Güncelle butonuna tıklama olayı ataması
            Controls.Add(btnGuncelle);

            
        }
        public string Email { get; set; }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            label2.Visible = false; // Mesajı gizle
            timer1.Stop(); // Timer'ı durdur
        }

        private void pictureProfil_Click(object sender, EventArgs e)
        {
            // Resim Seç seçeneği
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png|Tüm Dosyalar|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = openFileDialog.FileName;

                // Dosya uzantısını kontrol et
                string dosyaUzantisi = Path.GetExtension(dosyaYolu).ToLower();
                if (dosyaUzantisi != ".jpg" && dosyaUzantisi != ".jpeg" && dosyaUzantisi != ".png")
                {
                   
                    label2.Visible = true;
                    label2.Text = "Resminiz güncellenemedi.";
                    timer1.Start(); // Timer'ı başlat
                    return;
                }

                pictureProfil.Image = System.Drawing.Image.FromFile(dosyaYolu);

                // Resim değiştirildiğinde aşağıdaki kodla güncelleme yapabilirsiniz.
                try
                {
                    EntityKullanici ent = new EntityKullanici();
                    ent.Email = Email;

                    // Resim verisini al
                    byte[] yeniResimVerisi;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        pictureProfil.Image.Save(ms, ImageFormat.Jpeg);
                        yeniResimVerisi = ms.ToArray();
                    }

                    bool isResimGuncellendi = LogicKullanici.ResimKaydet(ent, yeniResimVerisi);

                    if (isResimGuncellendi)
                    {
                       
                        label2.Visible = true;
                        label2.Text = "Resminiz güncellendi.";
                        timer1.Start(); // Timer'ı başlat
                    }
                    else
                    {
                        
                        label2.Visible = true;
                        label2.Text = "Resminiz güncellenemedi.";
                        timer1.Start(); // Timer'ı başlat
                        
                    }
                }
                catch (Exception ex)
                {
                    
                    label2.Visible = true;
                    label2.Text = "Resminiz güncellenemedi.";
                    timer1.Start(); // Timer'ı başlat

                }
                finally
                {
                    Baglanti.bgl.Close(); // Bağlantıyı kapat
                }
            }
        }

        string dogumtarihi;

        private void BtnGuncelle_Click(object sender, EventArgs e)
{
    try
    {
        if (string.IsNullOrEmpty(rchtxtaciklama.Text) || string.IsNullOrEmpty(LABELAD.Text) ||
             string.IsNullOrEmpty(MskTelefon.Text) ||
            string.IsNullOrEmpty(TxtSifre.Text) || string.IsNullOrEmpty(dogumtarihi) ||
            string.IsNullOrEmpty(Email))
        {
            MessageBox.Show("Tüm bilgileri eksiksiz doldurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        EntityKullanici ent = new EntityKullanici();
        ent.Aciklama = rchtxtaciklama.Text;
        ent.Email = Email;
        ent.Ad = LABELAD.Text;
       
        ent.Telefon = MskTelefon.Text;
        ent.Sifre = TxtSifre.Text;
        ent.Tarih = Convert.ToDateTime(dogumtarihi);

        

        bool success = LogicKullanici.LLKullanicilGuncelle(ent);

        if (success)
        {
            MessageBox.Show("Kullanıcı güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            MessageBox.Show("Kullanıcı güncellenemedi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    catch (Exception ex)
    {
        MessageBox.Show("Hata:" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
    finally
    {
        Baglanti.bgl.Close(); // Bağlantıyı kapat
    }
}

        private void YasLabeliniGuncelle(DateTime dogumTarihi)
        {
            DateTime bugun = DateTime.Now;
            int yas = bugun.Year - dogumTarihi.Year;

            if (bugun.Month < dogumTarihi.Month || (bugun.Month == dogumTarihi.Month && bugun.Day < dogumTarihi.Day))
            {
                yas--;
            }

            labelyas.Text = yas.ToString(); // Yaş etiketini güncelle
        }

        private async void FrmProfilDuzenle_Load(object sender, EventArgs e)
        {
            await FormAnimation.SlideDown(this, 500); // Bu, yeni formun açılma animasyonunu çalıştırır.
            try
            {
                SqlCommand komut = new SqlCommand("SELECT * FROM TblKullanicilar WHERE EMAIL=@EMAIL", Baglanti.bgl);
                komut.Parameters.AddWithValue("@EMAIL", Email);

                Baglanti.bgl.Open();

                SqlDataReader dr = komut.ExecuteReader();
                if (dr.Read())
                {
                    LABELAD.Text = dr[1].ToString();
                   
                    txtemail.Text = dr[3].ToString();
                    MskTelefon.Text = dr[4].ToString();
                    TxtSifre.Text = dr[5].ToString();
                    dogumtarihi = Convert.ToDateTime(dr[7]).ToString("dd/MM/yyyy");
                    rchtxtaciklama.Text = dr[8].ToString();

                    // Doğum tarihi sütununu DateTime olarak doğrudan alın
                    DateTime? dogumTarihi = dr.IsDBNull(7) ? (DateTime?)null : dr.GetDateTime(7);
                    if (dogumTarihi != null)
                    {
                        dogumtarihi = dogumTarihi.Value.ToString("dd/MM/yyyy");
                        YasLabeliniGuncelle(dogumTarihi.Value);
                    }
                    else
                    {
                        dogumtarihi = string.Empty; // Eğer doğum tarihi null ise, metni boş bırakabilirsiniz.
                    }

                    // Resim sütunundan veriyi al
                    byte[] resimVerisi = (byte[])dr[9];

                    // Resmi MemoryStream'e yükle
                    MemoryStream ms = new MemoryStream(resimVerisi);
                    pictureProfil.Image = System.Drawing.Image.FromStream(ms);
                    ms.Close();
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (Baglanti.bgl.State == ConnectionState.Open)
                    Baglanti.bgl.Close();
            }
            labelKaydirma.Visible = false;
            labelBegeniler.Visible = false;
            labelEslesmeler.Visible = false;
            labelProfil.Visible = false;

            
            

        }








     

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            FrmAnaSayfa fr = new FrmAnaSayfa();
            fr.Email = GlobalVeriler.Email;
            fr.Show();
            this.Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            FrmMesajlar fr = new FrmMesajlar();
            fr.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

            foreach (Form frm in Application.OpenForms)
            {
                if (frm is FrmProfilDuzenle)
                {
                    // Form zaten açıksa, bu formu yeniden açmak yerine odaklayın.
                    frm.Focus();
                    return;
                }
            }

            FrmProfilDuzenle fr = new FrmProfilDuzenle();
            fr.Email = GlobalVeriler.Email;
            fr.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            FrmAyarlar fr = new FrmAyarlar();
            fr.Show();
            this.Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            FrmBegeniler fr = new FrmBegeniler();
            fr.Show();
            this.Hide();
        }

        private void rchtxtaciklama_Click(object sender, EventArgs e)
        {
            label1.Visible = false;
        }

        private void rchtxtaciklama_TextChanged(object sender, EventArgs e)
        {
            label1.Visible = string.IsNullOrWhiteSpace(rchtxtaciklama.Text);
        }
    }
}
