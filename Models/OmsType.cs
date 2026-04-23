using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace BackendApp.Models
{
    public class OmsType
    {
        public long Id { get; set; }

        [StringLength(254, MinimumLength = 0, ErrorMessage = "Наименование типа ОМС (OmsType -> Name) не должна превышать 254 символа")]
        public string Name { get; set; }

        public List<f008_TipOms> f008_TipOms { get; set; } = new List<f008_TipOms>();
    }
}
