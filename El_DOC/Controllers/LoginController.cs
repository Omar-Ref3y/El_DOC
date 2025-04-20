using Microsoft.AspNetCore.Mvc;

namespace Presentation_Layer.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
