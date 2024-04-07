using System.ComponentModel.DataAnnotations;

namespace PlannerApplication.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime EventDate { get; set; }
        public String Category { get; set; }
    
    }
}
