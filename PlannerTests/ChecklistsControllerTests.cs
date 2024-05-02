using Microsoft.AspNetCore.Mvc;
using Moq;
using PlannerApplication.Controllers;
using PlannerApplication.Data;
using PlannerApplication.Models;
using PlannerTests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApplication.Tests.Controllers
{
    public class ChecklistsControllerTests
    {
        [Fact]
        public async Task Index_ReturnsViewResult_WithChecklists()
        {
            // Arrange
            var checklists = new List<Checklist> { new Checklist(), new Checklist() };
            var mockContext = new Mock<PlannerApplicationDbContext>();
            mockContext.Setup(c => c.Checklists).Returns(DbSetMock.GetQueryableMockDbSet(checklists));
            var controller = new ChecklistsController(mockContext.Object);

            // Act
            var result = await controller.Index() as ViewResult;
            var model = result.Model as List<Checklist>;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(model);
            Assert.Equal(checklists.Count, model.Count);
        }

        [Fact]
        public void Create_ReturnsViewResult()
        {
            // Arrange
            var mockContext = new Mock<PlannerApplicationDbContext>();
            var controller = new ChecklistsController(mockContext.Object);

            // Act
            var result = controller.Create() as ViewResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Create_RedirectsToIndexAction_WhenModelStateIsValid()
        {
            // Arrange
            var checklist = new Checklist();
            var mockContext = new Mock<PlannerApplicationDbContext>();
            var controller = new ChecklistsController(mockContext.Object);

            // Act
            var result = await controller.Create(checklist) as RedirectToActionResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
        }

        [Fact]
        public async Task Details_ReturnsViewResult_WithValidId()
        {
            // Arrange
            var checklist = new Checklist { Id = 1 };
            var mockContext = new Mock<PlannerApplicationDbContext>();
            mockContext.Setup(c => c.Checklists.FindAsync(1)).ReturnsAsync(checklist);
            var controller = new ChecklistsController(mockContext.Object);

            // Act
            var result = await controller.Details(1) as ViewResult;
            var model = result.Model as Checklist;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(model);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public async Task Details_ReturnsNotFound_WithInvalidId()
        {
            // Arrange
            var mockContext = new Mock<PlannerApplicationDbContext>();
            mockContext.Setup(c => c.Checklists.FindAsync(It.IsAny<int>())).ReturnsAsync((Checklist)null);
            var controller = new ChecklistsController(mockContext.Object);

            // Act
            var result = await controller.Details(999) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Edit_ReturnsViewResult_WithValidId()
        {
            // Arrange
            var checklist = new Checklist { Id = 1 };
            var mockContext = new Mock<PlannerApplicationDbContext>();
            mockContext.Setup(c => c.Checklists.FindAsync(1)).ReturnsAsync(checklist);
            var controller = new ChecklistsController(mockContext.Object);

            // Act
            var result = await controller.Edit(1) as ViewResult;
            var model = result.Model as Checklist;

            // Assert
            Assert.NotNull(result);
            Assert.NotNull(model);
            Assert.Equal(1, model.Id);
        }

        [Fact]
        public async Task Edit_ReturnsNotFound_WithInvalidId()
        {
            // Arrange
            var mockContext = new Mock<PlannerApplicationDbContext>();
            mockContext.Setup(c => c.Checklists.FindAsync(It.IsAny<int>())).ReturnsAsync((Checklist)null);
            var controller = new ChecklistsController(mockContext.Object);

            // Act
            var result = await controller.Edit(999) as NotFoundResult;

            // Assert
            Assert.NotNull(result);
        }


    }
}