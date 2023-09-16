using GenericEnv;
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
            string adminPasswordEnv = Environment.GetEnvironmentVariable("ADMIN__PASSWORD");
            int adminPassword = 0;
            if (adminPasswordEnv != null)
            {
                adminPassword = int.Parse(adminPasswordEnv);
            }
            else
            {
                adminPassword = _adminConstant.PASSWORD;
            }
            if (password != adminPassword)
            {
                return "You are not admin!";
            }
            return "Welcome, admin!";
        }
    }
}
