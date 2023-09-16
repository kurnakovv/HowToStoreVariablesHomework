using HowToStoreVariablesHomework.Secrets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HowToStoreVariablesHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly AdminConstant _adminConstant;

        public AdminController(
            AdminConstant adminConstant)
        {
            _adminConstant = adminConstant;
        }

        [HttpPost]
        public string Login(int password)
        {
            if (password != _adminConstant.PASSWORD)
            {
                return "You are not admin!";
            }
            return "Welcome, admin!";
        }
    }
}
