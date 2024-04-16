using System.ComponentModel.DataAnnotations;

namespace PlannerApplication.Models
{
    public class Checklist : IChecklist
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public List<ChecklistItem> Items { get; set; }
    }

    public class ChecklistItem
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsCompleted { get; set; }
    }
}
