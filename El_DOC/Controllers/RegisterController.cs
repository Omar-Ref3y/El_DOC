using DataAccess_Layer.Entities;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;
using DataAccess_Layer.Context;

namespace Presentation_Layer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AppDbContext _context;

        public RegisterController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user, string specialization = "", string bio = "")
        {
            Console.WriteLine("Register Action Hit");

            if (!ModelState.IsValid)
            {

            return View(user);
            }
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            if (user.Role == "Doctor")
            {
                var doctor = new Doctor
                {
                    Specialization = specialization,
                    Bio = bio,
                    UserId = user.Id,
                    IsAvailable = true
                };
                _context.Doctors.Add(doctor);
                
            }else if (user.Role == "Patient")
            {
                var Patient = new Patient
                {
                    UserId = user.Id,

                };
                _context.Patients.Add(Patient);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Login");
           
        }

    }
}
