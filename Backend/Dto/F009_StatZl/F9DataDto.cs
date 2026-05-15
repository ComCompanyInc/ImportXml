using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.F009_StatZl
{
    public class F9DataDto : IDictionaryTypesDto
    {
        [XmlElement("IDStatus")]
        public long Id { get; set; }

        [XmlElement("StatusName")]
        public string Name { get; set; }

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; }

        [XmlElement("DATEEND")]
        public string DateEnd { get; set; }
    }
}
