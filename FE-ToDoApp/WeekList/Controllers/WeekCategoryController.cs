using System;
using System.Collections.Generic;
using FE_ToDoApp.WeekList.Data;
using FE_ToDoApp.WeekList.Models;

namespace FE_ToDoApp.WeekList.Controllers
{
    
    public class WeekCategoryController
    {
        private readonly WeekCategoryRepository _repository;

        public WeekCategoryController()
        {
            _repository = new WeekCategoryRepository();
        }

  
        public List<WeekCategory> GetAllCategories()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi load danh sách categories: {ex.Message}", ex);
            }
        }

  
        public int AddCategory(string categoryName, DateTime weekStartDate, DateTime weekEndDate)
        {
            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentException("Tên category không được để trống");
            }

            if (weekEndDate < weekStartDate)
            {
                throw new ArgumentException("Ngày kết thúc phải sau ngày bắt đầu");
            }

            if ((weekEndDate - weekStartDate).Days != 6)
            {
                throw new ArgumentException("Khoảng thời gian phải đúng 7 ngày (1 tuần)");
            }

            try
            {
                return _repository.Insert(categoryName.Trim(), weekStartDate, weekEndDate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm category: {ex.Message}", ex);
            }
        }

        public void UpdateCategory(int categoryId, string categoryName, DateTime weekStartDate, DateTime weekEndDate)
        {
            if (categoryId <= 0)
            {
                throw new ArgumentException("CategoryId không hợp lệ");
            }

            if (string.IsNullOrWhiteSpace(categoryName))
            {
                throw new ArgumentException("Tên category không được để trống");
            }

            if (weekEndDate < weekStartDate)
            {
                throw new ArgumentException("Ngày kết thúc phải sau ngày bắt đầu");
            }

            if ((weekEndDate - weekStartDate).Days != 6)
            {
                throw new ArgumentException("Khoảng thời gian phải đúng 7 ngày (1 tuần)");
            }

            try
            {
                _repository.Update(categoryId, categoryName.Trim(), weekStartDate, weekEndDate);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật category: {ex.Message}", ex);
            }
        }

        public void DeleteCategory(int categoryId)
        {
            if (categoryId <= 0)
            {
                throw new ArgumentException("CategoryId không hợp lệ");
            }

            try
            {
                _repository.Delete(categoryId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa category: {ex.Message}", ex);
            }
        }
    }
}
