using System.ComponentModel.DataAnnotations;

namespace PlannerApplication.Models
{
    public class ChecklistModel
    {
        public int Id { get; set; } 

        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } 

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } 
    }
}
