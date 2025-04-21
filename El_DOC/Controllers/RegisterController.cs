using DataAccess_Layer.Entities;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto.Generators;
using BCrypt.Net;
using DataAccess_Layer.Context;
using System.Data.Entity;

namespace Presentation_Layer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly AppDbContext _context;

        public RegisterController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(User user, string specialization = "", string bio = "")
        {
            Console.WriteLine("Register Action Hit");

                // Check if email already exists
                if (_context.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View(user);
                }


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
                        IsAvailable = true,
                        DoctorImage = user.Sex == "male" ? "Man.png" : "Woman.png",
                    };
                Console.WriteLine(user.Sex);
                    Console.WriteLine($"Saving user {user.Name}, role: {user.Role}");
                    _context.Doctors.Add(doctor);
                    Console.WriteLine("Doctor or Patient object added");


                }
                else if (user.Role == "Patient")
                {
                    var Patient = new Patient
                    {
                        UserId = user.Id,
                        PatientImage = user.Sex == "male" ? "Man.png" : "Woman.png",
                    };
                    Console.WriteLine($"Saving user {user.Name}, role: {user.Role}");

                    _context.Patients.Add(Patient);
                    Console.WriteLine("Doctor or Patient object added");

                }
                await _context.SaveChangesAsync();
                return Redirect("Login");

        
           
        }

    }
}
