using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto
{
    public class MoDataDto
    {
        [XmlElement("IDMO")]
        public string MoId { get; set; }

        [XmlElement("NAM_MOP")]
        public string Name { get; set; }

        [XmlElement("NAM_MOK")]
        public string ShortName { get; set; }

        [XmlElement("INN")]
        public string Inn { get; set; }

        [XmlElement("KPP")]
        public string Kpp { get; set; }

        [XmlElement("OGRN")]
        public string Ogrn { get; set; }

        [XmlElement("OID_MO")]
        public string OidMo { get; set; }

        [XmlElement("OKOPF")]
        public string Okopf { get; set; }

        [XmlElement("OKFS")]
        public string Okfs { get; set; }

        [XmlElement("ADDR_J")]
        public string FullAddressName { get; set; }

        [XmlElement("ADDR_J_GAR")]
        public string AddressCode { get; set; }

        [XmlElement("OKTMO")]
        public string Oktmo { get; set; }

        [XmlElement("EMAIL")]
        public string Email { get; set; }

        [XmlElement("PHONE")]
        public string Phone { get; set; }

        [XmlElement("FAX")]
        public string Fax { get; set; }

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; }

        [XmlElement("DATEEND")]
        public string DateEnd { get; set; }
    }
}
