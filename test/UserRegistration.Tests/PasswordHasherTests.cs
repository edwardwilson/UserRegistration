namespace UserRegistration.Tests
{
    using System;
    using UserRegistration.Services;
    using Xunit;

    public class PasswordHasherTests
    {
        [Fact]
        public void HashPassword_ReturnsATuple_WithASaltAndPasswordHash()
        {
            // Arrange
            var password = "MySecurePassword";

            // Act
            var result = PasswordHasher.HashPassword(password);

            // Assert
            Assert.IsType<ValueTuple<string, string>>(result);
            Assert.False(string.IsNullOrWhiteSpace(result.salt));
            Assert.False(string.IsNullOrWhiteSpace(result.passwordHash));
        }
    }
}