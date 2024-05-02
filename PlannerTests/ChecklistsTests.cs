using PlannerApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApplication.Tests.Models
{
    public class ChecklistTests
{
    [Fact]
    public void Checklist_Title_Required()
    {
        // Arrange
        var checklist = new Checklist();

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(checklist, new ValidationContext(checklist), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, v => v.MemberNames.Contains("Title"));
    }

    [Fact]
    public void ChecklistItem_Description_Required()
    {
        // Arrange
        var checklistItem = new ChecklistItem();

        // Act
        var validationResults = new List<ValidationResult>();
        var isValid = Validator.TryValidateObject(checklistItem, new ValidationContext(checklistItem), validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Contains(validationResults, v => v.MemberNames.Contains("Description"));
    }

        [Fact]
        public void IChecklist_Interface_Contains_Id_Property()
        {
            // Arrange
            var checklist = new Checklist();

            // Act

            // Assert
            Assert.True(checklist is IChecklist);
            Assert.NotNull(typeof(IChecklist).GetProperty("Id"));
        }

        [Fact]
        public void IChecklist_Interface_Contains_Title_Property()
        {
            // Arrange
            var checklist = new Checklist();

            // Act

            // Assert
            Assert.True(checklist is IChecklist);
            Assert.NotNull(typeof(IChecklist).GetProperty("Title"));
        }

        [Fact]
        public void IChecklist_Interface_Contains_Items_Property()
        {
            // Arrange
            var checklist = new Checklist();

            // Act

            // Assert
            Assert.True(checklist is IChecklist);
            Assert.NotNull(typeof(IChecklist).GetProperty("Items"));
        }
    }
}