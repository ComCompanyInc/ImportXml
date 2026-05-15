using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class PaymentStatus
    {
        public long Id { get; set; } // IDIDIST

        [StringLength(254, MinimumLength = 0, ErrorMessage = "Наименование статуса оплаты (StatusName) не должно превышать 254 символа")]
        public string StatusName { get; set; } //STNAME

        public List<f005_StatOpl> F005_StatOpls { get; set; } = new List<f005_StatOpl>();
    }
}
