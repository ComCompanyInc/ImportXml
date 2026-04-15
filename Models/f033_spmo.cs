using BackendApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class f033_spmo
    {
        [StringLength(17, MinimumLength = 0, ErrorMessage = "Ключ Id (UIDSPMO) должен иметь длинну от 0 до 17 символов")]
        public string Id { get; set; } // UIDSPMO

        [StringLength(17, MinimumLength = 0, ErrorMessage = "Поле Code (IDSPMO) должно иметь длинну от 0 до 100 символов")]
        public string Code { get; set; } // IDSMO

        [StringLength(4000, MinimumLength = 0, ErrorMessage = "Поле Name (NAM_SPMO) должно иметь длинну от 0 до 4000 символов")]
        public string? Name { get; set; } // NAM_SPMO

        [StringLength(4000, MinimumLength = 0, ErrorMessage = "Поле ShortName (NAM_SK_SPMO) должно иметь длинну от 0 до 4000 символов")]
        public string? ShortName { get; set; } // NAM_SK_SPMO

        public DateTime DateBeg { get; set; } // DateBeg

        public DateTime DateEnd { get; set; } // DateEnd

        public EOspType OspType { get; set; } // OSP
        public long OspTypeId { get; set; }

        public OrgDocument OrgDocument { get; set; } // VID_SPMO, OID_SPMO
        public long OrgDocumentId { get; set; }

        public Communication Communication { get; set; } // PHONE
        public long CommunicationId { get; set; }

        public long BaseDataId { get; set; }
        public BaseData BaseData { get; set; }

        public List<f038_addrmp> F038_Addrmp { get; set; } = new List<f038_addrmp>();
    }
}
