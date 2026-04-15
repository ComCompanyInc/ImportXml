using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Models
{
    public class License
    {
        public long Id { get; set; }

        public DateTime? Dstart { get; set; }

        public DateTime? DateE { get; set; }

        public DateTime? Dterm { get; set; }

        public string LicenseNum { get; set; }

        List<f038_addrmp> F038_Addrmps { get; set; } = new List<f038_addrmp>();


    }
}
