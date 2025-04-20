using DataAccess_Layer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet <AvailableSlot> AvailableSlots { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=OMAR_REFAY;Database=ElDocDb;Trusted_Connection=True;MultipleActiveResultSets=true;trustservercertificate=true;Integrated Security=SSPI";
                optionsBuilder.UseSqlServer(connectionString).LogTo(Console.WriteLine, LogLevel.Information);
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // User <-> Doctor 1-to-1
            modelBuilder.Entity<User>()
                .HasOne(u => u.Doctor)
                .WithOne(d => d.User)
                .HasForeignKey<Doctor>(d => d.UserId)
                .OnDelete(DeleteBehavior.Cascade); // يمكنك الاحتفاظ بالحذف المتتالي هنا

            // User <-> Patient 1-to-1
            modelBuilder.Entity<User>()
                .HasOne(u => u.Patient)
                .WithOne(p => p.User)
                .HasForeignKey<Patient>(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade); // يمكنك الاحتفاظ بالحذف المتتالي هنا

            // Doctor <-> Appointment 1-to-many
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(a => a.DoctorId)
                .OnDelete(DeleteBehavior.NoAction); // استخدم NoAction لتجنب الحذف المتتالي

            // Patient <-> Appointment 1-to-many
            modelBuilder.Entity<Appointment>()
                .HasOne(a => a.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(a => a.PatientId)
                .OnDelete(DeleteBehavior.NoAction); // استخدم NoAction لتجنب الحذف المتتالي

            // Doctor <-> AvailableSlots 1-to-many
            modelBuilder.Entity<AvailableSlot>()
                .HasOne(s => s.Doctor)
                .WithMany(d => d.AvailableSlots)
                .HasForeignKey(s => s.DoctorId)
                .OnDelete(DeleteBehavior.Cascade); // أو استخدم NoAction إذا أردت تجنب الحذف المتتالي
        }
    }
}
