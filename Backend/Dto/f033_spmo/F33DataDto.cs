using BackendApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f033_spmo
{
    public class F33DataDto
    {
        [XmlElement("UIDSPMO")]
        public string Id { get; set; }

        [XmlElement("IDSPMO")]
        public string Code { get; set; }

        [XmlElement("NAM_SPMO")]
        public string Name { get; set; }

        [XmlElement("NAM_SK_SPMO")]
        public string ShortName { get; set; }

        [XmlElement("PHONE")]
        public string Phone { get; set; }

        [XmlElement("OSP")]
        public EOspType Osp { get; set; }

        [XmlElement("VID_SPMO")]
        public string VidType { get; set; }

        [XmlElement("OID_SPMO")]
        public string OidSpmo { get; set; }

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; }

        [XmlElement("DATEEND")]
        public string DateEnd { get; set; }
    }
}
