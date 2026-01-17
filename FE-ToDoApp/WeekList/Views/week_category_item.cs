using System;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.WeekList.Views
{

    public partial class week_category_item : UserControl
    {
        public int CategoryId { get; set; }
        
        private string _categoryName = string.Empty;
        private DateTime _weekStart;
        private DateTime _weekEnd;

        public string CategoryName
        {
            get => _categoryName;
            set 
            { 
                _categoryName = value;
                UpdateDisplay();
            }
        }

        public DateTime WeekStart
        {
            get => _weekStart;
            set
            {
                _weekStart = value;
                UpdateDisplay();
            }
        }

        public DateTime WeekEnd
        {
            get => _weekEnd;
            set
            {
                _weekEnd = value;
                UpdateDisplay();
            }
        }

        public event EventHandler? Clicked;
        public event EventHandler? EditRequested;
        public event EventHandler? DeleteRequested;

        public week_category_item()
        {
            InitializeComponent();
            WireClickRecursive(this);
            
            menuItemEdit.Click += (s, e) => EditRequested?.Invoke(this, EventArgs.Empty);
            menuItemDelete.Click += (s, e) => DeleteRequested?.Invoke(this, EventArgs.Empty);
        }

        public void SetCategoryName(string name) => CategoryName = name;

        public void SetWeekRange(DateTime weekStart, DateTime weekEnd)
        {
            WeekStart = weekStart;
            WeekEnd = weekEnd;
        }

        private void UpdateDisplay()
        {
            if (_weekStart != DateTime.MinValue && _weekEnd != DateTime.MinValue)
            {
                string dateRange = $"({_weekStart:dd/M} - {_weekEnd:dd/M})";
                lblCategoryName.Text = $"{_categoryName}\n{dateRange}";
            }
            else
            {
                lblCategoryName.Text = _categoryName;
            }
        }

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
