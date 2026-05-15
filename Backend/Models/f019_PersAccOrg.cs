using Microsoft.EntityFrameworkCore;
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

        //public long? AddressId { get; set; }
        //public Address? Address { get; set; }

        public DateTime DateBeg { get; set; }

        public DateTime? DateEnd { get; set; }

        public string? F002_SmoEmpId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)] //ON DELETE NO ACTION и ON UPDATE NO ACTION
        public f002_smoEmp? F002_SmoEmp { get; set; }

        public long F001_TfomsId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)] //ON DELETE NO ACTION и ON UPDATE NO ACTION
        public f001_tfoms F001_Tfoms { get; set; }

        //public long F010_SubectiId { get; set; }
        //public f010_Subecti F010_Subecti { get; set; }

        public long SubjectId { get; set; }
        public Subject Subject { get; set; }
    }
}
