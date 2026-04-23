using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f008_TipOms
{
    public class F8DataDto
    {
        [XmlElement("IDDOC")]
        public long DocId { get; set; }

        [XmlElement("DOCNAME")]
        public string OmsTypeName { get; set; }

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; }

        [XmlElement("DATEEND")]
        public string DateEnd { get; set; }
    }
}
