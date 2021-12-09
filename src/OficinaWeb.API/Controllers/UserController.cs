using Microsoft.AspNetCore.Mvc;

namespace OficinaWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Login(string username, string password)
        {
            return Ok(new { Response = "Está logado" });
        }
    }
}