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
            sidebarPanel = new Panel();
            lblScheduleGroups = new Label();
            panelGroupsContainer = new Panel();
            btnNewGroup = new Button();
            btnSettings = new Button();
            btnScheduleGroups = new Button();
            btnCalendar = new Button();
            btnWeekly = new Button();
            btnTasks = new Button();
            btnInbox = new Button();
            btnDashboard = new Button();
            btnHome = new Button();
            btnQuickAdd = new Button();
            lblSchedule = new Label();
            mainPanel = new Panel();
            panelStats = new Panel();
            lblPossibilitiesText = new Label();
            lblPossibilities = new Label();
            lblScheduleGroupsText = new Label();
            lblScheduleGroupsCount = new Label();
            lblPagesCount = new Label();
            lblPages = new Label();
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
            mainPanel.SuspendLayout();
            panelStats.SuspendLayout();
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
            sidebarPanel.Controls.Add(lblScheduleGroups);
            sidebarPanel.Controls.Add(panelGroupsContainer);
            sidebarPanel.Controls.Add(btnSettings);
            sidebarPanel.Controls.Add(btnScheduleGroups);
            sidebarPanel.Controls.Add(btnCalendar);
            sidebarPanel.Controls.Add(btnWeekly);
            sidebarPanel.Controls.Add(btnTasks);
            sidebarPanel.Controls.Add(btnInbox);
            sidebarPanel.Controls.Add(btnDashboard);
            sidebarPanel.Controls.Add(btnHome);
            sidebarPanel.Controls.Add(btnQuickAdd);
            sidebarPanel.Controls.Add(lblSchedule);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(290, 900);
            sidebarPanel.TabIndex = 0;
            // 
            // lblScheduleGroups
            // 
            lblScheduleGroups.AutoSize = true;
            lblScheduleGroups.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblScheduleGroups.ForeColor = Color.FromArgb(128, 128, 128);
            lblScheduleGroups.Location = new Point(20, 370);
            lblScheduleGroups.Name = "lblScheduleGroups";
            lblScheduleGroups.Size = new Size(147, 20);
            lblScheduleGroups.TabIndex = 10;
            lblScheduleGroups.Text = "SCHEDULE GROUPS";
            // 
            // panelGroupsContainer
            // 
            panelGroupsContainer.AutoScroll = true;
            panelGroupsContainer.Controls.Add(btnNewGroup);
            panelGroupsContainer.Location = new Point(20, 400);
            panelGroupsContainer.Name = "panelGroupsContainer";
            panelGroupsContainer.Size = new Size(250, 400);
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
            btnNewGroup.Location = new Point(0, 0);
            btnNewGroup.Margin = new Padding(0, 5, 0, 0);
            btnNewGroup.Name = "btnNewGroup";
            btnNewGroup.Padding = new Padding(10, 0, 0, 0);
            btnNewGroup.Size = new Size(250, 33);
            btnNewGroup.TabIndex = 4;
            btnNewGroup.Text = "+ New Group";
            btnNewGroup.TextAlign = ContentAlignment.MiddleLeft;
            btnNewGroup.UseVisualStyleBackColor = false;
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
            btnSettings.Padding = new Padding(20, 0, 0, 0);
            btnSettings.Size = new Size(290, 45);
            btnSettings.TabIndex = 9;
            btnSettings.Text = "⚙️ Settings";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.UseVisualStyleBackColor = true;
            btnSettings.Click += btn_CaiDat;
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
            btnHome.Margin = new Padding(0, 20, 0, 0);
            btnHome.Name = "btnHome";
            btnHome.Padding = new Padding(20, 0, 0, 0);
            btnHome.Size = new Size(290, 45);
            btnHome.TabIndex = 2;
            btnHome.Text = "🏠 Home";
            btnHome.TextAlign = ContentAlignment.MiddleLeft;
            btnHome.UseVisualStyleBackColor = true;
            // 
            // btnQuickAdd
            // 
            btnQuickAdd.BackColor = Color.FromArgb(0, 109, 207);
            btnQuickAdd.Cursor = Cursors.Hand;
            btnQuickAdd.FlatAppearance.BorderSize = 0;
            btnQuickAdd.FlatStyle = FlatStyle.Flat;
            btnQuickAdd.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnQuickAdd.ForeColor = Color.White;
            btnQuickAdd.Location = new Point(20, 65);
            btnQuickAdd.Name = "btnQuickAdd";
            btnQuickAdd.Size = new Size(250, 45);
            btnQuickAdd.TabIndex = 1;
            btnQuickAdd.Text = "+ Quick Add";
            btnQuickAdd.UseVisualStyleBackColor = false;
            // 
            // lblSchedule
            // 
            lblSchedule.AutoSize = true;
            lblSchedule.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblSchedule.ForeColor = Color.FromArgb(55, 53, 47);
            lblSchedule.Location = new Point(20, 15);
            lblSchedule.Name = "lblSchedule";
            lblSchedule.Size = new Size(177, 37);
            lblSchedule.TabIndex = 0;
            lblSchedule.Text = "📅 Schedule";
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.BackColor = Color.White;
            mainPanel.Controls.Add(panelStats);
            mainPanel.Controls.Add(panelFeatureCards);
            mainPanel.Controls.Add(lblMainTitle);
            mainPanel.Controls.Add(lblWelcome);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(290, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(40);
            mainPanel.Size = new Size(1110, 900);
            mainPanel.TabIndex = 1;
            // 
            // panelStats
            // 
            panelStats.Controls.Add(lblPossibilitiesText);
            panelStats.Controls.Add(lblPossibilities);
            panelStats.Controls.Add(lblScheduleGroupsText);
            panelStats.Controls.Add(lblScheduleGroupsCount);
            panelStats.Controls.Add(lblPagesCount);
            panelStats.Controls.Add(lblPages);
            panelStats.Location = new Point(40, 620);
            panelStats.Name = "panelStats";
            panelStats.Size = new Size(1000, 150);
            panelStats.TabIndex = 4;
            // 
            // lblPossibilitiesText
            // 
            lblPossibilitiesText.AutoSize = true;
            lblPossibilitiesText.Font = new Font("Segoe UI", 11F);
            lblPossibilitiesText.ForeColor = Color.White;
            lblPossibilitiesText.Location = new Point(680, 80);
            lblPossibilitiesText.Name = "lblPossibilitiesText";
            lblPossibilitiesText.Size = new Size(109, 25);
            lblPossibilitiesText.TabIndex = 5;
            lblPossibilitiesText.Text = "Possibilities";
            // 
            // lblPossibilities
            // 
            lblPossibilities.AutoSize = true;
            lblPossibilities.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblPossibilities.ForeColor = Color.White;
            lblPossibilities.Location = new Point(680, 20);
            lblPossibilities.Name = "lblPossibilities";
            lblPossibilities.Size = new Size(56, 54);
            lblPossibilities.TabIndex = 4;
            lblPossibilities.Text = "∞";
            // 
            // lblScheduleGroupsText
            // 
            lblScheduleGroupsText.AutoSize = true;
            lblScheduleGroupsText.Font = new Font("Segoe UI", 11F);
            lblScheduleGroupsText.ForeColor = Color.White;
            lblScheduleGroupsText.Location = new Point(350, 80);
            lblScheduleGroupsText.Name = "lblScheduleGroupsText";
            lblScheduleGroupsText.Size = new Size(155, 25);
            lblScheduleGroupsText.TabIndex = 3;
            lblScheduleGroupsText.Text = "Schedule Groups";
            // 
            // lblScheduleGroupsCount
            // 
            lblScheduleGroupsCount.AutoSize = true;
            lblScheduleGroupsCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblScheduleGroupsCount.ForeColor = Color.White;
            lblScheduleGroupsCount.Location = new Point(350, 20);
            lblScheduleGroupsCount.Name = "lblScheduleGroupsCount";
            lblScheduleGroupsCount.Size = new Size(46, 54);
            lblScheduleGroupsCount.TabIndex = 2;
            lblScheduleGroupsCount.Text = "4";
            // 
            // lblPagesCount
            // 
            lblPagesCount.AutoSize = true;
            lblPagesCount.Font = new Font("Segoe UI", 11F);
            lblPagesCount.ForeColor = Color.White;
            lblPagesCount.Location = new Point(20, 80);
            lblPagesCount.Name = "lblPagesCount";
            lblPagesCount.Size = new Size(120, 25);
            lblPagesCount.TabIndex = 1;
            lblPagesCount.Text = "Pages & Views";
            // 
            // lblPages
            // 
            lblPages.AutoSize = true;
            lblPages.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblPages.ForeColor = Color.White;
            lblPages.Location = new Point(20, 20);
            lblPages.Name = "lblPages";
            lblPages.Size = new Size(46, 54);
            lblPages.TabIndex = 0;
            lblPages.Text = "7";
            // 
            // panelFeatureCards
            // 
            panelFeatureCards.AutoScroll = true;
            panelFeatureCards.Controls.Add(cardSmartCalendar);
            panelFeatureCards.Controls.Add(cardTaskManagement);
            panelFeatureCards.Controls.Add(cardTimePlanning);
            panelFeatureCards.Controls.Add(cardGroupOrganization);
            panelFeatureCards.Location = new Point(40, 250);
            panelFeatureCards.Name = "panelFeatureCards";
            panelFeatureCards.Size = new Size(1030, 350);
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
            cardSmartCalendar.Size = new Size(480, 180);
            cardSmartCalendar.TabIndex = 0;
            // 
            // descSmartCalendar
            // 
            descSmartCalendar.AutoSize = true;
            descSmartCalendar.Font = new Font("Segoe UI", 10F);
            descSmartCalendar.ForeColor = Color.FromArgb(100, 100, 100);
            descSmartCalendar.Location = new Point(20, 115);
            descSmartCalendar.MaximumSize = new Size(450, 0);
            descSmartCalendar.Name = "descSmartCalendar";
            descSmartCalendar.Size = new Size(388, 46);
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
            cardTaskManagement.Location = new Point(489, 3);
            cardTaskManagement.Name = "cardTaskManagement";
            cardTaskManagement.Size = new Size(480, 180);
            cardTaskManagement.TabIndex = 1;
            // 
            // descTaskManagement
            // 
            descTaskManagement.AutoSize = true;
            descTaskManagement.Font = new Font("Segoe UI", 10F);
            descTaskManagement.ForeColor = Color.FromArgb(100, 100, 100);
            descTaskManagement.Location = new Point(20, 115);
            descTaskManagement.MaximumSize = new Size(450, 0);
            descTaskManagement.Name = "descTaskManagement";
            descTaskManagement.Size = new Size(406, 46);
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
            cardTimePlanning.Size = new Size(480, 160);
            cardTimePlanning.TabIndex = 2;
            // 
            // descTimePlanning
            // 
            descTimePlanning.AutoSize = true;
            descTimePlanning.Font = new Font("Segoe UI", 10F);
            descTimePlanning.ForeColor = Color.FromArgb(100, 100, 100);
            descTimePlanning.Location = new Point(20, 55);
            descTimePlanning.MaximumSize = new Size(450, 0);
            descTimePlanning.Name = "descTimePlanning";
            descTimePlanning.Size = new Size(432, 46);
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
            cardGroupOrganization.Location = new Point(489, 189);
            cardGroupOrganization.Name = "cardGroupOrganization";
            cardGroupOrganization.Size = new Size(480, 160);
            cardGroupOrganization.TabIndex = 3;
            // 
            // descGroupOrganization
            // 
            descGroupOrganization.AutoSize = true;
            descGroupOrganization.Font = new Font("Segoe UI", 10F);
            descGroupOrganization.ForeColor = Color.FromArgb(100, 100, 100);
            descGroupOrganization.Location = new Point(20, 55);
            descGroupOrganization.MaximumSize = new Size(450, 0);
            descGroupOrganization.Name = "descGroupOrganization";
            descGroupOrganization.Size = new Size(412, 46);
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
            lblMainTitle.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            lblMainTitle.ForeColor = Color.FromArgb(55, 53, 47);
            lblMainTitle.Location = new Point(40, 75);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new Size(589, 162);
            lblMainTitle.TabIndex = 1;
            lblMainTitle.Text = "Your Time,\r\nPerfectly Organized";
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 10F);
            lblWelcome.ForeColor = Color.FromArgb(128, 128, 128);
            lblWelcome.Location = new Point(40, 40);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(203, 23);
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
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1400, 900);
            Controls.Add(mainPanel);
            Controls.Add(sidebarPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Trangchu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Schedule";
            Load += Form1_Load;
            sidebarPanel.ResumeLayout(false);
            sidebarPanel.PerformLayout();
            panelGroupsContainer.ResumeLayout(false);
            panelGroupsContainer.PerformLayout();
            mainPanel.ResumeLayout(false);
            mainPanel.PerformLayout();
            panelStats.ResumeLayout(false);
            panelStats.PerformLayout();
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
        private Label lblScheduleGroups;
        private Panel panelGroupsContainer;
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
        private Panel panelStats;
        private Label lblPages;
        private Label lblPagesCount;
        private Label lblScheduleGroupsCount;
        private Label lblScheduleGroupsText;
        private Label lblPossibilities;
        private Label lblPossibilitiesText;
        private Button btnOpenDashboard;
        private Button btnGetStarted;
        private Button btnViewCalendar;
    }
}
