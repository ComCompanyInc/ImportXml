using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f015_okrug
{
    public class F15DataDto
    {
        [XmlElement("KOD_OK")]
        public string Code { get; set; }

        [XmlElement("OKRNAME")]
        public string DistrictName { get; set; }

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; }

        [XmlElement("DATEEND")]
        public string DateEnd { get; set; }
    }
}
