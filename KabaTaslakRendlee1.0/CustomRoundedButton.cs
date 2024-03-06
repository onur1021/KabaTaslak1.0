using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace KabaTaslakRendlee1._0
{
    public class CustomRoundedButton : Button
    {
        public CustomRoundedButton()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint | ControlStyles.DoubleBuffer, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            FlatAppearance.BorderColor = Color.FromArgb(179, 68, 108); // Çerçeve rengi
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            using (GraphicsPath path = new GraphicsPath())
            {
                int cornerRadius = 15; // Köşe yuvarlatma yarıçapı
                path.AddArc(0, 0, cornerRadius * 2, cornerRadius * 2, 180, 90);
                path.AddArc(Width - cornerRadius * 2, 0, cornerRadius * 2, cornerRadius * 2, 270, 90);
                path.AddArc(Width - cornerRadius * 2, Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
                path.AddArc(0, Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
                path.CloseAllFigures();

                Region = new Region(path);

                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                using (SolidBrush backgroundBrush = new SolidBrush(Color.Red)) // Arkaplan rengini değiştir
                {
                    pevent.Graphics.FillPath(backgroundBrush, path);
                }
            }

            base.OnPaint(pevent);
        }
    }
}
