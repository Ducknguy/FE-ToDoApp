namespace FE_ToDoApp.WeekList.Models
{
    /// <summary>
    /// Entity ??i di?n cho 1 Task trong tu?n
    /// </summary>
    public class WeekTask
    {
        public int TaskId { get; set; }
        public int CategoryId { get; set; }  // Link ??n Category
        public int WeekPlanId { get; set; }
        public int DayOfWeek { get; set; }   // 1=Monday, 7=Sunday
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        public int OrderIndex { get; set; }
    }
}
