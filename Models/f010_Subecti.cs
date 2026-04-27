using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class f010_Subecti
    {
        [Key]
        public long Id { get; set; }

        public long BaseDataId { get; set; }
        public BaseData BaseData { get; set; }

        [StringLength(2, MinimumLength = 0, ErrorMessage = "Длинна кода ТФОМС (CodeTf) не должна превышать 2х символов")]
        public string CodeTf { get; set; }

        public long SubjectId { get; set; }
        public Subject Subject { get; set; }

        public DateTime DateBeg { get; set; }

        public DateTime? DateEnd { get; set; }
    }
}
