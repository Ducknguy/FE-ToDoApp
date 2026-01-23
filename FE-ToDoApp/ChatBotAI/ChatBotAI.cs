    #nullable disable
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    using System.Net;
    using System.Threading.Tasks;
    using FE_ToDoApp.DAO;
    using FE_ToDoApp.ChatBotAI.HistoryItem;
    using System.Configuration;
    using FE_ToDoApp.ChatBotAI.GeminiService;
using System.Diagnostics;


namespace ChatbotAI_Form
    {

        public partial class ChatbotAI : Form
        {

        private int currentUserId = 1; // hoặc lấy từ LoginForm    

        private ChatDAO chatDAO = new ChatDAO();
            private ChatSession currentSession;

            private GeminiService gemini;
            private ChatUIController ui;

        //biến to nhỏ
        private bool isVerticalMaximized = false;
        private Rectangle normalBounds;

        //khai bao bien
        private List<string> currentAttachments = new List<string>();

        public ChatbotAI()
            {
                InitializeComponent();

            // BO GOC CA NUT
            UIHelper.TuDongBoGocKhiHover(this, 35);

            //khoi tao 
            ui = new ChatUIController(
                panelHeader,
                flowActions,
                flowMessages,
                panelBody
                );
            ui.ShowWelcome();
            // tránh tình trangj quên key
            string apiKey = ConfigurationManager.AppSettings["GeminiApiKey"];
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                MessageBox.Show("❌ Chưa cấu hình Gemini API Key", "Lỗi cấu hình");
                return;
            }
            gemini = new GeminiService(apiKey);

            // Click các khu vực khác → đóng popup
            panelHeader.MouseDown += (s, e) => CloseDropdown();
                panelBody.MouseDown += (s, e) => CloseDropdown();
                panelFooter.MouseDown += (s, e) => CloseDropdown();
                panelDropdownHistory.MouseDown += (s, e) => { };

                // Gọi bo góc khi Form đã nạp xong (sử dụng sự kiện Load hoặc HandleCreated)
                this.Load += (s, e) =>
                {
                    UIHelper.BoGoc(btnAction1, 15);
                    UIHelper.BoGoc(btnAction2, 15);
                    UIHelper.BoGoc(btnAction3, 15);

                    // Bo góc cho thanh nhập liệu
                    UIHelper.BoGoc(panelInputContainer, 30);

                    //bo góc form chính
                    UIHelper.BoGoc(this, 30);
                };

                btnSend.Click += btnSend_Click;
                // (Tùy chọn) Bấm Enter để gửi
                txtInput.KeyDown += (s, e) =>
                {
                    if (e.KeyCode == Keys.Enter && !e.Shift)
                    {
                        e.SuppressKeyPress = true;
                        btnSend.PerformClick();
                    }
                };

                this.Load += (s, e) =>
                {
                    // 1. Vẫn giữ bo góc
                    UIHelper.BoGoc(panelInputContainer, 20);

                    // 2. Thiết lập hiện viền khi bấm vào
                    UIHelper.VeVienFocus(
                        panelInputContainer,
                        txtInput,
                        Color.FromArgb(35, 131, 226), // Màu xanh khi bấm vào (Focus)
                        Color.FromArgb(220, 220, 220)  // Màu xám nhạt khi bình thường
                    );
                };
            }

        private void btnAttachment_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Multiselect = true })
            {
                // Lọc chỉ cho chọn ảnh và PDF
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.webp;*.heic|PDF Files|*.pdf|All Files|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string filePath in ofd.FileNames)
                    {
                        // 1. Thêm vào danh sách tạm
                        currentAttachments.Add(filePath);

                        string name = System.IO.Path.GetFileName(filePath);
                        Panel chip = null;

                        // 2. Tạo chip hiển thị
                        chip = UIHelper.CreateFileChip(name, () =>
                        {
                            // Khi bấm X xóa chip
                            flowFileAttachments.Controls.Remove(chip);
                            chip.Dispose();

                            // Xóa khỏi danh sách list
                            currentAttachments.Remove(filePath);
                        });

                        flowFileAttachments.Controls.Add(chip);
                    }
                }
            }
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
            {

            }

            private void btnTitleLeft_Click(object sender, EventArgs e)
            {
                UIHelper.BoGoc(panelDropdownHistory, 30); // bogoc panal

                panelDropdownHistory.Visible = !panelDropdownHistory.Visible;

                if (panelDropdownHistory.Visible)
                {
                    panelDropdownHistory.BringToFront();
                    panelDropdownHistory.Location = new Point(  
                        btnTitleLeft.Left,
                        panelTitleBar.Bottom

                    );
                    LoadHistory();

                }
            }

            private void btnEdit_Click(object sender, EventArgs e)
            {
            panelHeader.Height = 110;   // hiện lại icon + chữ

            flowActions.Visible = true;
            flowMessages.Visible = false;
            flowMessages.Controls.Clear();

            currentSession = null;
            txtInput.Clear();

            // ===== RESET UI VỀ BAN ĐẦU =====
            panelHeader.Visible = true;
            flowActions.Visible = true;
            flowMessages.Visible = false;

            flowMessages.Controls.Clear();
            currentSession = null;

            ui.ShowWelcome();
        }

        private void ChatbotAI_Load(object sender, EventArgs e)
        {

        }
        private async void btnSend_Click(object sender, EventArgs e)
        {
            // 1. LẤY DỮ LIỆU
            string text = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(text) && currentAttachments.Count == 0) return;

            // 2. CHUYỂN UI
            if (panelHeader.Visible) ui.ShowChat();

            // 3. TẠO SESSION
            if (currentSession == null)
            {
                string title = string.IsNullOrEmpty(text) ? "Hình ảnh" : (text.Length > 30 ? text.Substring(0, 30) : text);
                currentSession = new ChatSession { UserId = currentUserId, Title = title, CreatedAt = DateTime.Now };
                chatDAO.SaveSession(currentSession);
                LoadHistory();
            }

            // 4. HIỆN TIN NHẮN USER
            List<string> filesForDisplay = new List<string>(currentAttachments);
            AddMessage(text, true, filesForDisplay);
            txtInput.Clear();
            txtInput.Focus();
            flowFileAttachments.Controls.Clear();

            List<string> filesToSend = new List<string>(currentAttachments);
            int fileCount = currentAttachments.Count;
            currentAttachments.Clear();

            // 5. LƯU DB
            string dbContent = text;
            if (fileCount > 0) dbContent += $"\n[Đính kèm {fileCount} file]";
            ChatMessage userMsg = new ChatMessage { IsUser = true, Content = dbContent, Files = filesToSend };
            chatDAO.SaveMessage(currentSession.Id, userMsg);
            currentSession.Messages.Add(userMsg);

            // 🔥 LOGIC THÔNG MINH 🔥
            
            Panel thinkingRow = AddThinkingMessage();
            string aiReply = "";

            try
            {
                // A. TRƯỜNG HỢP CÓ FILE: Gửi File + Lịch sử chat
                if (filesToSend.Count > 0)
                {
                    // Lấy lịch sử cũ
                    List<string> history = BuildConversationHistory();
                    // Thêm câu hỏi hiện tại vào cuối
                    history.Add($"User (đang gửi kèm file): {text}");

                    aiReply = await gemini.SendAsync(history, filesToSend);
                }
                // B. TRƯỜNG HỢP TEXT-TO-SQL (Dùng não to)
                else
                {
                    // --- BƯỚC 1: HỎI SQL (Chỉ gửi câu hiện tại để AI tập trung viết Code) ---
                    string schema = chatDAO.GetFullDatabaseSchema();
                    // Lấy ngày giờ hiện tại
                    string currentDateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                    string promptGetSQL = $@"
                    Bạn là chuyên gia SQL (SQLite).
                    THỜI GIAN HIỆN TẠI: {currentDateTime} (Hãy dùng thời gian này để xác định 'Tuần này', 'Hôm nay').

                    {schema}
    
                        YÊU CẦU:
                        - Câu hỏi User: ""{text}""
    
                        Nhiệm vụ:
                        - Nếu User muốn XEM dữ liệu: Viết câu lệnh SELECT.
                        - Nếu User muốn THÊM (Insert), SỬA (Update), XÓA (Delete): Hãy viết câu lệnh SQL tương ứng để thực hiện thay đổi đó ngay lập tức.
                        - Nếu là xã giao (không liên quan DB): Trả lời ""NO_SQL"".

                        LƯU Ý: 
                        - Chỉ trả về code SQL duy nhất, không giải thích, không markdown.
                        - Với lệnh INSERT: nhớ lấy ngày giờ hiện tại là datetime('now').
                        - Với lệnh DELETE/UPDATE: phải có WHERE cụ thể để tránh xóa nhầm all.
                    ";

                    // Lần 1: Không cần gửi lịch sử, chỉ cần lấy SQL chuẩn
                    string aiResponse1 = await gemini.SendAsync(new List<string> { promptGetSQL }, null);
                    string cleanSQL = aiResponse1.Replace("```sql", "").Replace("```", "").Trim();

                    // --- BƯỚC 2: XỬ LÝ KẾT QUẢ VÀ TRẢ LỜI (CÓ KÈM TRÍ NHỚ) ---

                    // Chuẩn bị sẵn lịch sử chat
                    List<string> chatContext = BuildConversationHistory();

                    if (cleanSQL.Contains("NO_SQL"))
                    {
                        // -> Xã giao: Gửi lịch sử + Câu hiện tại
                        chatContext.Add($"User: {text}");
                        aiReply = await gemini.SendAsync(chatContext, null);
                    }
                    else
                    {
                        // -> Có SQL: Chạy lệnh lấy dữ liệu
                        string dbResult = chatDAO.ExecuteDynamicSQL(cleanSQL);

                        // Tạo prompt cuối cùng chứa: Lịch sử + Kết quả DB + Câu hỏi hiện tại
                        string promptFinal = $@"
                            [THÔNG TIN TỪ DATABASE CHO CÂU HỎI HIỆN TẠI]
                            SQL đã chạy: {cleanSQL}
                            Kết quả: 
                            {dbResult}

                            [YÊU CẦU TRẢ LỜI]
                            User vừa hỏi: ""{text}""
                            Hãy trả lời User dựa trên KẾT QUẢ DATABASE ở trên.
                            Lưu ý: Hãy kết hợp với lịch sử chat bên trên nếu cần thiết.
                        ";

                        // Thêm prompt này vào cuối danh sách lịch sử
                        chatContext.Add(promptFinal);

                        aiReply = await gemini.SendAsync(chatContext, null);
                    }
                }
            }
            catch (Exception ex)
            {
                aiReply = "⚠️ Lỗi xử lý: " + ex.Message;
            }

            // HIỆN CÂU TRẢ LỜI
            flowMessages.Controls.Remove(thinkingRow);
            thinkingRow.Dispose();
            AddMessage(aiReply, false, null);

            ChatMessage aiMsg = new ChatMessage { IsUser = false, Content = aiReply };
            chatDAO.SaveMessage(currentSession.Id, aiMsg);
            currentSession.Messages.Add(aiMsg);
        }
        private void AddMessage(string text, bool isUser, List<string> files = null)
        {
            // 1. CẤU HÌNH CƠ BẢN
            int chatWidth = flowMessages.ClientSize.Width;
            if (chatWidth <= 0) chatWidth = 500;

            // Bong bóng rộng tối đa 70% khung chat
            int maxMessageWidth = (int)(chatWidth * 0.7);
            int avatarSize = 35;
            int gap = 5;

            Font fontText = new Font("Segoe UI", 11F);
            Font fontFile = new Font("Segoe UI", 10F, FontStyle.Regular);

            // 2. TẠO BONG BÓNG TEXT
            Size textSize = TextRenderer.MeasureText(text, fontText, new Size(maxMessageWidth - 26, 0), TextFormatFlags.WordBreak);

            // Đảm bảo bong bóng đủ rộng (tối thiểu 150px) để tên file không bị ép quá bé
            int minBubbleWidth = 150;
            int bubbleWidth = Math.Max(textSize.Width + 26, minBubbleWidth);
            if (bubbleWidth > maxMessageWidth) bubbleWidth = maxMessageWidth;

            Panel pnlBubble = new Panel
            {
                Size = new Size(bubbleWidth, textSize.Height + 26),
                BackColor = isUser ? Color.FromArgb(225, 247, 255) : Color.FromArgb(242, 242, 242),
                Padding = new Padding(13)
            };

            // Bo góc
            if (isUser) UIHelper.BoGocTuyChinh(pnlBubble, 18, true, true, false, true);
            else UIHelper.BoGocTuyChinh(pnlBubble, 18, true, true, true, false);

            Label lblContent = new Label
            {
                Text = text,
                Font = fontText,
                ForeColor = Color.Black,
                AutoSize = false,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopLeft,
                BackColor = Color.Transparent
            };
            pnlBubble.Controls.Add(lblContent);

            // 3. XỬ LÝ DANH SÁCH FILE (FIX LỖI HIỂN THỊ Ở ĐÂY)
            FlowLayoutPanel pnlAttachments = new FlowLayoutPanel
            {
                AutoSize = true,
                MaximumSize = new Size(bubbleWidth, 0), // Rộng bằng bong bóng chat
                MinimumSize = new Size(bubbleWidth, 0), // Đảm bảo không bị co lại
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 5, 0, 0)
            };

            if (files != null && files.Count > 0)
            {
                foreach (string filePath in files)
                {
                    string fileName = System.IO.Path.GetFileName(filePath);

                    LinkLabel lnkFile = new LinkLabel
                    {
                        Text = "📎 " + fileName,
                        Font = fontFile,

                        // --- SỬA LẠI ĐOẠN NÀY ĐỂ HIỆN TÊN FILE ---
                        AutoSize = false, // Tắt tự động co giãn
                        Width = bubbleWidth - 10, // Rộng gần bằng panel chứa nó
                        Height = 25, // Chiều cao cố định
                        AutoEllipsis = true, // Tự động thêm "..." nếu dài quá
                                             // -----------------------------------------

                        LinkColor = Color.FromArgb(0, 102, 204),
                        ActiveLinkColor = Color.Red,
                        LinkBehavior = LinkBehavior.HoverUnderline,
                        Margin = new Padding(0, 0, 0, 2),
                        Cursor = Cursors.Hand,
                        TextAlign = ContentAlignment.MiddleLeft // Căn trái
                    };

                    // Sự kiện click
                    lnkFile.Click += (s, e) =>
                    {
                        try { System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo { FileName = filePath, UseShellExecute = true }); }
                        catch { MessageBox.Show("Không thể mở file!"); }
                    };

                    // Thêm tooltip để hover vào xem được tên đầy đủ
                    toolTip1.SetToolTip(lnkFile, fileName);

                    pnlAttachments.Controls.Add(lnkFile);
                }
            }

            // 4. THANH CÔNG CỤ
            FlowLayoutPanel pnlTools = new FlowLayoutPanel
            {
                AutoSize = false,
                Size = new Size(bubbleWidth, 25),
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            };
            pnlTools.FlowDirection = isUser ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;

            if (isUser)
            {
                pnlTools.Controls.Add(UIHelper.CreateToolButton("✎", "Sửa", (s, e) => { txtInput.Text = text; txtInput.Focus(); }, toolTip1));
                pnlTools.Controls.Add(UIHelper.CreateToolButton("❐", "Copy", (s, e) => { Clipboard.SetText(text); }, toolTip1));
            }
            else
            {
                pnlTools.Controls.Add(UIHelper.CreateToolButton("❐", "Copy", (s, e) => { Clipboard.SetText(text); }, toolTip1));
            }

            // 5. TÍNH TOÁN GROUP
            int filesHeight = (files != null && files.Count > 0) ? pnlAttachments.PreferredSize.Height + 5 : 0;
            int groupHeight = pnlBubble.Height + filesHeight + pnlTools.Height;

            Panel pnlGroup = new Panel
            {
                Size = new Size(bubbleWidth, groupHeight),
                BackColor = Color.Transparent,
                Margin = new Padding(0)
            };

            // Xếp vị trí
            pnlBubble.Location = new Point(0, 0); // Bong bóng

            if (filesHeight > 0)
            {
                // File nằm dưới bong bóng
                pnlAttachments.Location = new Point(0, pnlBubble.Height);
                pnlGroup.Controls.Add(pnlAttachments);
            }

            pnlTools.Location = new Point(0, pnlBubble.Height + filesHeight);

            pnlGroup.Controls.Add(pnlBubble);
            pnlGroup.Controls.Add(pnlTools);

            // 6. TẠO ROW CHỨA AVATAR + GROUP
            Panel pnlRow = new Panel
            {
                Width = chatWidth - 25,
                Height = Math.Max(pnlGroup.Height, avatarSize) + 10,
                BackColor = Color.Transparent,
                Margin = new Padding(0, 0, 0, 15)
            };

            Label lblAvatar = new Label
            {
                Text = isUser ? "👤" : "🤖",
                Font = new Font("Segoe UI Emoji", 14F),
                AutoSize = false,
                Size = new Size(avatarSize, avatarSize),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent
            };

            if (isUser)
            {
                lblAvatar.Location = new Point(pnlRow.Width - avatarSize, 0);
                pnlGroup.Location = new Point(pnlRow.Width - avatarSize - gap - pnlGroup.Width, 0);
            }
            else
            {
                lblAvatar.Location = new Point(0, 0);
                pnlGroup.Location = new Point(avatarSize + gap, 0);
            }

            pnlRow.Controls.Add(lblAvatar);
            pnlRow.Controls.Add(pnlGroup);

            flowMessages.Controls.Add(pnlRow);
            flowMessages.ScrollControlIntoView(pnlRow);
        }

        private void btnHide_Click(object sender, EventArgs e)
            {
                this.WindowState = FormWindowState.Minimized;
            }

            private void btnMode_Click(object sender, EventArgs e)
            {
                if (!isVerticalMaximized)
                {
                    normalBounds = this.Bounds; //luu cũ

                    //kích thước
                    Rectangle workArea = Screen.FromControl(this).WorkingArea;
                    this.Location = new Point(this.Location.X, workArea.Top);
                    this.Height = workArea.Height;

                    btnMode.Text = "🗗";
                    /*btnMode.Image = FE_ToDoApp.Properties.Resources.ic_restore;*/

                    isVerticalMaximized = true;
                }
                else
                {
                    this.Bounds = normalBounds;
                    btnMode.Image = null;
                    btnMode.Text = "🗖";
                    isVerticalMaximized = false;
                }

                UIHelper.BoGoc(this, 30);
                this.Invalidate();
            }

            private void btnAction3_Click(object sender, EventArgs e)
            {
                txtInput.Text = btnAction3.Text;
                btnSend.PerformClick();
            }

            private void btnAction2_Click(object sender, EventArgs e)
            {
                txtInput.Text = btnAction2.Text;
                btnSend.PerformClick();
            }

            private void btnAction1_Click(object sender, EventArgs e)
            {
                txtInput.Text = btnAction1.Text;
                btnSend.PerformClick();
            }

            private void ChatbotAI_MouseDown(object sender, MouseEventArgs e)  // hàm click ra ngoài form
            {
            // Nếu menu đang ẩn thì thôi
            if (!panelDropdownHistory.Visible) return;

            // Lấy vị trí chuột trên màn hình
            Point cursor = Cursor.Position;

            // Lấy vị trí của bảng lịch sử và nút mở menu
            Rectangle historyRect = panelDropdownHistory.RectangleToScreen(panelDropdownHistory.ClientRectangle);
            Rectangle btnRect = btnTitleLeft.RectangleToScreen(btnTitleLeft.ClientRectangle);

            // Nếu chuột KHÔNG nằm trong bảng lịch sử VÀ KHÔNG nằm trong nút mở
            if (!historyRect.Contains(cursor) && !btnRect.Contains(cursor))
                {
                    panelDropdownHistory.Visible = false; // Tắt đi
                }
            }

            private void CloseDropdown()
            {
                if (panelDropdownHistory.Visible)
                    panelDropdownHistory.Visible = false;
            }

            private void btnDeleteSession_Click(object sender, EventArgs e)
            {

            }

        // LOAD DANH SÁCH LỊCH SỬ
        private void LoadHistory()
        {
            flowHistory.Controls.Clear();

            var sessions = chatDAO.GetSessions(currentUserId);

            DateTime today = DateTime.Today;
            DateTime yesterday = today.AddDays(-1);

            // Group theo ngày
            var groups = sessions.GroupBy(s =>
            {
                if (s.CreatedAt.Date == today) return "Hôm nay";
                if (s.CreatedAt.Date == yesterday) return "Hôm qua";
                if (s.CreatedAt.Date >= today.AddDays(-7)) return "7 ngày trước";
                return s.CreatedAt.ToString("MM/yyyy");
            });

            foreach (var group in groups)
            {
                // ===== HEADER NGÀY =====
                Label lblGroup = new Label
                {
                    Text = group.Key,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.Gray,
                    AutoSize = false,
                    Height = 28,
                    Dock = DockStyle.Top,
                    Padding = new Padding(12, 6, 0, 0)
                };

                flowHistory.Controls.Add(lblGroup);

                // ===== SESSION ITEMS =====
                foreach (var session in group)
                {
                    Panel item = HistoryItem.CreateFromTemplate(
                        session,
                        panelSessionItem,
                        session.Id == currentSession?.Id,
                        OnSelectSession,
                        OnDeleteSession
                    );

                    flowHistory.Controls.Add(item);
                }
            }
        }

        // CLICK 1 SESSION
        private void OnSelectSession(ChatSession session, Panel pnl, Label lblCheck)
        {
            panelHeader.Visible = false;
            currentSession = session;
            // Tải tin nhắn từ Database lên ---
            currentSession.Messages = chatDAO.GetMessages(session.Id);

            flowMessages.Controls.Clear();
            flowActions.Visible = false;
            flowMessages.Visible = true;

            // Load lại tin nhắn
            foreach (var msg in currentSession.Messages)
            {
                AddMessage(msg.Content, msg.IsUser, msg.Files);
            }

            // Reset tất cả item khác
            foreach (Control c in flowHistory.Controls)
            {
                // Chỉ xử lý nếu nó là Panel (Bỏ qua các dòng chữ Label "Hôm nay", "Hôm qua")
                if (c is Panel item)
                {
                    var check = item.Controls
                        .OfType<Label>()
                        .FirstOrDefault(l => (string)l.Tag == "check");

                    if (check != null) check.Visible = false;

                    item.BackColor = Color.Transparent;
                }

                // Hiện tick cho item đang chọn
                lblCheck.Visible = true;
                pnl.BackColor = Color.White;
            }
        }
            // XÓA SESSION
            private void OnDeleteSession(ChatSession session, Panel pnl)
            {
                if (MessageBox.Show(
                    "Bạn có chắc muốn xóa cuộc trò chuyện này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                ) == DialogResult.No)
                    return;

            chatDAO.DeleteSession(session.Id, currentUserId);           //  cần có hàm này trong DAO

            flowHistory.Controls.Remove(pnl);
                pnl.Dispose();

                if (currentSession?.Id == session.Id)
                {
                    currentSession = null;
                    flowMessages.Controls.Clear();
                    flowActions.Visible = true;
                }
            }
            private List<string> BuildGeminiContext()
            {
                var list = new List<string>
            {
                "Bạn là trợ lý AI, trả lời ngắn gọn, rõ ràng như Notion AI."
            };

                foreach (var msg in currentSession.Messages)
                {
                    list.Add(
                        (msg.IsUser ? "User: " : "AI: ") + msg.Content
                    );
                }

                return list;
            }

        // AI ĐANG SUY NGHĨ
        private Panel AddThinkingMessage()
        {
            Panel pnlBubble = new Panel
            {
                Padding = new Padding(12),
                AutoSize = true,
                MaximumSize = new Size((int)(flowMessages.Width * 0.7), 0),
                BackColor = Color.FromArgb(242, 242, 242),
                Margin = new Padding(0, 10, 0, 0)
            };
            pnlBubble.Paint += (s, e) => UIHelper.BoGoc(pnlBubble, 12);

            Label lbl = new Label
            {
                Text = "🤖 Đang suy nghĩ...",
                Font = new Font("Segoe UI", 10F, FontStyle.Italic),
                ForeColor = Color.Gray,
                AutoSize = true
            };

            pnlBubble.Controls.Add(lbl);

            Panel row = new Panel
            {
                Width = flowMessages.ClientSize.Width - 25,
                Height = pnlBubble.PreferredSize.Height + 10
            };

            row.Controls.Add(pnlBubble);
            flowMessages.Controls.Add(row);
            flowMessages.ScrollControlIntoView(row);
            return row; // trả về để xóa sau
        }

        // UI: MÀN HÌNH CHÀO
        private void ShowWelcomeUI()
        {
            panelHeader.Visible = true;

            flowActions.Visible = true;
            flowMessages.Visible = false;

            panelBody.Padding = new Padding(20);
        }

        // UI: ĐANG CHAT
        private void ShowChatUI()
        {
            panelHeader.Visible = false;
            flowActions.Visible = false;
            flowMessages.Visible = true;
            panelBody.Padding = new Padding(0);
        }

        // Hàm này gom lại lịch sử chat để gửi kèm cho AI đỡ quên
        private List<string> BuildConversationHistory()
        {
            var history = new List<string>();

            // 1. System Prompt (Nhắc vai trò)
            history.Add("System: Bạn là trợ lý ảo cá nhân. Hãy trả lời ngắn gọn, thân thiện và ghi nhớ bối cảnh cuộc trò chuyện.");

            // 2. Lấy 10 tin nhắn gần nhất (để tiết kiệm Token và tránh lỗi quá dài)
            if (currentSession != null && currentSession.Messages != null)
            {
                // Lấy 10 tin cuối cùng
                var recentMsgs = currentSession.Messages.Skip(Math.Max(0, currentSession.Messages.Count - 10));

                foreach (var msg in recentMsgs)
                {
                    // Định dạng: "User: nội dung" hoặc "AI: nội dung"
                    string role = msg.IsUser ? "User" : "AI";
                    // Chỉ lấy nội dung text, bỏ qua thông báo file đính kèm rườm rà
                    string cleanContent = msg.Content.Replace("[Đính kèm file]", "").Trim();
                    history.Add($"{role}: {cleanContent}");
                }
            }

            return history;
        }
    }
}
