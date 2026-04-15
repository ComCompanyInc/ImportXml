using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class f038_addrmp
    {
        [Key]
        [StringLength(19, MinimumLength = 0, ErrorMessage = "Поле IDADDRESS (Id) должно содержать от 0 до 19 символов")]
        public string Id { get; set; } // IDADDRESS

        [StringLength(17, MinimumLength = 0, ErrorMessage = "Поле UIDMO (Id) должно содержать от 0 до 17 символов")]
        public string? F032_TrmoId { get; set; } // UIDMO
        public f032_trmo F032_Trmo { get; set; }

        [StringLength(17, MinimumLength = 0, ErrorMessage = "Поле UIDSPMO (Id) должно содержать от 0 до 17 символов")]
        public string? F033_SpmoId { get; set; } // UIDSPMO
        public f033_spmo F033_Spmo { get; set; }

        public License License { get; set; }
        public long LicenseId { get; set; } // N_DOC

        //[StringLength(32, MinimumLength = 0, ErrorMessage = "Поле N_DOC (LicenseNum) должно содержать от 0 до 32 символов")]
        //public string LicenseNum { get; set; } // N_DOC

        public long AddressId { get; set; }
        public Address Address { get; set; }

        public DateTime DateBeg { get; set; } // DATEBEG
        public DateTime DateEnd { get; set; } // DATEEND

        public long BaseDataId { get; set; }
        public BaseData BaseData { get; set; }
    }
}
