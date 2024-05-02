using Microsoft.AspNetCore.Mvc;
using Moq;
using PlannerApplication.Controllers;
using PlannerApplication.Data;
using PlannerApplication.Models;
using Xunit;



namespace PlannerApplication.Tests.Controllers
{
    public class RemindersControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewResult_WithReminders()
        {
            // Arrange
            var reminders = new List<Reminders> { new Reminders(), new Reminders() };
            var mockContext = new Mock<PlannerApplicationDbContext>();
            mockContext.Setup(c => c.Reminders).Returns((Microsoft.EntityFrameworkCore.DbSet<Reminders>)reminders.AsQueryable());
            var controller = new RemindersController(mockContext.Object);

            // Act
            var result = controller.Index() as ViewResult;
            var model = result.Model as List<Reminders>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(model);
            Assert.Equal(reminders.Count, model.Count);
        }

        [Fact]
        public void Create_ReturnsViewResult()
        {
            // Arrange
            var mockContext = new Mock<PlannerApplicationDbContext>();
            var controller = new RemindersController(mockContext.Object);

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Create_RedirectsToIndexAction_WhenModelStateIsValid()
        {
            // Arrange
            var reminder = new Reminders();
            var mockContext = new Mock<PlannerApplicationDbContext>();
            var controller = new RemindersController(mockContext.Object);

            // Act
            var result = await controller.Create(reminder) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }
    }
}