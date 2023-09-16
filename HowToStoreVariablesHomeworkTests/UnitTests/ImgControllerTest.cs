using HowToStoreVariablesHomework.Constants;
using HowToStoreVariablesHomework.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HowToStoreVariablesHomeworkTests.UnitTests
{
    public class ImgControllerTest
    {
        [Fact]
        public void Validate_CanValidateValidImgs_true()
        {
            // Arrange
            var imgs = new List<string>() { "first.png", "second.jpg", "third.gif" };
            var imgConstants = new ImgConstants()
            {
                Formats = new List<string>
                {
                    "png", "jpg", "gif",
                }
            };

            // Act
            var result = new ImgController(imgConstants).Validate(imgs);

            // Assert
            Assert.True(result.IsValid);
            Assert.Null(result.InvalidImgs);
        }

        [Fact]
        public void Validate_CannotValidateInvalidImgsWithInvalidFormat_falseAndListOfInvalidImgs()
        {
            // Arrange
            var imgs = new List<string>() { "first.png", "second.jpg", "third.pdf" };
            var imgConstants = new ImgConstants()
            {
                Formats = new List<string>
                {
                    "png", "jpg", "gif",
                }
            };

            // Act
            var result = new ImgController(imgConstants).Validate(imgs);

            // Assert
            Assert.False(result.IsValid);
            Assert.NotNull(result.InvalidImgs);
            Assert.Contains("third.pdf", result.InvalidImgs.First());
        }

        [Fact]
        public void GetImgFormats_ReturnImgFormats_ImgFormats()
        {
            // Arrange
            var imgConstants = new ImgConstants()
            {
                Formats = new List<string>
                {
                    "png", "jpg", "gif",
                }
            };

            // Act
            var result = new ImgController(imgConstants).GetImgFormats();

            // Assert
            Assert.Equal("Available photo formats: png, jpg, gif", result);
        }
    }
}
