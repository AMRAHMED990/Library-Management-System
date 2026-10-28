using System.Drawing;
using System.Windows.Forms;

namespace Library_Manegement_System
{
    public static class Theme
    {
        public static readonly Color Lamp = Color.FromArgb(30, 59, 51);
        public static readonly Color LampActive = Color.FromArgb(45, 84, 72);
        public static readonly Color LampText = Color.FromArgb(194, 209, 202);
        public static readonly Color Brass = Color.FromArgb(201, 151, 63);
        public static readonly Color Paper = Color.FromArgb(242, 244, 241);
        public static readonly Color Ink = Color.FromArgb(28, 36, 33);
        public static readonly Color Muted = Color.FromArgb(102, 117, 111);
        public static readonly Color Border = Color.FromArgb(217, 224, 220);
        public static readonly Color Red = Color.FromArgb(181, 56, 75);
        public static readonly Color Green = Color.FromArgb(46, 125, 91);

        public static void StyleGrid(DataGridView grid)
        {
            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.GridColor = Border;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.RowHeadersVisible = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
            grid.MultiSelect = false;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowTemplate.Height = 34;

            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersHeight = 38;
            grid.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Muted;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9f);

            grid.DefaultCellStyle.Font = new Font("Segoe UI", 10f);
            grid.DefaultCellStyle.ForeColor = Ink;
            grid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(245, 234, 211);
            grid.DefaultCellStyle.SelectionForeColor = Ink;

            // "Book_Name" -> "Book Name", and short dates
            grid.DataBindingComplete += (sender, e) =>
            {
                foreach (DataGridViewColumn column in grid.Columns)
                {
                    column.HeaderText = column.Name.Replace("_", " ");
                    if (column.ValueType == typeof(System.DateTime))
                        column.DefaultCellStyle.Format = "dd MMM yyyy";
                }
            };
        }

        public static Color StatusColor(string status)
        {
            if (status == "Overdue" || status == "Unpaid") return Red;
            if (status == "Returned" || status == "Paid") return Green;
            return Brass;
        }
    }
}
