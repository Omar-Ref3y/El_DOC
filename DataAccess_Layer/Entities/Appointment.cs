using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace DataAccess_Layer.Entities
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        [ForeignKey(nameof(Patient))]
        public int PatientId { get; set; }
        [ForeignKey(nameof(Doctor))]
        public int DoctorId { get; set; }
        public AppointmentStatus Status{ get; set; }
        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
        public enum AppointmentStatus { Pending, Confirmed, Cancelled }
}
