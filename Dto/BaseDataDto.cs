using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto
{
    public class BaseDataDto
    {
        [XmlElement("type")]
        public string Type { get; set; }

        [XmlElement("version")]
        public string Version { get; set; }

        [XmlElement("date")]
        public string Date { get; set; }
    }
}
