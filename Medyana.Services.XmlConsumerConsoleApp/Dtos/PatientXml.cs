using System.Xml.Serialization;

namespace Medyana.Services.XmlConsumerConsoleApp.Dtos
{
    public class PatientXml
    {
        [XmlElement("polycliniccode")]
        public string PolyclinicCode { get; set; }

        [XmlElement("doctorregistrycode")]
        public string DoctorRegistryCode { get; set; }

        [XmlElement("doctorname")]
        public string DoctorName { get; set; }

        [XmlElement("doctorsurname")]
        public string DoctorSurname { get; set; }

        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("surname")]
        public string Surname { get; set; }

        [XmlElement("dateofbirth")]
        public string DateOfBirth { get; set; }

        [XmlElement("gender")]
        public string Gender { get; set; }

        [XmlElement("citizenshipnumber")]
        public string CitizenshipNumber { get; set; }

        [XmlElement("telephonenumber")]
        public string TelephoneNumber { get; set; }

        [XmlElement("visitationdate")]
        public string VisitationDate { get; set; }

        [XmlElement("nextvisitationdate")]
        public string NextVisitationDate { get; set; }

        [XmlElement("doctornote")]
        public string DoctorNote { get; set; }
    }
}
