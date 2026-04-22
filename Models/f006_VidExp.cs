using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class f006_VidExp
    {
        [Key]
        public long VidId { get; set; } // IDVID

        public long BaseDataId { get; set; }
        public BaseData BaseData { get; set; }

        public long ExpTypeId { get; set; }
        public ExpType ExpType { get; set; }

        public DateTime DateBeg { get; set; }

        public DateTime? DateEnd { get; set; }
    }
}
