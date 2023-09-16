using HowToStoreVariablesHomework.Constants;
using HowToStoreVariablesHomework.Controllers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToStoreVariablesHomeworkTests.IntegrationTests
{
    public class ImgControllerTests
    {
        private readonly ImgConstants _imgConstants;

        public ImgControllerTests()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            _imgConstants = configuration.GetSection("Img").Get<ImgConstants>();
        }

        [Fact]
        public void Validate_CanValidateValidImgs_true()
        {
            // Arrange
            var imgs = new List<string>() { "first.png", "second.jpg", "third.gif" };

            // Act
            var result = new ImgController(_imgConstants).Validate(imgs);

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.InvalidImgs);
        }

        [Fact]
        public void Validate_CannotValidateInvalidImgsWithInvalidFormat_falseAndListOfInvalidImgs()
        {
            // Arrange
            var imgs = new List<string>() { "first.png", "second.jpg", "third.pdf" };

            // Act
            var result = new ImgController(_imgConstants).Validate(imgs);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotNull(result.InvalidImgs);
            Assert.Contains("third.pdf", result.InvalidImgs.First());
        }

        [Fact]
        public void GetImgFormats_ReturnImgFormats_ImgFormats()
        {
            // Act
            var result = new ImgController(_imgConstants).GetImgFormats();

            // Assert
            Assert.Equal("Available photo formats: png, jpg, gif", result);
        }
    }
}
