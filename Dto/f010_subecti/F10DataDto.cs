using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f010_subecti
{
    public class F10DataDto
    {
        [XmlElement("KOD_TF")]
        public string CodeTf { get; set; }

        [XmlElement("KOD_OKATO")]
        public string Okato { get; set; }

        [XmlElement("SUBNAME")]
        public string SubjectName { get; set; }

        [XmlElement("OKRUG")]
        public long DistrictCode { get; set; }

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; }

        [XmlElement("DATEEND")]
        public string? DateEnd { get; set; }
    }
}
