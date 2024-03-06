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
    public partial class FrmBegeniler : Form
    {
        private PictureBoxInteraction pictureBoxInteraction10;
        private PictureBoxInteraction pictureBoxInteraction6;
        private PictureBoxInteraction pictureBoxInteraction12;
        private PictureBoxInteraction pictureBoxInteraction9;

        public FrmBegeniler()
        {
            InitializeComponent();
            // PictureBoxInteraction nesnelerini oluşturun ve PictureBox ile Label nesnelerini geçirin
            pictureBoxInteraction10 = new PictureBoxInteraction(pictureBox10, labelKaydirma);
            pictureBoxInteraction6 = new PictureBoxInteraction(pictureBox6, labelEslesmeler);
            pictureBoxInteraction12 = new PictureBoxInteraction(pictureBox12, labelBegeniler);
            pictureBoxInteraction9 = new PictureBoxInteraction(pictureBox9, labelProfil);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            FrmProfilDuzenle fr = new FrmProfilDuzenle();
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

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            FrmAnaSayfa fr = new FrmAnaSayfa();
            fr.Email = GlobalVeriler.Email;
            fr.Show();
            this.Hide();
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            // Kontrol edilecek formun tipine uygun bir koleksiyon oluşturun.
            foreach (Form frm in Application.OpenForms)
            {
                if (frm is FrmBegeniler)
                {
                    // Form zaten açıksa, bu formu yeniden açmak yerine odaklayın.
                    frm.Focus();
                    return;
                }
            }
        }

        private  void FrmBegeniler_Load(object sender, EventArgs e)
        {
           
            labelKaydirma.Visible = false;
            labelBegeniler.Visible = false;
            labelEslesmeler.Visible = false;
            labelProfil.Visible = false;
        }
    }
}
