using Microsoft.AspNetCore.Mvc;

namespace OficinaWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}