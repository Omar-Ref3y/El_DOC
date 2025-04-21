using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
    }
}
