using System.ComponentModel.DataAnnotations;

namespace PlannerApplication.Models
{
    public class Reminders : IReminders
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter a reminder title")]
        [StringLength(20, ErrorMessage ="Title must be 20 characters or less.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a reminder description")]
        [StringLength(100, ErrorMessage ="Description must be 100 characters or less.")]
        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Date { get; set; }

    }
}
