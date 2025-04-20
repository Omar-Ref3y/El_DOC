
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess_Layer.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string? PatientImage { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>(); 
    }
}
