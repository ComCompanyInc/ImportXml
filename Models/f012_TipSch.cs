using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class f012_TipSch
    {
        [Key]
        [StringLength(2, MinimumLength = 0, ErrorMessage = "Номер счета (SchId) не должен превышать длинну в 2 символа")]
        public string SchId { get; set; }

        public long BaseDataId { get; set; }
        public BaseData BaseData { get; set; }

        [StringLength(254, MinimumLength = 0, ErrorMessage = "Полное наименование типа счета не должно превышать 254 символов")]
        public string Name { get; set; }

        [StringLength(254, MinimumLength = 0, ErrorMessage = "Краткое наименование типа счета не должно превышать 254 символов")]
        public string ShortName { get; set; }

        public DateTime DateBeg { get; set; }

        public DateTime? DateEnd { get; set; }
    }
}
