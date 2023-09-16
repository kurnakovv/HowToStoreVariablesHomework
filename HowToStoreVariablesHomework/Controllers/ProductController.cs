using GenericEnv;
using HowToStoreVariablesHomework.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HowToStoreVariablesHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpPost]
        public BuyProductResponseModel Buy(string productName)
        {
            // Buy product code...
            bool sendCheckByEmail = GenericEnvironment.GetEnvironmentVariable<bool>("SendCheckByEmail");
            if (sendCheckByEmail)
            {
                // Send check by email code...
            }
            return new BuyProductResponseModel
            {
                ProductName = productName,
                IsCheckSent = sendCheckByEmail,
            };
        }
    }
}
