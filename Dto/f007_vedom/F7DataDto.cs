using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f007_vedom
{
    public class F7DataDto
    {
        [XmlElement("IDVED")]
        public long VedId { get; set; }

        [XmlElement("VEDNAME")]
        public string VedName { get; set; }

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; }

        [XmlElement("DATEEND")]
        public string DateEnd { get; set; }
    }
}
