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
            panelGroupsContainer = new Panel();
            btnNewGroup = new Button();
            lblScheduleGroups = new Label();
            panelNavigation = new Panel();
            btnSettings = new Button();
            btnChatbotAI = new Button();
            btnScheduleGroups = new Button();
            btnCalendar = new Button();
            btnWeekly = new Button();
            btnTasks = new Button();
            btnInbox = new Button();
            btnDashboard = new Button();
            btnHome = new Button();
            panelFooter = new Panel();
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
            lblWelcome = new Label();
            btnOpenDashboard = new Button();
            btnGetStarted = new Button();
            btnViewCalendar = new Button();
            sidebarPanel.SuspendLayout();
            panelGroupsContainer.SuspendLayout();
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
            sidebarPanel.BackColor = Color.White;
            sidebarPanel.Controls.Add(panelGroupsContainer);
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
            // panelGroupsContainer
            // 
            panelGroupsContainer.AutoScroll = true;
            panelGroupsContainer.Controls.Add(btnNewGroup);
            panelGroupsContainer.Controls.Add(lblScheduleGroups);
            panelGroupsContainer.Dock = DockStyle.Fill;
            panelGroupsContainer.Location = new Point(0, 422);
            panelGroupsContainer.Name = "panelGroupsContainer";
            panelGroupsContainer.Padding = new Padding(20, 15, 20, 0);
            panelGroupsContainer.Size = new Size(290, 398);
            panelGroupsContainer.TabIndex = 11;
            // 
            // btnNewGroup
            // 
            btnNewGroup.AutoSize = true;
            btnNewGroup.BackColor = Color.Transparent;
            btnNewGroup.Dock = DockStyle.Top;
            btnNewGroup.FlatAppearance.BorderSize = 0;
            btnNewGroup.FlatStyle = FlatStyle.Flat;
            btnNewGroup.Font = new Font("Segoe UI", 10F);
            btnNewGroup.ForeColor = Color.FromArgb(89, 89, 89);
            btnNewGroup.Location = new Point(20, 45);
            btnNewGroup.Name = "btnNewGroup";
            btnNewGroup.Padding = new Padding(10, 0, 0, 0);
            btnNewGroup.Size = new Size(250, 33);
            btnNewGroup.TabIndex = 4;
            btnNewGroup.Text = "+ New Group";
            btnNewGroup.TextAlign = ContentAlignment.MiddleLeft;
            btnNewGroup.UseVisualStyleBackColor = false;
            // 
            // lblScheduleGroups
            // 
            lblScheduleGroups.AutoSize = true;
            lblScheduleGroups.Dock = DockStyle.Top;
            lblScheduleGroups.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblScheduleGroups.ForeColor = Color.FromArgb(128, 128, 128);
            lblScheduleGroups.Location = new Point(20, 15);
            lblScheduleGroups.Name = "lblScheduleGroups";
            lblScheduleGroups.Padding = new Padding(0, 0, 0, 10);
            lblScheduleGroups.Size = new Size(147, 30);
            lblScheduleGroups.TabIndex = 10;
            lblScheduleGroups.Text = "SCHEDULE GROUPS";
            // 
            // panelNavigation
            // 
            panelNavigation.Controls.Add(btnSettings);
            panelNavigation.Controls.Add(btnChatbotAI);
            panelNavigation.Controls.Add(btnScheduleGroups);
            panelNavigation.Controls.Add(btnCalendar);
            panelNavigation.Controls.Add(btnWeekly);
            panelNavigation.Controls.Add(btnTasks);
            panelNavigation.Controls.Add(btnInbox);
            panelNavigation.Controls.Add(btnDashboard);
            panelNavigation.Controls.Add(btnHome);
            panelNavigation.Dock = DockStyle.Top;
            panelNavigation.Location = new Point(0, 107);
            panelNavigation.Name = "panelNavigation";
            panelNavigation.Size = new Size(290, 315);
            panelNavigation.TabIndex = 3;
            // 
            // btnSettings
            // 
            btnSettings.Dock = DockStyle.Top;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 11F);
            btnSettings.ForeColor = Color.FromArgb(89, 89, 89);
            btnSettings.Location = new Point(0, 360);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(20, 0, 0, 0);
            btnSettings.Size = new Size(290, 45);
            btnSettings.TabIndex = 9;
            btnSettings.Text = "⚙️ Settings";
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
            btnChatbotAI.Location = new Point(0, 315);
            btnChatbotAI.Name = "btnChatbotAI";
            btnChatbotAI.Padding = new Padding(20, 0, 0, 0);
            btnChatbotAI.Size = new Size(290, 45);
            btnChatbotAI.TabIndex = 10;
            btnChatbotAI.Text = "🤖 Chatbot AI";
            btnChatbotAI.TextAlign = ContentAlignment.MiddleLeft;
            btnChatbotAI.UseVisualStyleBackColor = true;
            btnChatbotAI.Click += btnChatbotAI_Click;
            // 
            // btnScheduleGroups
            // 
            btnScheduleGroups.Dock = DockStyle.Top;
            btnScheduleGroups.FlatAppearance.BorderSize = 0;
            btnScheduleGroups.FlatStyle = FlatStyle.Flat;
            btnScheduleGroups.Font = new Font("Segoe UI", 11F);
            btnScheduleGroups.ForeColor = Color.FromArgb(89, 89, 89);
            btnScheduleGroups.Location = new Point(0, 270);
            btnScheduleGroups.Name = "btnScheduleGroups";
            btnScheduleGroups.Padding = new Padding(20, 0, 0, 0);
            btnScheduleGroups.Size = new Size(290, 45);
            btnScheduleGroups.TabIndex = 8;
            btnScheduleGroups.Text = "📋 Schedule Groups";
            btnScheduleGroups.TextAlign = ContentAlignment.MiddleLeft;
            btnScheduleGroups.UseVisualStyleBackColor = true;
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
            btnCalendar.Padding = new Padding(20, 0, 0, 0);
            btnCalendar.Size = new Size(290, 45);
            btnCalendar.TabIndex = 7;
            btnCalendar.Text = "📆 Calendar";
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
            btnWeekly.Padding = new Padding(20, 0, 0, 0);
            btnWeekly.Size = new Size(290, 45);
            btnWeekly.TabIndex = 6;
            btnWeekly.Text = "📅 Weekly";
            btnWeekly.TextAlign = ContentAlignment.MiddleLeft;
            btnWeekly.UseVisualStyleBackColor = true;
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
            btnTasks.Padding = new Padding(20, 0, 0, 0);
            btnTasks.Size = new Size(290, 45);
            btnTasks.TabIndex = 5;
            btnTasks.Text = "☑️ Tasks";
            btnTasks.TextAlign = ContentAlignment.MiddleLeft;
            btnTasks.UseVisualStyleBackColor = true;
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
            btnInbox.Padding = new Padding(20, 0, 0, 0);
            btnInbox.Size = new Size(290, 45);
            btnInbox.TabIndex = 4;
            btnInbox.Text = "👜 Inbox";
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
            btnDashboard.Padding = new Padding(20, 0, 0, 0);
            btnDashboard.Size = new Size(290, 45);
            btnDashboard.TabIndex = 3;
            btnDashboard.Text = "📊 Dashboard";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = true;
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
            btnHome.Padding = new Padding(20, 0, 0, 0);
            btnHome.Size = new Size(290, 45);
            btnHome.TabIndex = 2;
            btnHome.Text = "🏠 Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = true;
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(btnTrash);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 820);
            panelFooter.Name = "panelFooter";
            panelFooter.Size = new Size(290, 73);
            panelFooter.TabIndex = 12;
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
            btnTrash.Padding = new Padding(20, 0, 0, 0);
            btnTrash.Size = new Size(290, 45);
            btnTrash.TabIndex = 10;
            btnTrash.Text = "🗑️ Trash";
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
            btnQuickAdd.Location = new Point(0, 62);
            btnQuickAdd.Margin = new Padding(20, 0, 20, 0);
            btnQuickAdd.Name = "btnQuickAdd";
            btnQuickAdd.Padding = new Padding(20, 0, 20, 0);
            btnQuickAdd.Size = new Size(290, 45);
            btnQuickAdd.TabIndex = 1;
            btnQuickAdd.Text = "+ Quick Add";
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
            lblSchedule.Padding = new Padding(20, 0, 0, 10);
            lblSchedule.Size = new Size(197, 47);
            lblSchedule.TabIndex = 0;
            lblSchedule.Text = "📅 Schedule";
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(panelFeatureCards);
            mainPanel.Controls.Add(lblMainTitle);
            mainPanel.Controls.Add(lblWelcome);
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
            panelFeatureCards.Location = new Point(40, 280);
            panelFeatureCards.Name = "panelFeatureCards";
            panelFeatureCards.Size = new Size(869, 370);
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
            cardSmartCalendar.Size = new Size(410, 180);
            cardSmartCalendar.TabIndex = 0;
            // 
            // descSmartCalendar
            // 
            descSmartCalendar.AutoSize = true;
            descSmartCalendar.Font = new Font("Segoe UI", 10F);
            descSmartCalendar.ForeColor = Color.FromArgb(100, 100, 100);
            descSmartCalendar.Location = new Point(20, 115);
            descSmartCalendar.MaximumSize = new Size(380, 0);
            descSmartCalendar.Name = "descSmartCalendar";
            descSmartCalendar.Size = new Size(325, 69);
            descSmartCalendar.TabIndex = 2;
            descSmartCalendar.Text = "View your schedules in daily, weekly, and monthly\r\nformats with intuitive navigation.";
            // 
            // titleSmartCalendar
            // 
            titleSmartCalendar.AutoSize = true;
            titleSmartCalendar.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            titleSmartCalendar.ForeColor = Color.FromArgb(55, 53, 47);
            titleSmartCalendar.Location = new Point(20, 80);
            titleSmartCalendar.Name = "titleSmartCalendar";
            titleSmartCalendar.Size = new Size(190, 32);
            titleSmartCalendar.TabIndex = 1;
            titleSmartCalendar.Text = "Smart Calendar";
            // 
            // iconSmartCalendar
            // 
            iconSmartCalendar.AutoSize = true;
            iconSmartCalendar.Font = new Font("Segoe UI Emoji", 32F);
            iconSmartCalendar.Location = new Point(20, 15);
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
            cardTaskManagement.Size = new Size(410, 180);
            cardTaskManagement.TabIndex = 1;
            // 
            // descTaskManagement
            // 
            descTaskManagement.AutoSize = true;
            descTaskManagement.Font = new Font("Segoe UI", 10F);
            descTaskManagement.ForeColor = Color.FromArgb(100, 100, 100);
            descTaskManagement.Location = new Point(20, 115);
            descTaskManagement.MaximumSize = new Size(380, 0);
            descTaskManagement.Name = "descTaskManagement";
            descTaskManagement.Size = new Size(345, 69);
            descTaskManagement.TabIndex = 2;
            descTaskManagement.Text = "Organize tasks with priorities, subtasks, and detailed\r\ntracking for better productivity.";
            // 
            // titleTaskManagement
            // 
            titleTaskManagement.AutoSize = true;
            titleTaskManagement.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            titleTaskManagement.ForeColor = Color.FromArgb(55, 53, 47);
            titleTaskManagement.Location = new Point(20, 80);
            titleTaskManagement.Name = "titleTaskManagement";
            titleTaskManagement.Size = new Size(221, 32);
            titleTaskManagement.TabIndex = 1;
            titleTaskManagement.Text = "Task Management";
            // 
            // iconTaskManagement
            // 
            iconTaskManagement.AutoSize = true;
            iconTaskManagement.Font = new Font("Segoe UI Emoji", 32F);
            iconTaskManagement.Location = new Point(20, 15);
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
            cardTimePlanning.Location = new Point(3, 189);
            cardTimePlanning.Name = "cardTimePlanning";
            cardTimePlanning.Size = new Size(410, 160);
            cardTimePlanning.TabIndex = 2;
            // 
            // descTimePlanning
            // 
            descTimePlanning.AutoSize = true;
            descTimePlanning.Font = new Font("Segoe UI", 10F);
            descTimePlanning.ForeColor = Color.FromArgb(100, 100, 100);
            descTimePlanning.Location = new Point(20, 55);
            descTimePlanning.MaximumSize = new Size(380, 0);
            descTimePlanning.Name = "descTimePlanning";
            descTimePlanning.Size = new Size(365, 69);
            descTimePlanning.TabIndex = 2;
            descTimePlanning.Text = "Schedule events with precise timing, recurring patterns,\r\nand smart reminders.";
            // 
            // titleTimePlanning
            // 
            titleTimePlanning.AutoSize = true;
            titleTimePlanning.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            titleTimePlanning.ForeColor = Color.FromArgb(55, 53, 47);
            titleTimePlanning.Location = new Point(20, 20);
            titleTimePlanning.Name = "titleTimePlanning";
            titleTimePlanning.Size = new Size(179, 32);
            titleTimePlanning.TabIndex = 1;
            titleTimePlanning.Text = "Time Planning";
            // 
            // cardGroupOrganization
            // 
            cardGroupOrganization.BackColor = Color.FromArgb(245, 245, 245);
            cardGroupOrganization.BorderStyle = BorderStyle.FixedSingle;
            cardGroupOrganization.Controls.Add(descGroupOrganization);
            cardGroupOrganization.Controls.Add(titleGroupOrganization);
            cardGroupOrganization.Location = new Point(419, 189);
            cardGroupOrganization.Name = "cardGroupOrganization";
            cardGroupOrganization.Size = new Size(410, 160);
            cardGroupOrganization.TabIndex = 3;
            // 
            // descGroupOrganization
            // 
            descGroupOrganization.AutoSize = true;
            descGroupOrganization.Font = new Font("Segoe UI", 10F);
            descGroupOrganization.ForeColor = Color.FromArgb(100, 100, 100);
            descGroupOrganization.Location = new Point(20, 55);
            descGroupOrganization.MaximumSize = new Size(380, 0);
            descGroupOrganization.Name = "descGroupOrganization";
            descGroupOrganization.Size = new Size(378, 69);
            descGroupOrganization.TabIndex = 2;
            descGroupOrganization.Text = "Categorize schedules into Work, Personal, Study, and\r\nHealth groups with custom colors.";
            // 
            // titleGroupOrganization
            // 
            titleGroupOrganization.AutoSize = true;
            titleGroupOrganization.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            titleGroupOrganization.ForeColor = Color.FromArgb(55, 53, 47);
            titleGroupOrganization.Location = new Point(20, 20);
            titleGroupOrganization.Name = "titleGroupOrganization";
            titleGroupOrganization.Size = new Size(242, 32);
            titleGroupOrganization.TabIndex = 1;
            titleGroupOrganization.Text = "Group Organization";
            // 
            // lblMainTitle
            // 
            lblMainTitle.AutoSize = true;
            lblMainTitle.Dock = DockStyle.Top;
            lblMainTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblMainTitle.ForeColor = Color.FromArgb(55, 53, 47);
            lblMainTitle.Location = new Point(40, 78);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Padding = new Padding(0, 20, 0, 20);
            lblMainTitle.Size = new Size(589, 202);
            lblMainTitle.TabIndex = 1;
            lblMainTitle.Text = "Your Time,\r\nPerfectly Organized";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Dock = DockStyle.Top;
            lblWelcome.Font = new Font("Segoe UI", 10F);
            lblWelcome.ForeColor = Color.FromArgb(128, 128, 128);
            lblWelcome.Location = new Point(40, 40);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Padding = new Padding(0, 0, 0, 15);
            lblWelcome.Size = new Size(203, 38);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "✨ Welcome to Schedule";
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
            MinimumSize = new Size(1000, 700);
            Name = "Trangchu";
            Text = "Schedule - Home";
            sidebarPanel.ResumeLayout(false);
            sidebarPanel.PerformLayout();
            panelGroupsContainer.ResumeLayout(false);
            panelGroupsContainer.PerformLayout();
            panelNavigation.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
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
        private Button btnScheduleGroups;
        private Button btnSettings;
        private Button btnChatbotAI;
        private Button btnTrash;
        private Label lblScheduleGroups;
        private Panel panelGroupsContainer;
        private Panel panelNavigation;
        private Panel panelFooter;
        private Button btnNewGroup;
        private Label lblWelcome;
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
    }
}
