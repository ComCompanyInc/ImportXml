using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackendApp.Models
{
    public class f001_tfoms
    {
        public long Id { get; set; }

        public long BaseDataId { get; set; }
        public BaseData BaseData { get; set; }

        public long f010_SubectiId { get; set; }
        [DeleteBehavior(DeleteBehavior.Restrict)] //ON DELETE NO ACTION и ON UPDATE NO ACTION
        public f010_Subecti F010_Subecti { get; set; }

        public long AddressId { get; set; }
        public Address Address { get; set; }

        public long DocumentId { get; set; }
        public Document Document { get; set; }

        public long OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public long CommunicationId { get; set; }
        public Communication Communication { get; set; }

        public long SenderAccountId { get; set; }
        [ForeignKey(nameof(SenderAccountId))]
        [DeleteBehavior(DeleteBehavior.Restrict)] //ON DELETE NO ACTION и ON UPDATE NO ACTION
        public Account SenderAccount { get; set; }

        public long ReceiverAccountId { get; set; }
        [ForeignKey(nameof(ReceiverAccountId))]
        [DeleteBehavior(DeleteBehavior.Restrict)] //ON DELETE NO ACTION и ON UPDATE NO ACTION
        public Account ReceiverAccount { get; set; }

        public long PersonId { get; set; }
        public Person Person { get; set; }

        [StringLength(9, MinimumLength = 0, ErrorMessage = "БИК не должен превышать 9 символов")]
        public string Bic { get; set; }

        public DateTime? DEdit { get; set; }
        public DateTime? DEnd { get; set; }

        public DateTime DBegin { get; set; }

        public bool NoSmo { get; set; }
    }
}
