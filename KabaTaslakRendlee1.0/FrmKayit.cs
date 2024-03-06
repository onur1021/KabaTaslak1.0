using DataAccessLayer;
using EntityLayer;
using LogicLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KabaTaslakRendlee1._0
{
    public partial class FrmKayit : Form
    {
        public FrmKayit()
        {
            InitializeComponent();
            InitializeUI();
            pictureProfil.Image = null;
        }
        private void InitializeUI()
        {
            CustomRoundedButton btnKayit = new CustomRoundedButton();
            btnKayit.Text = "Kayıt Yap";
            btnKayit.Size = new System.Drawing.Size(181, 37);
            btnKayit.Location = new System.Drawing.Point(54, 381); // Yükseklik değerini isteğinize göre ayarlayabilirsiniz
            btnKayit.BackColor = Color.LightGray; // İstediğiniz bir renk seçebilirsiniz
            btnKayit.Click += btnKayitYap_Click; // Kayıt Yap butonuna tıklama olayı ataması
            Controls.Add(btnKayit);
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Frmbaglantilar fr=new Frmbaglantilar();
            fr.Show();
            this.Hide();
        }

        private void btnKayitYap_Click(object sender, EventArgs e)
        {
            // Gerekli bilgilerin doldurulup doldurulmadığını kontrol et
            if (string.IsNullOrEmpty(TxtAd.Text) || string.IsNullOrEmpty(txtSoyad.Text) ||
                string.IsNullOrEmpty(txtemail.Text) || string.IsNullOrEmpty(txttelefon.Text) ||
                string.IsNullOrEmpty(TxtSifre.Text) || string.IsNullOrEmpty(CmbCinsiyet.Text) ||
                string.IsNullOrEmpty(mskTarih.Text) || pictureProfil.Image == null)
            {
                label2.Visible = false;
                label1.Visible = true;
                label1.Text = "Tüm bilgileri eksiksiz doldurunuz ve profil resmi ekleyiniz.";
                return;
            }

            // İlgili giriş bilgilerini al ve kontrol et
            string ad = TxtAd.Text;
            string soyad = txtSoyad.Text;
            string email = txtemail.Text;
            string telefon = txttelefon.Text;
            string sifre = TxtSifre.Text;
            string cinsiyet = CmbCinsiyet.Text;
            string tarih = mskTarih.Text;

            // Kullanıcı adı, soyadı ve diğer bilgileri uygunsuz ifadelere karşı kontrol et
            if (ContainsInappropriateWords(ad) || ContainsInappropriateWords(soyad) || ContainsInappropriateWords(email))
            {
                label1.Visible = true;
                label1.Text = "Uygunsuz ifadeler içeren bilgi girdiniz.";
                label2.Visible = true;
                label2.Text = "Lütfen geçerli bilgi giriniz.";
                return;
            }

            // E-posta adresini kontrol et
            if (IsEmailAlreadyRegistered(email))
            {
                txtemail.Focus();
                label2.Visible = false;
                label1.Visible = true;
                label1.Text = "Bu e-posta zaten kayıtlı.";
                return;
            }

            if (IsPhoneNumberAlreadyRegistered(telefon))
            {
                txttelefon.Focus();
                label2.Visible = false;
                label1.Visible = true;
                label1.Text = "Bu telefon numarası zaten kayıtlı.";
                return;
            }

            if (HasRepeatingCharacters(TxtSifre.Text))
            {
                TxtSifre.Focus();
                label2.Visible = true;
                label1.Visible = true;
                label1.Text = "Aynı karakterler tekrarlanamaz.";
                label2.Text = "Lütfen yeni bir şifre giriniz";
                return;
            }

            if (HasSequentialNumbers(TxtSifre.Text))
            {
                TxtSifre.Focus();
                label2.Visible = true;
                label1.Visible = true;
                label1.Text = "Şifrenizde ardışık sayılar bulunamaz.";
                label2.Text = "Lütfen yeni bir şifre giriniz";
                return;
            }

            if (!HasAtLeastOneLetterAndOneDigit(TxtSifre.Text))
            {
                TxtSifre.Focus();
                label2.Visible = true;
                label1.Visible = true;
                label1.Text = "Şifrenizde en az bir harf ve bir sayı olmalıdır.";
                label2.Text = "Lütfen yeni bir şifre giriniz";
                return;
            }

            string dgmtarih = mskTarih.Text;

            // Şifre içerisinde doğum tarihini kontrol et
            if (DoesPasswordContainDate(TxtSifre.Text, dgmtarih))
            {
                TxtSifre.Focus();
                label2.Visible = true;
                label1.Visible = true;
                label1.Text = "Şifreniz doğum tarihinizi içeremez.";
                label2.Text = "Lütfen yeni bir şifre giriniz";
                return;
            }

            if (DoesPasswordContainName(TxtSifre.Text.ToLower(), TxtAd.Text.ToLower(), txtSoyad.Text.ToLower()))
            {
                TxtSifre.Focus();
                label2.Visible = true;
                label1.Visible = true;
                label1.Text = "Şifreniz adınız veya soyadınızı içeremez.";
                label2.Text = "Lütfen yeni bir şifre giriniz";
                return;
            }


            pictureBox2.Visible = false;
            EntityKullanici ent = new EntityKullanici();
            ent.Ad = ad;
            ent.Soyad = soyad;
            ent.Email = email;
            ent.Telefon = telefon;
            ent.Sifre = sifre;
            ent.Cinsiyet = cinsiyet;

            if (DateTime.TryParseExact(tarih, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime dogumTarihi))
            {
                int yas = DateTime.Now.Year - dogumTarihi.Year;
                if (DateTime.Now.Month < dogumTarihi.Month || (DateTime.Now.Month == dogumTarihi.Month && DateTime.Now.Day < dogumTarihi.Day))
                {
                    yas--;
                }

                if (yas >= 18)
                {
                    ent.Tarih = dogumTarihi;

                  

                    // Şifre uzunluğunu kontrol et
                    if (TxtSifre.Text.Length < 4)
                    {

                        TxtSifre.Focus();

                        label1.Visible = true;      
                        label2.Visible = true;
                        label1.Text = "Şifreniz en az 4 haneli olmalıdır.";
                        label2.Text="Lütfen yeni bir şifre giriniz";
                        return;
                    }

                    // Resim seçme işlemi
                    byte[] resimVerisi = null;
                    if (pictureProfil.Image != null)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            pictureProfil.Image.Save(ms, ImageFormat.Jpeg);
                            resimVerisi = ms.ToArray();
                        }
                    }

                    // Kullanıcı adı, soyadı ve diğer bilgileri tekrar kontrol et (kayıt öncesinde)
                    if (!ContainsInappropriateWords(ent.Ad) && !ContainsInappropriateWords(ent.Soyad) && !ContainsInappropriateWords(ent.Email))
                    {
                        int result = LogicKullanici.LLKullaniciKayit(ent, ent.Telefon, ent.Cinsiyet, ent.Tarih.ToString("dd.MM.yyyy"), resimVerisi);

                        if (result > 0)
                        {

                            MessageBox.Show("Kullanıcı Kaydınız Yapılmıştır", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FrmGiris fr = new FrmGiris();
                            fr.Show();
                            this.Hide();
                        }
                        else
                        {
                            label2.Visible = false;
                            label1.Visible = true;
                            label1.Text = "Kayıt sırasında bir hata oluştu.";
                            
                        }
                    }
                    else
                    {
                        label1.Visible = true;
                        label1.Text = "Uygunsuz ifadeler içeren bilgi girdiniz.";
                        label2.Visible = true;
                        label2.Text = "Lütfen geçerli bilgi giriniz.";
                    }
                }
                else
                {
                    label2.Visible = false;
                    mskTarih.Focus();
                    label1.Visible = true;
                    label1.Text = "18 yaşından küçükler kayıt olamaz";
                   
                }
            }
            else
            {
                label2.Visible = false;
                label1.Visible = true;
                label1.Text = "Geçerli bir tarih formatı giriniz (örn. 01.01.2000)";
                
                if (mskTarih.MaskFull)
                {
                    label14.Visible = false; // Tarih girilmişse etiketi gizle
                }
                else
                {
                    
                    label14.Visible = true; // Tarih girilmemişse etiketi görünür yap
                }
            }
        }

        private static bool IsEmailAlreadyRegistered(string email)
        {
            try
            {
                Baglanti.bgl.Open();

                using (SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM TBLKullanicilar WHERE EMAIL = @Email", Baglanti.bgl))
                {
                    komut.Parameters.AddWithValue("@Email", email);
                    int count = (int)komut.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi burada yapılabilir
                // Örneğin: Loglama, hata mesajı kullanıcıya gösterme, vb.
                return false; // Hata durumunda false dönebiliriz
            }
            finally
            {
                Baglanti.bgl.Close(); // Her durumda bağlantıyı kapatmak için finally bloğunda kapatıyoruz
            }
        }


        private static bool IsPhoneNumberAlreadyRegistered(string phoneNumber)
        {
            try
            {
                Baglanti.bgl.Open();

                using (SqlCommand komut = new SqlCommand("SELECT COUNT(*) FROM TBLKullanicilar WHERE TELEFON = @Telefon", Baglanti.bgl))
                {
                    komut.Parameters.AddWithValue("@Telefon", phoneNumber);
                    int count = (int)komut.ExecuteScalar();
                    return count > 0;
                }
            }
            catch (Exception ex)
            {
                // Hata yönetimi burada yapılabilir
                // Örneğin: Loglama, hata mesajı kullanıcıya gösterme, vb.
                return false; // Hata durumunda false dönebiliriz
            }
            finally
            {
                Baglanti.bgl.Close(); // Her durumda bağlantıyı kapatmak için finally bloğunda kapatıyoruz
            }
        }

        private bool HasRepeatingCharacters(string password)
        {
            for (int i = 0; i < password.Length - 2; i++)
            {
                if (password[i] == password[i + 1] && password[i] == password[i + 2])
                {
                    return true; // Aynı karakterler üç kez veya daha fazla tekrarlanıyor
                }
            }

            return false; // Aynı karakterler üç kez veya daha fazla tekrarlanmıyor
        }

        private bool HasSequentialNumbers(string password)          //şifrede ardısık sayı var mı ona bakıyo
        {
            int consecutiveCount = 0;

            for (int i = 0; i < password.Length - 1; i++)
            {
                if (char.IsDigit(password[i]) && char.IsDigit(password[i + 1]))
                {
                    int num1 = int.Parse(password[i].ToString());
                    int num2 = int.Parse(password[i + 1].ToString());

                    if (num2 == num1 + 1)
                    {
                        consecutiveCount++;

                        if (consecutiveCount >= 2) // 3 veya daha fazla ardışık sayı bulundu
                        {
                            return true;
                        }
                    }
                    else
                    {
                        consecutiveCount = 0;
                    }
                }
            }

            return false; // 3 veya daha fazla ardışık sayı bulunamadı
        }

        private bool HasAtLeastOneLetterAndOneDigit(string password)  //enaaz 1 harf ve 1 sayı içermek zorunda
        {
            bool hasLetter = false;
            bool hasDigit = false;

            foreach (char c in password)
            {
                if (char.IsLetter(c))
                {
                    hasLetter = true;
                }
                else if (char.IsDigit(c))
                {
                    hasDigit = true;
                }

                if (hasLetter && hasDigit)
                {
                    return true; // Hem harf hem de sayı içeriyor
                }
            }

            return false; // Hem harf hem de sayı içermiyor
        }

        private bool DoesPasswordContainDate(string password, string date)
        {
            // Kullanıcı adını ve şifreyi küçük harfe çeviriyoruz
            password = password.ToLower();
            date = date.ToLower();

            // Şifrede gün, ay ve yıl kombinasyonunu kontrol ediyoruz
            if (password.Contains(date) || password.Contains(date.Replace(".", "")))
            {
                return true; // Şifre, doğum tarihini içeriyor
            }

            // Yılı çıkardıktan sonra tekrar kontrol ediyoruz
            string[] dateParts = date.Split('.');
            if (dateParts.Length == 3)
            {
                string dayMonth = dateParts[0] + dateParts[1];
                string monthDay = dateParts[1] + dateParts[0]; // Aynı kombinasyonun tersi
                if (password.Contains(dayMonth) || password.Contains(monthDay))
                {
                    return true; // Şifre, gün ve ay kombinasyonunu veya ay ve gün kombinasyonunu içeriyor
                }
            }

            // Sadece yılı kontrol ediyoruz
            if (password.Contains(dateParts[2]))
            {
                return true; // Şifre, doğum yılını içeriyor
            }

            return false; // Şifre, doğum tarihini veya yılını içermiyor
        }





        private bool DoesPasswordContainName(string password, string name, string surname)
        {
            // Kullanıcı adını ve soyadını küçük harfe çeviriyoruz
            name = name.ToLower();
            surname = surname.ToLower();

            // Şifrede ad veya soyad varsa true döner
            if (password.Contains(name) || password.Contains(surname))
            {
                return true; // Şifre, ad veya soyadı içeriyor
            }

            return false; // Şifre, ad veya soyadı içermiyor
        }


        public static bool ContainsInappropriateWords(string text)
        {
            string[] inappropriateWords = { "am", "yarrak", "yarak", "bastard","puşt","ibne","dallama","fahişe",
                "lezbiyen","trans","transseksüel","amdelisi","amcıkdelisi","amsiken",
                "aptal","salak","keriz","orospu","oruspu","bok","götdeliği","amcıksiken","amınakorum","kevaşe",
                "gay","gey","yarağımı","yaragımı","yarragımı","kıç","bacı","bacını","sikmek","sikeyim","budala","siktir",
                "hayvan","göt","götoş","amcık","amcik","sürtük","kahpe","sikik","geber","sıçarım","sıçmak","mal",
                 "piç","pezevenk","gavat","götveren","escort","şerefsiz","serefsiz",
                "tennim","kirremı","serevi","Kuze","Xırremi","Benamus","Gunnemi","Mıttekro",     //kürtçe
                "العمى","الحمار","حيوان","اهبل ",                                               //arapça
                "блядь","хуй","ебать","пиздец","говно","сука",                                   //rusça
                "bitch","chav","shit","fuck","dick","dickhead","asshole","donkey","pussy","skank","pimp","whore","slut",
                "cunt","cuckold","damn","idiot","Idiot","ass","mother","fucker","fool","motherfucker","transsexual","animal", }; // Uygunsuz ifadelerin listesi

            foreach (string word in inappropriateWords)
            {
                if (text.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return true; // Uygunsuz ifade bulundu
                }
            }

            return false; // Uygunsuz ifade bulunamadı
        }




        private void TxtAd_Click(object sender, EventArgs e)
        {
            label8.Visible = false;
        }

        private void txtSoyad_Click(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void txtemail_Click(object sender, EventArgs e)
        {
            label10.Visible = false;
        }

        private void txttelefon_Click(object sender, EventArgs e)
        {
            label11.Visible = false;
        }

        private void TxtSifre_Click(object sender, EventArgs e)
        {
            label12.Visible = false;
        }

        private void CmbCinsiyet_Click(object sender, EventArgs e)
        {
            label13.Visible = false;
        }

      
        private void mskTarih_Click(object sender, EventArgs e)
        {
            label14.Visible = false;
        }

        private void pictureProfil_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Resim Dosyaları|*.jpg;*.jpeg;*.png|Tüm Dosyalar|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string dosyaYolu = openFileDialog.FileName;
                pictureProfil.Image = Image.FromFile(dosyaYolu);
            }
        }

        private void txttelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Sadece sayıları ve bazı kontrol tuşlarını (Backspace, Delete, vb.) kabul et
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtAd_TextChanged(object sender, EventArgs e)
        {
            label8.Visible = string.IsNullOrWhiteSpace(TxtAd.Text);
        }

        private void txtSoyad_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = string.IsNullOrWhiteSpace(txtSoyad.Text);
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

            label10.Visible = string.IsNullOrWhiteSpace(txtemail.Text);
        }

        private void txttelefon_TextChanged(object sender, EventArgs e)
        {
            label11.Visible = string.IsNullOrWhiteSpace(txttelefon.Text);
        }

        private void TxtSifre_TextChanged(object sender, EventArgs e)
        {
            label12.Visible = string.IsNullOrWhiteSpace(TxtSifre.Text);
        }

        private void CmbCinsiyet_TextChanged(object sender, EventArgs e)
        {
            label13.Visible = string.IsNullOrWhiteSpace(CmbCinsiyet.Text);
        }

        private async void FrmKayit_Load(object sender, EventArgs e)
        {
            await FormAnimation.SlideDown(this, 500); // Mevcut formun kaybolma animasyonunu çalıştırır.
        }
    }
}
