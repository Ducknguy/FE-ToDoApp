using System;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.Lich_Trinh
{
    public partial class ToDoListItem : UserControl
    {
        public int TodoId { get; set; }

        public string Title
        {
            get => lblTitle.Text;
            set => lblTitle.Text = value;
        }

        public event EventHandler? Clicked;

        public ToDoListItem()
        {
            InitializeComponent();
            WireClickRecursive(this);
        }

        public void SetTitle(string title) => Title = title;

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
