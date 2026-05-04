using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class f014_OplOtk
    {
        public long Id { get; set; }

        [Range(0, 999, ErrorMessage = "Код ошибки не должен превышать трехзначное число")]
        public int ErrorCode { get; set; }

        public long BaseDataId { get; set; }
        public BaseData BaseData { get; set; }

        public long? f006_VidExpVidId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)] //ON DELETE NO ACTION и ON UPDATE NO ACTION
        public f006_VidExp? F006_VidExp { get; set; }

        public long RefusalGroundId { get; set; }
        public RefusalGround RefusalGround { get; set; }

        [StringLength(1000, MinimumLength = 0, ErrorMessage = "Причина отказа оплаты не должна превышать 1000 символов")]
        public string? RefusalReason { get; set; }

        [StringLength(100, MinimumLength = 0, ErrorMessage = "Служебный комментарий не должен превышать 100 символов")]
        public string? OfficialComment { get; set; }

        public decimal? CoefNonPay { get; set; }

        public decimal? CoefForfeit { get; set; }

        [StringLength(20, MinimumLength = 0, ErrorMessage = "Код по форме N ПГ не должен превышать 20 символов")]
        public string? CodePG { get; set; }

        public DateTime DateBeg { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
