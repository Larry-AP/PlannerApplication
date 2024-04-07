using System.ComponentModel.DataAnnotations;

namespace PlannerApplication.Models
{
    public class ReminderModel
    { 
        public int Id { get; set; } 
        
        public string Text { get; set; } 

        [DataType(DataType.Date)]
        public DateTime ReminderDate { get; set; } 

    }
}
