using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f002_smo_emp
{
    [XmlRoot("PACKET", Namespace = "")]
    public class F2DataDto
    {
        [XmlElement("VERSION")]
        public string Version { get; set; }

        [XmlElement("DATE")]
        public string Date { get; set; }

        [XmlElement("insCompany")]
        public List<InsCompany> InsCompanies { get; set; } = new List<InsCompany>();
    }
}
