using DataAccess_Layer.Context;
using DataAccess_Layer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Presentation_Layer.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(String Email, String Password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Email && u.PasswordHash == Password);
            if (user != null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Invalid username or password";
            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user ,string roleSpecificFeild1,string roleSpecificFeild2 )
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Login");
        }


    }
}
