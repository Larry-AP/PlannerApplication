using System.ComponentModel.DataAnnotations;

namespace PlannerApplication.Models
{
    public class User : IUser
    {
        public string Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
