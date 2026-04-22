using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f005_statopl
{
    public class F5DataDto
    {
        [XmlElement("IDIDST")]
        public long StatusCode { get; set; }

        [XmlElement("STNAME")]
        public string StatusName { get; set; }

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; }

        [XmlElement("DATEEND")]
        public string DateEnd { get; set; }
    }
}
