using System;
using System.Collections.Generic;
using FE_ToDoApp.WeekList.Data;
using FE_ToDoApp.WeekList.Models;

namespace FE_ToDoApp.WeekList.Controllers
{
    /// <summary>
    /// Controller x? lý logic nghi?p v? cho Task
    /// </summary>
    public class WeekTaskController
    {
        private readonly WeekTaskRepository _repository;

        public WeekTaskController(string connectionString)
        {
            _repository = new WeekTaskRepository(connectionString);
        }

        /// <summary>
        /// L?y t?t c? tasks c?a 1 category trong tu?n
        /// </summary>
        public List<WeekTask> GetTasksByCategory(int categoryId, DateTime weekStart)
        {
            if (categoryId <= 0)
            {
                throw new ArgumentException("CategoryId không h?p l?");
            }

            try
            {
                return _repository.GetByCategory(categoryId, weekStart);
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi load tasks: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Thêm task m?i
        /// </summary>
        public int AddTask(int categoryId, DateTime weekStart, int dayOfWeek, string title)
        {
            if (categoryId <= 0)
            {
                throw new ArgumentException("CategoryId không h?p l?");
            }

            if (dayOfWeek < 1 || dayOfWeek > 7)
            {
                throw new ArgumentException("DayOfWeek ph?i t? 1 (Monday) ??n 7 (Sunday)");
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Tiêu ?? task không ???c ?? tr?ng");
            }

            try
            {
                return _repository.Insert(categoryId, weekStart, dayOfWeek, title.Trim());
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi thêm task: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// S?a task
        /// </summary>
        public void UpdateTask(int taskId, string title, int dayOfWeek)
        {
            if (taskId <= 0)
            {
                throw new ArgumentException("TaskId không h?p l?");
            }

            if (dayOfWeek < 1 || dayOfWeek > 7)
            {
                throw new ArgumentException("DayOfWeek ph?i t? 1 (Monday) ??n 7 (Sunday)");
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Tiêu ?? task không ???c ?? tr?ng");
            }

            try
            {
                _repository.Update(taskId, title.Trim(), dayOfWeek);
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi c?p nh?t task: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Toggle tr?ng thái Done/Undone
        /// </summary>
        public void ToggleTaskStatus(int taskId, bool isDone)
        {
            if (taskId <= 0)
            {
                throw new ArgumentException("TaskId không h?p l?");
            }

            try
            {
                _repository.UpdateStatus(taskId, isDone);
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi c?p nh?t tr?ng thái: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Xóa task
        /// </summary>
        public void DeleteTask(int taskId)
        {
            if (taskId <= 0)
            {
                throw new ArgumentException("TaskId không h?p l?");
            }

            try
            {
                _repository.Delete(taskId);
            }
            catch (Exception ex)
            {
                throw new Exception($"L?i khi xóa task: {ex.Message}", ex);
            }
        }
    }
}
