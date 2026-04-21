using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Models
{
    public class f002_smo_insAdvice
    {
        public long Id { get; set; }

        public string YearWork { get; set; }

        public DateTime Duved { get; set; }

        public string? KolZl { get; set; }

        public DateTime DEdit { get; set; }

        public f002_smoEmp F002_SmoEmp { get; set; }
        public string F002_SmoEmpSmoCod { get; set; }
    }
}
