using System;
using System.Collections.Generic;
using FE_ToDoApp.WeekList.Data;
using FE_ToDoApp.WeekList.Models;

namespace FE_ToDoApp.WeekList.Controllers
{
    /// <summary>
    /// Controller x? lý logic nghi?p v? cho Category
    /// </summary>
    public class WeekCategoryController
    {
        private readonly WeekCategoryRepository _repository;

        public WeekCategoryController(string connectionString)
        {
            _repository = new WeekCategoryRepository(connectionString);
        }

        /// <summary>
        /// L?y t?t c? categories
        /// </summary>
        public List<WeekCategory> GetAllCategories()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi load danh sách categories: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Thêm category m?i
        /// </summary>
        public int AddCategory(string categoryName)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentException("Tên category không ???c ?? tr?ng");
            }

            try
            {
                return _repository.Insert(categoryName.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi thêm category: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// S?a category
        /// </summary>
        public void UpdateCategory(int categoryId, string categoryName)
        {
            if (categoryId <= 0)
            {
                throw new ArgumentException("CategoryId không h?p l?");
            }

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentException("Tên category không ???c ?? tr?ng");
            }

            try
            {
                _repository.Update(categoryId, categoryName.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi c?p nh?t category: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Xóa category
        /// </summary>
        public void DeleteCategory(int categoryId)
        {
            if (categoryId <= 0)
            {
                throw new ArgumentException("CategoryId không h?p l?");
            }

            try
            {
                _repository.Delete(categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi xóa category: {ex.Message}", ex);
            }
        }
    }
}
