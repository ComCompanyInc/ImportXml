using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f038_addrmp
{
    public class F38DataDto
    {
        [XmlElement("IDADDRESS")]
        public string Id { get; set; }

        [XmlElement("UIDMO")]
        public string F032_TrmosId { get; set; }

        [XmlElement("UIDSPMO")]
        public string F033_SpmosId { get; set; }

        [XmlElement("N_DOC")]
        public string LicenseNum { get; set; }

        [XmlElement("ADDR")]
        public string AddressName { get; set; }
        
        [XmlElement("ADDR_GAR")]
        public string AddressGar { get; set; }

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; }

        [XmlElement("DATEEND")]
        public string DateEnd { get; set; }
    }
}
