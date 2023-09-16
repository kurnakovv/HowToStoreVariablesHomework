using HowToStoreVariablesHomework.Constants;
using HowToStoreVariablesHomework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HowToStoreVariablesHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImgController : ControllerBase
    {
        private readonly ImgConstants _imgConstants;

        public ImgController(
            ImgConstants imgConstants)
        {
            _imgConstants = imgConstants;
        }

        [HttpPost("Validate")]
        public ValidateImgsResponseModel Validate(List<string> imgs)
        {
            IEnumerable<string> invalidImgs = imgs.Where(x => !_imgConstants.Formats.Any(x.Contains));
            if (!invalidImgs.Any())
            {
                return new ValidateImgsResponseModel()
                {
                    IsValid = true,
                };
            }
            return new ValidateImgsResponseModel()
            {
                IsValid = false,
                InvalidImgs = invalidImgs.ToList(),
            };
        }

        [HttpGet("GetImgFormats")]
        public string GetImgFormats()
        {
            return $"Available photo formats: {string.Join(", ", _imgConstants.Formats)}";
        }
    }
}
