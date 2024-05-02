using Microsoft.EntityFrameworkCore;
using PlannerApplication.Data;
using PlannerApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApplication.Tests.Data
{
    public class PlannerApplicationDbContextTests
    {
        [Fact]
        public void OnModelCreating_SeedData_CreatesExpectedEntities()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<PlannerApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new PlannerApplicationDbContext(options);
            var expectedUsers = new List<User>
            {
                new User { Id = "austin2024", FullName = "Austin Johnson", Password = "4321" },
                new User { Id = "ben.j.smith99", FullName = "Ben Smith", Password = "1234" }
            };

            // Act
            context.Database.EnsureCreated();

            // Assert
            Assert.Equal(expectedUsers.Count, context.Users.Count());
            foreach (var expectedUser in expectedUsers)
            {
                var actualUser = context.Users.FirstOrDefault(u => u.Id == expectedUser.Id);
                Assert.NotNull(actualUser);
                Assert.Equal(expectedUser.FullName, actualUser.FullName);
                Assert.Equal(expectedUser.Password, actualUser.Password);
            }
        }
    }
}