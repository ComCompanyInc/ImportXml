using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f005_statopl
{
    public class F5DataDto : IDictionaryTypesDto
    {
        [XmlElement("IDIDST")]
        public long Id { get; set; }

        [XmlElement("STNAME")]
        public string Name { get; set; }

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; }

        [XmlElement("DATEEND")]
        public string DateEnd { get; set; }
    }
}
