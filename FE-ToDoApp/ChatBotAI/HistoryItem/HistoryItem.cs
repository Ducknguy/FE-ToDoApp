using System;
using System.Drawing;
using System.Windows.Forms;
using ChatbotAI_Form;

namespace FE_ToDoApp.ChatBotAI.HistoryItem
{
    public static class HistoryItem
    {
        /// <summary>
        /// Tạo một dòng lịch sử bằng cách COPY giao diện từ mẫu (Template) trong Designer
        /// </summary>
        public static Panel CreateFromTemplate(
            ChatSession session,
            Panel templatePanel, // Mẫu thiết kế trong Designer (panelSessionItem)
            bool isSelected,
            Action<ChatSession, Panel, Label> onSelect,
            Action<ChatSession, Panel> onDelete)
        {
            // 1. Tạo Panel chứa (Clone từ templatePanel)
            Panel pnl = new Panel();
            CopyProperties(templatePanel, pnl);
            pnl.Visible = true; // Hiện lên (vì mẫu đang ẩn)
            pnl.Tag = session;  // Lưu dữ liệu vào Tag

            // Lấy các control mẫu bên trong template để copy
            // Lưu ý: Tên control phải khớp với tên bạn đặt trong Designer (lblSessionTitle, btnDeleteSession, lblSelected)
            // Hoặc ta tìm theo kiểu (Type) nếu lười tìm tên. Ở đây mình tìm theo tên cho chắc.

            Label tmplTitle = templatePanel.Controls["lblSessionTitle"] as Label;
            Button tmplDel = templatePanel.Controls["btnDeleteSession"] as Button;
            Label tmplCheck = templatePanel.Controls["lblSelected"] as Label;

            // 2. Tạo nút Xóa (Clone từ btnDeleteSession)
            Button btnDel = new Button();
            if (tmplDel != null)
            {
                CopyButtonProps(tmplDel, btnDel);
                btnDel.Click += (s, e) => onDelete(session, pnl);
            }

            // 3. Tạo dấu Tích V (Clone từ lblSelected)
            Label lblCheck = new Label();
            if (tmplCheck != null)
            {
                CopyLabelProps(tmplCheck, lblCheck);
                lblCheck.Visible = isSelected; // Chỉ hiện nếu đang chọn
                lblCheck.Tag = "check"; // Đánh dấu để tìm lại
            }

            // 4. Tạo Tiêu đề (Clone từ lblSessionTitle)
            Label lblTitle = new Label();
            if (tmplTitle != null)
            {
                CopyLabelProps(tmplTitle, lblTitle);
                lblTitle.Text = session.Title; // Gán tên session
            }

            // 5. Xử lý sự kiện Click chọn dòng
            EventHandler clickHandler = (s, e) => onSelect(session, pnl, lblCheck);
            pnl.Click += clickHandler;
            lblTitle.Click += clickHandler; // Bấm vào chữ cũng ăn

            // 6. Hiệu ứng Hover (Copy màu nền hover nếu muốn, hoặc dùng logic riêng)
            Color defaultColor = isSelected ? Color.White : Color.Transparent; // Hoặc lấy từ templatePanel.BackColor
            // Ở đây mình giữ logic sidebar: Chọn thì trắng, không chọn thì trong suốt
            pnl.BackColor = defaultColor;

            pnl.MouseEnter += (s, e) => { if (!lblCheck.Visible) pnl.BackColor = Color.FromArgb(235, 235, 235); };
            pnl.MouseLeave += (s, e) => { if (!lblCheck.Visible) pnl.BackColor = Color.Transparent; };

            // 7. Thêm vào Panel theo đúng thứ tự để Dock hoạt động đúng
            // Trong Designer: cái nào Dock Right thêm trước, Fill thêm sau cùng.
            // Thứ tự controls trong Designer code thường là ngược lại với thứ tự Add.
            // Ta cứ Add theo thứ tự: Nút xóa (Right) -> Tích (Right) -> Tiêu đề (Fill)

            pnl.Controls.Add(btnDel);
            pnl.Controls.Add(lblCheck);
            pnl.Controls.Add(lblTitle);

            // Đẩy Title lên trên cùng (Z-Index) để nó fill phần còn lại (nếu cần)
            lblTitle.BringToFront();

            // Vẽ bo góc (nếu cần)
            pnl.Paint += (s, e) => UIHelper.BoGoc(pnl, 10);

            return pnl;
        }

        // --- Các hàm hỗ trợ Copy thuộc tính ---

        private static void CopyProperties(Control source, Control dest)
        {
            dest.Size = source.Size; // Nếu Dock thì Size này chỉ mang tính tham khảo
            dest.Dock = source.Dock; // Quan trọng
            dest.Margin = source.Margin;
            dest.Padding = source.Padding;
            dest.BackColor = source.BackColor;
            dest.ForeColor = source.ForeColor;
            dest.Font = source.Font;
            dest.Cursor = source.Cursor;
        }

        private static void CopyLabelProps(Label source, Label dest)
        {
            CopyProperties(source, dest);
            dest.TextAlign = source.TextAlign;
            dest.AutoEllipsis = source.AutoEllipsis;
            dest.AutoSize = source.AutoSize;
            dest.Text = source.Text; // Copy text mẫu (sau đó sẽ bị ghi đè)
        }

        private static void CopyButtonProps(Button source, Button dest)
        {
            CopyProperties(source, dest);
            dest.FlatStyle = source.FlatStyle;
            dest.FlatAppearance.BorderSize = source.FlatAppearance.BorderSize;
            dest.FlatAppearance.MouseOverBackColor = source.FlatAppearance.MouseOverBackColor;
            dest.FlatAppearance.MouseDownBackColor = source.FlatAppearance.MouseDownBackColor;
            dest.Text = source.Text;
            dest.Image = source.Image;
            dest.ImageAlign = source.ImageAlign;
        }
    }
}