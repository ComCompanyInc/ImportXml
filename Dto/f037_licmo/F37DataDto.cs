using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f037_licmo
{
    public class F37DataDto
    {
        [XmlElement("IDMO")]
        public string F031_ErmoId { get; set; }

        [XmlElement("OID_MO")]
        public string OidMo { get; set; }

        [XmlElement("MCOD")]
        public string MCode { get; set; }

        [XmlElement("UIDMO")]
        public string F032_TrmoId { get; set; }

        [XmlElement("N_DOC")]
        public string LicenseNum { get; set; }

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; }

        [XmlElement("DATEEND")]
        public string DateEnd { get; set; }
    }
}
