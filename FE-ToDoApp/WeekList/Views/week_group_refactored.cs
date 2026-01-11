using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FE_ToDoApp.WeekList.Controllers;
using FE_ToDoApp.WeekList.Models;
using FE_ToDoApp.WeekList.Views;
using FE_ToDoApp.WeekList.Views.Dialogs;

namespace FE_ToDoApp.WeekList
{
    /// <summary>
    /// Main container cho WeekList module (MVC Pattern)
    /// Sidebar: Danh sách categories
    /// Main content: WeekItemsControl hi?n th? tasks c?a category ???c ch?n
    /// </summary>
    public partial class week_group_refactored : UserControl
    {
        // ===== CONNECTION =====
        private const string ConnectionString = "Data Source=duc;Initial Catalog=ToDoApp;Integrated Security=True;Encrypt=False";

        // ===== CONTROLLERS =====
        private WeekCategoryController _categoryController;
        private WeekTaskController _taskController;

        // ===== STATE =====
        private List<WeekCategory> _categories = new List<WeekCategory>();
        private week_category_item? _selectedCategoryItem;
        private int _currentCategoryId = -1;
        private DateTime _currentWeekStart;

        // ===== CHILD CONTROLS =====
        private WeekItemsControl _weekItemsControl;

        public week_group_refactored()
        {
            InitializeComponent();

            // Initialize Controllers
            _categoryController = new WeekCategoryController(ConnectionString);
            _taskController = new WeekTaskController(ConnectionString);

            // Initialize WeekItemsControl
            _weekItemsControl = new WeekItemsControl
            {
                Dock = DockStyle.Fill
            };
            _weekItemsControl.Initialize(ConnectionString);
            _weekItemsControl.TaskChanged += (s, e) => RefreshCategoryIfNeeded();
            
            // Add to flowLayoutPanel2 (main content area)
            flowLayoutPanel2.Controls.Clear();
            flowLayoutPanel2.Controls.Add(_weekItemsControl);

            // Calculate current week
            _currentWeekStart = GetMonday(DateTime.Now);

            // Wire button events (category management)
            button1.Click += BtnAddCategory_Click;      // Thêm category
            button2.Click += BtnEditCategory_Click;     // S?a category
            button3.Click += BtnDeleteCategory_Click;   // Xóa category

            // Wire search event
            txt_search_place.TextChanged += TxtSearch_TextChanged;

            // Load initial data
            LoadCategories();
        }

        // =============================
        // CATEGORY MANAGEMENT
        // =============================
        
        /// <summary>
        /// Load t?t c? categories vào sidebar
        /// </summary>
        private void LoadCategories()
        {
            try
            {
                _categories = _categoryController.GetAllCategories();

                // Clear old items in flowLayoutPanel1
                var toRemove = flowLayoutPanel1.Controls.OfType<week_category_item>().ToList();
                foreach (var item in toRemove)
                {
                    flowLayoutPanel1.Controls.Remove(item);
                    item.Dispose();
                }

                // Render new items
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
                }

                // Auto-select first category
                if (_categories.Any())
                {
                    var firstItem = flowLayoutPanel1.Controls.OfType<week_category_item>().FirstOrDefault();
                    if (firstItem != null)
                    {
                        CategoryItem_Clicked(firstItem, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"L?i load categories: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// X? lý khi click vào 1 category
        /// </summary>
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

            // Load week items for this category
            _weekItemsControl.LoadWeekItems(_currentCategoryId, _currentWeekStart);
        }

        /// <summary>
        /// Thêm category m?i
        /// </summary>
        private void BtnAddCategory_Click(object? sender, EventArgs e)
        {
            var dialog = new CategoryEditDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int newCategoryId = _categoryController.AddCategory(dialog.CategoryName);
                    
                    MessageBox.Show("Thêm nhóm công vi?c thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    LoadCategories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"L?i: {ex.Message}", "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// S?a category ?ang ch?n
        /// </summary>
        private void BtnEditCategory_Click(object? sender, EventArgs e)
        {
            if (_selectedCategoryItem == null)
            {
                MessageBox.Show("Vui lòng ch?n nhóm công vi?c c?n s?a!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var dialog = new CategoryEditDialog(_selectedCategoryItem.CategoryName);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _categoryController.UpdateCategory(_currentCategoryId, dialog.CategoryName);
                    
                    MessageBox.Show("C?p nh?t nhóm công vi?c thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    LoadCategories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"L?i: {ex.Message}", "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Xóa category ?ang ch?n
        /// </summary>
        private void BtnDeleteCategory_Click(object? sender, EventArgs e)
        {
            if (_selectedCategoryItem == null)
            {
                MessageBox.Show("Vui lòng ch?n nhóm công vi?c c?n xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show(
                $"B?n có ch?c mu?n xóa nhóm '{_selectedCategoryItem.CategoryName}'?\n" +
                $"T?t c? tasks trong nhóm này c?ng s? b? xóa!",
                "Xác nh?n xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _categoryController.DeleteCategory(_currentCategoryId);
                    
                    MessageBox.Show("Xóa nhóm công vi?c thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    _selectedCategoryItem = null;
                    _currentCategoryId = -1;
                    LoadCategories();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"L?i: {ex.Message}", "L?i",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =============================
        // SEARCH
        // =============================
        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            // TODO: Implement search across all categories
            // For now, just reload current category
            if (_currentCategoryId > 0)
            {
                _weekItemsControl.LoadWeekItems(_currentCategoryId, _currentWeekStart);
            }
        }

        // =============================
        // HELPERS
        // =============================
        private void RefreshCategoryIfNeeded()
        {
            // Reload current category when tasks change
            if (_currentCategoryId > 0)
            {
                _weekItemsControl.LoadWeekItems(_currentCategoryId, _currentWeekStart);
            }
        }

        private DateTime GetMonday(DateTime date)
        {
            int daysFromMonday = ((int)date.DayOfWeek - 1 + 7) % 7;
            return date.Date.AddDays(-daysFromMonday);
        }
    }
}
