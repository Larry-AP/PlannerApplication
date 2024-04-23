using Microsoft.EntityFrameworkCore;
using PlannerApplication.Models;

namespace PlannerApplication.Data
{
    public class PlannerApplicationDbContext : DbContext
    {
        public PlannerApplicationDbContext(DbContextOptions<PlannerApplicationDbContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Checklist> Checklists { get; set; }
        public DbSet<Reminders> Reminders { get; set; }

        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<string> FirstList = new List<string> { "Take trash out", "Run some laundry" };
            List<string> SecondList = new List<string> { "Advanced C#", "Final project" };

            modelBuilder.Entity<User>().HasData(
                new User { Id = "austin2024", FullName = "Austin Johnson" },
                new User { Id = "ben.j.smith99", FullName = "Ben Smith" }
                );
            modelBuilder.Entity<ChecklistItem>().HasData(
                new ChecklistItem { Id = 100, Description = "Take trash out", IsCompleted = true },
                new ChecklistItem { Id = 101, Description = "Run some laundry", IsCompleted = false });

            
            /*modelBuilder.Entity<Checklist>().HasData(
                new Checklist { Id = 1234, Title = "Housekeeping", Items = },
                new Checklist { Id = 5678, Title = "Homework", Items = SecondList}
                );*/

        }
    }
}
