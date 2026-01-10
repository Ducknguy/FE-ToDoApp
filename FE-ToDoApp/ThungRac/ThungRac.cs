using System;
using System.Windows.Forms;

namespace ChatbotAI_Form
{
    public partial class Thungrac : Form
    {
        public Thungrac()
        {
            InitializeComponent();

            txtSearch.TextChanged += (s, e) =>
            {
                // bo góc  hàm bo góc trong phàn chatbot .
                UIHelper.BoGoc(pnlSearch, 14);

            };
            // Khi form vừa mở → không focus TextBox
            this.Shown += (s, e) =>
            {
                this.ActiveControl = null;
            };

            // Click ra ngoài → mất focus
            this.MouseDown += (s, e) =>
            {
                this.ActiveControl = null;
            };
            // Viền focus  
            UIHelperThungrac.VienFocus(
                pnlSearch,
                txtSearch,
                Color.FromArgb(60, 120, 255),
                Color.FromArgb(245, 245, 245)
                );

            //
        }
    }
}
