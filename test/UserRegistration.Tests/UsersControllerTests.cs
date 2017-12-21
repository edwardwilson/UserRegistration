namespace UserRegistration.Tests
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using UserRegistration.Controllers;
    using UserRegistration.Models;
    using UserRegistration.Services;
    using Xunit;

    public class UsersControllerTests
    {
        [Fact]
        public void Register_ReturnsAViewResult_WithAUserViewModel()
        {
            // Arrange
            var controller = new UsersController(null, null);

            // Act
            var result = controller.Register();

            // Assert
            Assert.IsType<ViewResult>(result);
            Assert.IsAssignableFrom<UserViewModel>(((ViewResult) result).ViewData.Model);
        }

        [Fact]
        public void Register_ReturnsModelStateError_WithInvalidModel()
        {
            // Arrange
            var userStoreMoq = new Moq.Mock<IUserStore>();
            var loggerMoq = new Moq.Mock<ILogger<UsersController>>();

            var controller = new UsersController(userStoreMoq.Object, loggerMoq.Object);

            // Act
            var result = controller.Register(new UserViewModel{ Password = "MyPassword1"});

            // Assert
            // This doesn't seem to work; could be a bug with .net core
            Assert.False(((ViewResult)result).ViewData.ModelState.IsValid);
        }
    }
}