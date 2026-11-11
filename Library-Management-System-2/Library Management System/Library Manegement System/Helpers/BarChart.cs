using System.Drawing;
using System.Windows.Forms;

namespace Library_Manegement_System
{
    // GDI+: a simple bar chart that we draw ourselves in OnPaint
    public class BarChart : Control
    {
        private string[] labels = new string[0];
        private int[] values = new int[0];

        public BarChart()
        {
            BackColor = Color.White;
            DoubleBuffered = true;   // stops flickering
        }

        public void SetData(string[] labels, int[] values)
        {
            this.labels = labels;
            this.values = values;
            Invalidate();   // tells Windows to call OnPaint again
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;

            if (values.Length == 0)
                return;

            // the biggest value decides how tall the bars can be
            int max = 1;
            foreach (int value in values)
                if (value > max) max = value;

            int bottom = Height - 25;              // leave room under the bars for the month names
            int slotWidth = Width / values.Length; // each bar gets an equal slice of the width

            using (Brush barBrush = new SolidBrush(Theme.Lamp))
            using (Font font = new Font("Segoe UI", 9))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    int barHeight = (bottom - 25) * values[i] / max;
                    int x = i * slotWidth + 10;
                    int y = bottom - barHeight;

                    g.FillRectangle(barBrush, x, y, slotWidth - 20, barHeight);
                    g.DrawString(values[i].ToString(), font, Brushes.Black, x, y - 18);
                    g.DrawString(labels[i], font, Brushes.Gray, x, bottom + 5);
                }
            }

            g.DrawLine(Pens.Gray, 0, bottom, Width, bottom);   // the base line
        }
    }
}
