using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Models
{
    public class f019_PersAccOrg
    {
        public long Id { get; set; }

        public long? OrganizationId { get; set; }
        public Organization? Organization { get; set; }

        public long? AddressId { get; set; }
        public Address? Address { get; set; }

        public DateTime DateBeg { get; set; }

        public DateTime DateEnd { get; set; }

        public string F002_SmoEmpId { get; set; }
        public f002_smoEmp F002_SmoEmp { get; set; }
    }
}
