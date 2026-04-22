using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class f005_StatOpl
    {
        [Key]
        public long StatusCode { get; set; } // IDIDIST

        public DateTime DateBeg { get; set; }

        public DateTime? DateEnd { get; set; }

        public PaymentStatus PaymentStatus { get; set; }
        public long PaymentStatusId { get; set; }

        public BaseData BaseData { get; set; }
        public long BaseDataId { get; set; }
    }
}
