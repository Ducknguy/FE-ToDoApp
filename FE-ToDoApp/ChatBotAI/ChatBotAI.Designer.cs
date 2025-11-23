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
            panelHeader = new Panel();
            lblGreeting = new Label();
            lblAvatar = new Label();
            panelBody = new Panel();
            flowActions = new FlowLayoutPanel();
            btnAction1 = new Panel();
            lblText1 = new Label();
            lblIcon1 = new Label();
            btnAction2 = new Panel();
            lblText2 = new Label();
            lblIcon2 = new Label();
            btnAction3 = new Panel();
            lblText3 = new Label();
            lblIcon3 = new Label();
            btnAction4 = new Panel();
            lblTagNew = new Label();
            lblText4 = new Label();
            lblIcon4 = new Label();
            panelFooter = new Panel();
            panelInputContainer = new Panel();
            txtInput = new TextBox();
            panelInputTools = new Panel();
            btnSend = new Button();
            lblToolSource = new Label();
            lblToolAuto = new Label();
            lblContextTag = new Label();
            toolTip1 = new ToolTip(components);
            panelTitleBar.SuspendLayout();
            panelHeader.SuspendLayout();
            panelBody.SuspendLayout();
            flowActions.SuspendLayout();
            btnAction1.SuspendLayout();
            btnAction2.SuspendLayout();
            btnAction3.SuspendLayout();
            btnAction4.SuspendLayout();
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
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Padding = new Padding(10, 0, 5, 0);
            panelTitleBar.Size = new Size(550, 40);
            panelTitleBar.TabIndex = 0;
            // 
            // btnTitleLeft
            // 
            btnTitleLeft.AutoSize = true;
            btnTitleLeft.Cursor = Cursors.Hand;
            btnTitleLeft.Dock = DockStyle.Left;
            btnTitleLeft.FlatAppearance.BorderSize = 0;
            btnTitleLeft.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnTitleLeft.FlatStyle = FlatStyle.Flat;
            btnTitleLeft.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnTitleLeft.ForeColor = Color.FromArgb(55, 53, 47);
            btnTitleLeft.Location = new Point(10, 0);
            btnTitleLeft.Name = "btnTitleLeft";
            btnTitleLeft.Size = new Size(200, 40);
            btnTitleLeft.TabIndex = 0;
            btnTitleLeft.Text = "Cuộc trò chuyện mới với AI ⌄";
            btnTitleLeft.TextAlign = ContentAlignment.MiddleLeft;
            btnTitleLeft.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.Dock = DockStyle.Right;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI Symbol", 10F);
            btnEdit.ForeColor = Color.FromArgb(64, 64, 64);
            btnEdit.Location = new Point(455, 0);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(30, 40);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "📝";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnMode
            // 
            btnMode.Cursor = Cursors.Hand;
            btnMode.Dock = DockStyle.Right;
            btnMode.FlatAppearance.BorderSize = 0;
            btnMode.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnMode.FlatStyle = FlatStyle.Flat;
            btnMode.Font = new Font("Segoe UI Symbol", 10F);
            btnMode.ForeColor = Color.FromArgb(64, 64, 64);
            btnMode.Location = new Point(485, 0);
            btnMode.Name = "btnMode";
            btnMode.Size = new Size(30, 40);
            btnMode.TabIndex = 2;
            btnMode.Text = "🗖";
            btnMode.UseVisualStyleBackColor = true;
            // 
            // btnHide
            // 
            btnHide.Cursor = Cursors.Hand;
            btnHide.Dock = DockStyle.Right;
            btnHide.FlatAppearance.BorderSize = 0;
            btnHide.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnHide.FlatStyle = FlatStyle.Flat;
            btnHide.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnHide.ForeColor = Color.FromArgb(64, 64, 64);
            btnHide.Location = new Point(515, 0);
            btnHide.Name = "btnHide";
            btnHide.Size = new Size(30, 40);
            btnHide.TabIndex = 3;
            btnHide.Text = "─";
            btnHide.UseVisualStyleBackColor = true;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.White;
            panelHeader.Controls.Add(lblGreeting);
            panelHeader.Controls.Add(lblAvatar);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 40);
            panelHeader.Name = "panelHeader";
            panelHeader.Padding = new Padding(20, 10, 20, 0);
            panelHeader.Size = new Size(550, 110);
            panelHeader.TabIndex = 1;
            // 
            // lblGreeting
            // 
            lblGreeting.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblGreeting.ForeColor = Color.FromArgb(55, 53, 47);
            lblGreeting.Location = new Point(20, 70);
            lblGreeting.Name = "lblGreeting";
            lblGreeting.Size = new Size(500, 40);
            lblGreeting.TabIndex = 1;
            lblGreeting.Text = "Xin hỏi hoàng thượng muốn thần làm gì?";
            // 
            // lblAvatar
            // 
            lblAvatar.Font = new Font("Segoe UI Emoji", 26F);
            lblAvatar.Location = new Point(20, 10);
            lblAvatar.Name = "lblAvatar";
            lblAvatar.Size = new Size(60, 60);
            lblAvatar.TabIndex = 0;
            lblAvatar.Text = "🤖";
            // 
            // panelBody
            // 
            panelBody.BackColor = Color.White;
            panelBody.Controls.Add(flowActions);
            panelBody.Dock = DockStyle.Fill;
            panelBody.Location = new Point(0, 150);
            panelBody.Name = "panelBody";
            panelBody.Padding = new Padding(20);
            panelBody.Size = new Size(550, 310);
            panelBody.TabIndex = 2;
            // 
            // flowActions
            // 
            flowActions.Controls.Add(btnAction1);
            flowActions.Controls.Add(btnAction2);
            flowActions.Controls.Add(btnAction3);
            flowActions.Controls.Add(btnAction4);
            flowActions.Dock = DockStyle.Fill;
            flowActions.FlowDirection = FlowDirection.TopDown;
            flowActions.Location = new Point(20, 20);
            flowActions.Name = "flowActions";
            flowActions.Size = new Size(510, 270);
            flowActions.TabIndex = 0;
            // 
            // btnAction1
            // 
            btnAction1.Controls.Add(lblText1);
            btnAction1.Controls.Add(lblIcon1);
            btnAction1.Cursor = Cursors.Hand;
            btnAction1.Location = new Point(0, 0);
            btnAction1.Margin = new Padding(0, 0, 0, 8);
            btnAction1.Name = "btnAction1";
            btnAction1.Size = new Size(510, 45);
            btnAction1.TabIndex = 0;
            // 
            // lblText1
            // 
            lblText1.Dock = DockStyle.Fill;
            lblText1.Font = new Font("Segoe UI", 11F);
            lblText1.Location = new Point(45, 0);
            lblText1.Name = "lblText1";
            lblText1.Size = new Size(465, 45);
            lblText1.TabIndex = 1;
            lblText1.Text = "Tìm kiếm bất cứ điều gì";
            lblText1.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIcon1
            // 
            lblIcon1.Dock = DockStyle.Left;
            lblIcon1.Font = new Font("Segoe UI Emoji", 14F);
            lblIcon1.Location = new Point(0, 0);
            lblIcon1.Name = "lblIcon1";
            lblIcon1.Size = new Size(45, 45);
            lblIcon1.TabIndex = 0;
            lblIcon1.Text = "🔍";
            lblIcon1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAction2
            // 
            btnAction2.Controls.Add(lblText2);
            btnAction2.Controls.Add(lblIcon2);
            btnAction2.Cursor = Cursors.Hand;
            btnAction2.Location = new Point(0, 53);
            btnAction2.Margin = new Padding(0, 0, 0, 8);
            btnAction2.Name = "btnAction2";
            btnAction2.Size = new Size(510, 45);
            btnAction2.TabIndex = 1;
            // 
            // lblText2
            // 
            lblText2.Dock = DockStyle.Fill;
            lblText2.Font = new Font("Segoe UI", 11F);
            lblText2.Location = new Point(45, 0);
            lblText2.Name = "lblText2";
            lblText2.Size = new Size(465, 45);
            lblText2.TabIndex = 1;
            lblText2.Text = "Soạn chương trình họp";
            lblText2.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIcon2
            // 
            lblIcon2.Dock = DockStyle.Left;
            lblIcon2.Font = new Font("Segoe UI Emoji", 14F);
            lblIcon2.Location = new Point(0, 0);
            lblIcon2.Name = "lblIcon2";
            lblIcon2.Size = new Size(45, 45);
            lblIcon2.TabIndex = 0;
            lblIcon2.Text = "📝";
            lblIcon2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAction3
            // 
            btnAction3.Controls.Add(lblText3);
            btnAction3.Controls.Add(lblIcon3);
            btnAction3.Cursor = Cursors.Hand;
            btnAction3.Location = new Point(0, 106);
            btnAction3.Margin = new Padding(0, 0, 0, 8);
            btnAction3.Name = "btnAction3";
            btnAction3.Size = new Size(510, 45);
            btnAction3.TabIndex = 2;
            // 
            // lblText3
            // 
            lblText3.Dock = DockStyle.Fill;
            lblText3.Font = new Font("Segoe UI", 11F);
            lblText3.Location = new Point(45, 0);
            lblText3.Name = "lblText3";
            lblText3.Size = new Size(465, 45);
            lblText3.TabIndex = 1;
            lblText3.Text = "Phân tích PDF hoặc hình ảnh";
            lblText3.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIcon3
            // 
            lblIcon3.Dock = DockStyle.Left;
            lblIcon3.Font = new Font("Segoe UI Emoji", 14F);
            lblIcon3.Location = new Point(0, 0);
            lblIcon3.Name = "lblIcon3";
            lblIcon3.Size = new Size(45, 45);
            lblIcon3.TabIndex = 0;
            lblIcon3.Text = "📄";
            lblIcon3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAction4
            // 
            btnAction4.Controls.Add(lblTagNew);
            btnAction4.Controls.Add(lblText4);
            btnAction4.Controls.Add(lblIcon4);
            btnAction4.Cursor = Cursors.Hand;
            btnAction4.Location = new Point(0, 159);
            btnAction4.Margin = new Padding(0, 0, 0, 8);
            btnAction4.Name = "btnAction4";
            btnAction4.Size = new Size(510, 45);
            btnAction4.TabIndex = 3;
            // 
            // lblTagNew
            // 
            lblTagNew.AutoSize = true;
            lblTagNew.BackColor = Color.FromArgb(237, 246, 255);
            lblTagNew.Font = new Font("Segoe UI", 8F, FontStyle.Bold);
            lblTagNew.ForeColor = Color.FromArgb(35, 131, 226);
            lblTagNew.Location = new Point(270, 15);
            lblTagNew.Name = "lblTagNew";
            lblTagNew.Padding = new Padding(4, 2, 4, 2);
            lblTagNew.Size = new Size(36, 17);
            lblTagNew.TabIndex = 2;
            lblTagNew.Text = "Mới";
            // 
            // lblText4
            // 
            lblText4.Dock = DockStyle.Fill;
            lblText4.Font = new Font("Segoe UI", 11F);
            lblText4.Location = new Point(45, 0);
            lblText4.Name = "lblText4";
            lblText4.Size = new Size(465, 45);
            lblText4.TabIndex = 1;
            lblText4.Text = "Tạo trình theo dõi nhiệm vụ";
            lblText4.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIcon4
            // 
            lblIcon4.Dock = DockStyle.Left;
            lblIcon4.Font = new Font("Segoe UI Emoji", 14F);
            lblIcon4.Location = new Point(0, 0);
            lblIcon4.Name = "lblIcon4";
            lblIcon4.Size = new Size(45, 45);
            lblIcon4.TabIndex = 0;
            lblIcon4.Text = "✅";
            lblIcon4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelFooter
            // 
            panelFooter.BackColor = Color.White;
            panelFooter.Controls.Add(panelInputContainer);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.Location = new Point(0, 460);
            panelFooter.Name = "panelFooter";
            panelFooter.Padding = new Padding(20);
            panelFooter.Size = new Size(550, 140);
            panelFooter.TabIndex = 3;
            // 
            // panelInputContainer
            // 
            panelInputContainer.BackColor = Color.White;
            panelInputContainer.Controls.Add(txtInput);
            panelInputContainer.Controls.Add(panelInputTools);
            panelInputContainer.Controls.Add(lblContextTag);
            panelInputContainer.Dock = DockStyle.Fill;
            panelInputContainer.Location = new Point(20, 20);
            panelInputContainer.Name = "panelInputContainer";
            panelInputContainer.Padding = new Padding(12);
            panelInputContainer.Size = new Size(510, 100);
            panelInputContainer.TabIndex = 0;
            // 
            // txtInput
            // 
            txtInput.BorderStyle = BorderStyle.None;
            txtInput.Dock = DockStyle.Fill;
            txtInput.Font = new Font("Segoe UI", 11F);
            txtInput.Location = new Point(12, 29);
            txtInput.Multiline = true;
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(486, 24);
            txtInput.TabIndex = 1;
            txtInput.Text = "Hỏi AI...";
            // 
            // panelInputTools
            // 
            panelInputTools.Controls.Add(btnSend);
            panelInputTools.Controls.Add(lblToolSource);
            panelInputTools.Controls.Add(lblToolAuto);
            panelInputTools.Dock = DockStyle.Bottom;
            panelInputTools.Location = new Point(12, 53);
            panelInputTools.Name = "panelInputTools";
            panelInputTools.Size = new Size(486, 35);
            panelInputTools.TabIndex = 2;
            // 
            // btnSend
            // 
            btnSend.BackColor = Color.FromArgb(240, 240, 240);
            btnSend.Cursor = Cursors.Hand;
            btnSend.Dock = DockStyle.Right;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.Location = new Point(451, 0);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(35, 35);
            btnSend.TabIndex = 2;
            btnSend.Text = "⬆";
            btnSend.UseVisualStyleBackColor = false;
            // 
            // lblToolSource
            // 
            lblToolSource.AutoSize = true;
            lblToolSource.Dock = DockStyle.Left;
            lblToolSource.ForeColor = Color.Gray;
            lblToolSource.Location = new Point(82, 0);
            lblToolSource.Name = "lblToolSource";
            lblToolSource.Padding = new Padding(0, 8, 15, 0);
            lblToolSource.Size = new Size(74, 23);
            lblToolSource.TabIndex = 1;
            lblToolSource.Text = "🌐 Nguồn";
            // 
            // lblToolAuto
            // 
            lblToolAuto.AutoSize = true;
            lblToolAuto.Dock = DockStyle.Left;
            lblToolAuto.ForeColor = Color.Gray;
            lblToolAuto.Location = new Point(0, 0);
            lblToolAuto.Name = "lblToolAuto";
            lblToolAuto.Padding = new Padding(0, 8, 15, 0);
            lblToolAuto.Size = new Size(82, 23);
            lblToolAuto.TabIndex = 0;
            lblToolAuto.Text = "📎 Tự động";
            // 
            // lblContextTag
            // 
            lblContextTag.Dock = DockStyle.Top;
            lblContextTag.ForeColor = Color.Gray;
            lblContextTag.Location = new Point(12, 12);
            lblContextTag.Name = "lblContextTag";
            lblContextTag.Padding = new Padding(0, 0, 0, 5);
            lblContextTag.Size = new Size(486, 17);
            lblContextTag.TabIndex = 0;
            lblContextTag.Text = "📄 Trang mới";
            // 
            // ChatbotAI
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(550, 600);
            Controls.Add(panelBody);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            Controls.Add(panelTitleBar);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ChatbotAI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ChatbotAI";
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelBody.ResumeLayout(false);
            flowActions.ResumeLayout(false);
            btnAction1.ResumeLayout(false);
            btnAction2.ResumeLayout(false);
            btnAction3.ResumeLayout(false);
            btnAction4.ResumeLayout(false);
            btnAction4.PerformLayout();
            panelFooter.ResumeLayout(false);
            panelInputContainer.ResumeLayout(false);
            panelInputContainer.PerformLayout();
            panelInputTools.ResumeLayout(false);
            panelInputTools.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // Khai báo biến đầy đủ
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
        private System.Windows.Forms.Panel btnAction1;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.Label lblIcon1;
        private System.Windows.Forms.Panel btnAction2;
        private System.Windows.Forms.Label lblText2;
        private System.Windows.Forms.Label lblIcon2;
        private System.Windows.Forms.Panel btnAction3;
        private System.Windows.Forms.Label lblText3;
        private System.Windows.Forms.Label lblIcon3;
        private System.Windows.Forms.Panel btnAction4;
        private System.Windows.Forms.Label lblTagNew;
        private System.Windows.Forms.Label lblText4;
        private System.Windows.Forms.Label lblIcon4;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Panel panelInputContainer;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Panel panelInputTools;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblToolSource;
        private System.Windows.Forms.Label lblToolAuto;
        private System.Windows.Forms.Label lblContextTag;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}