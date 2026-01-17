namespace ChatbotAI_Form
{
    partial class ChatbotAI
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
            components = new System.ComponentModel.Container();
            panelTitleBar = new Panel();
            btnTitleLeft = new Button();
            btnEdit = new Button();
            btnMode = new Button();
            btnHide = new Button();
            panelDropdownHistory = new Panel();
            flowHistory = new FlowLayoutPanel();
            panelSessionItem = new Panel();
            lblSessionTitle = new Label();
            lblSelected = new Label();
            btnDeleteSession = new Button();
            lblToday = new Label();
            panelHeader = new Panel();
            lblGreeting = new Label();
            lblAvatar = new Label();
            panelBody = new Panel();
            flowMessages = new FlowLayoutPanel();
            flowActions = new FlowLayoutPanel();
            btnAction1 = new Button();
            btnAction2 = new Button();
            btnAction3 = new Button();
            panelFooter = new Panel();
            panelInputContainer = new Panel();
            txtInput = new TextBox();
            flowFileAttachments = new FlowLayoutPanel();
            panelInputTools = new Panel();
            btnSend = new Button();
            btnSource = new Button();
            btnAuto = new Button();
            btnAttachment = new Button();
            toolTip1 = new ToolTip(components);
            panelTitleBar.SuspendLayout();
            panelDropdownHistory.SuspendLayout();
            flowHistory.SuspendLayout();
            panelSessionItem.SuspendLayout();
            panelHeader.SuspendLayout();
            panelBody.SuspendLayout();
            flowActions.SuspendLayout();
            panelFooter.SuspendLayout();
            panelInputContainer.SuspendLayout();
            panelInputTools.SuspendLayout();
            SuspendLayout();
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.White;
            panelTitleBar.Controls.Add(btnTitleLeft);
            panelTitleBar.Controls.Add(btnEdit);
            panelTitleBar.Controls.Add(btnMode);
            panelTitleBar.Controls.Add(btnHide);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Margin = new Padding(4);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Padding = new Padding(12, 0, 6, 0);
            panelTitleBar.Size = new Size(688, 50);
            panelTitleBar.TabIndex = 0;
            panelTitleBar.MouseDown += ChatbotAI_MouseDown;
            // 
            // btnTitleLeft
            // 
            btnTitleLeft.AutoSize = true;
            btnTitleLeft.Cursor = Cursors.Hand;
            btnTitleLeft.Dock = DockStyle.Left;
            btnTitleLeft.FlatAppearance.BorderSize = 0;
            btnTitleLeft.FlatAppearance.MouseDownBackColor = Color.FromArgb(225, 225, 225);
            btnTitleLeft.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 240, 240);
            btnTitleLeft.FlatStyle = FlatStyle.Flat;
            btnTitleLeft.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTitleLeft.ForeColor = Color.FromArgb(55, 53, 47);
            btnTitleLeft.Location = new Point(12, 0);
            btnTitleLeft.Margin = new Padding(4);
            btnTitleLeft.Name = "btnTitleLeft";
            btnTitleLeft.Size = new Size(259, 50);
            btnTitleLeft.TabIndex = 0;
            btnTitleLeft.Text = "Lịch sử trò chuyện với AI";
            btnTitleLeft.UseVisualStyleBackColor = true;
            btnTitleLeft.Click += btnTitleLeft_Click;
            // 
            // btnEdit
            // 
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Dock = DockStyle.Right;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 240, 240);
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI Symbol", 10F);
            btnEdit.ForeColor = Color.FromArgb(64, 64, 64);
            btnEdit.Location = new Point(539, 0);
            btnEdit.Margin = new Padding(4);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(49, 50);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "📝";
            toolTip1.SetToolTip(btnEdit, "Tạo đoạn chat mới");
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnMode
            // 
            btnMode.Cursor = Cursors.Hand;
            btnMode.Dock = DockStyle.Right;
            btnMode.FlatAppearance.BorderSize = 0;
            btnMode.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 240, 240);
            btnMode.FlatStyle = FlatStyle.Flat;
            btnMode.Font = new Font("Segoe UI Symbol", 10F);
            btnMode.ForeColor = Color.FromArgb(64, 64, 64);
            btnMode.Location = new Point(588, 0);
            btnMode.Margin = new Padding(4);
            btnMode.Name = "btnMode";
            btnMode.Size = new Size(48, 50);
            btnMode.TabIndex = 2;
            btnMode.Text = "🗖";
            toolTip1.SetToolTip(btnMode, "Phóng to");
            btnMode.UseVisualStyleBackColor = true;
            btnMode.Click += btnMode_Click;
            // 
            // btnHide
            // 
            btnHide.Cursor = Cursors.Hand;
            btnHide.Dock = DockStyle.Right;
            btnHide.FlatAppearance.BorderSize = 0;
            btnHide.FlatAppearance.MouseDownBackColor = Color.FromArgb(241, 112, 122);
            btnHide.FlatAppearance.MouseOverBackColor = Color.FromArgb(232, 17, 35);
            btnHide.FlatStyle = FlatStyle.Flat;
            btnHide.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnHide.ForeColor = Color.FromArgb(64, 64, 64);
            btnHide.Location = new Point(636, 0);
            btnHide.Margin = new Padding(4);
            btnHide.Name = "btnHide";
            btnHide.Size = new Size(46, 50);
            btnHide.TabIndex = 3;
            btnHide.Text = "─";
            toolTip1.SetToolTip(btnHide, "Ẩn ");
            btnHide.UseVisualStyleBackColor = true;
            btnHide.Click += btnHide_Click;
            // 
            // panelDropdownHistory
            // 
            panelDropdownHistory.BackColor = SystemColors.Control;
            panelDropdownHistory.Controls.Add(flowHistory);
            panelDropdownHistory.Controls.Add(lblToday);
            panelDropdownHistory.Location = new Point(29, 38);
            panelDropdownHistory.Margin = new Padding(4);
            panelDropdownHistory.Name = "panelDropdownHistory";
            panelDropdownHistory.Size = new Size(400, 375);
            panelDropdownHistory.TabIndex = 2;
            panelDropdownHistory.Visible = false;
            // 
            // flowHistory
            // 
            flowHistory.AutoScroll = true;
            flowHistory.BackColor = SystemColors.Control;
            flowHistory.Controls.Add(panelSessionItem);
            flowHistory.Dock = DockStyle.Fill;
            flowHistory.FlowDirection = FlowDirection.TopDown;
            flowHistory.Location = new Point(0, 20);
            flowHistory.Margin = new Padding(4);
            flowHistory.Name = "flowHistory";
            flowHistory.Size = new Size(400, 355);
            flowHistory.TabIndex = 1;
            flowHistory.WrapContents = false;
            // 
            // panelSessionItem
            // 
            panelSessionItem.BackColor = Color.White;
            panelSessionItem.Controls.Add(lblSessionTitle);
            panelSessionItem.Controls.Add(lblSelected);
            panelSessionItem.Controls.Add(btnDeleteSession);
            panelSessionItem.Cursor = Cursors.Hand;
            panelSessionItem.Location = new Point(2, 5);
            panelSessionItem.Margin = new Padding(2, 5, 10, 0);
            panelSessionItem.Name = "panelSessionItem";
            panelSessionItem.Size = new Size(359, 58);
            panelSessionItem.TabIndex = 0;
            panelSessionItem.Visible = false;
            // 
            // lblSessionTitle
            // 
            lblSessionTitle.AutoEllipsis = true;
            lblSessionTitle.Dock = DockStyle.Fill;
            lblSessionTitle.Font = new Font("Segoe UI", 9.5F);
            lblSessionTitle.Location = new Point(32, 0);
            lblSessionTitle.Margin = new Padding(4, 0, 4, 0);
            lblSessionTitle.Name = "lblSessionTitle";
            lblSessionTitle.Padding = new Padding(15, 0, 0, 0);
            lblSessionTitle.Size = new Size(287, 58);
            lblSessionTitle.TabIndex = 0;
            lblSessionTitle.Text = "Session title";
            lblSessionTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSelected
            // 
            lblSelected.Dock = DockStyle.Left;
            lblSelected.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSelected.ForeColor = Color.Green;
            lblSelected.Location = new Point(0, 0);
            lblSelected.Margin = new Padding(4, 0, 4, 0);
            lblSelected.Name = "lblSelected";
            lblSelected.Size = new Size(32, 58);
            lblSelected.TabIndex = 1;
            lblSelected.Text = "✓";
            lblSelected.TextAlign = ContentAlignment.MiddleCenter;
            lblSelected.Visible = false;
            // 
            // btnDeleteSession
            // 
            btnDeleteSession.Dock = DockStyle.Right;
            btnDeleteSession.FlatAppearance.BorderSize = 0;
            btnDeleteSession.FlatStyle = FlatStyle.Flat;
            btnDeleteSession.Font = new Font("Segoe UI Symbol", 9F);
            btnDeleteSession.Location = new Point(319, 0);
            btnDeleteSession.Margin = new Padding(4);
            btnDeleteSession.Name = "btnDeleteSession";
            btnDeleteSession.Size = new Size(40, 58);
            btnDeleteSession.TabIndex = 2;
            btnDeleteSession.Text = "🗑";
            toolTip1.SetToolTip(btnDeleteSession, "Xóa lịch sử này");
            btnDeleteSession.UseVisualStyleBackColor = true;
            // 
            // lblToday
            // 
            lblToday.AutoSize = true;
            lblToday.BackColor = SystemColors.ControlLightLight;
            lblToday.Dock = DockStyle.Top;
            lblToday.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblToday.Location = new Point(0, 0);
            lblToday.Margin = new Padding(4, 0, 4, 0);
            lblToday.Name = "lblToday";
            lblToday.Size = new Size(72, 20);
            lblToday.TabIndex = 0;
            lblToday.Text = "Hôm nay";
            lblToday.Visible = false;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblGreeting);
            panelHeader.Controls.Add(lblAvatar);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 50);
            panelHeader.Margin = new Padding(4);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(25, 12, 25, 0);
            panelHeader.Size = new Size(688, 138);
            panelHeader.TabIndex = 1;
            panelHeader.MouseDown += ChatbotAI_MouseDown;
            // 
            // lblGreeting
            // 
            lblGreeting.AutoSize = true;
            lblGreeting.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblGreeting.ForeColor = Color.FromArgb(55, 53, 47);
            lblGreeting.Location = new Point(25, 88);
            lblGreeting.Margin = new Padding(4, 0, 4, 0);
            lblGreeting.MaximumSize = new Size(625, 0);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(599, 41);
            lblGreeting.TabIndex = 1;
            lblGreeting.Text = "Xin hỏi hoàng thượng muốn thần làm gì?";
            // 
            // lblAvatar
            // 
            lblAvatar.AutoSize = true;
            lblAvatar.Font = new Font("Segoe UI Emoji", 26F);
            lblAvatar.Location = new Point(29, 12);
            lblAvatar.Margin = new Padding(4, 0, 4, 0);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(85, 58);
            lblAvatar.TabIndex = 0;
            lblAvatar.Text = "🤖";
            // 
            // panelBody
            // 
            panelBody.BackColor = Color.White;
            panelBody.Controls.Add(flowMessages);
            panelBody.Controls.Add(flowActions);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 188);
            panelBody.Margin = new Padding(4);
            panelBody.Name = "panelBody";
            panelBody.Size = new Size(688, 324);
            panelBody.TabIndex = 2;
            panelBody.MouseDown += ChatbotAI_MouseDown;
            // 
            // flowMessages
            // 
            flowMessages.AutoScroll = true;
            flowMessages.BackColor = Color.White;
            flowMessages.Dock = DockStyle.Fill;
            flowMessages.FlowDirection = FlowDirection.TopDown;
            flowMessages.Location = new Point(0, 0);
            flowMessages.Margin = new Padding(0);
            flowMessages.Name = "flowMessages";
            flowMessages.Padding = new Padding(25, 12, 25, 25);
            flowMessages.Size = new Size(688, 324);
            flowMessages.TabIndex = 1;
            flowMessages.Visible = false;
            flowMessages.WrapContents = false;
            flowMessages.MouseDown += ChatbotAI_MouseDown;
            // 
            // flowActions
            // 
            flowActions.Controls.Add(btnAction1);
            flowActions.Controls.Add(btnAction2);
            flowActions.Controls.Add(btnAction3);
            flowActions.Dock = DockStyle.Fill;
            flowActions.FlowDirection = FlowDirection.TopDown;
            flowActions.Location = new Point(0, 0);
            flowActions.Margin = new Padding(0);
            flowActions.Name = "flowActions";
            flowActions.Size = new Size(688, 324);
            flowActions.TabIndex = 0;
            // 
            // btnAction1
            // 
            btnAction1.Cursor = Cursors.Hand;
            btnAction1.FlatAppearance.BorderSize = 0;
            btnAction1.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 245, 245);
            btnAction1.FlatStyle = FlatStyle.Flat;
            btnAction1.Font = new Font("Segoe UI", 11F);
            btnAction1.Location = new Point(0, 0);
            btnAction1.Margin = new Padding(0, 0, 0, 10);
            btnAction1.Name = "btnAction1";
            btnAction1.Size = new Size(638, 56);
            btnAction1.TabIndex = 0;
            btnAction1.Text = "  🔍   Dịch trang này.";
            btnAction1.TextAlign = ContentAlignment.MiddleLeft;
            btnAction1.UseVisualStyleBackColor = true;
            btnAction1.Click += btnAction1_Click;
            btnAction1.MouseDown += ChatbotAI_MouseDown;
            // 
            // btnAction2
            // 
            btnAction2.Cursor = Cursors.Hand;
            btnAction2.FlatAppearance.BorderSize = 0;
            btnAction2.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 245, 245);
            btnAction2.FlatStyle = FlatStyle.Flat;
            btnAction2.Font = new Font("Segoe UI", 11F);
            btnAction2.Location = new Point(0, 66);
            btnAction2.Margin = new Padding(0, 0, 0, 10);
            btnAction2.Name = "btnAction2";
            btnAction2.Size = new Size(638, 56);
            btnAction2.TabIndex = 1;
            btnAction2.Text = "  📝   Tóm tắt trang này.";
            btnAction2.TextAlign = ContentAlignment.MiddleLeft;
            btnAction2.UseVisualStyleBackColor = true;
            btnAction2.Click += btnAction2_Click;
            btnAction2.MouseDown += ChatbotAI_MouseDown;
            // 
            // btnAction3
            // 
            btnAction3.Cursor = Cursors.Hand;
            btnAction3.FlatAppearance.BorderSize = 0;
            btnAction3.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 245, 245);
            btnAction3.FlatStyle = FlatStyle.Flat;
            btnAction3.Font = new Font("Segoe UI", 11F);
            btnAction3.Location = new Point(0, 132);
            btnAction3.Margin = new Padding(0, 0, 0, 10);
            btnAction3.Name = "btnAction3";
            btnAction3.Size = new Size(638, 56);
            btnAction3.TabIndex = 2;
            btnAction3.Text = "  ✅   Tạo bảng theo dõi nhiệm vụ.";
            btnAction3.TextAlign = ContentAlignment.MiddleLeft;
            btnAction3.UseVisualStyleBackColor = true;
            btnAction3.Click += btnAction3_Click;
            btnAction3.MouseDown += ChatbotAI_MouseDown;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.White;
            panelFooter.Controls.Add(panelInputContainer);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 512);
            panelFooter.Margin = new Padding(4);
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(25);
            panelFooter.Size = new Size(688, 238);
            panelFooter.TabIndex = 3;
            // 
            // panelInputContainer
            // 
            panelInputContainer.BackColor = Color.White;
            panelInputContainer.Controls.Add(txtInput);
            panelInputContainer.Controls.Add(flowFileAttachments);
            panelInputContainer.Controls.Add(panelInputTools);
            panelInputContainer.Location = new Point(12, 8);
            panelInputContainer.Margin = new Padding(4);
            panelInputContainer.Name = "panelInputContainer";
            panelInputContainer.Padding = new Padding(15);
            panelInputContainer.Size = new Size(669, 215);
            panelInputContainer.TabIndex = 0;
            panelInputContainer.MouseDown += ChatbotAI_MouseDown;
            // 
            // txtInput
            // 
            txtInput.BorderStyle = BorderStyle.None;
            txtInput.Dock = DockStyle.Fill;
            txtInput.Font = new Font("Segoe UI", 11F);
            txtInput.Location = new Point(15, 21);
            txtInput.Margin = new Padding(4);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.PlaceholderText = "Hỏi AI...";
            txtInput.Size = new Size(639, 135);
            txtInput.TabIndex = 1;
            txtInput.MouseDown += ChatbotAI_MouseDown;
            // 
            // flowFileAttachments
            // 
            flowFileAttachments.AutoSize = true;
            flowFileAttachments.BackColor = Color.Transparent;
            flowFileAttachments.Dock = DockStyle.Top;
            flowFileAttachments.Location = new Point(15, 15);
            flowFileAttachments.Margin = new Padding(4);
            flowFileAttachments.Name = "flowFileAttachments";
            flowFileAttachments.Padding = new Padding(6, 6, 6, 0);
            flowFileAttachments.Size = new Size(639, 6);
            flowFileAttachments.TabIndex = 0;
            // 
            // panelInputTools
            // 
            panelInputTools.Controls.Add(btnSend);
            panelInputTools.Controls.Add(btnSource);
            panelInputTools.Controls.Add(btnAuto);
            panelInputTools.Controls.Add(btnAttachment);
            panelInputTools.Dock = DockStyle.Bottom;
            panelInputTools.Location = new Point(15, 156);
            panelInputTools.Margin = new Padding(4);
            panelInputTools.Name = "panelInputTools";
            panelInputTools.Size = new Size(639, 44);
            panelInputTools.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(240, 240, 240);
            btnSend.Cursor = Cursors.Hand;
            btnSend.Dock = DockStyle.Right;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Location = new Point(595, 0);
            btnSend.Margin = new Padding(4);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(44, 44);
            btnSend.TabIndex = 2;
            btnSend.Text = "⬆";
            toolTip1.SetToolTip(btnSend, "Gửi tin nhắn");
            btnSend.UseVisualStyleBackColor = false;
            btnSend.Click += btnSend_Click;
            btnSend.MouseHover += btnSend_Click;
            // 
            // btnSource
            // 
            btnSource.AutoSize = true;
            btnSource.Dock = DockStyle.Left;
            btnSource.FlatAppearance.BorderSize = 0;
            btnSource.FlatStyle = FlatStyle.Flat;
            btnSource.Location = new Point(138, 0);
            btnSource.Margin = new Padding(4);
            btnSource.Name = "btnSource";
            btnSource.Size = new Size(111, 44);
            btnSource.TabIndex = 3;
            btnSource.Text = "🌐 Nguồn";
            // 
            // btnAuto
            // 
            btnAuto.AutoSize = true;
            btnAuto.Dock = DockStyle.Left;
            btnAuto.FlatAppearance.BorderSize = 0;
            btnAuto.FlatStyle = FlatStyle.Flat;
            btnAuto.Location = new Point(44, 0);
            btnAuto.Margin = new Padding(4);
            btnAuto.Name = "btnAuto";
            btnAuto.Size = new Size(94, 44);
            btnAuto.TabIndex = 4;
            btnAuto.Text = "Tự động";
            // 
            // btnAttachment
            // 
            btnAttachment.Dock = DockStyle.Left;
            btnAttachment.FlatAppearance.BorderSize = 0;
            btnAttachment.FlatStyle = FlatStyle.Flat;
            btnAttachment.Location = new Point(0, 0);
            btnAttachment.Margin = new Padding(4);
            btnAttachment.Name = "btnAttachment";
            btnAttachment.Size = new Size(44, 44);
            btnAttachment.TabIndex = 5;
            btnAttachment.Text = "📎";
            toolTip1.SetToolTip(btnAttachment, "Đính kèm file");
            btnAttachment.Click += btnAttachment_Click;
            // 
            // ChatbotAI
            // 
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(688, 750);
            Controls.Add(panelDropdownHistory);
            Controls.Add(panelBody);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            Controls.Add(panelTitleBar);
            FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Name = "ChatbotAI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChatbotAI";
            MouseDown += ChatbotAI_MouseDown;
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            panelDropdownHistory.ResumeLayout(false);
            panelDropdownHistory.PerformLayout();
            flowHistory.ResumeLayout(false);
            panelSessionItem.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            panelBody.ResumeLayout(false);
            flowActions.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            panelInputContainer.ResumeLayout(false);
            panelInputContainer.PerformLayout();
            panelInputTools.ResumeLayout(false);
            panelInputTools.PerformLayout();
            ResumeLayout(false);
        }



        #endregion

        private System.Windows.Forms.Panel panelTitleBar;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Button btnMode;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnTitleLeft;
        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblGreeting;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.Panel panelBody;
        private System.Windows.Forms.FlowLayoutPanel flowActions;
        private System.Windows.Forms.Button btnAction1;
        private System.Windows.Forms.Button btnAction2;
        private System.Windows.Forms.Button btnAction3;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelInputContainer;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Panel panelInputTools;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnAttachment;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.Button btnSource;
        private System.Windows.Forms.FlowLayoutPanel flowFileAttachments;

        private FlowLayoutPanel flowMessages;
        private Panel panelDropdownHistory;
        private FlowLayoutPanel flowHistory;
        private Label lblToday;
        private Panel panelSessionItem;
        private Label lblSessionTitle;
        private Button btnDeleteSession;
        private Label lblSelected;


    }

}