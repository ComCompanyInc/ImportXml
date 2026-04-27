using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class StatType
    {
        public long Id { get; set; }

        [StringLength(254, MinimumLength = 0, ErrorMessage = "Статус работы (StatType -> StatusName) не должен превышать 254 символов")]
        public string StatusName { get; set; }

        public List<f009_StatZl> F009_StatZls { get; set; } = new List<f009_StatZl>();
    }
}
