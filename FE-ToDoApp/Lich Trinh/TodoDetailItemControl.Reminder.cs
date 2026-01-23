using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using FE_ToDoApp.Services;
using System.Data.SQLite;
using FE_ToDoApp.Database;

namespace FE_ToDoApp.Lich_Trinh
{
    public partial class TodoDetailItemControl
    {
        private void AddItem()
        {
            if (TodoId <= 0) return;

            string text = Interaction.InputBox("Nhập nội dung công việc:", "Thêm công việc");
            if (string.IsNullOrWhiteSpace(text)) return;

            var result = MessageBox.Show(
                "Bạn có muốn đặt thời gian nhắc nhở cho công việc này không?",
                "Nhắc nhở",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            DateTime? reminderTime = null;

            if (result == DialogResult.Yes)
            {
                using (var reminderForm = new ReminderInputForm())
                {
                    if (reminderForm.ShowDialog() == DialogResult.OK)
                    {
                        reminderTime = reminderForm.SelectedDateTime;
                    }
                }
            }

            SQLiteHelper.ExecuteNonQuery(@"
                INSERT INTO Todo_List_Item (id_todo, item_detail, status, ReminderTime)
                VALUES (@todoId, @item_detail, 0, @reminder)",
                new SQLiteParameter("@todoId", TodoId),
                new SQLiteParameter("@item_detail", text),
                new SQLiteParameter("@reminder", 
                    reminderTime.HasValue ? (object)reminderTime.Value : DBNull.Value)
            );

            LoadItems();
        }

        private void EditItem(int itemId)
        {
            string current = Db_GetItemText(itemId);
            DateTime? currentReminder = NotificationService.GetItemReminder(itemId);

            string edited = Interaction.InputBox("Sửa nội dung:", "Sửa công việc", current);
            
            if (!string.IsNullOrWhiteSpace(edited) && edited != current)
            {
                Db_UpdateItemText(itemId, edited);
            }

            // Hỏi có muốn đổi reminder không
            var changeReminder = MessageBox.Show(
                "Bạn có muốn thay đổi thời gian nhắc nhở không?",
                "Nhắc nhở",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (changeReminder == DialogResult.Yes)
            {
                using (var reminderForm = new ReminderInputForm(currentReminder))
                {
                    if (reminderForm.ShowDialog() == DialogResult.OK)
                    {
                        NotificationService.SetItemReminder(itemId, reminderForm.SelectedDateTime);
                    }
                }
            }

            LoadItems();
        }
    }

    public class ReminderInputForm : Form
    {
        private DateTimePicker dtpDate;
        private DateTimePicker dtpTime;
        private Button btnOK;
        private Button btnCancel;
        private CheckBox chkNoReminder;

        public DateTime? SelectedDateTime { get; private set; }

        public ReminderInputForm(DateTime? currentReminder = null)
        {
            InitializeUI();

            if (currentReminder.HasValue)
            {
                dtpDate.Value = currentReminder.Value.Date;
                dtpTime.Value = currentReminder.Value;
                chkNoReminder.Checked = false;
            }
            else
            {
                dtpDate.Value = DateTime.Now.Date.AddDays(1);
                dtpTime.Value = DateTime.Now.Date.AddHours(9);
            }
        }

        private void InitializeUI()
        {
            this.Text = "Đặt thời gian nhắc nhở";
            this.Size = new Size(350, 200);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label lblDate = new Label
            {
                Text = "Ngày:",
                Location = new Point(20, 20),
                AutoSize = true
            };

            dtpDate = new DateTimePicker
            {
                Location = new Point(80, 18),
                Width = 200,
                Format = DateTimePickerFormat.Short,
                MinDate = DateTime.Now.Date
            };

            Label lblTime = new Label
            {
                Text = "Giờ:",
                Location = new Point(20, 55),
                AutoSize = true
            };

            dtpTime = new DateTimePicker
            {
                Location = new Point(80, 53),
                Width = 200,
                Format = DateTimePickerFormat.Time,
                ShowUpDown = true
            };

            chkNoReminder = new CheckBox
            {
                Text = "Không nhắc nhở",
                Location = new Point(80, 90),
                AutoSize = true
            };

            chkNoReminder.CheckedChanged += (s, e) =>
            {
                dtpDate.Enabled = !chkNoReminder.Checked;
                dtpTime.Enabled = !chkNoReminder.Checked;
            };

            btnOK = new Button
            {
                Text = "OK",
                Location = new Point(100, 120),
                Size = new Size(80, 30),
                DialogResult = DialogResult.OK
            };

            btnCancel = new Button
            {
                Text = "Hủy",
                Location = new Point(190, 120),
                Size = new Size(80, 30),
                DialogResult = DialogResult.Cancel
            };

            btnOK.Click += (s, e) =>
            {
                if (!chkNoReminder.Checked)
                {
                    var selectedDateTime = new DateTime(
                        dtpDate.Value.Year,
                        dtpDate.Value.Month,
                        dtpDate.Value.Day,
                        dtpTime.Value.Hour,
                        dtpTime.Value.Minute,
                        0
                    );

                    if (selectedDateTime <= DateTime.Now)
                    {
                        MessageBox.Show("Thời gian nhắc nhở phải lớn hơn thời gian hiện tại!",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.DialogResult = DialogResult.None;
                        return;
                    }

                    SelectedDateTime = selectedDateTime;
                }
                else
                {
                    SelectedDateTime = null;
                }
            };

            this.Controls.AddRange(new Control[] {
                lblDate, dtpDate, lblTime, dtpTime, chkNoReminder, btnOK, btnCancel
            });

            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }
    }
}
