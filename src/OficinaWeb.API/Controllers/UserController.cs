using Microsoft.AspNetCore.Mvc;
using OficinaWeb.Domain;

namespace OficinaWeb.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpPost]
        public IActionResult Login(User user)
        {
            return Ok(new { response = "Está logado" });
        }
    }
}