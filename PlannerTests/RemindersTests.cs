using PlannerApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlannerApplication.Tests.Models
{
    public class RemindersTests
    {
        [Fact]
        public void Title_RequiredAttribute_Validation()
        {
            // Arrange
            var reminder = new Reminders();

            // Act
            var validationResult = ValidateModel(reminder);

            // Assert
            Assert.Single(validationResult, v => v.MemberNames.Contains("Title"));
            Assert.Single(validationResult, v => v.ErrorMessage == "The Title field is required.");
        }

        [Fact]
        public void Date_DataTypeAttribute_Validation()
        {
            // Arrange
            var reminder = new Reminders { Title = "Test Reminder", Date = DateTime.Now };

            // Act
            var validationResult = ValidateModel(reminder);

            // Assert
            Assert.Empty(validationResult);
        }

        private static System.Collections.Generic.List<ValidationResult> ValidateModel(object model)
        {
            var validationResults = new System.Collections.Generic.List<ValidationResult>();
            var validationContext = new ValidationContext(model, serviceProvider: null, items: null);
            Validator.TryValidateObject(model, validationContext, validationResults, validateAllProperties: true);
            return validationResults;
        }
        [Fact]
        public void Reminders_Implements_IReminders_Interface()
        {
            // Arrange
            var reminders = new Reminders();

            // Act & Assert
            Assert.IsAssignableFrom<IReminders>(reminders);
        }
    }
}