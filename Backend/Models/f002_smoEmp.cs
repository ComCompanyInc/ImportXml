using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class f002_smoEmp
    {
        [Key]
        [StringLength(5, MinimumLength = 0, ErrorMessage = "SmoCode (smocod) должно быть в диапазоне от 0 до 5 символов")]
        public string SmoCod { get; set; }

        public long AddressId { get; set; }
        public Address Address { get; set; }

        public long OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public long DocumentId { get; set; }
        public Document Document { get; set; }

        public long CommunicationId { get; set; }
        public Communication Communication { get; set; }

        public long PersonId { get; set; }
        public Person Person { get; set; }

        public long BaseDataId { get; set; }
        public BaseData BaseData { get; set; }

        public long LicenseId { get; set; }
        public License License { get; set; }

        public long F002_InsIncludeId { get; set; }
        public f002_InsInclude F002_InsInclude { get; set; }

        public List<f019_PersAccOrg> F019_PersAccOrgs { get; set; } = new List<f019_PersAccOrg>();

        public List<f002_smo_insAdvice> F002_Smo_InsAdvices { get; set; } = new List<f002_smo_insAdvice>();

        //public List<f002_InsInclude> F002_Smo_InsIncludes { get; set; } = new List<f002_InsInclude>();
    }
}
