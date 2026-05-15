using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class f017_BillTypes
    {
        public long Id { get; set; }

        public long BaseDataId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)] //ON DELETE NO ACTION и ON UPDATE NO ACTION
        public BaseData BaseData { get; set; }

        [StringLength(1, MinimumLength = 0, ErrorMessage = "Источник финансирования должен иметь только один символ")]
        public string? BudgetSource { get; set; } // IS_PAY

        public string f012_TipSchId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)] //ON DELETE NO ACTION и ON UPDATE NO ACTION
        public f012_TipSch f012_TipSch { get; set; }

        public long OrgTypeId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)] //ON DELETE NO ACTION и ON UPDATE NO ACTION
        public OrgType OrgType { get; set; }

        public long SubjectId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)] //ON DELETE NO ACTION и ON UPDATE NO ACTION
        public Subject Subject { get; set; }

        public DateTime DateBeg { get; set; }

        public DateTime? DateEnd { get; set; }
    }
}
