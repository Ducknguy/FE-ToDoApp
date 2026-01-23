# ?? THÊM EVENT HANDLER VÀO WeekGroupMVC.cs

File WeekGroupMVC.cs ?ang m? nên không th? t? ??ng edit. Hãy thêm method sau vào file:

## ?? V? TRÍ: Thêm SAU method `CategoryItem_Clicked()` (kho?ng dòng 140)

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

## ? SAU KHI THÊM:

1. Save file
2. Build (Ctrl + Shift + B)
3. Run ?ng d?ng
4. Click nút "? Thêm" trong sidebar ? Dialog s? hi?n ra

---

## ?? ?Ã HOÀN THÀNH T? ??NG:

? WeekCategory.cs - Thêm WeekStartDate/WeekEndDate
? WeekCategoryRepository.cs - FULL CRUD
? WeekCategoryController.cs - Validation
? WeekGroupMVC.Designer.cs - Thêm btnAddCategory

## ? C?N LÀM TH? CÔNG:

? WeekGroupMVC.cs - Thêm BtnAddCategory_Click (copy code trên)
? CategoryEditDialog.cs - Update theo MANUAL_UPDATE_INSTRUCTIONS.md
? week_category_item.cs - Thêm right-click menu theo h??ng d?n

?? Sau khi làm xong 3 b??c trên, module Week s? hoàn ch?nh!
