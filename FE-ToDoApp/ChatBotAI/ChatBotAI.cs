using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ChatbotAI_Form
{
    public partial class ChatbotAI : Form
    {
        // --- CẤU HÌNH MÀU SẮC ---
        private readonly Color HOVER_COLOR = Color.FromArgb(225, 225, 225);
        private readonly Color NORMAL_COLOR = Color.White;
        private readonly Color NOTION_BLUE = Color.FromArgb(35, 131, 226);
        private readonly Color BORDER_GRAY = Color.FromArgb(220, 220, 220);

        // Biến UI động
        private Label lblAttachFile;
        private ContextMenuStrip menuAuto;
        private ContextMenuStrip menuSource;

        private bool isInputFocused = false;

        // --- CẤU HÌNH ĐỔ BÓNG ---
        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (!this.DesignMode) cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public ChatbotAI()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            if (!this.DesignMode)
            {
                SetupGiaoDien();
                Setup3NutChucNang(); // <-- Đã sửa lại logic sắp xếp trong này
                SetupChucNangChung();
                SetupMenus();
                SetupLogic();
            }
        }

        // ==========================================
        // PHẦN 1: LOGIC XỬ LÝ CHAT & HIỆU ỨNG
        // ==========================================

        private void SetupLogic()
        {
            txtInput.TextChanged += (s, e) =>
            {
                bool hasText = !string.IsNullOrWhiteSpace(txtInput.Text) && txtInput.Text != "Hỏi AI...";
                btnSend.BackColor = hasText ? NOTION_BLUE : Color.FromArgb(240, 240, 240);
                btnSend.ForeColor = hasText ? Color.White : Color.Gray;
            };

            txtInput.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter && !e.Shift)
                {
                    e.SuppressKeyPress = true;
                    PerformSendMessage();
                }
            };

            btnSend.Click += (s, e) => PerformSendMessage();
        }

        private void PerformSendMessage()
        {
            string question = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(question) || question == "Hỏi AI...") return;

            if (flowActions.Controls.Count > 0 && flowActions.Controls[0] is Panel && flowActions.Controls[0].Name.Contains("btnAction"))
            {
                flowActions.Controls.Clear();
            }

            AddMessageBubble(question, isUser: true);

            txtInput.Text = "";
            txtInput.Focus();

            string aiResponse = GetFakeAIResponse(question);

            Timer thinkTimer = new Timer();
            thinkTimer.Interval = 600;
            thinkTimer.Tick += (s, e) => {
                thinkTimer.Stop();
                thinkTimer.Dispose();
                AddMessageBubble(aiResponse, isUser: false);
            };
            thinkTimer.Start();
        }

        private void AddMessageBubble(string text, bool isUser)
        {
            Panel pnlMsg = new Panel();
            pnlMsg.Width = flowActions.Width - 25;
            pnlMsg.AutoSize = true;
            pnlMsg.Margin = new Padding(0, 0, 0, 20);

            Label lblIcon = new Label();
            lblIcon.Size = new Size(30, 30);
            lblIcon.Location = new Point(0, 0);
            lblIcon.Font = new Font("Segoe UI Emoji", 14);
            lblIcon.Text = isUser ? "👤" : "🤖";

            Label lblContent = new Label();
            lblContent.Location = new Point(40, 4);
            lblContent.MaximumSize = new Size(pnlMsg.Width - 50, 0);
            lblContent.AutoSize = true;
            lblContent.Font = new Font("Segoe UI", 11);
            lblContent.ForeColor = Color.FromArgb(55, 53, 47);

            pnlMsg.Controls.Add(lblIcon);
            pnlMsg.Controls.Add(lblContent);
            flowActions.Controls.Add(pnlMsg);

            if (isUser) lblContent.Text = text;
            else StartTypingEffect(lblContent, text);

            flowActions.ScrollControlIntoView(pnlMsg);
        }

        private void StartTypingEffect(Label targetLabel, string fullText)
        {
            Timer typingTimer = new Timer();
            typingTimer.Interval = 10;
            int currentIndex = 0;

            typingTimer.Tick += (s, e) =>
            {
                if (targetLabel.IsDisposed) { typingTimer.Stop(); return; }

                if (currentIndex < fullText.Length)
                {
                    targetLabel.Text += fullText[currentIndex];
                    currentIndex++;
                    if (currentIndex % 5 == 0) flowActions.ScrollControlIntoView(targetLabel.Parent);
                }
                else
                {
                    typingTimer.Stop();
                    typingTimer.Dispose();
                }
            };
            typingTimer.Start();
        }

        private string GetFakeAIResponse(string input)
        {
            input = input.ToLower();
            if (input.Contains("chào") || input.Contains("hello")) return "Chào bạn! Tôi là trợ lý AI của bạn.";
            if (input.Contains("pdf") || input.Contains("ảnh")) return "Vui lòng đính kèm tệp của bạn bằng nút kẹp giấy (📎) bên dưới.";
            return "Cảm ơn câu hỏi thú vị này. Tôi đang phân tích ngữ cảnh để đưa ra câu trả lời chính xác nhất.";
        }

        // ==========================================
        // PHẦN 2: SETUP GIAO DIỆN & STYLE
        // ==========================================

        private void Setup3NutChucNang()
        {
            // 1. TẠO NÚT GỬI FILE (Code tạo động)
            lblAttachFile = new Label();
            lblAttachFile.Text = "📎";
            lblAttachFile.Font = new Font("Segoe UI Emoji", 12F);
            lblAttachFile.AutoSize = true;
            lblAttachFile.Padding = new Padding(8, 6, 8, 6);
            lblAttachFile.Dock = DockStyle.Left; // Neo bên trái
            lblAttachFile.TextAlign = ContentAlignment.MiddleCenter;
            lblAttachFile.Cursor = Cursors.Hand;

            // Thêm vào Panel
            panelInputTools.Controls.Add(lblAttachFile);

            // 2. CẬP NHẬT 2 NÚT CŨ
            lblToolAuto.Text = "✨ Tự động";
            lblToolAuto.Padding = new Padding(8, 8, 8, 8);

            lblToolSource.Text = "🌐 Nguồn";
            lblToolSource.Padding = new Padding(8, 8, 8, 8);

            // 3. ÉP BUỘC THỨ TỰ (SetChildIndex)
            // Trong DockStyle.Left: Index 0 là sát trái nhất, Index càng cao càng về bên phải
            // Cách này mạnh hơn BringToFront và chắc chắn sẽ chạy đúng

            panelInputTools.Controls.SetChildIndex(lblAttachFile, 0); // Vị trí 1: Ngoài cùng bên trái
            panelInputTools.Controls.SetChildIndex(lblToolAuto, 1);   // Vị trí 2: Ở giữa
            panelInputTools.Controls.SetChildIndex(lblToolSource, 2); // Vị trí 3: Bên phải

            // 4. SỰ KIỆN CLICK
            lblAttachFile.Click += (s, e) => {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Title = "Chọn tệp để gửi cho AI";
                    ofd.Multiselect = true;
                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show($"Đã chọn: {string.Join(", ", ofd.SafeFileNames)}");
                    }
                }
            };

            lblToolAuto.Click += (s, e) => menuAuto.Show(lblToolAuto, new Point(0, -menuAuto.Height - 5));
            lblToolSource.Click += (s, e) => menuSource.Show(lblToolSource, new Point(0, -menuSource.Height - 5));

            SetupHoverEffect(lblAttachFile);
            SetupHoverEffect(lblToolAuto);
            SetupHoverEffect(lblToolSource);
        }

        private void SetupChucNangChung()
        {
            btnHide.Click += (s, e) => this.WindowState = FormWindowState.Minimized;
            btnMode.Click += (s, e) => this.WindowState = (this.WindowState == FormWindowState.Normal) ? FormWindowState.Maximized : FormWindowState.Normal;
            btnEdit.Click += (s, e) => { txtInput.Text = ""; txtInput.Focus(); };
            btnTitleLeft.Click += (s, e) => MessageBox.Show("Menu chức năng đang phát triển!", "Thông báo");

            panelTitleBar.MouseDown += DragForm;
            lblGreeting.MouseDown += DragForm;
        }

        private void SetupMenus()
        {
            ToolStripProfessionalRenderer notionRenderer = new ToolStripProfessionalRenderer(new NotionColorTable());
            notionRenderer.RoundedEdges = true;

            menuAuto = new ContextMenuStrip();
            menuAuto.Renderer = notionRenderer;
            menuAuto.Font = new Font("Segoe UI", 9F);

            var itemAuto = new ToolStripMenuItem("Tự động") { Checked = true, Image = CreateSymbolImage("✨") };
            var itemClaude = new ToolStripMenuItem("Claude Sonnet 3.5") { Image = CreateSymbolImage("🟠") };
            var itemGPT = new ToolStripMenuItem("GPT-4o") { Image = CreateSymbolImage("⚫") };

            void ItemClick(object sender, EventArgs e)
            {
                itemAuto.Checked = false; itemClaude.Checked = false; itemGPT.Checked = false;
                ((ToolStripMenuItem)sender).Checked = true;
                lblToolAuto.Text = "✨ " + ((ToolStripMenuItem)sender).Text.Split(' ')[0];
            };
            itemAuto.Click += ItemClick; itemClaude.Click += ItemClick; itemGPT.Click += ItemClick;
            menuAuto.Items.AddRange(new ToolStripItem[] { itemAuto, itemClaude, itemGPT });

            menuSource = new ContextMenuStrip();
            menuSource.Renderer = notionRenderer;
            menuSource.Items.Add(new ToolStripMenuItem("Tìm kiếm trên web") { Checked = true, Image = CreateSymbolImage("🌐") });
            menuSource.Items.Add(new ToolStripMenuItem("Ứng dụng và tích hợp") { Checked = true, Image = CreateSymbolImage("🔗") });
        }

        private Image CreateSymbolImage(string text)
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
                g.DrawString(text, new Font("Segoe UI Emoji", 10), Brushes.Black, 0, 0);
            return bmp;
        }

        private void SetupGiaoDien()
        {
            btnEdit.Width = 40; btnMode.Width = 40; btnHide.Width = 40;
            BoGoc(this, 12); BoGoc(panelInputContainer, 10); BoGoc(btnSend, 18);
            BoGoc(btnAction1, 22); BoGoc(btnAction2, 22); BoGoc(btnAction3, 22); BoGoc(btnAction4, 22);
            BoGoc(lblTagNew, 8);

            btnEdit.Font = new Font("Segoe MDL2 Assets", 10F); btnEdit.Text = "\uE70F";
            btnMode.Font = new Font("Segoe MDL2 Assets", 10F); btnMode.Text = "\uE923";
            btnHide.Font = new Font("Segoe MDL2 Assets", 10F); btnHide.Text = "\uE921";

            FixButtonColor(btnHide); FixButtonColor(btnMode); FixButtonColor(btnEdit); FixButtonColor(btnTitleLeft);
            SetupHoverEffect(btnHide); SetupHoverEffect(btnMode); SetupHoverEffect(btnEdit); SetupHoverEffect(btnTitleLeft);
            SetupHoverEffect(btnAction1); SetupHoverEffect(btnAction2); SetupHoverEffect(btnAction3); SetupHoverEffect(btnAction4);

            panelInputContainer.Paint += (s, e) => {
                if (this.DesignMode) return;
                Color borderColor = isInputFocused ? NOTION_BLUE : BORDER_GRAY;
                int penWidth = isInputFocused ? 2 : 1;
                using (Pen pen = new Pen(borderColor, penWidth))
                {
                    Rectangle rect = panelInputContainer.ClientRectangle; rect.Width -= 1; rect.Height -= 1;
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (GraphicsPath path = GetRoundedPath(rect, 10)) e.Graphics.DrawPath(pen, path);
                }
            };
            txtInput.GotFocus += (s, e) => { isInputFocused = true; panelInputContainer.Invalidate(); if (txtInput.Text == "Hỏi AI...") { txtInput.Text = ""; txtInput.ForeColor = Color.Black; } };
            txtInput.LostFocus += (s, e) => { isInputFocused = false; panelInputContainer.Invalidate(); if (string.IsNullOrWhiteSpace(txtInput.Text)) { txtInput.Text = "Hỏi AI..."; txtInput.ForeColor = Color.Gray; } };

            void ActionClick(string text) { txtInput.Text = text; txtInput.Focus(); SendKeys.Send("{ENTER}"); }
            btnAction1.Click += (s, e) => ActionClick("Hãy tìm kiếm thông tin về...");
            btnAction2.Click += (s, e) => ActionClick("Giúp tôi soạn agenda cuộc họp về...");
            btnAction3.Click += (s, e) => ActionClick("Phân tích tài liệu này giúp tôi.");
            btnAction4.Click += (s, e) => ActionClick("Tạo bảng theo dõi nhiệm vụ cho dự án.");
        }

        private void FixButtonColor(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = NORMAL_COLOR; btn.FlatAppearance.MouseOverBackColor = HOVER_COLOR;
        }

        private void SetupHoverEffect(Control ctrl)
        {
            void MouseEnter(object sender, EventArgs e) { if (!(ctrl is Button)) ctrl.BackColor = HOVER_COLOR; ctrl.Cursor = Cursors.Hand; }
            void MouseLeave(object sender, EventArgs e)
            {
                if (ctrl.ContextMenuStrip != null && ctrl.ContextMenuStrip.Visible) return;
                Point pt = ctrl.PointToClient(Cursor.Position);
                if (!ctrl.ClientRectangle.Contains(pt)) if (!(ctrl is Button)) ctrl.BackColor = NORMAL_COLOR;
            }
            ctrl.MouseEnter += MouseEnter; ctrl.MouseLeave += MouseLeave;
            foreach (Control child in ctrl.Controls)
            {
                child.MouseEnter -= MouseEnter; child.MouseLeave -= MouseLeave;
                child.MouseEnter += MouseEnter; child.MouseLeave += MouseLeave;
                child.Cursor = Cursors.Hand;
                if (ctrl is Button) child.Click += (s, e) => ((Button)ctrl).PerformClick();
                else if (ctrl is Panel) child.Click += (s, e) => ((Panel)ctrl).InvokeOnClick(ctrl, EventArgs.Empty);
            }
        }

        private void DragForm(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, 0xA1, 0x2, 0); }
        }

        private void BoGoc(Control control, int radius)
        {
            if (control.Width <= 0) return;
            DoBoGoc(control, radius); control.Resize += (s, e) => DoBoGoc(control, radius);
        }
        private void DoBoGoc(Control control, int radius)
        {
            if (control.Width <= 0) return;
            using (GraphicsPath path = GetRoundedPath(control.ClientRectangle, radius)) control.Region = new Region(path);
        }
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath(); int d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90); path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90); path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure(); return path;
        }

        public class NotionColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(241, 241, 241);
            public override Color MenuItemBorder => Color.Transparent;
            public override Color MenuBorder => Color.FromArgb(230, 230, 230);
            public override Color ToolStripDropDownBackground => Color.White;
            public override Color ImageMarginGradientBegin => Color.White;
            public override Color ImageMarginGradientMiddle => Color.White;
            public override Color ImageMarginGradientEnd => Color.White;
        }
    }
}