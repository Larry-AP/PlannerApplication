using System.ComponentModel.DataAnnotations;

namespace PlannerApplication.Models
{
    public class Event
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime EndTime { get; set; }

        public string Location { get; set; }

        // Foreign key
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
