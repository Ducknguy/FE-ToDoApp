using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ChatbotAI_Form
{
    public partial class ChatbotAI : Form
    {
        // --- MÀU SẮC CHUẨN NOTION ---
        private readonly Color NOTION_BLUE = Color.FromArgb(35, 131, 226);
        private readonly Color BORDER_GRAY = Color.FromArgb(220, 220, 220);
        private readonly Color HOVER_COLOR = Color.FromArgb(235, 235, 235);
        private readonly Color NORMAL_COLOR = Color.White;
        private readonly Color TEXT_COLOR = Color.FromArgb(64, 64, 64);

        // Biến UI
        private Label? btnAttach;
        private Label? btnAutoSmart;
        private Label? btnSourceSmart;

        private ContextMenuStrip? menuAuto;
        private ContextMenuStrip? menuSource;
        private FlowLayoutPanel? flowToolsLeft;

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
                // Kích thước chuẩn đẹp đã chốt
                this.Size = new Size(550, 680);

                SetupGiaoDien();
                Setup3NutChucNang();
                SetupChucNangChung();
                SetupMenus();
                SetupLogicChat();
            }
        }

        // ==========================================
        // PHẦN 1: THANH CÔNG CỤ (BUTTONS)
        // ==========================================
        private void Setup3NutChucNang()
        {
            panelInputTools.Height = 45;
            panelInputTools.Dock = DockStyle.Bottom;
            panelInputTools.Padding = new Padding(10, 5, 10, 0);
            panelInputTools.BringToFront();

            Control? safeBtnSend = null;
            if (panelInputTools.Controls.Contains(btnSend)) safeBtnSend = btnSend;
            panelInputTools.Controls.Clear();

            flowToolsLeft = new FlowLayoutPanel();
            flowToolsLeft.Dock = DockStyle.Left;
            flowToolsLeft.AutoSize = true;
            flowToolsLeft.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowToolsLeft.FlowDirection = FlowDirection.LeftToRight;
            flowToolsLeft.WrapContents = false;
            flowToolsLeft.Padding = new Padding(0);
            flowToolsLeft.Margin = new Padding(0);
            flowToolsLeft.BackColor = Color.Transparent;

            btnAttach = CreateIconButton("📎");
            btnAutoSmart = CreatePillButton("✨ Tự động");
            btnSourceSmart = CreatePillButton("🌐 Nguồn");

            flowToolsLeft.Controls.Add(btnAttach);
            flowToolsLeft.Controls.Add(btnAutoSmart);
            flowToolsLeft.Controls.Add(btnSourceSmart);

            panelInputTools.Controls.Add(flowToolsLeft);

            if (safeBtnSend != null)
            {
                panelInputTools.Controls.Add(safeBtnSend);
                safeBtnSend.Dock = DockStyle.Right;
                safeBtnSend.Size = new Size(32, 32);
                BoGoc(safeBtnSend, 16);
                if (safeBtnSend is Button b) b.Margin = new Padding(0);
            }

            btnAttach.Click += (s, e) => {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Multiselect = true;
                    if (ofd.ShowDialog() == DialogResult.OK) MessageBox.Show($"Đã chọn: {ofd.FileNames.Length} file.");
                }
            };
            btnAutoSmart.Click += (s, e) => {
                if (menuAuto != null && btnAutoSmart != null) menuAuto.Show(btnAutoSmart, new Point(0, -menuAuto.Height - 5));
            };
            btnSourceSmart.Click += (s, e) => {
                if (menuSource != null && btnSourceSmart != null) menuSource.Show(btnSourceSmart, new Point(0, -menuSource.Height - 5));
            };

            SetupHoverEffect(btnAttach);
            SetupHoverEffect(btnAutoSmart);
            SetupHoverEffect(btnSourceSmart);
        }

        private Label CreateIconButton(string text)
        {
            Label btn = new Label();
            btn.Text = text;
            btn.Font = new Font("Segoe UI Emoji", 12F);
            btn.ForeColor = TEXT_COLOR;
            btn.AutoSize = false;
            btn.Size = new Size(32, 32);
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Cursor = Cursors.Hand;
            btn.Margin = new Padding(0, 0, 8, 0);
            BoGoc(btn, 16);
            return btn;
        }

        private Label CreatePillButton(string text)
        {
            Label btn = new Label();
            btn.Text = text;
            btn.Font = new Font("Segoe UI Semibold", 9.5F);
            btn.ForeColor = TEXT_COLOR;
            btn.AutoSize = true;
            btn.Padding = new Padding(10, 0, 10, 0);
            btn.TextAlign = ContentAlignment.MiddleCenter;
            btn.Cursor = Cursors.Hand;
            btn.MinimumSize = new Size(0, 32);
            btn.Margin = new Padding(0, 0, 8, 0);
            btn.Paint += (s, e) => { BoGoc(btn, 16); };
            return btn;
        }

        // ==========================================
        // PHẦN 2: LOGIC CHAT
        // ==========================================
        private void SetupLogicChat()
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
                flowActions.Controls.Clear();

            AddMessageBubble(question, isUser: true);
            txtInput.Text = "";
            txtInput.Focus();

            string aiResponse = GetFakeAIResponse(question);
            System.Windows.Forms.Timer thinkTimer = new System.Windows.Forms.Timer();
            thinkTimer.Interval = 600;
            thinkTimer.Tick += (s, e) => {
                thinkTimer.Stop(); thinkTimer.Dispose();
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
            System.Windows.Forms.Timer typingTimer = new System.Windows.Forms.Timer();
            typingTimer.Interval = 10;
            int currentIndex = 0;
            typingTimer.Tick += (s, e) => {
                if (targetLabel.IsDisposed) { typingTimer.Stop(); return; }
                if (currentIndex < fullText.Length)
                {
                    targetLabel.Text += fullText[currentIndex];
                    currentIndex++;
                    if (currentIndex % 5 == 0) flowActions.ScrollControlIntoView(targetLabel.Parent);
                }
                else { typingTimer.Stop(); typingTimer.Dispose(); }
            };
            typingTimer.Start();
        }

        private string GetFakeAIResponse(string input)
        {
            input = input.ToLower();
            if (input.Contains("chào") || input.Contains("hello")) return "Chào bạn! Tôi là trợ lý AI Notion.";
            if (input.Contains("pdf") || input.Contains("ảnh")) return "Vui lòng đính kèm tệp của bạn bằng nút kẹp giấy (📎).";
            return "Cảm ơn câu hỏi của bạn. Tôi đang xử lý thông tin...";
        }

        // ==========================================
        // PHẦN 3: GIAO DIỆN CHUNG (ĐÃ CHỈNH TEXT SÁT LÊN TRÊN)
        // ==========================================
        private void SetupGiaoDien()
        {
            btnEdit.Width = 40; btnMode.Width = 40; btnHide.Width = 40;
            btnEdit.Font = new Font("Segoe MDL2 Assets", 10F); btnEdit.Text = "\uE70F";
            btnMode.Font = new Font("Segoe MDL2 Assets", 10F); btnMode.Text = "\uE923";
            btnHide.Font = new Font("Segoe MDL2 Assets", 10F); btnHide.Text = "\uE921";

            BoGoc(this, 12); BoGoc(panelInputContainer, 12);
            BoGoc(btnSend, 18);
            BoGoc(btnAction1, 22); BoGoc(btnAction2, 22); BoGoc(btnAction3, 22); BoGoc(btnAction4, 22);
            BoGoc(lblTagNew, 8);

            FixButtonColor(btnHide); FixButtonColor(btnMode); FixButtonColor(btnEdit); FixButtonColor(btnTitleLeft);
            SetupHoverEffect(btnHide); SetupHoverEffect(btnMode); SetupHoverEffect(btnEdit); SetupHoverEffect(btnTitleLeft);
            SetupHoverEffect(btnAction1); SetupHoverEffect(btnAction2); SetupHoverEffect(btnAction3); SetupHoverEffect(btnAction4);

            // --- GIỮ CHIỀU CAO NÀY ---
            panelFooter.Height = 170;

            // --- [CHANGE] CHỈNH PADDING TOP NHỎ LẠI ---
            // Padding Top = 5: Đẩy sát lên trên
            panelInputContainer.Padding = new Padding(20, 5, 20, 5);

            // 1. THANH CÔNG CỤ (BOTTOM)
            panelInputTools.Dock = DockStyle.Bottom;

            // 2. LABEL "TRANG MỚI" (TOP)
            lblContextTag.AutoSize = false;
            lblContextTag.Height = 25; // Giảm chiều cao xuống để gọn hơn
            lblContextTag.Dock = DockStyle.Top;
            lblContextTag.TextAlign = ContentAlignment.TopLeft; // [CHANGE] Căn sát đỉnh
            lblContextTag.Padding = new Padding(0, 0, 0, 0);
            lblContextTag.Font = new Font("Segoe UI", 9F, FontStyle.Regular);

            // 3. TEXTBOX (FILL)
            txtInput.Dock = DockStyle.Fill;
            txtInput.BringToFront();

            // --- Z-ORDER ---
            panelInputContainer.Controls.SetChildIndex(panelInputTools, panelInputContainer.Controls.Count - 1);
            panelInputContainer.Controls.SetChildIndex(lblContextTag, panelInputContainer.Controls.Count - 2);
            panelInputContainer.Controls.SetChildIndex(txtInput, 0);

            // --- CẤU HÌNH TEXTBOX ---
            txtInput.Font = new Font("Segoe UI", 11.5F);
            txtInput.ScrollBars = ScrollBars.Vertical;
            txtInput.Multiline = true;
            txtInput.WordWrap = true;
            txtInput.Margin = new Padding(0, 0, 0, 0);

            panelInputContainer.Paint += (object? s, PaintEventArgs e) => {
                if (this.DesignMode) return;
                Color borderColor = isInputFocused ? NOTION_BLUE : BORDER_GRAY;
                int penWidth = isInputFocused ? 2 : 1;
                using (Pen pen = new Pen(borderColor, penWidth))
                {
                    Rectangle rect = panelInputContainer.ClientRectangle; rect.Width -= 1; rect.Height -= 1;
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    using (GraphicsPath path = GetRoundedPath(rect, 12)) e.Graphics.DrawPath(pen, path);
                }
            };

            txtInput.GotFocus += (object? s, EventArgs e) => {
                isInputFocused = true; panelInputContainer.Invalidate();
                if (txtInput.Text == "Hỏi AI...") { txtInput.Text = ""; txtInput.ForeColor = Color.Black; }
            };
            txtInput.LostFocus += (object? s, EventArgs e) => {
                isInputFocused = false; panelInputContainer.Invalidate();
                if (string.IsNullOrWhiteSpace(txtInput.Text)) { txtInput.Text = "Hỏi AI..."; txtInput.ForeColor = Color.Gray; }
            };

            void ActionClick(string text) { txtInput.Text = text; txtInput.Focus(); SendKeys.Send("{ENTER}"); }

            AssignClickToPanel(btnAction1, () => ActionClick("Hãy tìm kiếm thông tin về..."));
            AssignClickToPanel(btnAction2, () => ActionClick("Giúp tôi soạn agenda cuộc họp về..."));
            AssignClickToPanel(btnAction3, () => ActionClick("Phân tích tài liệu này giúp tôi."));
            AssignClickToPanel(btnAction4, () => ActionClick("Tạo bảng theo dõi nhiệm vụ cho dự án."));
        }

        private void AssignClickToPanel(Control pnl, Action action)
        {
            EventHandler handler = (object? s, EventArgs e) => action();
            pnl.Click += handler;
            foreach (Control child in pnl.Controls) child.Click += handler;
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

            void ItemClick(object? sender, EventArgs e)
            {
                if (menuAuto == null || sender == null) return;
                foreach (ToolStripItem item in menuAuto.Items) if (item is ToolStripMenuItem) ((ToolStripMenuItem)item).Checked = false;

                ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
                clickedItem.Checked = true;
                if (btnAutoSmart != null) btnAutoSmart.Text = "✨ " + clickedItem.Text.Split(' ')[0];
            };
            itemAuto.Click += ItemClick; itemClaude.Click += ItemClick; itemGPT.Click += ItemClick;
            menuAuto.Items.AddRange(new ToolStripItem[] { itemAuto, itemClaude, itemGPT });

            menuSource = new ContextMenuStrip();
            menuSource.Renderer = notionRenderer;
            menuSource.Items.Add(new ToolStripMenuItem("Tìm kiếm trên web") { Checked = true, Image = CreateSymbolImage("🌐") });
            menuSource.Items.Add(new ToolStripMenuItem("Ứng dụng và tích hợp") { Checked = true, Image = CreateSymbolImage("🔗") });
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

        private void FixButtonColor(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat; btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = NORMAL_COLOR; btn.FlatAppearance.MouseOverBackColor = HOVER_COLOR;
        }

        private void SetupHoverEffect(Control? ctrl)
        {
            if (ctrl == null) return;
            void MouseEnter(object? sender, EventArgs e) { if (!(ctrl is Button)) ctrl.BackColor = HOVER_COLOR; ctrl.Cursor = Cursors.Hand; }
            void MouseLeave(object? sender, EventArgs e)
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
            }
        }

        private Image CreateSymbolImage(string text)
        {
            Bitmap bmp = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmp))
                g.DrawString(text, new Font("Segoe UI Emoji", 10), Brushes.Black, 0, 0);
            return bmp;
        }

        private void DragForm(object? sender, MouseEventArgs e)
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
        }
    }
}