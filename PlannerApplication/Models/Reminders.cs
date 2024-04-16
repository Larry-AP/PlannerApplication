using System.ComponentModel.DataAnnotations;

namespace PlannerApplication.Models
{
    public class Reminders : IReminders
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

    }
}
