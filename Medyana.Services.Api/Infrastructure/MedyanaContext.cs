using Medyana.Services.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyana.Services.Api.Infrastructure
{
    public class MedyanaContext : DbContext
    {
        public MedyanaContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(entity =>
            {
                entity.Property(p => p.Id)
                .ValueGeneratedOnAdd();

                entity.Property(p => p.PolyclinicCode)
                .IsRequired()
                .HasMaxLength(4).IsFixedLength();

                entity.Property(p => p.DoctorRegistryCode)
                .IsRequired()
                .HasMaxLength(8).IsFixedLength();

                entity.Property(p => p.DoctorName)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(p => p.DoctorSurname)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(p => p.Name)
               .IsRequired()
               .HasMaxLength(50);

                entity.Property(p => p.Surname)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(p => p.DateOfBirth)
               .IsRequired()
               .HasColumnType("smalldatetime");

                entity.Property(p => p.Gender)
                .IsRequired()
                .HasComment("1-Kadın 2-Erkek 3-Belirtilmemiş");

                entity.Property(p => p.CitizenshipNumber)
                .IsRequired()
                .HasMaxLength(11).IsFixedLength();

                entity.Property(p => p.TelephoneNumber)
                .IsRequired()
                .HasMaxLength(10).IsFixedLength();

                entity.Property(p => p.VisitationDate)
                .IsRequired();
                
                entity.Property(p => p.DoctorNote)
                .HasMaxLength(1000);
            });
                
        }
    }
}
