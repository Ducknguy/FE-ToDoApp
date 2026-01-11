using System;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.WeekList.Views
{
    /// <summary>
    /// UserControl ??i di?n cho 1 category item trong sidebar
    /// Gi?ng TodoListItem trong Lich Trinh
    /// </summary>
    public partial class week_category_item : UserControl
    {
        public int CategoryId { get; set; }

        public string CategoryName
        {
            get => lblCategoryName.Text;
            set => lblCategoryName.Text = value;
        }

        public event EventHandler? Clicked;

        public week_category_item()
        {
            InitializeComponent();
            WireClickRecursive(this);
        }

        public void SetCategoryName(string name) => CategoryName = name;

        public void SetSelected(bool selected)
        {
            BackColor = selected ? Color.FromArgb(200, 220, 255) : Color.FromArgb(230, 240, 255);
        }

        private void WireClickRecursive(Control root)
        {
            root.Cursor = Cursors.Hand;
            root.Click += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);

            foreach (Control c in root.Controls)
                WireClickRecursive(c);
        }
    }
}
