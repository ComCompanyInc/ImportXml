using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class f007_Vedom
    {
        [Key]
        public long VedId { get; set; }

        public long VedomTypeId { get; set; }
        public VedomType VedomType { get; set; }

        public long BaseDataId { get; set; }
        public BaseData BaseData { get; set; }

        public DateTime DateBeg { get; set; }

        public DateTime? DateEnd { get; set; }
    }
}
