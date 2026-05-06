using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class Account
    {
        public long Id { get; set; }

        [StringLength(250, MinimumLength = 0, ErrorMessage = "Наименование отправителя/получателя не должно превышать 250 символов")]
        public string Name { get; set; } // наименование отправителя/получателя

        [StringLength(250, MinimumLength = 0, ErrorMessage = "Банк отправителя/получателя не должен превышать 100 символов")]
        public string Bank { get; set; } // банк отправителя/получателя

        [StringLength(20, MinimumLength = 0, ErrorMessage = "Рассчетный счет отправителя/получателя не должен превышать 20 символов")]
        public string Rs { get; set; }
    }
}
