using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f006_videxp
{
    public class F6DataDto
    {
        [XmlElement("IDVID")]
        public long VidId { get; set; }

        [XmlElement("VIDNAME")]
        public string VidName { get; set; }

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; }

        [XmlElement("DATEEND")]
        public string DateEnd { get; set; }
    }
}
