using System;
using System.Collections.Generic;
using FE_ToDoApp.WeekList.Data;
using FE_ToDoApp.WeekList.Models;

namespace FE_ToDoApp.WeekList.Controllers
{

    public class WeekTaskController
    {
        private readonly WeekTaskRepository _repository;

        public WeekTaskController()
        {
            _repository = new WeekTaskRepository();
        }

        public List<WeekTask> GetTasksByCategory(int categoryId, DateTime weekStart)
        {
            if (categoryId <= 0)
            {
                throw new ArgumentException("CategoryId không hợp lệ");
            }

            try
            {
                return _repository.GetByCategory(categoryId, weekStart);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi load tasks: {ex.Message}", ex);
            }
        }

        public int AddTask(int categoryId, DateTime weekStart, int dayOfWeek, string title)
        {
            if (categoryId <= 0)
            {
                throw new ArgumentException("CategoryId không hợp lệ");
            }

            if (dayOfWeek < 1 || dayOfWeek > 7)
            {
                throw new ArgumentException("DayOfWeek phải từ 1 (Monday) đến 7 (Sunday)");
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Tiêu đề task không được để trống");
            }

            try
            {
                return _repository.Insert(categoryId, weekStart, dayOfWeek, title.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi thêm task: {ex.Message}", ex);
            }
        }

       
        public void UpdateTask(int taskId, string title, int dayOfWeek)
        {
            if (taskId <= 0)
            {
                throw new ArgumentException("TaskId không hợp lệ");
            }

            if (dayOfWeek < 1 || dayOfWeek > 7)
            {
                throw new ArgumentException("DayOfWeek phải từ 1 (Monday) đến 7 (Sunday)");
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Tiêu đề task không được để trống");
            }

            try
            {
                _repository.Update(taskId, title.Trim(), dayOfWeek);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật task: {ex.Message}", ex);
            }
        }

        
        public void ToggleTaskStatus(int taskId, bool isDone)
        {
            if (taskId <= 0)
            {
                throw new ArgumentException("TaskId không hợp lệ");
            }

            try
            {
                _repository.UpdateStatus(taskId, isDone);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi cập nhật trạng thái: {ex.Message}", ex);
            }
        }

        
        public void DeleteTask(int taskId)
        {
            if (taskId <= 0)
            {
                throw new ArgumentException("TaskId không hợp lệ");
            }

            try
            {
                _repository.Delete(taskId);
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi khi xóa task: {ex.Message}", ex);
            }
        }
    }
}
