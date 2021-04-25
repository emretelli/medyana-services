using System.Collections.Generic;
using System.Xml.Serialization;

namespace Medyana.Services.XmlConsumerConsoleApp.Dtos
{
    [XmlRoot("patients")]
    public class PatientsXml
    {
        [XmlElement("patient")]
        public List<PatientXml> PatientList { get; set; }
    }
}
