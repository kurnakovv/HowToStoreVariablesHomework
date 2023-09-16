using HowToStoreVariablesHomework.Constants;
using HowToStoreVariablesHomework.Controllers;
using HowToStoreVariablesHomework.Secrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToStoreVariablesHomeworkTests.UnitTests
{
    public class AdminControllerTest
    {
        [Fact]
        public void Login_CanLoginIfPasswordIsValid_WelcomeAdmin()
        {
            // Arrange
            var adminConstants = new AdminConstant
            {
                PASSWORD = 12345
            };

            // Act
            var result = new AdminController(adminConstants).Login(12345);

            // Assert
            Assert.Equal("Welcome, admin!", result);
        }

        [Fact]
        public void Login_CannotLoginIfPasswordIsInvalid_YouAreNotAdmin()
        {
            // Arrange
            var adminConstants = new AdminConstant
            {
                PASSWORD = 12345
            };

            // Act
            var result = new AdminController(adminConstants).Login(123);

            // Assert
            Assert.Equal("You are not admin!", result);
        }
    }
}
