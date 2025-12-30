using System;
using System.Windows.Forms;

namespace FE_ToDoApp.Lich_Trinh
{
    public partial class ToDoListItem : UserControl
    {
        public int TodoId { get; set; }

        public event EventHandler? Clicked;

        public ToDoListItem()
        {
            InitializeComponent();
            WireClickRecursive(this);
        }

        public void SetTitle(string title)
        {
            lblTitle.Text = title;
        }

        private void WireClickRecursive(Control root)
        {
            root.Click += (s, e) => Clicked?.Invoke(this, EventArgs.Empty);
            foreach (Control c in root.Controls)
                WireClickRecursive(c);
        }
    }
}
