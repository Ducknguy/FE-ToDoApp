namespace FE_ToDoApp.WeekList.Models
{

    public class WeekTask
    {
        public int TaskId { get; set; }
        public int CategoryId { get; set; } 
        public int WeekPlanId { get; set; }
        public int DayOfWeek { get; set; }  
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        public int OrderIndex { get; set; }
        public DateTime? ReminderTime { get; set; }
        public DateTime StartDate { get; set; }
    }
}
