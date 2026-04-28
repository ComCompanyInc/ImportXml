using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f012_tipsch
{
    public class F12DataDto
    {
        [XmlElement("IDSch")]
        public string SchId { get; set; }

        [XmlElement("SchNameP")]
        public string Name { get; set; }

        [XmlElement("SchNameK")]
        public string ShortName { get; set; }

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; }

        [XmlElement("DATEEND")]
        public string DateEnd { get; set; }
    }
}
