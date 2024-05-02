using Microsoft.AspNetCore.Mvc;
using Moq;
using PlannerApplication.Controllers;
using PlannerApplication.Data;
using PlannerApplication.Models;
using Xunit;

namespace PlannerTests
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_ReturnsViewResult_WithCurrentDate()
        {
            // Arrange
            var currentDate = DateTime.Now;
            var mockContext = new Mock<PlannerApplicationDbContext>();
            var controller = new HomeController(mockContext.Object);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(currentDate, result.Model);
        }

        [Fact]
        public void Index_ReturnsViewResult_WithUsers()
        {
            // Arrange
            var users = new List<User> { new User(), new User() }; // Sample users
            var mockContext = new Mock<PlannerApplicationDbContext>();
             var controller = new HomeController(mockContext.Object);

            // Act
            var result = controller.Index() as ViewResult;
            var model = result.Model as HomeController.HomePageViewModel;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(model);
            Assert.Equal(users.Count, model.Users.Count());
        }

        [Fact]
        public void Privacy_ReturnsViewResult()
        {
            // Arrange
            var mockContext = new Mock<PlannerApplicationDbContext>();
            var controller = new HomeController(mockContext.Object);

            // Act
            var result = controller.Privacy() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }
    }
}