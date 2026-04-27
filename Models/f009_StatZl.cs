using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class f009_StatZl
    {
        [Key]
        public long StatusId { get; set; } // IDSTATUS

        public long BaseDataId { get; set; }
        public BaseData BaseData { get; set; }

        public long StatTypeId { get; set; }
        public StatType StatType { get; set; }

        public DateTime DateBeg { get; set; }

        public DateTime? DateEnd { get; set; }
    }
}
