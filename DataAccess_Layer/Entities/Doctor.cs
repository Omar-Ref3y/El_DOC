
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess_Layer.Entities
{
    public class Doctor
    {
        public int Id { get; set; }
        public required string Specialization { get; set; }
        public bool IsAvailable { get; set; }
        public required string Bio { get; set; }
        public  string? DoctorImage { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<AvailableSlot> AvailableSlots { get; set; } = new List<AvailableSlot>();

    }
}
