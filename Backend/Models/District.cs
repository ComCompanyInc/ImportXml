using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class District
    {
        public long Id { get; set; }

        public long? Code { get; set; } // Код округа

        [StringLength(250, MinimumLength = 0, ErrorMessage = "Название округа (Name) - не должно превышать 250 символов")]
        public string? Name { get; set; }

        //public DateTime? DateBegin { get; set; }

        //public DateTime? DateEnd { get; set; }

        public long? SubjectId { get; set; }
        public Subject? Subject { get; set; }

        public List<Address> Addresses { get; set; } = new List<Address>();
    }
}
