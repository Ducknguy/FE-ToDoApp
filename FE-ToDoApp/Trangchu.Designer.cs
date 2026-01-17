namespace FE_ToDoApp
{
    partial class Trangchu
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trangchu));
            sidebarPanel = new Panel();
            panelNavigation = new Panel();
            btnSettings = new Button();
            btnChatbotAI = new Button();
            btnCalendar = new Button();
            btnWeekly = new Button();
            btnTasks = new Button();
            btnInbox = new Button();
            btnDashboard = new Button();
            btnHome = new Button();
            panelFooter = new Panel();
            btn_logout = new Button();
            btnTrash = new Button();
            btnQuickAdd = new Button();
            lblSchedule = new Label();
            mainPanel = new Panel();
            panelFeatureCards = new FlowLayoutPanel();
            cardSmartCalendar = new Panel();
            descSmartCalendar = new Label();
            titleSmartCalendar = new Label();
            iconSmartCalendar = new Label();
            cardTaskManagement = new Panel();
            descTaskManagement = new Label();
            titleTaskManagement = new Label();
            iconTaskManagement = new Label();
            cardTimePlanning = new Panel();
            descTimePlanning = new Label();
            titleTimePlanning = new Label();
            cardGroupOrganization = new Panel();
            descGroupOrganization = new Label();
            titleGroupOrganization = new Label();
            lblMainTitle = new Label();
            btnOpenDashboard = new Button();
            btnGetStarted = new Button();
            btnViewCalendar = new Button();
            sidebarPanel.SuspendLayout();
            panelNavigation.SuspendLayout();
            panelFooter.SuspendLayout();
            mainPanel.SuspendLayout();
            panelFeatureCards.SuspendLayout();
            cardSmartCalendar.SuspendLayout();
            cardTaskManagement.SuspendLayout();
            cardTimePlanning.SuspendLayout();
            cardGroupOrganization.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(243, 242, 241);
            sidebarPanel.Controls.Add(panelNavigation);
            sidebarPanel.Controls.Add(panelFooter);
            sidebarPanel.Controls.Add(btnQuickAdd);
            sidebarPanel.Controls.Add(lblSchedule);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Padding = new Padding(0, 15, 0, 15);
            sidebarPanel.Size = new Size(290, 908);
            sidebarPanel.TabIndex = 0;
            // 
            // panelNavigation
            // 
            panelNavigation.Controls.Add(btnSettings);
            panelNavigation.Controls.Add(btnChatbotAI);
            panelNavigation.Controls.Add(btnCalendar);
            panelNavigation.Controls.Add(btnWeekly);
            panelNavigation.Controls.Add(btnTasks);
            panelNavigation.Controls.Add(btnInbox);
            panelNavigation.Controls.Add(btnDashboard);
            panelNavigation.Controls.Add(btnHome);
            panelNavigation.Dock = DockStyle.Top;
            panelNavigation.Location = new Point(0, 108);
            panelNavigation.Name = "panelNavigation";
            panelNavigation.Size = new Size(290, 361);
            panelNavigation.TabIndex = 3;
            // 
            // btnSettings
            // 
            btnSettings.Dock = DockStyle.Top;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 11F);
            btnSettings.ForeColor = Color.FromArgb(89, 89, 89);
            btnSettings.Location = new Point(0, 315);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(21, 0, 0, 0);
            btnSettings.Size = new Size(290, 45);
            btnSettings.TabIndex = 9;
            btnSettings.Text = "⚙️ Cài đặt";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btn_CaiDat;
            // 
            // btnChatbotAI
            // 
            btnChatbotAI.Dock = DockStyle.Top;
            btnChatbotAI.FlatAppearance.BorderSize = 0;
            btnChatbotAI.FlatStyle = FlatStyle.Flat;
            btnChatbotAI.Font = new Font("Segoe UI", 11F);
            btnChatbotAI.ForeColor = Color.FromArgb(89, 89, 89);
            btnChatbotAI.Location = new Point(0, 270);
            btnChatbotAI.Name = "btnChatbotAI";
            btnChatbotAI.Padding = new Padding(21, 0, 0, 0);
            btnChatbotAI.Size = new Size(290, 45);
            btnChatbotAI.TabIndex = 10;
            btnChatbotAI.Text = "🤖 Chatbot AI";
            btnChatbotAI.TextAlign = ContentAlignment.MiddleLeft;
            btnChatbotAI.UseVisualStyleBackColor = true;
            btnChatbotAI.Click += btnChatbotAI_Click;
            // 
            // btnCalendar
            // 
            btnCalendar.Dock = DockStyle.Top;
            btnCalendar.FlatAppearance.BorderSize = 0;
            btnCalendar.FlatStyle = FlatStyle.Flat;
            btnCalendar.Font = new Font("Segoe UI", 11F);
            btnCalendar.ForeColor = Color.FromArgb(89, 89, 89);
            btnCalendar.Location = new Point(0, 225);
            btnCalendar.Name = "btnCalendar";
            btnCalendar.Padding = new Padding(21, 0, 0, 0);
            btnCalendar.Size = new Size(290, 45);
            btnCalendar.TabIndex = 7;
            btnCalendar.Text = "📆 Lịch tháng";
            btnCalendar.TextAlign = ContentAlignment.MiddleLeft;
            btnCalendar.UseVisualStyleBackColor = true;
            btnCalendar.Click += btnCalendar_Click;
            // 
            // btnWeekly
            // 
            btnWeekly.Dock = DockStyle.Top;
            btnWeekly.FlatAppearance.BorderSize = 0;
            btnWeekly.FlatStyle = FlatStyle.Flat;
            btnWeekly.Font = new Font("Segoe UI", 11F);
            btnWeekly.ForeColor = Color.FromArgb(89, 89, 89);
            btnWeekly.Location = new Point(0, 180);
            btnWeekly.Name = "btnWeekly";
            btnWeekly.Padding = new Padding(21, 0, 0, 0);
            btnWeekly.Size = new Size(290, 45);
            btnWeekly.TabIndex = 6;
            btnWeekly.Text = "📅 Lịch tuần";
            btnWeekly.TextAlign = ContentAlignment.MiddleLeft;
            btnWeekly.UseVisualStyleBackColor = true;
            btnWeekly.Click += btnWeekly_Click;
            // 
            // btnTasks
            // 
            btnTasks.Dock = DockStyle.Top;
            btnTasks.FlatAppearance.BorderSize = 0;
            btnTasks.FlatStyle = FlatStyle.Flat;
            btnTasks.Font = new Font("Segoe UI", 11F);
            btnTasks.ForeColor = Color.FromArgb(89, 89, 89);
            btnTasks.Location = new Point(0, 135);
            btnTasks.Name = "btnTasks";
            btnTasks.Padding = new Padding(21, 0, 0, 0);
            btnTasks.Size = new Size(290, 45);
            btnTasks.TabIndex = 5;
            btnTasks.Text = "☑️ Công việc";
            btnTasks.TextAlign = ContentAlignment.MiddleLeft;
            btnTasks.UseVisualStyleBackColor = true;
            btnTasks.Click += btnTasks_Click;
            // 
            // btnInbox
            // 
            btnInbox.Dock = DockStyle.Top;
            btnInbox.FlatAppearance.BorderSize = 0;
            btnInbox.FlatStyle = FlatStyle.Flat;
            btnInbox.Font = new Font("Segoe UI", 11F);
            btnInbox.ForeColor = Color.FromArgb(89, 89, 89);
            btnInbox.Location = new Point(0, 90);
            btnInbox.Name = "btnInbox";
            btnInbox.Padding = new Padding(21, 0, 0, 0);
            btnInbox.Size = new Size(290, 45);
            btnInbox.TabIndex = 4;
            btnInbox.Text = "👜 Thông báo";
            btnInbox.TextAlign = ContentAlignment.MiddleLeft;
            btnInbox.UseVisualStyleBackColor = true;
            // 
            // btnDashboard
            // 
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 11F);
            btnDashboard.ForeColor = Color.FromArgb(89, 89, 89);
            btnDashboard.Location = new Point(0, 45);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(21, 0, 0, 0);
            btnDashboard.Size = new Size(290, 45);
            btnDashboard.TabIndex = 3;
            btnDashboard.Text = "📊 Thống kê";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Top;
            btnHome.FlatAppearance.BorderSize = 0;
            btnHome.FlatStyle = FlatStyle.Flat;
            btnHome.Font = new Font("Segoe UI", 11F);
            btnHome.ForeColor = Color.FromArgb(89, 89, 89);
            btnHome.ImageAlign = ContentAlignment.MiddleLeft;
            btnHome.Location = new Point(0, 0);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(21, 0, 0, 0);
            btnHome.Size = new Size(290, 45);
            btnHome.TabIndex = 2;
            btnHome.Text = "🏠 Trang chủ";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = true;
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(btn_logout);
            panelFooter.Controls.Add(btnTrash);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 820);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(290, 73);
            panelFooter.TabIndex = 12;
            // 
            // btn_logout
            // 
            btn_logout.Dock = DockStyle.Top;
            btn_logout.FlatAppearance.BorderSize = 0;
            btn_logout.FlatStyle = FlatStyle.Flat;
            btn_logout.Font = new Font("Segoe UI", 11F);
            btn_logout.ForeColor = Color.FromArgb(89, 89, 89);
            btn_logout.Location = new Point(0, 35);
            btn_logout.Name = "btn_logout";
            btn_logout.Padding = new Padding(21, 0, 0, 0);
            btn_logout.Size = new Size(290, 35);
            btn_logout.TabIndex = 11;
            btn_logout.Text = "🗑️ Đăng xuất";
            btn_logout.TextAlign = ContentAlignment.MiddleLeft;
            btn_logout.UseVisualStyleBackColor = true;
            // 
            // btnTrash
            // 
            btnTrash.Dock = DockStyle.Top;
            btnTrash.FlatAppearance.BorderSize = 0;
            btnTrash.FlatStyle = FlatStyle.Flat;
            btnTrash.Font = new Font("Segoe UI", 11F);
            btnTrash.ForeColor = Color.FromArgb(89, 89, 89);
            btnTrash.Location = new Point(0, 0);
            btnTrash.Name = "btnTrash";
            btnTrash.Padding = new Padding(21, 0, 0, 0);
            btnTrash.Size = new Size(290, 35);
            btnTrash.TabIndex = 10;
            btnTrash.Text = "🗑️ Thùng rác";
            btnTrash.TextAlign = ContentAlignment.MiddleLeft;
            btnTrash.UseVisualStyleBackColor = true;
            btnTrash.Click += btnTrash_Click;
            // 
            // btnQuickAdd
            // 
            btnQuickAdd.BackColor = Color.FromArgb(0, 109, 207);
            btnQuickAdd.Cursor = Cursors.Hand;
            btnQuickAdd.Dock = DockStyle.Top;
            btnQuickAdd.FlatAppearance.BorderSize = 0;
            btnQuickAdd.FlatStyle = FlatStyle.Flat;
            btnQuickAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnQuickAdd.ForeColor = Color.White;
            btnQuickAdd.Location = new Point(0, 63);
            btnQuickAdd.Margin = new Padding(21, 0, 21, 0);
            btnQuickAdd.Name = "btnQuickAdd";
            btnQuickAdd.Padding = new Padding(21, 0, 21, 0);
            btnQuickAdd.Size = new Size(290, 45);
            btnQuickAdd.TabIndex = 1;
            btnQuickAdd.Text = "+ Thêm nhanh";
            btnQuickAdd.UseVisualStyleBackColor = false;
            // 
            // lblSchedule
            // 
            lblSchedule.AutoSize = true;
            lblSchedule.Dock = DockStyle.Top;
            lblSchedule.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSchedule.ForeColor = Color.FromArgb(55, 53, 47);
            lblSchedule.Location = new Point(0, 15);
            lblSchedule.Name = "lblSchedule";
            lblSchedule.Padding = new Padding(21, 0, 0, 11);
            lblSchedule.Size = new Size(198, 48);
            lblSchedule.TabIndex = 0;
            lblSchedule.Text = "📅 Schedule";
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(panelFeatureCards);
            mainPanel.Controls.Add(lblMainTitle);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(290, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(40);
            mainPanel.Size = new Size(949, 908);
            mainPanel.TabIndex = 1;
            // 
            // panelFeatureCards
            // 
            panelFeatureCards.AutoScroll = true;
            panelFeatureCards.Controls.Add(cardSmartCalendar);
            panelFeatureCards.Controls.Add(cardTaskManagement);
            panelFeatureCards.Controls.Add(cardTimePlanning);
            panelFeatureCards.Controls.Add(cardGroupOrganization);
            panelFeatureCards.Dock = DockStyle.Top;
            panelFeatureCards.Location = new Point(40, 243);
            panelFeatureCards.Name = "panelFeatureCards";
            panelFeatureCards.Size = new Size(869, 395);
            panelFeatureCards.TabIndex = 3;
            // 
            // cardSmartCalendar
            // 
            cardSmartCalendar.BackColor = Color.FromArgb(245, 245, 245);
            cardSmartCalendar.BorderStyle = BorderStyle.FixedSingle;
            cardSmartCalendar.Controls.Add(descSmartCalendar);
            cardSmartCalendar.Controls.Add(titleSmartCalendar);
            cardSmartCalendar.Controls.Add(iconSmartCalendar);
            cardSmartCalendar.Location = new Point(3, 3);
            cardSmartCalendar.Name = "cardSmartCalendar";
            cardSmartCalendar.Size = new Size(410, 205);
            cardSmartCalendar.TabIndex = 0;
            // 
            // descSmartCalendar
            // 
            descSmartCalendar.AutoSize = true;
            descSmartCalendar.Font = new Font("Segoe UI", 10F);
            descSmartCalendar.ForeColor = Color.FromArgb(100, 100, 100);
            descSmartCalendar.Location = new Point(21, 115);
            descSmartCalendar.MaximumSize = new Size(379, 0);
            descSmartCalendar.Name = "descSmartCalendar";
            descSmartCalendar.Size = new Size(373, 46);
            descSmartCalendar.TabIndex = 2;
            descSmartCalendar.Text = "Xem lịch theo ngày, tuần và tháng với điều hướng trực quan.";
            // 
            // titleSmartCalendar
            // 
            titleSmartCalendar.AutoSize = true;
            titleSmartCalendar.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            titleSmartCalendar.ForeColor = Color.FromArgb(55, 53, 47);
            titleSmartCalendar.Location = new Point(21, 80);
            titleSmartCalendar.Name = "titleSmartCalendar";
            titleSmartCalendar.Size = new Size(190, 32);
            titleSmartCalendar.TabIndex = 1;
            titleSmartCalendar.Text = "Smart Calendar";
            // 
            // iconSmartCalendar
            // 
            iconSmartCalendar.AutoSize = true;
            iconSmartCalendar.Font = new Font("Segoe UI Emoji", 32F);
            iconSmartCalendar.Location = new Point(21, 15);
            iconSmartCalendar.Name = "iconSmartCalendar";
            iconSmartCalendar.Size = new Size(104, 72);
            iconSmartCalendar.TabIndex = 0;
            iconSmartCalendar.Text = "📅";
            // 
            // cardTaskManagement
            // 
            cardTaskManagement.BackColor = Color.FromArgb(245, 245, 245);
            cardTaskManagement.BorderStyle = BorderStyle.FixedSingle;
            cardTaskManagement.Controls.Add(descTaskManagement);
            cardTaskManagement.Controls.Add(titleTaskManagement);
            cardTaskManagement.Controls.Add(iconTaskManagement);
            cardTaskManagement.Location = new Point(419, 3);
            cardTaskManagement.Name = "cardTaskManagement";
            cardTaskManagement.Size = new Size(410, 205);
            cardTaskManagement.TabIndex = 1;
            // 
            // descTaskManagement
            // 
            descTaskManagement.AutoSize = true;
            descTaskManagement.Font = new Font("Segoe UI", 10F);
            descTaskManagement.ForeColor = Color.FromArgb(100, 100, 100);
            descTaskManagement.Location = new Point(21, 115);
            descTaskManagement.MaximumSize = new Size(379, 0);
            descTaskManagement.Name = "descTaskManagement";
            descTaskManagement.Size = new Size(373, 46);
            descTaskManagement.TabIndex = 2;
            descTaskManagement.Text = "Sắp xếp công việc theo ưu tiên, công việc con và theo dõi chi tiết để tăng hiệu suất.";
            // 
            // titleTaskManagement
            // 
            titleTaskManagement.AutoSize = true;
            titleTaskManagement.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            titleTaskManagement.ForeColor = Color.FromArgb(55, 53, 47);
            titleTaskManagement.Location = new Point(21, 80);
            titleTaskManagement.Name = "titleTaskManagement";
            titleTaskManagement.Size = new Size(221, 32);
            titleTaskManagement.TabIndex = 1;
            titleTaskManagement.Text = "Task Management";
            // 
            // iconTaskManagement
            // 
            iconTaskManagement.AutoSize = true;
            iconTaskManagement.Font = new Font("Segoe UI Emoji", 32F);
            iconTaskManagement.Location = new Point(21, 15);
            iconTaskManagement.Name = "iconTaskManagement";
            iconTaskManagement.Size = new Size(104, 72);
            iconTaskManagement.TabIndex = 0;
            iconTaskManagement.Text = "✅";
            // 
            // cardTimePlanning
            // 
            cardTimePlanning.BackColor = Color.FromArgb(245, 245, 245);
            cardTimePlanning.BorderStyle = BorderStyle.FixedSingle;
            cardTimePlanning.Controls.Add(descTimePlanning);
            cardTimePlanning.Controls.Add(titleTimePlanning);
            cardTimePlanning.Location = new Point(3, 214);
            cardTimePlanning.Name = "cardTimePlanning";
            cardTimePlanning.Size = new Size(410, 175);
            cardTimePlanning.TabIndex = 2;
            // 
            // descTimePlanning
            // 
            descTimePlanning.AutoSize = true;
            descTimePlanning.Font = new Font("Segoe UI", 10F);
            descTimePlanning.ForeColor = Color.FromArgb(100, 100, 100);
            descTimePlanning.Location = new Point(21, 55);
            descTimePlanning.MaximumSize = new Size(379, 0);
            descTimePlanning.Name = "descTimePlanning";
            descTimePlanning.Size = new Size(377, 46);
            descTimePlanning.TabIndex = 2;
            descTimePlanning.Text = "Lên lịch với thời gian chính xác, lặp lại linh hoạt và nhắc nhở thông minh.";
            // 
            // titleTimePlanning
            // 
            titleTimePlanning.AutoSize = true;
            titleTimePlanning.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            titleTimePlanning.ForeColor = Color.FromArgb(55, 53, 47);
            titleTimePlanning.Location = new Point(21, 20);
            titleTimePlanning.Name = "titleTimePlanning";
            titleTimePlanning.Size = new Size(271, 32);
            titleTimePlanning.TabIndex = 1;
            titleTimePlanning.Text = "Lập kế hoạch thời gian";
            // 
            // cardGroupOrganization
            // 
            cardGroupOrganization.BackColor = Color.FromArgb(245, 245, 245);
            cardGroupOrganization.BorderStyle = BorderStyle.FixedSingle;
            cardGroupOrganization.Controls.Add(descGroupOrganization);
            cardGroupOrganization.Controls.Add(titleGroupOrganization);
            cardGroupOrganization.Location = new Point(419, 214);
            cardGroupOrganization.Name = "cardGroupOrganization";
            cardGroupOrganization.Size = new Size(410, 175);
            cardGroupOrganization.TabIndex = 3;
            // 
            // descGroupOrganization
            // 
            descGroupOrganization.AutoSize = true;
            descGroupOrganization.Font = new Font("Segoe UI", 10F);
            descGroupOrganization.ForeColor = Color.FromArgb(100, 100, 100);
            descGroupOrganization.Location = new Point(21, 55);
            descGroupOrganization.MaximumSize = new Size(379, 0);
            descGroupOrganization.Name = "descGroupOrganization";
            descGroupOrganization.Size = new Size(379, 46);
            descGroupOrganization.TabIndex = 2;
            descGroupOrganization.Text = "Phân loại lịch theo Công việc, Cá nhân, Học tập và Sức khỏe với màu tùy chỉnh.";
            // 
            // titleGroupOrganization
            // 
            titleGroupOrganization.AutoSize = true;
            titleGroupOrganization.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            titleGroupOrganization.ForeColor = Color.FromArgb(55, 53, 47);
            titleGroupOrganization.Location = new Point(21, 20);
            titleGroupOrganization.Name = "titleGroupOrganization";
            titleGroupOrganization.Size = new Size(224, 32);
            titleGroupOrganization.TabIndex = 1;
            titleGroupOrganization.Text = "Tổ chức nhóm lịch";
            // 
            // lblMainTitle
            // 
            lblMainTitle.Dock = DockStyle.Top;
            lblMainTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblMainTitle.ForeColor = Color.FromArgb(55, 53, 47);
            lblMainTitle.Location = new Point(40, 40);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Padding = new Padding(0, 20, 0, 20);
            lblMainTitle.Size = new Size(869, 203);
            lblMainTitle.TabIndex = 1;
            lblMainTitle.Text = "Chào mừng đến với Schedule";
            // 
            // btnOpenDashboard
            // 
            btnOpenDashboard.Location = new Point(0, 0);
            btnOpenDashboard.Name = "btnOpenDashboard";
            btnOpenDashboard.Size = new Size(75, 23);
            btnOpenDashboard.TabIndex = 0;
            // 
            // btnGetStarted
            // 
            btnGetStarted.Location = new Point(0, 0);
            btnGetStarted.Name = "btnGetStarted";
            btnGetStarted.Size = new Size(75, 23);
            btnGetStarted.TabIndex = 0;
            // 
            // btnViewCalendar
            // 
            btnViewCalendar.Location = new Point(0, 0);
            btnViewCalendar.Name = "btnViewCalendar";
            btnViewCalendar.Size = new Size(75, 23);
            btnViewCalendar.TabIndex = 0;
            // 
            // Trangchu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1239, 908);
            Controls.Add(mainPanel);
            Controls.Add(sidebarPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1000, 698);
            Name = "Trangchu";
            Text = "Schedule - Home";
            WindowState = FormWindowState.Maximized;
            sidebarPanel.ResumeLayout(false);
            sidebarPanel.PerformLayout();
            panelNavigation.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            panelFeatureCards.ResumeLayout(false);
            cardSmartCalendar.ResumeLayout(false);
            cardSmartCalendar.PerformLayout();
            cardTaskManagement.ResumeLayout(false);
            cardTaskManagement.PerformLayout();
            cardTimePlanning.ResumeLayout(false);
            cardTimePlanning.PerformLayout();
            cardGroupOrganization.ResumeLayout(false);
            cardGroupOrganization.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel sidebarPanel;
        private Panel mainPanel;
        private Label lblSchedule;
        private Button btnQuickAdd;
        private Button btnHome;
        private Button btnDashboard;
        private Button btnInbox;
        private Button btnTasks;
        private Button btnWeekly;
        private Button btnCalendar;
        private Button btnSettings;
        private Button btnChatbotAI;
        private Button btnTrash;
        private Panel panelNavigation;
        private Panel panelFooter;
        private Label lblMainTitle;
        private FlowLayoutPanel panelFeatureCards;
        private Panel cardSmartCalendar;
        private Label iconSmartCalendar;
        private Label titleSmartCalendar;
        private Label descSmartCalendar;
        private Panel cardTaskManagement;
        private Label iconTaskManagement;
        private Label titleTaskManagement;
        private Label descTaskManagement;
        private Panel cardTimePlanning;
        private Label titleTimePlanning;
        private Label descTimePlanning;
        private Panel cardGroupOrganization;
        private Label titleGroupOrganization;
        private Label descGroupOrganization;
        private Button btnOpenDashboard;
        private Button btnGetStarted;
        private Button btnViewCalendar;
        private Button btn_logout;
    }
}
