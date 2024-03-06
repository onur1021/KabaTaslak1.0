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
    public partial class Frmbaglantilar : Form
    {
        public Frmbaglantilar()
        {
            InitializeComponent();
            InitializeUI();
        }
        private void InitializeUI()
        {
            int buttonSpacing = 10; // Düğmeler arasındaki boşluk

            CustomRoundedButton button1 = new CustomRoundedButton();
            button1.Text = "HESABIM VAR";
            button1.Size = new System.Drawing.Size(194, 28);
            button1.Location = new System.Drawing.Point(40, 308);
            button1.BackColor = Color.Coral;
            button1.Click += button1_Click;
            button1.Font = new Font(button1.Font.FontFamily, 8); // Yazı boyutunu 8 olarak ayarla
            Controls.Add(button1);

            CustomRoundedButton button2 = new CustomRoundedButton();
            button2.Text = "KAYIT OL";
            button2.Size = new System.Drawing.Size(194, 28);
            button2.Location = new System.Drawing.Point(40, button1.Bottom + buttonSpacing);
            button2.BackColor = Color.LightBlue;
            button2.Click += button2_Click;
            button2.Font = new Font(button2.Font.FontFamily, 8); // Yazı boyutunu 8 olarak ayarla
            Controls.Add(button2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmGiris fr = new FrmGiris();
            fr.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmKayit fr = new FrmKayit();
            fr.Show();
            this.Hide();
        }

       
    }
}
