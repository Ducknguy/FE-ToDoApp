# ?? MANUAL UPDATE REQUIRED - Files ?ang m? không th? t? ??ng s?a

## ? ?Ã HOÀN THÀNH T? ??NG:
1. ? WeekCategory.cs - Thêm WeekStartDate/WeekEndDate
2. ? WeekCategoryRepository.cs - FULL CRUD v?i WeekCategory table
3. ? WeekCategoryController.cs - Validation + CRUD methods

---

## ?? C?N S?A TH? CÔNG (3 files ?ang m?):

### 1. CategoryEditDialog.cs
**File:** `FE-ToDoApp\WeekList\Views\Dialogs\CategoryEditDialog.cs`

**THAY TH? TOÀN B? N?I DUNG b?ng:**

```csharp
using System;
using System.Drawing;
using System.Windows.Forms;

namespace FE_ToDoApp.WeekList.Views.Dialogs
{
    public class CategoryEditDialog : Form
    {
        private TextBox txtCategoryName;
        private DateTimePicker dtpWeekStart;
        private DateTimePicker dtpWeekEnd;
        private Button btnOK;
        private Button btnCancel;
        private Label lblCategoryName;
        private Label lblWeekStart;
        private Label lblWeekEnd;
        private Label lblWeekInfo;

        public string CategoryName { get; private set; } = string.Empty;
        public DateTime WeekStartDate { get; private set; }
        public DateTime WeekEndDate { get; private set; }

        public CategoryEditDialog(string categoryName = "", DateTime? weekStartDate = null, DateTime? weekEndDate = null)
        {
            CategoryName = categoryName;
            
            if (weekStartDate.HasValue && weekEndDate.HasValue)
            {
                WeekStartDate = weekStartDate.Value;
                WeekEndDate = weekEndDate.Value;
            }
            else
            {
                DateTime monday = GetMonday(DateTime.Now);
                WeekStartDate = monday;
                WeekEndDate = monday.AddDays(6);
            }
            
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = string.IsNullOrEmpty(CategoryName) ? "Thêm Nhóm Công Vi?c" : "S?a Nhóm Công Vi?c";
            this.Size = new Size(450, 240);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            lblCategoryName = new Label
            {
                Text = "Tên nhóm:",
                Location = new Point(20, 20),
                Size = new Size(100, 23),
                Font = new Font("Segoe UI", 10F)
            };
            this.Controls.Add(lblCategoryName);

            txtCategoryName = new TextBox
            {
                Location = new Point(130, 20),
                Size = new Size(280, 27),
                Font = new Font("Segoe UI", 10F),
                Text = CategoryName
            };
            this.Controls.Add(txtCategoryName);

            lblWeekStart = new Label
            {
                Text = "T? ngày:",
                Location = new Point(20, 60),
                Size = new Size(100, 23),
                Font = new Font("Segoe UI", 10F)
            };
            this.Controls.Add(lblWeekStart);

            dtpWeekStart = new DateTimePicker
            {
                Location = new Point(130, 60),
                Size = new Size(280, 27),
                Font = new Font("Segoe UI", 10F),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Value = WeekStartDate
            };
            dtpWeekStart.ValueChanged += (s, e) => dtpWeekEnd.Value = dtpWeekStart.Value.AddDays(6);
            this.Controls.Add(dtpWeekStart);

            lblWeekEnd = new Label
            {
                Text = "??n ngày:",
                Location = new Point(20, 100),
                Size = new Size(100, 23),
                Font = new Font("Segoe UI", 10F)
            };
            this.Controls.Add(lblWeekEnd);

            dtpWeekEnd = new DateTimePicker
            {
                Location = new Point(130, 100),
                Size = new Size(280, 27),
                Font = new Font("Segoe UI", 10F),
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "dd/MM/yyyy",
                Value = WeekEndDate,
                Enabled = false
            };
            this.Controls.Add(dtpWeekEnd);

            lblWeekInfo = new Label
            {
                Text = "?? Kho?ng th?i gian s? t? ??ng là 7 ngày (1 tu?n)",
                Location = new Point(130, 130),
                Size = new Size(280, 20),
                Font = new Font("Segoe UI", 8F),
                ForeColor = Color.Gray
            };
            this.Controls.Add(lblWeekInfo);

            btnOK = new Button
            {
                Text = "OK",
                Location = new Point(210, 160),
                Size = new Size(90, 30),
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat
            };
            btnOK.Click += BtnOK_Click;
            this.Controls.Add(btnOK);

            btnCancel = new Button
            {
                Text = "H?y",
                Location = new Point(310, 160),
                Size = new Size(90, 30),
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.LightGray,
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.Cancel
            };
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }

        private void BtnOK_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Vui lòng nh?p tên nhóm công vi?c!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return;
            }

            CategoryName = txtCategoryName.Text.Trim();
            WeekStartDate = dtpWeekStart.Value.Date;
            WeekEndDate = dtpWeekEnd.Value.Date;

            DialogResult = DialogResult.OK;
            Close();
        }

        private DateTime GetMonday(DateTime date)
        {
            int daysFromMonday = ((int)date.DayOfWeek - 1 + 7) % 7;
            return date.Date.AddDays(-daysFromMonday);
        }
    }
}
```

---

### 2. week_category_item.cs
**File:** `FE-ToDoApp\WeekList\Views\week_category_item.cs`

**THÊM VÀO SAU dòng `public int CategoryId { get; set; }`:**

```csharp
        public DateTime WeekStartDate { get; set; }
        public DateTime WeekEndDate { get; set; }
```

**THÊM VÀO SAU dòng `public event EventHandler? Clicked;`:**

```csharp
        public event EventHandler? EditRequested;
        public event EventHandler? DeleteRequested;

        private ContextMenuStrip? _contextMenu;
```

**THÊM VÀO trong constructor SAU dòng `WireClickRecursive(this);`:**

```csharp
            CreateContextMenu();
```

**THÊM CÁC METHODS M?I ? cu?i class (tr??c d?u `}` cu?i cùng):**

```csharp
        private void CreateContextMenu()
        {
            _contextMenu = new ContextMenuStrip();

            var editItem = new ToolStripMenuItem("?? S?a category");
            editItem.Click += (s, e) => EditRequested?.Invoke(this, EventArgs.Empty);

            var deleteItem = new ToolStripMenuItem("??? Xóa category");
            deleteItem.Click += (s, e) => DeleteRequested?.Invoke(this, EventArgs.Empty);

            _contextMenu.Items.Add(editItem);
            _contextMenu.Items.Add(deleteItem);

            this.ContextMenuStrip = _contextMenu;
            ApplyContextMenuRecursive(this);
        }

        private void ApplyContextMenuRecursive(Control root)
        {
            root.ContextMenuStrip = _contextMenu;
            foreach (Control c in root.Controls)
                ApplyContextMenuRecursive(c);
        }
```

---

### 3. WeekGroupMVC.cs
**File:** `FE-ToDoApp\WeekList\WeekGroupMVC.cs`

#### A. TÌM method `LoadCategories()` và S?A nh? sau:

**TÌM ?o?n:**
```csharp
                foreach (var category in _categories)
                {
                    var item = new week_category_item
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        Width = 267,
                        Height = 50,
                        Margin = new Padding(3)
                    };

                    item.Clicked += CategoryItem_Clicked;
                    flowLayoutPanel1.Controls.Add(item);
                    flowLayoutPanel1.Controls.SetChildIndex(item, insertIndex++);
                }
```

**THAY B?NG:**
```csharp
                foreach (var category in _categories)
                {
                    var item = new week_category_item
                    {
                        CategoryId = category.CategoryId,
                        CategoryName = category.CategoryName,
                        WeekStartDate = category.WeekStartDate,
                        WeekEndDate = category.WeekEndDate,
                        Width = 267,
                        Height = 50,
                        Margin = new Padding(3)
                    };

                    item.Clicked += CategoryItem_Clicked;
                    item.EditRequested += CategoryItem_EditRequested;
                    item.DeleteRequested += CategoryItem_DeleteRequested;
                    
                    flowLayoutPanel1.Controls.Add(item);
                    flowLayoutPanel1.Controls.SetChildIndex(item, insertIndex++);
                }
```

#### B. TÌM method `CategoryItem_Clicked()` và S?A nh? sau:

**TÌM ?o?n:**
```csharp
        private void CategoryItem_Clicked(object? sender, EventArgs e)
        {
            var clickedItem = sender as week_category_item;
            if (clickedItem == null) return;

            // Deselect old item
            if (_selectedCategoryItem != null)
            {
                _selectedCategoryItem.SetSelected(false);
            }

            // Select new item
            _selectedCategoryItem = clickedItem;
            _selectedCategoryItem.SetSelected(true);
            _currentCategoryId = clickedItem.CategoryId;

            // Load tasks cho category này
            LoadWeek();
        }
```

**THAY B?NG:**
```csharp
        private void CategoryItem_Clicked(object? sender, EventArgs e)
        {
            var clickedItem = sender as week_category_item;
            if (clickedItem == null) return;

            // Deselect old item
            if (_selectedCategoryItem != null)
            {
                _selectedCategoryItem.SetSelected(false);
            }

            // Select new item
            _selectedCategoryItem = clickedItem;
            _selectedCategoryItem.SetSelected(true);
            _currentCategoryId = clickedItem.CategoryId;
            _currentWeekStart = clickedItem.WeekStartDate;

            // Update header labels v?i ngày c? th?
            UpdateWeekHeaders();

            // Load tasks cho category này
            LoadWeek();
        }
```

#### C. THÊM 3 METHODS M?I ? cu?i class (tr??c d?u `}` cu?i cùng):

```csharp
        // =============================
        // CATEGORY CRUD EVENT HANDLERS
        // =============================
        
        private void CategoryItem_EditRequested(object? sender, EventArgs e)
        {
            var item = sender as week_category_item;
            if (item == null) return;

            var dialog = new CategoryEditDialog(
                item.CategoryName,
                item.WeekStartDate,
                item.WeekEndDate);

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _categoryController.UpdateCategory(
                        item.CategoryId,
                        dialog.CategoryName,
                        dialog.WeekStartDate,
                        dialog.WeekEndDate);

                    LoadCategories();
                    
                    MessageBox.Show("C?p nh?t nhóm công vi?c thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"L?i: {ex.Message}", "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CategoryItem_DeleteRequested(object? sender, EventArgs e)
        {
            var item = sender as week_category_item;
            if (item == null) return;

            var result = MessageBox.Show(
                $"B?n có ch?c mu?n xóa nhóm '{item.CategoryName}'?\n\n" +
                $"Các tasks trong nhóm này s? không b? xóa.",
                "Xác nh?n xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _categoryController.DeleteCategory(item.CategoryId);
                    LoadCategories();
                    
                    MessageBox.Show("Xóa nhóm công vi?c thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"L?i: {ex.Message}", "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateWeekHeaders()
        {
            // Update labels v?i ngày c? th?
            var label2 = (Label)panel6.Controls[0];
            label2.Text = $"Th? 2 - {_currentWeekStart:dd/MM}";
            
            var label3 = (Label)panel8.Controls[0];
            label3.Text = $"Th? 3 - {_currentWeekStart.AddDays(1):dd/MM}";
            
            var label4 = (Label)panel10.Controls[0];
            label4.Text = $"Th? 4 - {_currentWeekStart.AddDays(2):dd/MM}";
            
            var label5 = (Label)panel12.Controls[0];
            label5.Text = $"Th? 5 - {_currentWeekStart.AddDays(3):dd/MM}";
            
            var label8 = (Label)panel16.Controls[0];
            label8.Text = $"Th? 6 - {_currentWeekStart.AddDays(4):dd/MM}";
            
            var label9 = (Label)panel18.Controls[0];
            label9.Text = $"Th? 7 - {_currentWeekStart.AddDays(5):dd/MM}";
            
            var label10 = (Label)panel20.Controls[0];
            label10.Text = $"CN - {_currentWeekStart.AddDays(6):dd/MM}";
        }
```

#### D. THÊM NÚT "? Thêm Category" vào panel4 trong constructor:

**TÌM ?o?n trong `WeekGroupMVC()` constructor:**
```csharp
            // Load initial data
            LoadCategories();
```

**THÊM TR??C dòng ?ó:**
```csharp
            // Thêm button "Thêm Category" vào header sidebar
            var btnAddCategory = new Button
            {
                Text = "? Thêm",
                Location = new Point(180, 20),
                Size = new Size(70, 25),
                Font = new Font("Segoe UI", 9F),
                BackColor = Color.LightGreen,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnAddCategory.Click += BtnAddCategory_Click;
            panel4.Controls.Add(btnAddCategory);
```

#### E. THÊM EVENT HANDLER cho button "Thêm Category":

```csharp
        private void BtnAddCategory_Click(object? sender, EventArgs e)
        {
            var dialog = new CategoryEditDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int newCategoryId = _categoryController.AddCategory(
                        dialog.CategoryName,
                        dialog.WeekStartDate,
                        dialog.WeekEndDate);

                    LoadCategories();
                    
                    // Select new category
                    var newItem = flowLayoutPanel1.Controls.OfType<week_category_item>()
                        .FirstOrDefault(i => i.CategoryId == newCategoryId);
                    if (newItem != null)
                    {
                        CategoryItem_Clicked(newItem, EventArgs.Empty);
                    }

                    MessageBox.Show("Thêm nhóm công vi?c thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"L?i: {ex.Message}", "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
```

---

## ?? SAU KHI S?A XONG:

1. **Save t?t c? files**
2. **Build Solution** (Ctrl + Shift + B)
3. **Ch?y ?ng d?ng**
4. **Test các ch?c n?ng:**
   - Click "? Thêm" trong sidebar ? Dialog hi?n v?i DateTimePicker
   - Right-click category ? Menu "S?a/Xóa" hi?n
   - Click category ? Header 7 ngày hi?n th? ?úng (Th? 2 - 12/01...)

---

## ?? CHECKLIST:

- [ ] CategoryEditDialog.cs - Thay code m?i
- [ ] week_category_item.cs - Thêm properties + events + methods
- [ ] WeekGroupMVC.cs - C?p nh?t LoadCategories()
- [ ] WeekGroupMVC.cs - C?p nh?t CategoryItem_Clicked()
- [ ] WeekGroupMVC.cs - Thêm 3 event handlers m?i
- [ ] WeekGroupMVC.cs - Thêm button trong constructor
- [ ] WeekGroupMVC.cs - Thêm BtnAddCategory_Click method
- [ ] Build thành công
- [ ] Test thành công

?? Hoàn t?t sau khi check h?t các m?c trên!
