using System;
using System.Collections.Generic;

namespace DataAccess_Layer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string PasswordHash { get; set; }
        public required string Email { get; set; }
        public required string Role { get; set; }
        public required string Sex { get; set; }
        public required DateTime DateOfBirth { get; set; }

        public Doctor? Doctor { get; set; }
        public Patient? Patient { get; set; }
    }
}
