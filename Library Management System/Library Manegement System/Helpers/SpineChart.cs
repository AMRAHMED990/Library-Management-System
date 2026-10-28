using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Library_Manegement_System
{
    // Our GDI+ part: a bar chart we draw ourselves, each bar looks like a book on a shelf
    public class SpineChart : Control
    {
        private string[] labels = new string[0];
        private int[] values = new int[0];

        private readonly Color[] spineColors =
        {
            Color.FromArgb(30, 59, 51),
            Color.FromArgb(201, 151, 63),
            Color.FromArgb(62, 92, 118),
            Color.FromArgb(181, 56, 75),
        };

        public SpineChart()
        {
            BackColor = Color.White;
            DoubleBuffered = true;   // stops flickering
            ResizeRedraw = true;
        }

        public void SetData(string[] newLabels, int[] newValues)
        {
            labels = newLabels;
            values = newValues;
            Invalidate();   // repaint with the new data
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            if (values.Length == 0)
                return;

            int shelfY = Height - 30;   // month names go under the shelf
            int maxValue = Math.Max(1, Max(values));
            float slotWidth = Width / (float)values.Length;
            float spineWidth = Math.Min(slotWidth * 0.5f, 56);

            using (Font font = new Font("Bahnschrift", 9.5f))
            using (Brush textBrush = new SolidBrush(Color.FromArgb(28, 36, 33)))
            using (Brush mutedBrush = new SolidBrush(Color.FromArgb(102, 117, 111)))
            using (Pen bandPen = new Pen(Color.FromArgb(150, 255, 255, 255), 1.5f))
            using (StringFormat center = new StringFormat { Alignment = StringAlignment.Center })
            {
                for (int i = 0; i < values.Length; i++)
                {
                    float spineHeight = (shelfY - 40) * values[i] / (float)maxValue;
                    float x = i * slotWidth + (slotWidth - spineWidth) / 2;
                    RectangleF spine = new RectangleF(x, shelfY - spineHeight, spineWidth, spineHeight);

                    using (Brush spineBrush = new SolidBrush(spineColors[i % spineColors.Length]))
                        g.FillRectangle(spineBrush, spine);

                    // the light bands make it look like a book spine
                    if (spineHeight > 30)
                    {
                        g.DrawLine(bandPen, spine.Left + 3, spine.Top + 8, spine.Right - 3, spine.Top + 8);
                        g.DrawLine(bandPen, spine.Left + 3, spine.Top + 13, spine.Right - 3, spine.Top + 13);
                        g.DrawLine(bandPen, spine.Left + 3, spine.Bottom - 10, spine.Right - 3, spine.Bottom - 10);
                    }

                    RectangleF slot = new RectangleF(i * slotWidth, 0, slotWidth, 20);
                    slot.Y = spine.Top - 20;
                    g.DrawString(values[i].ToString(), font, textBrush, slot, center);
                    slot.Y = shelfY + 10;
                    g.DrawString(labels[i], font, mutedBrush, slot, center);
                }
            }

            using (Brush shelfBrush = new SolidBrush(Color.FromArgb(150, 112, 31)))
                g.FillRectangle(shelfBrush, 0, shelfY, Width, 6);
        }

        private static int Max(int[] numbers)
        {
            int max = 0;
            foreach (int n in numbers)
                if (n > max) max = n;
            return max;
        }
    }
}
