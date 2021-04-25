using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Medyana.Services.Api.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string PolyclinicCode { get; set; }
        public int DoctorRegistryCode { get; set; }
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int CitizenshipNumber { get; set; }
        public int TelephoneNumber { get; set; }
        public DateTime VisitationDate { get; set; }
        public DateTime NextVisitationDate { get; set; }
        public string DoctorNote { get; set; }
    }

    public enum Gender
    {
        Female = 1,
        Male = 2,
        Unspecified = 3
    }
}
