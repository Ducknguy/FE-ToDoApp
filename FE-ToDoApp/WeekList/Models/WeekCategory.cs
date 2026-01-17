using System;

namespace FE_ToDoApp.WeekList.Models
{
    public class WeekCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public DateTime WeekStartDate { get; set; }
        public DateTime WeekEndDate { get; set; }
        public int OrderIndex { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
