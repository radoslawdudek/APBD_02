using LegacyApp;

namespace LegacyAppTests
{
    public class UserServiceTest
    {
            [Fact] // @Test w Javie
            public void ValidateUserName_ValidNames_ReturnsTrue()
            {
                // Arrange
                var userService = new UserValidationService();

                // Act
                bool result = userService.IsFullNameValid("John", "Doe");

                // Assert
                Assert.Equal(true,result);
            }

            [Fact]
            public void ValidateUserName_EmptyFirstName_ReturnsFalse()
            {
                // Arrange
                var userService = new UserValidationService();

                // Act
                bool result = userService.IsFullNameValid("", "Doe");

                // Assert
                Assert.Equal(false, result);
            }

            [Fact]
            public void ValidateEmail_ValidEmail_ReturnsTrue()
            {
                // Arrange
                var userService = new UserValidationService();

                // Act
                bool result = userService.IsEmailValid("john.doe@example.com");

                // Assert
                Assert.Equal(true,result);
            }
            
            // Można więcej, ale chyba wystarczy
        }
    }
