using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f008_TipOms
{
    public class F8DataDto : IDictionaryTypesDto
    {
        [XmlElement("IDDOC")]
        public long Id { get; set; }

        [XmlElement("DOCNAME")]
        public string Name { get; set; }

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; }

        [XmlElement("DATEEND")]
        public string DateEnd { get; set; }
    }
}
