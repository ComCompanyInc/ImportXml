using BackendApp.Dto.f010_subecti;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f001_tfoms
{
    [XmlRoot("packet")]
    public class F1Document
    {
        [XmlAttribute("version")]  // Атрибут version из нашего корневого тэга packet
        public string Version { get; set; }

        [XmlAttribute("date")]     // Атрибут date из нашего корневого тэга packet
        public string Date { get; set; }

        [XmlElement("TFOMS")]
        public List<F1DataDto> F1Data = new List<F1DataDto>();
    }
}
