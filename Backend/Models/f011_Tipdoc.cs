using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class f011_Tipdoc
    {
        public long Id { get; set; }

        public long F008_TipOmsId { get; set; }
        public f008_TipOms F008_TipOms { get; set; }

        [StringLength(10, MinimumLength = 0, ErrorMessage = "Серия документа (DocSer) не должна превышать 10 символов")]
        public string DocSer { get; set; }

        [StringLength(25, MinimumLength = 0, ErrorMessage = "Номер документа (DocNum) не должен превышать 25 символов")]
        public string DocNum { get; set; }
    }
}
