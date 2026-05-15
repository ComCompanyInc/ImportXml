using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class f015_Okrug
    {
        [Key]
        [StringLength(4, MinimumLength = 0, ErrorMessage = "Код региона (округа) не должен превышать 4х символов")]
        public string Code { get; set; } // код района (KOD_OK)

        public long BaseDataId { get; set; }
        public BaseData BaseData { get; set; }

        public long DistrictId { get; set; }
        public District District { get; set; }

        public DateTime DateBeg { get; set; }

        public DateTime? DateEnd { get; set; }
    }
}
