using BackendApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Text;

namespace BackendApp.Models
{
    public class f002_InsInclude
    {
        public long Id { get; set; }

        [StringLength(1, MinimumLength = 1, ErrorMessage = "Причина и основание исключения МО (NameE) - должно быть 1 символ")]
        public string NameE { get; set; }

        public string? NalP { get; set; }

        //public f002_smoEmp F002_SmoEmp { get; set; }
        //public long F002_SmoEmpId { get; set; }

        public DateTime? DBegin { get; set; }

        public DateTime? DEnd { get; set; }
    }
}
