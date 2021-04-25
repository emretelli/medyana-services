using Ardalis.GuardClauses;
using Medyana.Services.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyana.Services.Api.Infrastructure
{
    public class PatientRepository : IRepository<Patient>
    {
        private readonly MedyanaContext _context;
        public PatientRepository(MedyanaContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Patient entity)
        {
            Guard.Against.Null(entity, nameof(entity));
            await _context.Patients.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(Patient entity)
        {
            Guard.Against.Null(entity, nameof(entity));
            _context.Patients.Remove(entity);
            _context.SaveChanges();
        }

        public async Task<Patient> GetAsync(long id)
        {
            Guard.Against.NegativeOrZero(id, nameof(id));
            return await _context.Patients.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        public void Update(Patient dbEntity, Patient entity)
        {
            Guard.Against.Null(dbEntity, nameof(dbEntity));
            Guard.Against.Null(entity, nameof(entity));
            dbEntity.CitizenshipNumber = entity.CitizenshipNumber;
            dbEntity.DateOfBirth = entity.DateOfBirth;
            dbEntity.DoctorName = entity.DoctorName;
            dbEntity.DoctorNote = entity.DoctorNote;
            dbEntity.DoctorRegistryCode = entity.DoctorRegistryCode;
            dbEntity.DoctorSurname = entity.DoctorSurname;
            dbEntity.Gender = entity.Gender;
            dbEntity.Name = entity.Name;
            dbEntity.NextVisitationDate = entity.NextVisitationDate;
            dbEntity.PolyclinicCode = entity.PolyclinicCode;
            dbEntity.Surname = entity.Surname;
            dbEntity.TelephoneNumber = entity.TelephoneNumber;
            dbEntity.VisitationDate = entity.VisitationDate;

            _context.SaveChanges();
        }
    }
}
