using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; // Thư viện để đổ bóng

namespace FE_ToDoApp.NewFolder
{
    public partial class ThungRac : Form
    {
        // *** HÀM MỚI ĐỂ THÊM ĐỔ BÓNG ***
        private const int CS_DROPSHADOW = 0x20000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW; // Bật cờ đổ bóng
                return cp;
            }
        }
        // *** HẾT HÀM MỚI ***

        // Constructor mới để nhận vị trí
        public ThungRac(Point startLocation)
        {
            InitializeComponent();

            // 1. Bỏ viền cửa sổ (để nó dính liền)
            this.FormBorderStyle = FormBorderStyle.None;

            // 2. Đặt vị trí thủ công
            this.StartPosition = FormStartPosition.Manual;
            this.Location = startLocation;
        }

        // --- 1. MÀU SẮC CHỦ ĐỀ SÁNG ---
        private Color colorBackground = Color.FromArgb(248, 248, 255);
        private Color colorPanelGray = Color.FromArgb(247, 247, 247);
        private Color colorText = Color.Black;
        private Color colorTextGray = Color.Gray;
        private Color colorBlue = Color.FromArgb(37, 99, 235);
        private Color colorBlueLight = Color.FromArgb(232, 239, 250);

        // --- 2. CÁC CONTROL SẼ TẠO BẰNG CODE ---
        private Panel panelMenuChinhSua;
        private TextBox txtTimKiem;
        private FlowLayoutPanel flpTags;
        private FlowLayoutPanel flpResults;

        // --- 3. DỮ LIỆU GIẢ LẬP ---
        private class DeletedPage
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Location { get; set; }
            public string DeletedBy { get; set; }
        }
        private List<DeletedPage> allPages = new List<DeletedPage>();

        string[] danhSachNguoiDung = { "Nguyễn Văn A", "Trần Thị B", "Lê Minh C", "Theo Theo", "Admin" };
        string[] danhSachTrang = { "Trang mới", "Không có quyền truy cập", "Welcome to Notion!", "Đang ghi chú phát hành", "Cải thiện nội dung..." };
        string[] danhSachKhongGian = { "Theo Theo's Workspace HQ", "Dự án X", "Tài liệu kỹ thuật" };

        private string currentMenuType = "";
        private Button lastClickedButton = null;

        public ThungRac()
        {
            InitializeComponent();
        }

        // *** HÀM ĐÃ SỬA LỖI CĂN GIỮA ***
        private void ThungRac_Load(object sender, EventArgs e)
        {
            // --- 4. TẠO CÁC PANEL ĐỘNG ---

            // A. Tạo Panel Menu
            panelMenuChinhSua = new Panel();
            panelMenuChinhSua.Name = "panelMenuChinhSua";
            panelMenuChinhSua.Visible = false;
            panelMenuChinhSua.Size = new Size(220, 250);
            panelMenuChinhSua.BackColor = colorBackground;
            panelMenuChinhSua.BorderStyle = BorderStyle.None;
            panelMenuChinhSua.Paint += PanelMenuChinhSua_Paint;
            this.Controls.Add(panelMenuChinhSua);
            BoGocChoControl(panelMenuChinhSua, 8);

            // B. Tạo Ô Tìm Kiếm
            txtTimKiem = new TextBox();
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Location = new Point(5, 5);
            txtTimKiem.Size = new Size(panelMenuChinhSua.Width - 10, 50);
            txtTimKiem.Font = new Font("Segoe UI", 10f);
            txtTimKiem.BackColor = colorPanelGray;
            txtTimKiem.ForeColor = colorText;
            txtTimKiem.BorderStyle = BorderStyle.None;
            txtTimKiem.TextChanged += TxtTimKiem_TextChanged;
            panelMenuChinhSua.Controls.Add(txtTimKiem);
            BoGocChoControl(txtTimKiem, 6);

            // --- SỬA LỖI LAYOUT BỊ TRÀN ---

            // C. Panel5 (cha) sẽ cuộn
            panel5.AutoScroll = true;

            // D. Đảm bảo panel7 (chứa label "Không có kết quả") lấp đầy
            panel7.Dock = DockStyle.Fill;
            panel7.BringToFront(); // Đẩy nó ra sau các panel Dock.Top

            // E. Tạo Panel chứa "Kết Quả" (Thêm vào panel5 THỨ HAI)
            flpResults = new FlowLayoutPanel();
            flpResults.Name = "flpResults";
            flpResults.Dock = DockStyle.Top;
            flpResults.AutoScroll = false;
            flpResults.AutoSize = true;
            flpResults.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpResults.Width = panel5.ClientSize.Width;
            panel5.Resize += (s, ev) => { flpResults.Width = panel5.ClientSize.Width; };
            panel5.Controls.Add(flpResults); // Thêm KẾT QUẢ

            // F. Tạo Panel chứa "Tag" (Thêm vào panel5 CUỐI CÙNG)
            flpTags = new FlowLayoutPanel();
            flpTags.Name = "flpTags";
            flpTags.Dock = DockStyle.Top;
            flpTags.AutoSize = true;
            flpTags.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel5.Controls.Add(flpTags); // Thêm TAGS (sẽ bay lên trên cùng)
            flpTags.ControlRemoved += (s, ev) => PerformSearch();
            flpTags.ControlAdded += (s, ev) => PerformSearch();

            // --- HẾT SỬA LỖI LAYOUT ---


            // --- 5. KHỞI TẠO DỮ LIỆU & SỰ KIỆN ---
            ApplyLightTheme();
            btnChinhSuaGanNhat.Click += btnChinhSuaGanNhat_Click;
            btnTrong.Click += btnTrong_Click;
            btnKhongGianNhom.Click += btnKhongGianNhom_Click;
            textBox1.TextChanged += (s, ev) => PerformSearch();
            InitializeMockData();
            PerformSearch();

            // Tự động đóng Form khi bấm ra ngoài
            this.Deactivate += (s, ev) => this.Close();

            // KÍCH HOẠT VẼ VIỀN CHO FORM
            this.Paint += ThungRac_Paint;

            // CẮT GÓC FORM
            BoGocChoControl(this, 8);
        }

        // HÀM VẼ VIỀN CHO FORM
        private void ThungRac_Paint(object sender, PaintEventArgs e)
        {
            int radius = 8;
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            Color borderColor = Color.FromArgb(220, 220, 220); // Màu viền xám nhạt

            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(borderColor, 1)) // Độ dày viền 1px
            {
                int d = radius * 2;
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseAllFigures();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // Làm mượt viền
                e.Graphics.DrawPath(pen, path);
            }
        }

        // HÀM VẼ VIỀN (của menu)
        private void PanelMenuChinhSua_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = sender as Panel;
            int radius = 8;
            Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
            Color borderColor = Color.FromArgb(220, 220, 220);

            using (GraphicsPath path = new GraphicsPath())
            using (Pen pen = new Pen(borderColor, 1))
            {
                int d = radius * 2;
                path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                path.CloseAllFigures();
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(pen, path);
            }
        }

        // HÀM ÁP DỤNG CHỦ ĐỀ SÁNG
        private void ApplyLightTheme()
        {
            this.BackColor = colorBackground;

            // Panel tìm kiếm chính
            panel1.BackColor = colorPanelGray;
            BoGocChoControl(panel1, 8);
            panel8.BackColor = colorPanelGray;
            panel9.BackColor = colorPanelGray;
            textBox1.BackColor = colorPanelGray;
            textBox1.ForeColor = colorText;
            textBox1.BorderStyle = BorderStyle.None;

            // Panel chứa các nút lọc
            panel2.BackColor = colorBackground;
            panel4.BackColor = colorBackground;

            // Các nút lọc
            Button[] buttons = { btnChinhSuaGanNhat, btnTrong, btnKhongGianNhom };
            foreach (Button btn in buttons)
            {
                btn.BackColor = colorPanelGray;
                btn.ForeColor = colorText;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);
                BoGocChoControl(btn, 8);
            }

            // Panel chứa kết quả
            panel5.BackColor = colorBackground;
            panel7.BackColor = colorBackground; // Panel7 (chứa label) cũng phải có nền trắng
            flpResults.BackColor = colorBackground;
            flpTags.BackColor = colorBackground;
            label1.BackColor = colorBackground;
            label1.ForeColor = colorTextGray;
            panel3.BackColor = colorBackground;
            label3.BackColor = colorPanelGray;
            label3.ForeColor = colorTextGray;
        }


        // HÀM TẠO DỮ LIỆU GIẢ
        private void InitializeMockData()
        {
            // Chỉ thêm dữ liệu nếu list đang rỗng
            if (allPages.Count == 0)
            {
                allPages.Add(new DeletedPage { Id = 1, Title = "Đang ghi chú phát hành", Location = "Dự án X", DeletedBy = "Theo Theo" });
                allPages.Add(new DeletedPage { Id = 2, Title = "Thiết kế giao diện", Location = "Dự án X", DeletedBy = "Nguyễn Văn A" });
                allPages.Add(new DeletedPage { Id = 3, Title = "Welcome to Notion!", Location = "Tài liệu kỹ thuật", DeletedBy = "Trần Thị B" });
                allPages.Add(new DeletedPage { Id = 4, Title = "Trang mới", Location = "Theo Theo's Workspace HQ", DeletedBy = "Theo Theo" });
                allPages.Add(new DeletedPage { Id = 5, Title = "Cải thiện nội dung...", Location = "Tài liệu kỹ thuật", DeletedBy = "Lê Minh C" });
            }
        }

        // --- 6. SỰ KIỆN CLICK CHO 3 NÚT ---

        private void btnChinhSuaGanNhat_Click(object sender, EventArgs e)
        {
            currentMenuType = "NguoiDung";
            txtTimKiem.PlaceholderText = "Tìm kiếm người dùng...";
            ShowMenu(btnChinhSuaGanNhat);
        }

        private void btnTrong_Click(object sender, EventArgs e)
        {
            currentMenuType = "Trong";
            txtTimKiem.PlaceholderText = "Tìm kiếm trang...";
            ShowMenu(btnTrong);
        }

        private void btnKhongGianNhom_Click(object sender, EventArgs e)
        {
            currentMenuType = "KhongGian";
            txtTimKiem.PlaceholderText = "Tìm không gian nhóm...";
            ShowMenu(btnKhongGianNhom);
        }

        // HÀM DÙNG CHUNG ĐỂ HIỂN THỊ MENU
        private void ShowMenu(Button clickedButton)
        {
            if (panelMenuChinhSua.Visible && lastClickedButton == clickedButton)
            {
                panelMenuChinhSua.Visible = false;
                lastClickedButton = null;
            }
            else
            {
                panelMenuChinhSua.Visible = true;
                lastClickedButton = clickedButton;
                Point buttonScreenPos = clickedButton.PointToScreen(new Point(0, 0));
                Point buttonFormPos = this.PointToClient(buttonScreenPos);
                int menuX = buttonFormPos.X;
                int menuY = buttonFormPos.Y + clickedButton.Height + 5;
                if (menuX + panelMenuChinhSua.Width > this.ClientSize.Width)
                {
                    menuX = buttonFormPos.X + clickedButton.Width - panelMenuChinhSua.Width;
                }
                panelMenuChinhSua.Location = new Point(menuX, menuY);
                panelMenuChinhSua.BringToFront();
                LoadMenuContent();
            }
        }

        // SỰ KIỆN GÕ Ô TÌM KIẾM (TRONG MENU)
        private void TxtTimKiem_TextChanged(object sender, EventArgs e)
        {
            LoadMenuContent();
        }

        // HÀM DÙNG CHUNG ĐỂ TẢI NỘI DUNG CHO MENU
        private void LoadMenuContent()
        {
            string tuKhoa = txtTimKiem.Text.Trim().ToLower();
            var oldButtons = panelMenuChinhSua.Controls.OfType<Button>().ToList();
            foreach (var btn in oldButtons)
            {
                panelMenuChinhSua.Controls.Remove(btn);
            }

            IEnumerable<string> itemsToShow;
            if (currentMenuType == "NguoiDung")
            {
                itemsToShow = danhSachNguoiDung.Where(ten => string.IsNullOrEmpty(tuKhoa) || ten.ToLower().Contains(tuKhoa));
            }
            else if (currentMenuType == "Trong")
            {
                itemsToShow = danhSachTrang.Where(ten => string.IsNullOrEmpty(tuKhoa) || ten.ToLower().Contains(tuKhoa));
            }
            else if (currentMenuType == "KhongGian")
            {
                itemsToShow = danhSachKhongGian.Where(ten => string.IsNullOrEmpty(tuKhoa) || ten.ToLower().Contains(tuKhoa));
            }
            else
            {
                itemsToShow = new string[0];
            }

            int y = txtTimKiem.Bottom + 5;
            foreach (string ten in itemsToShow)
            {
                Button btn = new Button();
                btn.Text = ten;
                btn.Width = panelMenuChinhSua.Width - 10;
                btn.Height = 35;
                btn.Left = 5;
                btn.Top = y;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = colorBackground;
                btn.ForeColor = colorText;
                btn.TextAlign = ContentAlignment.MiddleLeft;
                btn.Cursor = Cursors.Hand;
                btn.MouseEnter += (s, e) => btn.BackColor = colorPanelGray;
                btn.MouseLeave += (s, e) => btn.BackColor = colorBackground;
                btn.Click += (s, e) =>
                {
                    if (currentMenuType == "NguoiDung")
                    {
                        CreateFilterTag("user", ten);
                    }
                    else if (currentMenuType == "Trong")
                    {
                        CreateFilterTag("page", ten);
                    }
                    else if (currentMenuType == "KhongGian")
                    {
                        CreateFilterTag("space", ten);
                    }
                    panelMenuChinhSua.Visible = false;
                    lastClickedButton = null;
                    txtTimKiem.Text = "";
                };
                panelMenuChinhSua.Controls.Add(btn);
                y += 40;
            }
        }

        // HÀM TẠO "TAG" ĐÃ SỬA LỖI LAYOUT
        private void CreateFilterTag(string type, string value)
        {
            string tagId = type + ":" + value;

            // 1. Kiểm tra trùng lặp
            foreach (Panel existingTag in flpTags.Controls.OfType<Panel>())
            {
                if (existingTag.Tag?.ToString() == tagId) return;
            }

            // 2. Tạo Panel (tag)
            Panel tagPanel = new Panel
            {
                Height = 28, // Cao 28px
                BackColor = colorBlueLight,
                Margin = new Padding(3),
                Padding = new Padding(0),
                Tag = tagId
            };

            // 3. Tạo Label
            string prefix = "";
            if (type == "user") prefix = "👤 ";
            if (type == "page") prefix = "📄 ";
            if (type == "space") prefix = "🏢 ";

            Label lblName = new Label
            {
                Text = prefix + value,
                Font = new Font("Segoe UI", 9f),
                ForeColor = colorBlue,
                Location = new Point(5, 7),
                AutoSize = false, // Tắt AutoSize
                AutoEllipsis = true // Bật ...
            };

            // 4. Tạo nút X
            Button btnClose = new Button
            {
                Text = "×",
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = colorBlue,
                Cursor = Cursors.Hand,
                Size = new Size(24, 28),
                Padding = new Padding(0)
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatAppearance.MouseOverBackColor = Color.FromArgb(219, 230, 249);
            btnClose.Click += (s, e) =>
            {
                flpTags.Controls.Remove(tagPanel); // Nút X 100% hoạt động
            };

            // 5. Tính toán Kích thước (Đây là phần sửa lỗi)

            // Đo kích thước chữ
            Size textSize = TextRenderer.MeasureText(lblName.Text, lblName.Font);

            // Giới hạn chiều rộng của label là 180px
            int labelWidth = Math.Min(textSize.Width, 180);

            // Set kích thước label
            lblName.Size = new Size(labelWidth, 20);

            // Đặt vị trí nút X (luôn nằm sau label)
            btnClose.Location = new Point(lblName.Right, 0);

            // Set kích thước cho toàn bộ cái Tag Panel
            tagPanel.Width = btnClose.Right + 5; // (5 là padding bên phải)

            // 6. Thêm control vào Panel
            tagPanel.Controls.Add(lblName);
            tagPanel.Controls.Add(btnClose);

            // 7. Thêm tag vào FlowPanel
            flpTags.Controls.Add(tagPanel);
            BoGocChoControl(tagPanel, 10);
        }


        // HÀM TÌM KIẾM CHÍNH
        private void PerformSearch()
        {
            string keyword = textBox1.Text.Trim().ToLower();

            var allTags = flpTags.Controls
                                 .OfType<Panel>()
                                 .Select(p => p.Tag.ToString())
                                 .ToList();

            var userFilters = allTags.Where(t => t.StartsWith("user:")).Select(t => t.Substring(5)).ToList();
            var pageFilters = allTags.Where(t => t.StartsWith("page:")).Select(t => t.Substring(5)).ToList();
            var spaceFilters = allTags.Where(t => t.StartsWith("space:")).Select(t => t.Substring(6)).ToList();

            var results = allPages;

            if (!string.IsNullOrEmpty(keyword))
            {
                results = results.Where(p => p.Title.ToLower().Contains(keyword)).ToList();
            }
            if (userFilters.Any())
            {
                results = results.Where(p => userFilters.Contains(p.DeletedBy)).ToList();
            }
            if (pageFilters.Any())
            {
                results = results.Where(p => pageFilters.Contains(p.Title)).ToList();
            }
            if (spaceFilters.Any())
            {
                var cleanSpaceFilters = spaceFilters.Select(s => s.Replace("🏢 ", "")).ToList();
                results = results.Where(p => cleanSpaceFilters.Contains(p.Location)).ToList();
            }

            DisplayResults(results);
        }

        // *** HÀM HIỂN THỊ KẾT QUẢ (ĐÃ SỬA LOGIC ẨN/HIỆN) ***
        private void DisplayResults(List<DeletedPage> results)
        {
            flpResults.Controls.Clear();

            // Nếu không có kết quả
            if (results.Count == 0)
            {
                flpResults.Visible = false; // Ẩn panel kết quả

                // VÀ chỉ hiện "Không có kết quả" nếu KHÔNG CÓ TAG LỌC NÀO
                if (flpTags.Controls.Count == 0)
                {
                    panel7.Visible = true; // Hiện panel7 (chứa label1)
                }
                else
                {
                    panel7.Visible = false; // Ẩn panel7 (vì đã có tag, không cần báo "Không có kết quả")
                }
            }
            else // Nếu CÓ kết quả
            {
                panel7.Visible = false; // Ẩn panel7 (chứa label1)
                flpResults.Visible = true; // Hiện panel kết quả

                foreach (var page in results)
                {
                    // 1. Tạo Panel item
                    Panel itemPanel = new Panel();
                    itemPanel.Width = panel5.ClientSize.Width - 10;
                    itemPanel.Height = 60;
                    itemPanel.Margin = new Padding(5, 5, 5, 0);
                    itemPanel.BackColor = colorBackground;
                    itemPanel.BorderStyle = BorderStyle.None;
                    itemPanel.Cursor = Cursors.Hand; // Thêm con trỏ
                    itemPanel.Tag = page; // Lưu 'page' vào panel

                    // 2. Tạo Label
                    Label lblTitle = new Label();
                    lblTitle.Text = page.Title;
                    lblTitle.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
                    lblTitle.Location = new Point(10, 10);
                    lblTitle.AutoSize = true;
                    lblTitle.ForeColor = colorText;
                    lblTitle.BackColor = Color.Transparent;
                    lblTitle.Cursor = Cursors.Hand; // Thêm con trỏ

                    Label lblLocation = new Label();
                    lblLocation.Text = "📄 " + page.Location + " (Xóa bởi: " + page.DeletedBy + ")";
                    lblLocation.Font = new Font("Segoe UI", 8f);
                    lblLocation.ForeColor = colorTextGray;
                    lblLocation.Location = new Point(10, 35);
                    lblLocation.AutoSize = true;
                    lblLocation.BackColor = Color.Transparent;
                    lblLocation.Cursor = Cursors.Hand; // Thêm con trỏ

                    // --- 3. TẠO 2 NÚT MỚI ---

                    // Nút Khôi phục ↩️
                    Button btnRestore = new Button();
                    btnRestore.Text = "↩️";
                    btnRestore.Font = new Font("Segoe UI", 10f);
                    btnRestore.FlatStyle = FlatStyle.Flat;
                    btnRestore.FlatAppearance.BorderSize = 0;
                    btnRestore.BackColor = Color.Transparent;
                    btnRestore.Size = new Size(30, 30);
                    btnRestore.Location = new Point(itemPanel.Width - 70, 15);
                    btnRestore.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                    btnRestore.Visible = true; // LUÔN HIỆN
                    btnRestore.Cursor = Cursors.Hand;
                    btnRestore.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);

                    // Nút Xóa vĩnh viễn 🗑️
                    Button btnDelete = new Button();
                    btnDelete.Text = "🗑️";
                    btnDelete.Font = new Font("Segoe UI", 10f);
                    btnDelete.FlatStyle = FlatStyle.Flat;
                    btnDelete.FlatAppearance.BorderSize = 0;
                    btnDelete.BackColor = Color.Transparent;
                    btnDelete.Size = new Size(30, 30);
                    btnDelete.Location = new Point(itemPanel.Width - 40, 15);
                    btnDelete.Anchor = AnchorStyles.Right | AnchorStyles.Top;
                    btnDelete.Visible = true; // LUÔN HIỆN
                    btnDelete.Cursor = Cursors.Hand;
                    btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(224, 224, 224);

                    // --- 4. GẮN SỰ KIỆN CLICK ---

                    // Click Khôi phục
                    btnRestore.Click += (s, e) => {
                        allPages.Remove(page);
                        PerformSearch(); // Tải lại kết quả
                    };

                    // Click Xóa vĩnh viễn
                    btnDelete.Click += (s, e) => {
                        var confirm = MessageBox.Show(
                            "Bạn có chắc chắn muốn xóa vĩnh viễn trang này?",
                            "Xác nhận xóa",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        if (confirm == DialogResult.Yes)
                        {
                            allPages.Remove(page);
                            PerformSearch(); // Tải lại kết quả
                        }
                    };

                    // HÀM CLICK ĐỂ XEM TRƯỚC
                    EventHandler previewClick = (s, e) => {
                        DeletedPage clickedPage = (DeletedPage)itemPanel.Tag;

                        MessageBox.Show(
                            $"ID: {clickedPage.Id}\n" +
                            $"Tiêu đề: {clickedPage.Title}\n" +
                            $"Vị trí: {clickedPage.Location}\n" +
                            $"Xóa bởi: {clickedPage.DeletedBy}\n\n" +
                            $"(Đang dùng dữ liệu cứng...)",
                            "Xem trước nội dung");
                    };

                    // Gắn sự kiện click này cho Panel và 2 Label
                    itemPanel.Click += previewClick;
                    lblTitle.Click += previewClick;
                    lblLocation.Click += previewClick;


                    // --- 5. THÊM TẤT CẢ VÀO ITEM PANEL ---
                    itemPanel.Controls.Add(lblTitle);
                    itemPanel.Controls.Add(lblLocation);
                    itemPanel.Controls.Add(btnRestore);
                    itemPanel.Controls.Add(btnDelete);

                    flpResults.Controls.Add(itemPanel);
                }
            }
        }

        // HÀM HỖ TRỢ BO GÓC
        private void BoGocChoControl(Control control, int radius)
        {
            Action<object, EventArgs> resizeAction = (sender, e) =>
            {
                var ctrl = sender as Control;
                if (ctrl == null || ctrl.Width <= 0 || ctrl.Height <= 0) return;
                using (GraphicsPath path = new GraphicsPath())
                {
                    Rectangle rect = new Rectangle(0, 0, ctrl.Width, ctrl.Height);
                    int d = radius * 2;
                    path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                    path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                    path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                    path.CloseAllFigures();
                    ctrl.Region = new Region(path);
                }
            };
            control.Resize += new EventHandler(resizeAction);
            resizeAction(control, EventArgs.Empty);
        }

        // CÁC HÀM CŨ (Để trống)
        private void panel4_Paint(object sender, PaintEventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}