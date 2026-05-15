using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f011_tipdoc
{
    public class F11DataDto
    {
        [XmlElement("IDDoc")]
        public long IdDoc { get; set; }

        [XmlElement("DocName")]
        public string Name { get; set; }

        [XmlElement("DocSer")]
        public string DocSer { get; set; }

        [XmlElement("DocNum")]
        public string DocNum { get; set; }

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; }

        [XmlElement("DATEEND")]
        public string? DateEnd { get; set; }
    }
}
