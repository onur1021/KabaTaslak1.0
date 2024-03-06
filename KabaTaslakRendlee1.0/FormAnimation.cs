using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KabaTaslakRendlee1._0
{
    public class FormAnimation
    {
        public static async Task SlideDown(Form form, int animationDuration)
        {
            int originalHeight = form.Height;
            int targetHeight = form.Height;

            form.Height = 0;
            form.Show();

            for (int i = 0; i <= animationDuration; i += 10)
            {
                form.Height = (int)(originalHeight * (i / (double)animationDuration));
                await Task.Delay(10);
            }

            form.Height = targetHeight;
        }

        public static async Task SlideUp(Form form, int animationDuration)
        {
            int originalHeight = form.Height;
            int targetHeight = 0;

            for (int i = 0; i <= animationDuration; i += 10)
            {
                form.Height = (int)(originalHeight * (1 - i / (double)animationDuration));
                await Task.Delay(10);
            }

            form.Height = targetHeight;
            form.Hide();
        }

        public static async Task SlideRight(Form form, int animationDuration)
        {
            int originalWidth = form.Width;
            int targetWidth = form.Width;

            form.Width = 0;
            form.Show();

            for (int i = 0; i <= animationDuration; i += 10)
            {
                form.Width = (int)(originalWidth * (i / (double)animationDuration));
                await Task.Delay(10);
            }

            form.Width = targetWidth;
        }
        public static async Task SlideLeft(Form form, int animationDuration)
        {
            int originalLeft = form.Left;
            int targetLeft = 0 - form.Width;

            form.Left = originalLeft;
            form.Show();

            for (int i = 0; i <= animationDuration; i += 10)
            {
                form.Left = (int)(originalLeft - (originalLeft + form.Width) * (i / (double)animationDuration));
                await Task.Delay(10);
            }

            form.Left = targetLeft;
            form.Hide();
        }



    }
}
