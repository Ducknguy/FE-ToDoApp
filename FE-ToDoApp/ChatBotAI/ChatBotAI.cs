#nullable disable
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net;
using FE_ToDoApp;
using System.Data;
using FE_ToDoApp;
using System.Text.RegularExpressions;

namespace ChatbotAI_Form
{

    // --- QUAN TRỌNG: Thêm IMessageFilter để xử lý việc bấm ra ngoài tự tắt ---
    public partial class ChatbotAI : Form, IMessageFilter
    {
        private bool isSending = false;

        //ket noi sql
        private DAO.ChatDAO chatDAO = new DAO.ChatDAO();

        // --- CẤU HÌNH API ---
        private const string API_KEY = "AIzaSyAgWow2_Dk0aHafcoizJlhTdnoOiSO_Nyw"; // API Key của bạn
        private static readonly HttpClient client = new HttpClient();

        // Mặc định là bản Flash cho nhanh
        private string currentModel = "gemini-2.5-flash";

        // --- MÀU SẮC ---
        private readonly Color NOTION_BLUE = Color.FromArgb(35, 131, 226);
        private readonly Color HOVER_COLOR = Color.FromArgb(242, 242, 242);
        private readonly Color BORDER_GRAY = Color.FromArgb(224, 224, 224); // Màu xám nhạt
        private readonly Color NORMAL_COLOR = Color.White;
        private readonly Color TEXT_COLOR = Color.FromArgb(64, 64, 64);
        private readonly Color DELETE_RED = Color.FromArgb(255, 70, 70);

        // Biến UI
        private Label? btnAttach;
        private Label? btnAutoSmart;
        private Label? btnSourceSmart;

        private ContextMenuStrip? menuAuto;
        private ContextMenuStrip? menuSource;
        private FlowLayoutPanel? flowToolsLeft;

        private bool isInputFocused = false;

        // --- BIẾN CUSTOM SCROLLBAR ---
        private Panel? pnlScrollTrack;
        private Panel? pnlScrollThumb;
        private bool isDraggingScroll = false;
        private Point lastMouseScroll;

        // --- BIẾN LỊCH SỬ ---
        private List<ChatSession> chatHistory = new List<ChatSession>();
        private ChatSession currentSession = null;
        private const string HISTORY_FILE = "history.json";

        private Panel pnlHistoryPopup;
        private FlowLayoutPanel flowHistoryList;

        // API Windows
        [DllImport("user32.dll")]
        private static extern bool ShowScrollBar(IntPtr hWnd, int wBar, bool bShow);
        private const int SB_VERT = 1;
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



            // --- ĐOẠN NÀY ĐỂ TOOLTIP HIỆN NHANH HƠN ---
            toolTip1.InitialDelay = 200;  // 0.2 giây là hiện (Mặc định là 0.5s)
            toolTip1.ReshowDelay = 100;   // Khi rê từ nút này sang nút kia thì hiện ngay lập tức
            toolTip1.AutoPopDelay = 5000; // Giữ chữ hiển thị trong 5 giây cho kịp đọc

            if (!this.DesignMode)

                try { ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12; } catch { }

            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);

            if (!this.DesignMode)
            {
                SetupGiaoDien();
                Setup3NutChucNang();
                SetupChucNangChung();
                SetupMenus();
                SetupLogicChat();
                SetupCustomScrollbar();

                LoadHistory();
                SetupHistoryPanel();
            }
        }

        // KHU VỰC XỬ LÝ LỊCH SỬ (ĐÃ NÂNG CẤP)

        // --- 1. Logic Tự động tắt khi bấm ra ngoài ---
        public bool PreFilterMessage(ref Message m)
        {
            // Bắt sự kiện Click chuột trái (0x201)
            if (m.Msg == 0x201 && pnlHistoryPopup.Visible)
            {
                // Lấy vị trí chuột trên màn hình
                Point cursor = Cursor.Position;

                // Kiểm tra: Nếu chuột KHÔNG nằm trong Panel lịch sử VÀ KHÔNG nằm trong nút Mở menu
                if (!pnlHistoryPopup.RectangleToScreen(pnlHistoryPopup.ClientRectangle).Contains(cursor) &&
                    !btnTitleLeft.RectangleToScreen(btnTitleLeft.ClientRectangle).Contains(cursor))
                {
                    HideHistoryPopup(); // Tắt panel
                }
            }
            return false;
        }

        private void ShowHistoryPopup()
        {
            if (pnlHistoryPopup.Visible) return;

            // Đặt vị trí
            pnlHistoryPopup.Location = new Point(btnTitleLeft.Left + panelTitleBar.Left, btnTitleLeft.Bottom + panelTitleBar.Top);
            RefreshHistoryListUI();
            pnlHistoryPopup.Visible = true;
            pnlHistoryPopup.BringToFront();

            // Đăng ký bộ lọc tin nhắn để bắt sự kiện click ra ngoài
            Application.AddMessageFilter(this);
        }

        private void HideHistoryPopup()
        {
            pnlHistoryPopup.Visible = false;
            // Hủy đăng ký bộ lọc để tiết kiệm tài nguyên
            Application.RemoveMessageFilter(this);
        }
        // ------------------------------------------------

        private void LoadHistory()
        {
            chatHistory.Clear();
            try
            {
                chatHistory = chatDAO.GetHistory();
            }
            catch (Exception ex) { MessageBox.Show("Lỗi tải lịch sử: " + ex.Message); }
        }

        private void SaveHistory()
        {
            try
            {
                chatHistory = chatHistory.OrderByDescending(x => x.CreatedAt).ToList();
                string json = JsonConvert.SerializeObject(chatHistory, Formatting.Indented);
                System.IO.File.WriteAllText(HISTORY_FILE, json);
            }
            catch { }
        }

        private void SetupHistoryPanel()
        {
            // 1. Khởi tạo Panel khung (Container)
            pnlHistoryPopup = new Panel();
            pnlHistoryPopup.Width = 320;
            pnlHistoryPopup.Height = 400;
            pnlHistoryPopup.Visible = false;

            // --- THAY ĐỔI QUAN TRỌNG TẠI ĐÂY ---

            // A. Đổi màu nền sang xám nhạt để tách biệt với form trắng
            // (Màu 245, 245, 245 là màu xám khói rất nhẹ, sang trọng)
            pnlHistoryPopup.BackColor = Color.FromArgb(245, 245, 245);

            // B. Bỏ hoàn toàn viền
            pnlHistoryPopup.BorderStyle = BorderStyle.None;

            // C. Padding để nội dung không dính sát mép
            pnlHistoryPopup.Padding = new Padding(5);

            // D. Chỉ cắt bo góc, KHÔNG vẽ viền đen nữa (sạch sẽ, không răng cưa)
            pnlHistoryPopup.Paint += (s, e) =>
            {
                BoGoc(pnlHistoryPopup, 12);
            };

            // ------------------------------------

            // 2. Setup danh sách cuộn bên trong
            flowHistoryList = new FlowLayoutPanel();
            flowHistoryList.Dock = DockStyle.Fill;
            flowHistoryList.FlowDirection = FlowDirection.TopDown;
            flowHistoryList.WrapContents = false;
            flowHistoryList.AutoScroll = true;

            // QUAN TRỌNG: Màu nền danh sách phải trùng màu khung
            flowHistoryList.BackColor = Color.FromArgb(245, 245, 245);
            flowHistoryList.Padding = new Padding(5);

            pnlHistoryPopup.Controls.Add(flowHistoryList);
            this.Controls.Add(pnlHistoryPopup);
            pnlHistoryPopup.BringToFront();

            // 3. Nút bấm tiêu đề
            btnTitleLeft.Text = "🗂️ Danh sách đoạn chat ⌄";

            // Reset sự kiện click để tránh lỗi
            btnTitleLeft.Click -= BtnTitleLeft_Click;
            btnTitleLeft.Click += BtnTitleLeft_Click;
        }

        // Hàm sự kiện click (Giữ nguyên)
        private void BtnTitleLeft_Click(object? sender, EventArgs e)
        {
            if (pnlHistoryPopup.Visible) HideHistoryPopup();
            else ShowHistoryPopup();
        }
        private void RefreshHistoryListUI()
        {
            flowHistoryList.Controls.Clear();
            var groups = chatHistory.GroupBy(x => x.CreatedAt.Date == DateTime.Today ? "Hôm nay" : "Cũ hơn");

            foreach (var group in groups)
            {
                Label lblHeader = new Label();
                lblHeader.Text = group.Key;
                lblHeader.Font = new Font("Segoe UI", 8, FontStyle.Bold);
                lblHeader.ForeColor = Color.Gray;
                lblHeader.AutoSize = true;
                lblHeader.Margin = new Padding(5, 10, 0, 5);
                flowHistoryList.Controls.Add(lblHeader);

                foreach (var session in group)
                {
                    Panel row = CreateHistoryRow(session);
                    flowHistoryList.Controls.Add(row);
                }
            }

            if (chatHistory.Count == 0)
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Chưa có cuộc trò chuyện nào.";
                lblEmpty.AutoSize = true;
                lblEmpty.ForeColor = Color.Gray;
                lblEmpty.Margin = new Padding(10);
                flowHistoryList.Controls.Add(lblEmpty);
            }
        }

        private Panel CreateHistoryRow(ChatSession session)
        {
            // Kiểm tra xem dòng này có đang được chọn không
            bool isSelected = (currentSession != null && currentSession.Id == session.Id);


            // 1. TẠO CÁI KHUNG (PANEL) - ĐÂY CHÍNH LÀ CÁI "NỀN" BẠN MUỐN BO
            Panel pnlRow = new Panel();
            pnlRow.Width = flowHistoryList.Width - 25; // Trừ hao thanh cuộn
            pnlRow.Height = 38; // Chiều cao vừa vặn
            pnlRow.Margin = new Padding(5, 0, 5, 4); // Cách xa các dòng khác một chút
            pnlRow.Cursor = Cursors.Hand;
            pnlRow.Padding = new Padding(5); // Đệm bên trong để chữ không dính mép

            // --- MẤU CHỐT 1: MÀU NỀN ---
            // Nếu được chọn -> Màu xanh nhạt (Notion). Không chọn -> Màu trắng.
            pnlRow.BackColor = isSelected ? Color.FromArgb(235, 245, 255) : Color.White;

            // --- MẤU CHỐT 2: BO GÓC ---
            // Gọi hàm bo góc cho chính cái khung này
            BoGoc(pnlRow, 10);

            // 2. ICON BÊN TRÁI
            Label lblIcon = new Label();
            lblIcon.Dock = DockStyle.Left;
            lblIcon.Width = 30;
            lblIcon.TextAlign = ContentAlignment.MiddleCenter;
            lblIcon.Font = new Font("Segoe UI Emoji", 10);
            lblIcon.Text = isSelected ? "✓" : "📄";
            lblIcon.ForeColor = isSelected ? NOTION_BLUE : Color.Gray;

            // --- MẤU CHỐT 3: TRONG SUỐT ---
            // Phải để Transparent để lộ cái góc bo của pnlRow ra
            lblIcon.BackColor = Color.Transparent;

            // 3. NÚT XÓA (BÊN PHẢI)
            Label btnDelete = new Label();
            btnDelete.Text = "🗑";
            btnDelete.Dock = DockStyle.Right;
            btnDelete.Width = 30;
            btnDelete.TextAlign = ContentAlignment.MiddleCenter;
            btnDelete.Font = new Font("Segoe UI Emoji", 9);
            btnDelete.ForeColor = Color.Gray;
            btnDelete.Visible = false; // Ẩn đi, hover mới hiện
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.BackColor = Color.Transparent; // Cũng phải trong suốt

            // 4. TIÊU ĐỀ (CHỮ)
            Label lblTitle = new Label();
            lblTitle.Text = session.Title;
            lblTitle.Dock = DockStyle.Fill; // Lấp đầy khoảng trống ở giữa
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            lblTitle.Font = new Font("Segoe UI", 9.5F, isSelected ? FontStyle.Bold : FontStyle.Regular);
            lblTitle.ForeColor = isSelected ? NOTION_BLUE : Color.FromArgb(64, 64, 64);
            lblTitle.AutoEllipsis = true;
            lblTitle.BackColor = Color.Transparent; // QUAN TRỌNG NHẤT: Chữ phải trong suốt nền

            // --- XỬ LÝ SỰ KIỆN ---

            // Sự kiện mở chat
            EventHandler openChat = (s, e) => {
                HideHistoryPopup();
                LoadChatSession(session);
            };
            pnlRow.Click += openChat;
            lblTitle.Click += openChat;
            lblIcon.Click += openChat;

            // Sự kiện Hover (Di chuột vào đổi màu nền)
            void HoverEnter(object? s, EventArgs e)
            {
                if (!isSelected) pnlRow.BackColor = Color.FromArgb(242, 242, 242); // Màu xám nhạt khi hover
                btnDelete.Visible = true;
            }
            void HoverLeave(object? s, EventArgs e)
            {
                // Kiểm tra chuột thực sự rời đi chưa
                if (!pnlRow.ClientRectangle.Contains(pnlRow.PointToClient(Cursor.Position)))
                {
                    if (!isSelected) pnlRow.BackColor = Color.White; // Trả về màu trắng
                    btnDelete.Visible = false;
                }
            }

            // Gán sự kiện hover cho tất cả
            pnlRow.MouseEnter += HoverEnter; pnlRow.MouseLeave += HoverLeave;
            lblTitle.MouseEnter += HoverEnter; lblTitle.MouseLeave += HoverLeave;
            lblIcon.MouseEnter += HoverEnter; lblIcon.MouseLeave += HoverLeave;

            // Xử lý nút xóa
            btnDelete.MouseEnter += (s, e) => { btnDelete.ForeColor = DELETE_RED; HoverEnter(s, e); };
            btnDelete.MouseLeave += (s, e) => { btnDelete.ForeColor = Color.Gray; HoverLeave(s, e); };
            btnDelete.Click += (s, e) => {
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    // GỌI DAO: Xóa trong DB
                    chatDAO.DeleteSession(session.Id);

                    // Xóa trên giao diện
                    chatHistory.Remove(session);
                    RefreshHistoryListUI();

                    if (currentSession != null && currentSession.Id == session.Id) StartNewChat();
                }
            };

            // Add controls (Thứ tự: Right -> Left -> Fill)
            pnlRow.Controls.Add(lblTitle);    // Fill
            pnlRow.Controls.Add(btnDelete);   // Right
            pnlRow.Controls.Add(lblIcon);     // Left

            return pnlRow;
        }
        private void StartNewChat()
        {
            flowActions.Controls.Clear();
            flowActions.Controls.Add(btnAction1);
            flowActions.Controls.Add(btnAction2);
            flowActions.Controls.Add(btnAction4);

            currentSession = null;
            txtInput.Text = "";
            lblGreeting.Text = "Xin hỏi hoàng thượng muốn thần làm gì?";
        }

        private void LoadChatSession(ChatSession session)
        {
            currentSession = session;
            flowActions.Controls.Clear();

            // 1. Gọi DAO lấy danh sách tin nhắn
            List<ChatMessage> messages = chatDAO.GetMessages(session.Id);

            session.Messages.Clear();

            foreach (var msg in messages)
            {
                // Hiển thị lên giao diện
                AddMessageBubble(msg.Content, msg.IsUser, msg.Files, isHistoryLoading: true);

                // Lưu vào RAM
                session.Messages.Add(msg);
            }

            ScrollToBottom();
        }


        // --- LOGIC CUSTOM SCROLLBAR (GIỮ NGUYÊN) ---
        private void SetupCustomScrollbar()
        {
            flowActions.AutoScroll = true;
            flowActions.WrapContents = false;
            flowActions.FlowDirection = FlowDirection.TopDown;

            ShowScrollBar(flowActions.Handle, SB_VERT, false);

            pnlScrollTrack = new Panel();
            pnlScrollTrack.Width = 8;
            pnlScrollTrack.BackColor = Color.Transparent;
            pnlScrollTrack.Dock = DockStyle.Right;
            pnlScrollTrack.Cursor = Cursors.Default;

            pnlScrollThumb = new Panel();
            pnlScrollThumb.Width = 6;
            pnlScrollThumb.BackColor = Color.FromArgb(200, 200, 200);
            pnlScrollThumb.Left = 1;
            pnlScrollThumb.Height = 50;
            BoGoc(pnlScrollThumb, 3);

            pnlScrollTrack.Controls.Add(pnlScrollThumb);
            panelBody.Controls.Add(pnlScrollTrack);
            pnlScrollTrack.BringToFront();

            flowActions.SizeChanged += (s, e) => UpdateScrollbarParams();
            flowActions.Layout += (s, e) => {
                ShowScrollBar(flowActions.Handle, SB_VERT, false);
                UpdateScrollbarParams();
            };
            flowActions.MouseWheel += (s, e) => UpdateScrollThumbPosition();

            pnlScrollThumb.MouseDown += (s, e) => {
                isDraggingScroll = true;
                lastMouseScroll = e.Location;
                pnlScrollThumb.BackColor = Color.FromArgb(160, 160, 160);
            };

            pnlScrollThumb.MouseMove += (s, e) => {
                if (!isDraggingScroll || pnlScrollThumb.Parent == null) return;
                int deltaY = e.Y - lastMouseScroll.Y;
                int newTop = pnlScrollThumb.Top + deltaY;
                if (newTop < 0) newTop = 0;
                if (newTop > pnlScrollTrack.Height - pnlScrollThumb.Height)
                    newTop = pnlScrollTrack.Height - pnlScrollThumb.Height;
                pnlScrollThumb.Top = newTop;
                float percent = (float)newTop / (pnlScrollTrack.Height - pnlScrollThumb.Height);
                int scrollVal = (int)(percent * (flowActions.DisplayRectangle.Height - flowActions.Height));
                flowActions.AutoScrollPosition = new Point(0, scrollVal);
            };

            pnlScrollThumb.MouseUp += (s, e) => {
                isDraggingScroll = false;
                pnlScrollThumb.BackColor = Color.FromArgb(200, 200, 200);
            };
        }

        private void UpdateScrollbarParams()
        {
            if (pnlScrollTrack == null || pnlScrollThumb == null) return;
            ShowScrollBar(flowActions.Handle, SB_VERT, false);
            int contentHeight = flowActions.DisplayRectangle.Height;
            int viewHeight = flowActions.Height;
            if (contentHeight <= viewHeight) { pnlScrollTrack.Visible = false; return; }
            pnlScrollTrack.Visible = true;
            int thumbHeight = (int)((float)viewHeight / contentHeight * viewHeight);
            if (thumbHeight < 30) thumbHeight = 30;
            if (pnlScrollThumb.Height != thumbHeight) { pnlScrollThumb.Height = thumbHeight; BoGoc(pnlScrollThumb, 3); }
            UpdateScrollThumbPosition();
        }

        private void UpdateScrollThumbPosition()
        {
            if (pnlScrollTrack == null || pnlScrollThumb == null || isDraggingScroll) return;
            int contentHeight = flowActions.DisplayRectangle.Height;
            int viewHeight = flowActions.Height;
            int maxScroll = contentHeight - viewHeight;
            if (maxScroll <= 0) return;
            int currentScroll = Math.Abs(flowActions.AutoScrollPosition.Y);
            float percent = (float)currentScroll / maxScroll;
            int maxThumbTop = pnlScrollTrack.Height - pnlScrollThumb.Height;
            pnlScrollThumb.Top = (int)(percent * maxThumbTop);
        }

        private void ScrollToBottom()
        {
            flowActions.AutoScrollPosition = new Point(0, flowActions.DisplayRectangle.Height);
            UpdateScrollThumbPosition();
        }

        // --- HÀM GỌI API GEMINI ---
        // Sửa lại hàm này để nhận vào cả lịch sử chat
        private async Task<string> GetGeminiResponse(string userMessage, List<string> filePaths)
        {
            if (string.IsNullOrEmpty(API_KEY)) return "⚠️ Lỗi: Bạn chưa nhập API Key.";

            string url = $"https://generativelanguage.googleapis.com/v1beta/models/{currentModel}:generateContent?key={API_KEY}";

            try
            {
                // 1. Tạo danh sách contents (Chứa cả lịch sử + câu hỏi mới)
                var contentsList = new List<object>();

                // A. Thêm lịch sử chat cũ (Nếu có session)
                if (currentSession != null && currentSession.Messages.Count > 0)
                {
                    // Lấy 20 tin nhắn gần nhất để tránh quá tải token (Tùy chỉnh số này)
                    var recentMessages = currentSession.Messages.Skip(Math.Max(0, currentSession.Messages.Count - 20));

                    foreach (var msg in recentMessages)
                    {
                        // Role: Nếu là User thì là "user", Bot thì là "model"
                        string role = msg.IsUser ? "user" : "model";

                        // Gemini yêu cầu parts phải là mảng
                        contentsList.Add(new
                        {
                            role = role,
                            parts = new[] { new { text = msg.Content } }
                        });
                    }
                }

                // B. Chuẩn bị nội dung cho câu hỏi MỚI hiện tại
                var currentParts = new List<object>();

                // Thêm Text câu hỏi
                if (!string.IsNullOrEmpty(userMessage))
                {
                    currentParts.Add(new { text = userMessage });
                }

                // Thêm File (Nếu có)
                if (filePaths != null && filePaths.Count > 0)
                {
                    foreach (string filePath in filePaths)
                    {
                        if (!System.IO.File.Exists(filePath)) continue;
                        string mimeType = GetMimeType(filePath);

                        if (mimeType == "text/plain" || filePath.EndsWith(".cs") || filePath.EndsWith(".sql") || filePath.EndsWith(".json"))
                        {
                            currentParts.Add(new { text = $"\n\n[File: {System.IO.Path.GetFileName(filePath)}]:\n{System.IO.File.ReadAllText(filePath)}" });
                        }
                        else
                        {
                            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
                            currentParts.Add(new { inline_data = new { mime_type = mimeType, data = Convert.ToBase64String(fileBytes) } });
                        }
                    }
                }

                // Add câu hỏi hiện tại vào danh sách contents
                contentsList.Add(new { role = "user", parts = currentParts.ToArray() });

                // 2. Đóng gói JSON cuối cùng
                var requestBody = new { contents = contentsList.ToArray() };

                string jsonBody = JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonBody, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(url, content);
                string responseString = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    dynamic jsonResponse = JsonConvert.DeserializeObject(responseString);
                    if (jsonResponse.candidates != null && jsonResponse.candidates.Count > 0)
                        return jsonResponse.candidates[0].content.parts[0].text;
                    return "🤖 AI không trả về nội dung.";
                }
                else
                {
                    return $"⚠️ Lỗi API ({response.StatusCode}): {responseString}";
                }
            }
            catch (Exception ex) { return $"❌ Lỗi hệ thống: {ex.Message}"; }
        }

        // --- LOGIC GIAO DIỆN CHAT ---
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

        // --- HÀM GỬI TIN NHẮN ---
        private async void PerformSendMessage()
        {
            // 🔥 1. CHẶN LẶP: Nếu đang gửi rồi thì thoát ngay, không chạy tiếp
            if (isSending) return;

            // 🔥 2. ĐÁNH DẤU: Bắt đầu gửi
            isSending = true;

            try // Dùng try để đảm bảo dù lỗi thì cuối cùng vẫn mở khóa
            {
                string question = txtInput.Text.Trim();

                if ((string.IsNullOrEmpty(question) || question == "Hỏi AI...") && tempAttachedFiles.Count == 0) return;
                if (question == "Hỏi AI...") question = "";

                // Xóa gợi ý nếu có
                if (flowActions.Controls.Count > 0 && flowActions.Controls.Contains(btnAction1))
                    flowActions.Controls.Clear();

                // --- LẤY FILE VÀ RESET UI ---
                List<string> sentFiles = new List<string>(tempAttachedFiles);
                tempAttachedFiles.Clear();
                pnlPreviewContainer.Controls.Clear();
                pnlPreviewContainer.Height = 0;

                txtInput.Text = "";
                txtInput.Focus();

                // HIỂN THỊ TIN NHẮN USER LÊN UI
                AddMessageBubble(question, true, sentFiles);

                // ================= [LƯU USER] =================
                if (currentSession == null)
                {
                    currentSession = new ChatSession()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = !string.IsNullOrEmpty(question) ? question : "Đoạn chat có file...",
                        CreatedAt = DateTime.Now
                    };
                    chatHistory.Insert(0, currentSession);
                    chatDAO.AddSession(currentSession);
                }
                chatDAO.AddMessage(currentSession.Id, question, true, sentFiles);

                // HIỆN TRẠNG THÁI ĐANG NGHĨ
                Label lblThinking = new Label();
                lblThinking.Text = "AI đang suy nghĩ...";
                lblThinking.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                lblThinking.ForeColor = Color.Gray;
                lblThinking.AutoSize = true;
                lblThinking.Margin = new Padding(45, 0, 0, 10);
                flowActions.Controls.Add(lblThinking);
                ScrollToBottom();
                txtInput.Enabled = false;

                // GỌI API GEMINI
                string aiResponse = await GetGeminiResponse(question, sentFiles);

                flowActions.Controls.Remove(lblThinking);

                // HIỂN THỊ CÂU TRẢ LỜI
                AddMessageBubble(aiResponse, isUser: false);

                // ================= [LƯU BOT] =================
                chatDAO.AddMessage(currentSession.Id, aiResponse, false);

                txtInput.Enabled = true;
                txtInput.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                txtInput.Enabled = true;
            }
            finally
            {
                // 🔥 3. MỞ KHÓA: Xong việc rồi, cho phép gửi tiếp
                isSending = false;
            }
        }

        private void AddMessageBubble(string text, bool isUser, List<string> files = null, bool isHistoryLoading = false)
        {
            // 1. TẠO PANEL CONTAINER CHÍNH
            FlowLayoutPanel pnlMsg = new FlowLayoutPanel();
            pnlMsg.AutoSize = true;
            pnlMsg.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlMsg.FlowDirection = FlowDirection.LeftToRight;
            pnlMsg.WrapContents = false;
            pnlMsg.Width = flowActions.Width - 25;
            pnlMsg.Margin = new Padding(0, 0, 0, 15);
            pnlMsg.BackColor = Color.Transparent;

            // ICON (Avatar)
            Label lblIcon = new Label();
            lblIcon.Size = new Size(35, 35);
            lblIcon.Font = new Font("Segoe UI Emoji", 14);
            lblIcon.Text = isUser ? "👤" : "🤖";
            lblIcon.TextAlign = ContentAlignment.TopCenter;
            lblIcon.Margin = new Padding(0, 0, 8, 0);

            // 2. CỘT NỘI DUNG (Chứa Text + File + NÚT CHỨC NĂNG)
            FlowLayoutPanel pnlContentColumn = new FlowLayoutPanel();
            pnlContentColumn.AutoSize = true;
            pnlContentColumn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlContentColumn.FlowDirection = FlowDirection.TopDown;
            pnlContentColumn.WrapContents = false;
            pnlContentColumn.Width = pnlMsg.Width - 50;
            pnlContentColumn.Margin = new Padding(0);

            // --- A. HIỂN THỊ TEXT ---
            if (!string.IsNullOrEmpty(text))
            {
                Label lblContent = new Label();
                lblContent.AutoSize = true;
                lblContent.MaximumSize = new Size(pnlContentColumn.Width - 20, 0);
                lblContent.Font = new Font("Segoe UI", 11);
                lblContent.ForeColor = Color.FromArgb(55, 53, 47);
                lblContent.Text = text;

                if (isUser)
                {
                    lblContent.BackColor = Color.FromArgb(235, 245, 255);
                    lblContent.Padding = new Padding(12, 8, 12, 8);
                    BoGoc(lblContent, 15);
                    lblContent.Margin = new Padding(0, 0, 0, 5);
                }
                else
                {
                    lblContent.BackColor = Color.Transparent;
                    lblContent.Padding = new Padding(0, 6, 0, 0);
                }
                pnlContentColumn.Controls.Add(lblContent);

                // Hiệu ứng gõ chữ (chỉ chạy khi AI trả lời mới)
                if (!isUser && !isHistoryLoading) StartTypingEffect(lblContent, text);
            }

            // --- B. HIỂN THỊ FILE ĐÍNH KÈM ---
            if (files != null && files.Count > 0)
            {
                foreach (string filePath in files)
                {
                    string fileName = System.IO.Path.GetFileName(filePath);
                    Label btnFile = new Label();
                    btnFile.Text = "📄 " + fileName;
                    btnFile.Font = new Font("Segoe UI", 10, FontStyle.Underline);
                    btnFile.ForeColor = Color.FromArgb(35, 131, 226);
                    btnFile.AutoSize = true;
                    btnFile.Padding = new Padding(5, 2, 5, 2);
                    btnFile.Cursor = Cursors.Hand;
                    btnFile.Margin = new Padding(0, 0, 0, 2);

                    btnFile.Click += (s, e) => {
                        try { System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(filePath) { UseShellExecute = true }); }
                        catch { MessageBox.Show("Không tìm thấy file."); }
                    };
                    btnFile.MouseEnter += (s, e) => btnFile.BackColor = Color.FromArgb(240, 240, 240);
                    btnFile.MouseLeave += (s, e) => btnFile.BackColor = Color.Transparent;

                    pnlContentColumn.Controls.Add(btnFile);
                }
            }
           // --- C. HIỂN THỊ CÁC NÚT CHỨC NĂNG \

            FlowLayoutPanel pnlTools = new FlowLayoutPanel();
            pnlTools.AutoSize = true;
            pnlTools.FlowDirection = FlowDirection.LeftToRight;
            pnlTools.BackColor = Color.Transparent;
            pnlTools.Margin = new Padding(2, 5, 0, 0); // Cách tin nhắn 5px

            // 1. NÚT COPY (Dùng chung cho cả User và Bot)
            pnlTools.Controls.Add(CreateMsgActionButton("❐", "Sao chép", () => {
                if (!string.IsNullOrEmpty(text))
                {
                    Clipboard.SetText(text);
                    MessageBox.Show("Đã sao chép!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }));

            if (isUser)
            {
                // 2. NÚT SỬA (Chỉ hiện cho User) -> Đẩy text vào ô nhập liệu để sửa
                pnlTools.Controls.Add(CreateMsgActionButton("✎", "Sửa câu hỏi", () => {
                    txtInput.Text = text;
                    txtInput.Focus();
                }));
            }
            else
            {
                // 3. NÚT CỘNG (Chỉ hiện cho Bot) -> Để thêm vào bài viết sau này
                pnlTools.Controls.Add(CreateMsgActionButton("⊕", "Thêm vào bài viết", () => {
                    // --- CHỖ NÀY ĐỂ BẠN VIẾT CODE SAU NÀY ---
                    MessageBox.Show("Tính năng [Thêm nội dung này vào bài viết] đang phát triển!", "Coming Soon");
                }));
            }

            // Thêm thanh công cụ vào cột nội dung
            pnlContentColumn.Controls.Add(pnlTools);

            // 3. GHÉP LẠI
            pnlMsg.Controls.Add(lblIcon);
            pnlMsg.Controls.Add(pnlContentColumn);
            flowActions.Controls.Add(pnlMsg);

            if (isUser || isHistoryLoading) ScrollToBottom();
        }

        private Label CreateToolButton(string icon, string tooltipText)
        {
            Label btn = new Label();
            btn.Text = icon;
            btn.Font = new Font("Segoe UI Symbol", 10F); // Font hỗ trợ icon tốt
            btn.ForeColor = Color.Gray;
            btn.AutoSize = true;
            btn.Cursor = Cursors.Hand;
            btn.Margin = new Padding(0, 0, 8, 0); // Khoảng cách giữa các nút

            // Tooltip
            toolTip1.SetToolTip(btn, tooltipText);

            // Hiệu ứng Hover vào nút thì đổi màu xanh Notion
            btn.MouseEnter += (s, e) => btn.ForeColor = NOTION_BLUE;
            btn.MouseLeave += (s, e) => btn.ForeColor = Color.Gray;

            return btn;
        }

        private void StartTypingEffect(Label targetLabel, string fullText)
        {
            if (string.IsNullOrEmpty(fullText)) return;
            System.Windows.Forms.Timer typingTimer = new System.Windows.Forms.Timer();
            typingTimer.Interval = fullText.Length > 200 ? 5 : 15;
            int currentIndex = 0;

            typingTimer.Tick += (s, e) => {
                if (targetLabel.IsDisposed) { typingTimer.Stop(); return; }
                int charsToAdd = fullText.Length > 200 ? 5 : 1;
                for (int i = 0; i < charsToAdd; i++)
                {
                    if (currentIndex < fullText.Length)
                    {
                        targetLabel.Text += fullText[currentIndex];
                        currentIndex++;
                    }
                }
                if (currentIndex % 20 == 0)
                {
                    flowActions.AutoScrollPosition = new Point(0, flowActions.DisplayRectangle.Height);
                    UpdateScrollThumbPosition();
                }
                if (currentIndex >= fullText.Length)
                {
                    typingTimer.Stop();
                    typingTimer.Dispose();
                    ScrollToBottom();
                    UpdateScrollbarParams();
                }
            };
            typingTimer.Start();
        }

        // --- CÁC HÀM GIAO DIỆN PHỤ TRỢ ---
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

            // Thay thế đoạn btnAttach.Click cũ bằng đoạn này:
            btnAttach.Click += (s, e) => {
                using (OpenFileDialog ofd = new OpenFileDialog())
                {
                    ofd.Multiselect = true;
                    ofd.Filter = "All Files (*.*)|*.*"; // Cho phép chọn mọi loại file

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        foreach (string file in ofd.FileNames)
                        {
                            // Kiểm tra trùng lặp nếu muốn, ở đây tôi cho thêm thoải mái
                            tempAttachedFiles.Add(file);
                            AddFileChipToPreview(file); // Gọi hàm tạo chip
                        }
                        // Hiện khung preview lên
                        pnlPreviewContainer.Height = 40;
                    }
                }
            };
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

        private void SetupGiaoDien()
        {
            // --- 1. SETUP CÁC NÚT TRÊN (GIỮ NGUYÊN) ---
            btnEdit.Width = 40; btnMode.Width = 40; btnHide.Width = 40;
            btnEdit.Font = new Font("Segoe MDL2 Assets", 10F); btnEdit.Text = "\uE70F";
            btnMode.Font = new Font("Segoe MDL2 Assets", 10F); btnMode.Text = "\uE922";
            btnHide.Font = new Font("Segoe MDL2 Assets", 10F); btnHide.Text = "\uE921";
            BoGoc(btnEdit, 20); BoGoc(btnMode, 20); BoGoc(btnHide, 20);

            toolTip1.SetToolTip(btnEdit, "Cuộc trò chuyện mới với AI");
            toolTip1.SetToolTip(btnMode, this.Height < Screen.FromControl(this).WorkingArea.Height ? "Kéo dài dọc màn hình" : "Thu nhỏ về mặc định");
            toolTip1.SetToolTip(btnHide, "Ẩn cuộc trò chuyện");

            btnTitleLeft.Dock = DockStyle.None; btnTitleLeft.AutoSize = false;
            btnTitleLeft.Size = new Size(220, 30); btnTitleLeft.Location = new Point(12, 5);
            BoGoc(btnTitleLeft, 15);

            BoGoc(this, 12); BoGoc(btnSend, 18);
            BoGoc(btnAction1, 22); BoGoc(btnAction2, 22); BoGoc(btnAction4, 22);
            BoGoc(lblTagNew, 8);

            if (panelInputContainer.Controls.Contains(lblContextTag))
                panelInputContainer.Controls.Remove(lblContextTag);

            // --- 2. KHUNG INPUT ---
            panelInputContainer.Controls.Clear();
            panelInputContainer.Padding = new Padding(15, 15, 10, 5);
            panelInputContainer.BackColor = Color.White;

            int minFooterHeight = 180;
            int maxFooterHeight = 250;

            panelFooter.Height = minFooterHeight;
            panelFooter.BackColor = Color.White;

            // --- 3. TOOLS BAR (giữ nguyên control panelInputTools của bạn) ---
            panelInputTools.Height = 50;
            panelInputTools.BackColor = Color.White;
            panelInputTools.Padding = new Padding(0, 5, 0, 0);
            panelInputTools.Dock = DockStyle.Fill; // IMPORTANT: vì sẽ đặt vào TableLayoutPanel

            // --- 4. TEXTBOX WRAPPER ---
            Panel pnlTextWrapper = new Panel();
            pnlTextWrapper.Dock = DockStyle.Fill;
            pnlTextWrapper.BackColor = Color.White;
            pnlTextWrapper.Padding = new Padding(0, 0, 0, 5);

            txtInput.Dock = DockStyle.Fill;
            txtInput.Font = new Font("Segoe UI", 11.5F);
            txtInput.Multiline = true;
            txtInput.WordWrap = true;
            txtInput.BorderStyle = BorderStyle.None;
            txtInput.ScrollBars = ScrollBars.None;
            txtInput.BackColor = Color.White;

            pnlTextWrapper.Controls.Add(txtInput);

            // --- 5. TABLE LAYOUT: 2 hàng (Text ở trên, Tools ở dưới) ---
            var tbl = new TableLayoutPanel();
            tbl.Dock = DockStyle.Fill;
            tbl.BackColor = Color.White;
            tbl.ColumnCount = 1;
            tbl.RowCount = 2;
            tbl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));         // Text
            tbl.RowStyles.Add(new RowStyle(SizeType.Absolute, panelInputTools.Height)); // Tools

            tbl.Controls.Add(pnlTextWrapper, 0, 0);
            tbl.Controls.Add(panelInputTools, 0, 1);

            panelInputContainer.Controls.Add(tbl);

            // --- 6. LOGIC GIÃN NỞ (Đã cập nhật tính cả chiều cao file đính kèm) ---
            txtInput.TextChanged -= TxtInput_TextChanged;
            txtInput.TextChanged += TxtInput_TextChanged;

            void TxtInput_TextChanged(object? sender, EventArgs e)
            {
                bool hasText = !string.IsNullOrWhiteSpace(txtInput.Text) && txtInput.Text != "Hỏi AI...";
                btnSend.BackColor = hasText ? NOTION_BLUE : Color.FromArgb(240, 240, 240);
                btnSend.ForeColor = hasText ? Color.White : Color.Gray;

                try
                {
                    int lineCount = txtInput.GetLineFromCharIndex(txtInput.TextLength) + 1;
                    if (txtInput.Text.EndsWith("\n")) lineCount++;

                    int textHeight = (lineCount * txtInput.Font.Height) + 50;

                    // TÍNH TOÁN LẠI CHIỀU CAO TỔNG:
                    // Bao gồm Padding trên dưới + Chiều cao của khung file đính kèm (nếu có)
                    int previewHeight = (pnlPreviewContainer != null) ? pnlPreviewContainer.Height : 0;

                    int paddingHeight =
                        panelInputContainer.Padding.Top +
                        panelInputContainer.Padding.Bottom +
                        pnlTextWrapper.Padding.Top +
                        pnlTextWrapper.Padding.Bottom +
                        previewHeight; // <--- Đã cộng thêm phần này

                    int toolsHeight = panelInputTools.Height;

                    int totalRequiredHeight = textHeight + toolsHeight + paddingHeight;

                    if (totalRequiredHeight <= minFooterHeight)
                    {
                        if (panelFooter.Height != minFooterHeight) panelFooter.Height = minFooterHeight;
                        if (txtInput.ScrollBars != ScrollBars.None) txtInput.ScrollBars = ScrollBars.None;
                    }
                    else if (totalRequiredHeight < maxFooterHeight)
                    {
                        if (panelFooter.Height != totalRequiredHeight) panelFooter.Height = totalRequiredHeight;
                        if (txtInput.ScrollBars != ScrollBars.None) txtInput.ScrollBars = ScrollBars.None;
                    }
                    else
                    {
                        if (panelFooter.Height != maxFooterHeight) panelFooter.Height = maxFooterHeight;
                        if (txtInput.ScrollBars == ScrollBars.None) txtInput.ScrollBars = ScrollBars.Vertical;

                        BeginInvoke(new Action(() =>
                        {
                            txtInput.SelectionStart = txtInput.TextLength;
                            txtInput.ScrollToCaret();
                        }));
                    }

                    panelInputContainer.Invalidate();
                }
                catch { }
            }

            // --- 7. VẼ VIỀN (GIỮ NGUYÊN) ---
            panelInputContainer.Paint -= PanelInputContainer_Paint;
            panelInputContainer.Paint += PanelInputContainer_Paint;

            void PanelInputContainer_Paint(object? s, PaintEventArgs e)
            {
                if (DesignMode) return;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Color borderColor = isInputFocused ? NOTION_BLUE : Color.FromArgb(220, 220, 220);

                if (!isInputFocused)
                {
                    using (GraphicsPath shadowPath = GetRoundedPath(new Rectangle(2, 2, panelInputContainer.Width - 4, panelInputContainer.Height - 2), 18))
                    using (Pen shadowPen = new Pen(Color.FromArgb(15, 0, 0, 0), 3))
                        e.Graphics.DrawPath(shadowPen, shadowPath);
                }

                using (Pen pen = new Pen(borderColor, isInputFocused ? 2 : 1))
                using (GraphicsPath path = GetRoundedPath(new Rectangle(1, 1, panelInputContainer.Width - 3, panelInputContainer.Height - 3), 18))
                    e.Graphics.DrawPath(pen, path);
            };

            txtInput.GotFocus += (s, e) =>
            {
                isInputFocused = true;
                panelInputContainer.Invalidate();
                if (txtInput.Text == "Hỏi AI...")
                {
                    txtInput.Text = "";
                    txtInput.ForeColor = Color.Black;
                }
            };

            txtInput.LostFocus += (s, e) =>
            {
                isInputFocused = false;
                panelInputContainer.Invalidate();
                if (string.IsNullOrWhiteSpace(txtInput.Text))
                {
                    txtInput.Text = "Hỏi AI...";
                    txtInput.ForeColor = Color.Gray;
                    panelFooter.Height = minFooterHeight;
                    txtInput.ScrollBars = ScrollBars.None;
                }
            };

            FixButtonColor(btnHide); FixButtonColor(btnMode); FixButtonColor(btnEdit); FixButtonColor(btnTitleLeft);
            SetupHoverEffect(btnHide); SetupHoverEffect(btnMode); SetupHoverEffect(btnEdit); SetupHoverEffect(btnTitleLeft);
            SetupHoverEffect(btnAction1); SetupHoverEffect(btnAction2); SetupHoverEffect(btnAction4);

            void ActionClick(string text) { txtInput.Text = text; txtInput.Focus(); SendKeys.Send("{ENTER}"); }
            AssignClickToPanel(btnAction1, () => ActionClick("Hãy tìm kiếm thông tin về..."));
            AssignClickToPanel(btnAction2, () => ActionClick("Giúp tôi soạn agenda cuộc họp về..."));
            AssignClickToPanel(btnAction4, () => ActionClick("Tạo bảng theo dõi nhiệm vụ cho dự án."));

            panelTitleBar.MouseDown += DragForm;
            lblGreeting.MouseDown += DragForm;
            panelHeader.MouseDown += DragForm;

            SetupAttachmentPreview();
        }

        // --- BIẾN ĐÍNH KÈM FILE (THÊM MỚI) ---
        private List<string> tempAttachedFiles = new List<string>(); // Lưu danh sách file đang chọn
        private FlowLayoutPanel pnlPreviewContainer; // Khung hiển thị tên file trước khi gửi

        // Hàm này để tạo cái khung chứa tên file ngay trên ô nhập liệu
        private void SetupAttachmentPreview()
        {
            // 1. Tạo khung chứa file
            pnlPreviewContainer = new FlowLayoutPanel();
            pnlPreviewContainer.Dock = DockStyle.Top;
            pnlPreviewContainer.Height = 0;
            pnlPreviewContainer.BackColor = Color.White;
            pnlPreviewContainer.FlowDirection = FlowDirection.LeftToRight;
            pnlPreviewContainer.WrapContents = false;
            pnlPreviewContainer.AutoScroll = true;
            pnlPreviewContainer.Padding = new Padding(5, 5, 0, 5);

            // 2. Đưa vào giao diện và xử lý thứ tự hiển thị (Z-Order)
            if (txtInput.Parent != null)
            {
                Control parentPanel = txtInput.Parent; // Đây chính là pnlTextWrapper

                // Gỡ txtInput ra tạm thời
                parentPanel.Controls.Remove(txtInput);

                // Thêm khung file vào
                parentPanel.Controls.Add(pnlPreviewContainer);

                // Thêm lại txtInput vào sau
                parentPanel.Controls.Add(txtInput);

                // --- QUAN TRỌNG: Cài đặt Dock và Thứ tự ưu tiên ---
                pnlPreviewContainer.Dock = DockStyle.Top;
                txtInput.Dock = DockStyle.Fill;

                // Lệnh SendToBack() đẩy khung file xuống "đáy" của danh sách quản lý layout
                // Trong WinForms, Dock=Top nằm ở "đáy" sẽ được ưu tiên xếp chỗ trước
                pnlPreviewContainer.SendToBack();

                // Lệnh BringToFront() đưa khung chat lên "đầu", nó sẽ lấp đầy phần diện tích CÒN LẠI
                txtInput.BringToFront();
            }
        }

        private void AddFileChipToPreview(string filePath)
        {
            string fileName = System.IO.Path.GetFileName(filePath);

            // 1. Panel bao bên ngoài (Cái thẻ)
            Panel pnlChip = new Panel();
            pnlChip.AutoSize = true;
            pnlChip.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlChip.BackColor = Color.FromArgb(242, 242, 242); // Màu xám nhạt
            pnlChip.Padding = new Padding(8, 4, 8, 4);
            pnlChip.Margin = new Padding(0, 0, 8, 0);
            pnlChip.Cursor = Cursors.Default;

            // Sự kiện vẽ bo góc cho cái thẻ (gọi hàm BoGoc có sẵn của bạn)
            pnlChip.Paint += (s, e) => BoGoc(pnlChip, 12);

            // 2. Tên file
            Label lblName = new Label();
            lblName.Text = "📎 " + (fileName.Length > 20 ? fileName.Substring(0, 17) + "..." : fileName);
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9);
            lblName.ForeColor = Color.Black;
            lblName.Location = new Point(5, 5);
            lblName.BackColor = Color.Transparent;

            // 3. Nút Xóa (Dấu X)
            Label btnRemove = new Label();
            btnRemove.Text = "✕";
            btnRemove.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnRemove.ForeColor = Color.Gray;
            btnRemove.AutoSize = true;
            btnRemove.Cursor = Cursors.Hand;
            btnRemove.Margin = new Padding(5, 0, 0, 0);
            btnRemove.BackColor = Color.Transparent;

            // Xử lý xóa file
            btnRemove.Click += (s, e) => {
                tempAttachedFiles.Remove(filePath);
                pnlPreviewContainer.Controls.Remove(pnlChip);
                if (tempAttachedFiles.Count == 0) pnlPreviewContainer.Height = 0; // Ẩn khung nếu hết file
            };

            // Hiệu ứng hover nút X
            btnRemove.MouseEnter += (s, e) => btnRemove.ForeColor = Color.Red;
            btnRemove.MouseLeave += (s, e) => btnRemove.ForeColor = Color.Gray;

            // Layout bên trong chip
            FlowLayoutPanel flowContent = new FlowLayoutPanel();
            flowContent.AutoSize = true;
            flowContent.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowContent.FlowDirection = FlowDirection.LeftToRight;
            flowContent.BackColor = Color.Transparent;
            flowContent.Controls.Add(lblName);
            flowContent.Controls.Add(btnRemove);

            pnlChip.Controls.Add(flowContent);
            pnlPreviewContainer.Controls.Add(pnlChip);
        }

        private void AssignClickToPanel(Control pnl, Action action)
        {
            EventHandler handler = (object? s, EventArgs e) => action();
            pnl.Click += handler;
            foreach (Control child in pnl.Controls) child.Click += handler;
        }

        private void SetupMenus()
        {
            // 1. Cấu hình giao diện Menu (giữ nguyên)
            ToolStripProfessionalRenderer notionRenderer = new ToolStripProfessionalRenderer(new NotionColorTable());
            notionRenderer.RoundedEdges = true;

            // --- MENU 1: CHỌN MODEL (TỰ ĐỘNG) ---
            menuAuto = new ContextMenuStrip();
            menuAuto.Renderer = notionRenderer;
            menuAuto.Font = new Font("Segoe UI", 9F);

            // Đổi tên hiển thị cho đúng ý bạn (gemini-2.5-flash)
            var itemAuto = new ToolStripMenuItem("Gemini 2.5 Flash") { Checked = true, Image = CreateSymbolImage("⚡") };
            var itemPro = new ToolStripMenuItem("Gemini 2.0 Pro") { Image = CreateSymbolImage("🧠") };
            // var itemGPT = new ToolStripMenuItem("GPT-4o") { Image = CreateSymbolImage("⚫") }; // Tùy chọn thêm

            // Logic đổi dấu tích V (Check)
            void ItemClick(object? sender, EventArgs e)
            {
                if (menuAuto == null || sender == null) return;
                foreach (ToolStripItem item in menuAuto.Items)
                    if (item is ToolStripMenuItem) ((ToolStripMenuItem)item).Checked = false;

                ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
                clickedItem.Checked = true;

                // Cập nhật chữ trên nút cho ngầu
                if (btnAutoSmart != null) btnAutoSmart.Text = "✨ " + clickedItem.Text;

                // Lưu ý: Bạn cần cập nhật biến 'currentModel' ở đây nếu đã khai báo biến đó như tôi gợi ý trước đó
                // currentModel = clickedItem.Text.Contains("Pro") ? "gemini-2.0-pro-exp" : "gemini-2.5-flash";
            };

            itemAuto.Click += ItemClick;
            itemPro.Click += ItemClick;
            // itemGPT.Click += ItemClick;

            menuAuto.Items.AddRange(new ToolStripItem[] { itemAuto, itemPro });


            // --- MENU 2: NGUỒN (SOURCE) ---
            menuSource = new ContextMenuStrip();
            menuSource.Renderer = notionRenderer;
            menuSource.Items.Add(new ToolStripMenuItem("Tìm kiếm trên web") { Checked = true, Image = CreateSymbolImage("🌐") });
            menuSource.Items.Add(new ToolStripMenuItem("Dự án này") { Checked = false, Image = CreateSymbolImage("📂") });


            // --- QUAN TRỌNG: GẮN SỰ KIỆN CLICK ĐỂ MENU HIỆN LÊN TRÊN (UP) ---

            // 1. Xử lý nút Tự động
            if (btnAutoSmart != null)
            {
                btnAutoSmart.Click += (s, e) => {
                    if (menuAuto != null)
                    {
                        // Tính toán vị trí để hiện LÊN TRÊN
                        // Y = 0 (ngang bằng nút) trừ đi Chiều cao menu trừ tiếp 5px cho thoáng
                        int menuHeight = menuAuto.PreferredSize.Height;
                        menuAuto.Show(btnAutoSmart, new Point(0, -menuHeight - 5));
                    }
                };
            }

            // 2. Xử lý nút Nguồn
            if (btnSourceSmart != null)
            {
                btnSourceSmart.Click += (s, e) => {
                    if (menuSource != null)
                    {
                        // Tương tự, hiện LÊN TRÊN
                        int menuHeight = menuSource.PreferredSize.Height;
                        menuSource.Show(btnSourceSmart, new Point(0, -menuHeight - 5));
                    }
                };
            }

            // --- MENU 2: NGUỒN (SOURCE) ---
            menuSource = new ContextMenuStrip();
            menuSource.Renderer = notionRenderer;
            menuSource.Font = new Font("Segoe UI", 9F);

            // Tạo các lựa chọn
            var itemInternet = new ToolStripMenuItem("Vũ trụ Internet") { Checked = true, Image = CreateSymbolImage("🌐") };
            var itemFileOnly = new ToolStripMenuItem("Chỉ file đính kèm") { Checked = false, Image = CreateSymbolImage("📄") };

            // Logic khi bấm chọn (Đổi dấu tích V và đổi Text nút)
            void SourceItemClick(object? sender, EventArgs e)
            {
                if (menuSource == null || sender == null) return;

                // Bỏ chọn tất cả
                foreach (ToolStripItem item in menuSource.Items)
                    if (item is ToolStripMenuItem) ((ToolStripMenuItem)item).Checked = false;

                // Chọn cái vừa bấm
                ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
                clickedItem.Checked = true;

                // Cập nhật giao diện nút bấm bên ngoài
                if (btnSourceSmart != null)
                {
                    // Lấy icon tương ứng (nếu muốn cầu kỳ thì lấy image, ở đây mình dùng text icon cho nhanh)
                    string icon = clickedItem.Text.Contains("Internet") ? "🌐" : "📄";
                    btnSourceSmart.Text = $"{icon} {clickedItem.Text}";
                }
            };

            itemInternet.Click += SourceItemClick;
            itemFileOnly.Click += SourceItemClick;

            menuSource.Items.AddRange(new ToolStripItem[] { itemInternet, itemFileOnly });

            // --- XỬ LÝ CLICK ĐỂ HIỆN MENU LÊN TRÊN (UP) ---
            if (btnSourceSmart != null)
            {
                btnSourceSmart.Click += (s, e) => {
                    if (menuSource != null)
                    {
                        // Đo chiều cao menu
                        int menuHeight = menuSource.PreferredSize.Height;

                        // Hiện menu tại vị trí: X=0, Y = Âm chiều cao (để bay lên trên) - 5px (cho thoáng)
                        menuSource.Show(btnSourceSmart, new Point(0, -menuHeight - 5));
                    }
                };
            }
        }

        private void SetupChucNangChung()
        {
            // 1. Nút Ẩn (Minimize) - Giữ nguyên
            btnHide.Click += (s, e) => this.WindowState = FormWindowState.Minimized;

            // 2. Nút "Kéo dài dọc" (Thay thế đoạn btnMode cũ)
            // Mặc định icon phóng to
            btnMode.Text = "\uE922";

            btnMode.Click += (s, e) =>
            {
                // Lấy kích thước màn hình hiện tại (trừ thanh Taskbar)
                Rectangle screenArea = Screen.FromControl(this).WorkingArea;

                // KIỂM TRA: Nếu chiều cao hiện tại NHỎ HƠN chiều cao màn hình -> Phóng to
                if (this.Height < screenArea.Height)
                {
                    // 1. Đưa lên sát mép trên
                    this.Top = screenArea.Top;

                    // 2. Kéo chiều cao bằng đúng chiều cao màn hình
                    this.Height = screenArea.Height;

                    // (Lưu ý: Width và Left giữ nguyên không động vào)

                    // Đổi icon và tooltip
                    btnMode.Text = "\uE923"; // Icon thu nhỏ
                    toolTip1.SetToolTip(btnMode, "Thu nhỏ về mặc định");
                }
                else // Nếu đang full chiều cao -> Thu nhỏ lại
                {
                    // Trả về kích thước mặc định (ví dụ 600px hoặc kích thước thiết kế ban đầu)
                    int defaultHeight = 600;
                    this.Height = defaultHeight;

                    // Căn giữa lại theo chiều dọc cho đẹp
                    this.Top = (screenArea.Height - defaultHeight) / 2;

                    // Đổi icon và tooltip
                    btnMode.Text = "\uE922";
                    toolTip1.SetToolTip(btnMode, "Kéo dài dọc màn hình");
                }
            };

            // 3. Nút Edit (Tạo chat mới) - Giữ nguyên
            btnEdit.Click += (s, e) => {
                if (currentSession != null) StartNewChat();
                else txtInput.Text = "";
            };

            // 4. Kéo thả cửa sổ - Giữ nguyên
            panelTitleBar.MouseDown += DragForm;
            lblGreeting.MouseDown += DragForm;
            panelHeader.MouseDown += DragForm;
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
            using (Graphics g = Graphics.FromImage(bmp)) g.DrawString(text, new Font("Segoe UI Emoji", 10), Brushes.Black, 0, 0);
            return bmp;
        }
        private void DragForm(object? sender, MouseEventArgs e) { if (e.Button == MouseButtons.Left) { ReleaseCapture(); SendMessage(Handle, 0xA1, 0x2, 0); } }
        private void BoGoc(Control? control, int radius)
        {
            if (control == null || control.Width <= 0) return;
            DoBoGoc(control, radius);
            control.Resize += (s, e) => DoBoGoc(control, radius);
        }
        private void DoBoGoc(Control control, int radius)
        {
            if (control.Width <= 0) return;
            using (GraphicsPath path = GetRoundedPath(control.ClientRectangle, radius)) control.Region = new Region(path);
        }
        // Hàm hỗ trợ vẽ bo góc chuẩn
        private GraphicsPath GetRoundedPath(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            float d = radius * 2F;

            // Các góc bo tròn
            path.AddArc(rect.X, rect.Y, d, d, 180, 90); // Góc trên-trái
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90); // Góc trên-phải
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90); // Góc dưới-phải
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90); // Góc dưới-trái

            path.CloseFigure(); // Nối khép kín
            return path;
        }
        public class NotionColorTable : ProfessionalColorTable

        {
            public override Color MenuItemSelected => Color.FromArgb(241, 241, 241);
            public override Color MenuItemBorder => Color.Transparent;
            public override Color MenuBorder => Color.FromArgb(230, 230, 230);
            public override Color ToolStripDropDownBackground => Color.White;
        }

        // --- HÀM GetMimeType PHẢI NẰM Ở ĐÂY ---
        private string GetMimeType(string filePath)
        {
            string ext = System.IO.Path.GetExtension(filePath).ToLower();
            switch (ext)
            {
                case ".png": return "image/png";
                case ".jpg": case ".jpeg": return "image/jpeg";
                case ".webp": return "image/webp";
                case ".heic": return "image/heic";
                case ".heif": return "image/heif";
                case ".pdf": return "application/pdf";
                default: return "text/plain";
            }
        }

        // Hàm tạo nút chức năng nhỏ (Icon + Tooltip + Sự kiện Click)
        private Label CreateMsgActionButton(string icon, string tooltip, Action onClick)
        {
            Label btn = new Label();
            btn.Text = icon;
            btn.Font = new Font("Segoe UI Symbol", 10F); // Font hỗ trợ ký tự đặc biệt
            btn.ForeColor = Color.DarkGray; // Màu xám nhạt cho tinh tế
            btn.AutoSize = true;
            btn.Cursor = Cursors.Hand;
            btn.Margin = new Padding(0, 2, 12, 0); // Cách lề phải 12px

            // Tooltip hiển thị khi di chuột vào
            toolTip1.SetToolTip(btn, tooltip);

            // Sự kiện Click
            btn.Click += (s, e) => onClick();

            // Hiệu ứng Hover: Đậm màu hơn khi di chuột vào
            btn.MouseEnter += (s, e) => btn.ForeColor = NOTION_BLUE; // Hoặc Color.Black
            btn.MouseLeave += (s, e) => btn.ForeColor = Color.DarkGray;

            return btn;
        }

        // Hàm xóa ký tự Markdown để hiển thị sạch sẽ trên Label
        private string CleanMarkdown(string text)
        {
            if (string.IsNullOrEmpty(text)) return "";

            // 1. Xóa in đậm (**text** -> text)
            text = Regex.Replace(text, @"\*\*(.*?)\*\*", "$1");

            // 2. Xóa in nghiêng (*text* -> text)
            text = Regex.Replace(text, @"\*(.*?)\*", "$1");

            // 3. Xóa tiêu đề (## Header -> Header)
            text = Regex.Replace(text, @"^#{1,6}\s+", "", RegexOptions.Multiline);

            // 4. Xóa Code block (```code``` -> code)
            text = text.Replace("```csharp", "").Replace("```sql", "").Replace("```", "");

            return text.Trim();
        }
    }


    // --- CÁC CLASS PHỤ ---


    public class ChatMessage
    {
        public bool IsUser { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public List<string> Files { get; set; } = new List<string>();
    }

    public class ChatSession
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Title { get; set; } = "Cuộc trò chuyện mới";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<ChatMessage> Messages { get; set; } = new List<ChatMessage>();
    }



}