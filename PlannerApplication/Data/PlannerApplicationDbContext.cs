using Microsoft.EntityFrameworkCore;
using PlannerApplication.Models;

namespace PlannerApplication.Data
{
    public class PlannerApplicationDbContext : DbContext
    {
        public PlannerApplicationDbContext(DbContextOptions<PlannerApplicationDbContext> options) 
            : base(options) { }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Checklist> Checklists { get; set; } = null!;
        public DbSet<Reminders> Reminders { get; set; } = null!;

        public DbSet<Event> Events { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<string> FirstList = new List<string> { "Take trash out", "Run some laundry" };
            List<string> SecondList = new List<string> { "Advanced C#", "Final project" };

            modelBuilder.Entity<User>().HasData(
                new User { Id = "austin2024", FullName = "Austin Johnson", Password = "4321" },
                new User { Id = "ben.j.smith99", FullName = "Ben Smith", Password = "1234" }
                // new User { Id = "smarquis", FullName = "Skyler Marquis", Password = "IloveC#" }
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
