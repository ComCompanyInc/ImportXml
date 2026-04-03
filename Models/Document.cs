using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class Document
    {
        public long Id { get; set; }

        [StringLength(12, MinimumLength = 12, ErrorMessage = "ИНН (Inn) - должен быть 12 символов")]
        public string Inn { get; set; }

        [StringLength(15, MinimumLength = 15, ErrorMessage = "ОГРН (Ogrn) - должен быть 15 символов")]
        public string Ogrn { get; set; }

        [StringLength(9, MinimumLength = 9, ErrorMessage = "КПП (Kpp) - должен быть 9 символов")]
        public string Kpp { get; set; }

        List<f032_trmo> F032_Trmos { get; set; } = new List<f032_trmo>();

        List<f031_ermo> F031_Ermos { get; set; } = new List<f031_ermo>();
    }
}
