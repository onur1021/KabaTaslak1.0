using System;
using System.Windows.Forms;

namespace KabaTaslakRendlee1._0
{
    public class PictureBoxInteraction
    {
        private PictureBox pictureBox;
        private Label label;

        public PictureBoxInteraction(PictureBox pictureBox, Label label)
        {
            this.pictureBox = pictureBox;
            this.label = label;

            // PictureBox nesnesinin MouseDown ve MouseUp olaylarına uygun olay dinleyicilerini ekleyin
            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseUp += PictureBox_MouseUp;

            // Label'ı başlangıçta gizleyin
            label.Visible = false;
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            // PictureBox'a tıklama başladığında çalışacak kod
            label.Visible = true; // Label'ı görünür yapın
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            // PictureBox'tan tıklama bırakıldığında çalışacak kod
            label.Visible = false; // Label'ı gizleyin
        }

        // PictureBox için başka yöntemler eklemek isterseniz burada tanımlayabilirsiniz.
    }
}
