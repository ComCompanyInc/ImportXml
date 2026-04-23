using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class f008_TipOms
    {
        [Key]
        public long DocId { get; set; }

        public long BaseDataId { get; set; }
        public BaseData BaseData { get; set; }

        public long OmsTypeId { get; set; }
        public OmsType OmsType { get; set; }

        public DateTime DateBeg { get; set; }

        public DateTime? DateEnd { get; set; }
    }
}
