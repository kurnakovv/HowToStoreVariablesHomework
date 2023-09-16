using HowToStoreVariablesHomework.Constants;
using HowToStoreVariablesHomework.Controllers;
using HowToStoreVariablesHomework.Secrets;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToStoreVariablesHomeworkTests.IntegrationTests
{
    public class AdminControllerTest
    {
        private readonly AdminConstant _adminConstant;

        public AdminControllerTest()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<Program>();
            var configuration = builder.Build();
            _adminConstant = configuration.GetSection("ADMIN").Get<AdminConstant>();
        }

        [Fact]
        public void Login_CanLoginIfPasswordIsValid_WelcomeAdmin()
        {
            // Act
            var result = new AdminController(_adminConstant).Login(12345);

            // Assert
            Assert.Equal("Welcome, admin!", result);
        }

        [Fact]
        public void Login_CannotLoginIfPasswordIsInvalid_YouAreNotAdmin()
        {
            // Act
            var result = new AdminController(_adminConstant).Login(123);

            // Assert
            Assert.Equal("You are not admin!", result);
        }
    }
}
