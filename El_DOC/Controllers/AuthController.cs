using DataAccess_Layer.Context;
using DataAccess_Layer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;
using static Microsoft.Graph.CoreConstants;

namespace Presentation_Layer.Controllers
{
    public class AuthController : Controller
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Login(string Email, string Password)
        //{
        //    var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Email && u.PasswordHash == Password);
        //    if (user != null)
        //    {
        //        return RedirectToAction("Index", "Home");
        //    }
        //    ViewBag.Error = "Invalid username or password";
        //    return View();
        //}

       



    }
}
