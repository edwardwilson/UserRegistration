namespace UserRegistration.Tests
{
    using Microsoft.AspNetCore.Mvc;
    using UserRegistration.Controllers;
    using UserRegistration.Models;
    using Xunit;

    public class UsersControllerTests
    {
        [Fact]
        public void Register_ReturnsAViewResult_WithAUserViewModel()
        {
            // Arrange
            var controller = new UsersController(null);

            // Act
            var result = controller.Register();

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<UserViewModel>(((ViewResult) result).ViewData.Model);
        }
    }
}