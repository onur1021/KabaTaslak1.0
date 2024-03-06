using System.Drawing;
using System;
using System.Windows.Forms;

namespace KabaTaslakRendlee1._0
{
    public partial class FrmAcilisSayfasi : Form
    {
        private string[] cumleler = { "İlk izlenim önemlidir, samimi bir profil fotoğrafı seçin.",
            "Karşı tarafın ilgi alanlarına dikkat edin ve ortak konular bulun.",
            "Mizahla ilgi çekin, samimi ve eğlenceli olun.",
            "Profilinizi sade ve çekici tutun.",
            "İlk mesajınız özgün ve dikkat çekici olsun.",
            "Tutkularınızı yaratıcı bir şekilde dile getirin.",
            "Karşılıklı ilgi uyandırıcı sorular sorun.",
            "Özgüveninizle hayatınıza daha fazla renk katın.",
            "Bilgilerinizi kimseyle paylaşmayınız. Gizliliğinizi koruyun!",
            "Profilinizi güncelleyerek çekiciliğinizi artırın." };


        private Timer timer; // Timer nesnesini tanımlayın

        public FrmAcilisSayfasi()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 3000; // 3 saniye
            timer.Tick += Timer_Tick;
        }

     

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop(); // Timer'ı durdurun
            Frmbaglantilar fr = new Frmbaglantilar(); // Geçmek istediğiniz formun örneğini oluşturun
            fr.Show(); // Form2'yi gösterin
            this.Hide(); // Şu anki formu gizleyin
        }

        private void FrmAcilisSayfasi_Load_1(object sender, EventArgs e)
        {
          

            timer.Start(); // Timer'ı başlatın

            Random random = new Random();
            int rastgeleIndex = random.Next(cumleler.Length);
            string rastgeleCumle = "İpucu:" + cumleler[rastgeleIndex];

           
            // Label kontrolüne rastgele kelimeyi yazdırın
            label1.Text = rastgeleCumle;

        }
    }
}
