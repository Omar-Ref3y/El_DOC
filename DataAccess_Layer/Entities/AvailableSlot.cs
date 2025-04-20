
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess_Layer.Entities
{
    public class AvailableSlot
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsBooked { get; set; }
        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
    }
}
