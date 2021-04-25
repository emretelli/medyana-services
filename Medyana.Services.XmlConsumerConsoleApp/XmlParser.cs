using Medyana.Services.XmlConsumerConsoleApp.Dtos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Medyana.Services.XmlConsumerConsoleApp
{
    public static class XmlParser
    {
        public static List<PatientEntity> ParseXmlFileToPatientList(string file)
        {
            List<PatientEntity> patientEntities = new List<PatientEntity>();

            XmlSerializer mySerializer = new XmlSerializer(typeof(PatientsXml));
            StreamReader streamReader = new StreamReader(file);

            var data = (PatientsXml)mySerializer.Deserialize(streamReader);
            streamReader.Close();
            List<PatientXml> patients = data.PatientList;

            foreach (var patient in patients)
            {
                var entity = new PatientEntity();
                entity.CitizenshipNumber = Convert.ToInt32(patient.CitizenshipNumber);
                entity.DateOfBirth = DateTime.ParseExact(patient.DateOfBirth, "dd.MM.yyyy", CultureInfo.InvariantCulture);
                entity.DoctorName = patient.DoctorName;
                entity.DoctorNote = patient.DoctorNote;
                entity.DoctorRegistryCode = Convert.ToInt32(patient.DoctorRegistryCode);
                entity.DoctorSurname = patient.DoctorSurname;
                entity.Gender = Enum.Parse<Gender>(patient.Gender);
                entity.Name = patient.Name;
                entity.NextVisitationDate = DateTime.ParseExact(patient.NextVisitationDate, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                entity.PolyclinicCode = patient.PolyclinicCode;
                entity.Surname = patient.Surname;
                entity.TelephoneNumber = Convert.ToInt32(patient.TelephoneNumber);
                entity.VisitationDate = DateTime.ParseExact(patient.VisitationDate, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
                patientEntities.Add(entity);
            }
            return patientEntities;
        }
    }
}
