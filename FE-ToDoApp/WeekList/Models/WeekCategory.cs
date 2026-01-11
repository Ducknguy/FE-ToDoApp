namespace FE_ToDoApp.WeekList.Models
{
    /// <summary>
    /// Entity ??i di?n cho 1 Category/Nhóm công vi?c
    /// </summary>
    public class WeekCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
