using LegacyApp;

namespace LegacyAppTests
{
    public class UserServiceTest
    {
        [Fact] // @Test w Javie
        public void Add_User_Should_When_Email_Without_At_And_Dot()
        {
            string firstName = "John";
            string lastName = "Doe";
            DateTime birthDate = new DateTime(year: 1980, month: 1, day: 1);
            int clientId = 1;
            string email = "doe";
            var service = new UserService();

            // Act
            bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);

            // Assert
            Assert.Equal(false, result);

        }

        [Fact]
        public void AddUser_Should_Return_False_When_Age_Less_Than_21()
        {
            // Arrange
            string firstName = "Jane";
            string lastName = "Doe";
            DateTime birthDate = new DateTime(year: 2010, month: 1, day: 1);
            int clientId = 2;
            string email = "doe2010@gmail.com";
            var service = new UserService();

            // Act
            bool result = service.AddUser(firstName, lastName, email, birthDate, clientId);

            // Assert
            Assert.Equal(false, result);
        }
    }
}
