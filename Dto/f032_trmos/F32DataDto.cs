using BackendApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f032_trmos
{
    public class F32DataDto
    {
        [XmlElement("UIDMO")]
        public string Id { get; set; } //f032_trmo.Id

        [XmlElement("IDMO")]
        public string F031_ErmosId { get; set; } //f031_ermo.Id

        [XmlElement("MCOD")]
        public string Mcod { get; set; } // Organization.Mcod

        [XmlElement("OKTMO_P")]
        public string Oktmo { get; set; } // Address.Oktmo

        [XmlElement("SUBJ")]
        public string Subject { get; set; } // Address.District.Subject.Name

        [XmlElement("D_BEGIN")]
        public string InclusionDate { get; set; } // f032_trmo.inclusionDate
        
        [XmlElement("D_BEGIN_OMS")]
        public string DateBeginOms { get; set; } // f032_trmo.DateBeginOms

        [XmlElement("D_END")]
        public string ExclusionDate { get; set; } // f032_trmo.exclusionDate

        [XmlElement("NAME_E")]
        public string NameE { get; set; } // Organization.NameE

        [XmlElement("OSP")]
        public EOspType Osp { get; set; } // Organization.OspType.Name

        [XmlElement("PARENT_IDMO")]
        public string ParentIdMo { get; set; } // f031_trmo.Id

        [XmlElement("PARENT_UIDMO")]
        public string ParentId { get; set; } // f032_trmo.Id

        [XmlElement("VID_MO")]
        public string VidMo { get; set; } // MoDocument.VidMo

        [XmlElement("OID_MO")]
        public string OidMo { get; set; } // MoDocument.OidMo

        [XmlElement("OID_SPMO")]
        public string OidSpmo { get; set; } // MoDocument.OidSpmo

        [XmlElement("NAM_MOP")]
        public string OrgName { get; set; } // Organization.Name

        [XmlElement("NAM_MOK")]
        public string OrgShortName { get; set; } // Organization.ShortName

        [XmlElement("INN")]
        public string Inn { get; set; } // Document.Inn

        [XmlElement("KPP")]
        public string Kpp { get; set; } // Document.Kpp

        [XmlElement("OGRN")]
        public string Ogrn { get; set; } // Document.Ogrn

        [XmlElement("JURADDRESS_INDEX")]
        public string Index { get; set; } // Address.Index

        [XmlElement("JURADDRESS_ADDRESS")]
        public string AddressName { get; set; } // Address.Name

        [XmlElement("GAR_ADDRESS")]
        public string AddressCode { get; set; } // Address.Name

        [XmlElement("OKFS")]
        public string Okfs { get; set; } // MoDocument.Okfs
       
        [XmlElement("VEDPRI")]
        public string VedPri { get; set; } // Organization.VedPri

        [XmlElement("PHONE")]
        public string Phone { get; set; } // Communication.Phone

        [XmlElement("FAX")]
        public string Fax { get; set; } // Communication.Fax

        [XmlElement("EMAIL")]
        public string Email { get; set; } // Communication.Email

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; } // f032_trmo.DateBeg

        [XmlElement("DATEEND")]
        public string DateEnd { get; set; } // f032_trmo.DateEnd
    }
}
