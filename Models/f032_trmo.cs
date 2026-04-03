using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackendApp.Models
{
    public class f032_trmo
    {
        public long Id { get; set; }

        // Первая связь с f031_ermo (основная)
        [ForeignKey(nameof(F031_Ermo))]
        public long? f031_ermoId { get; set; }
        [InverseProperty(nameof(f031_ermo.F032_Trmos))]
        public f031_ermo F031_Ermo { get; set; }

        public long OrganizationId { get; set; }
        public Organization Organization { get; set; }

        public long AddressId { get; set; }
        public Address Address { get; set; }

        public long DocumentId { get; set; }
        public Document Document { get; set; }

        public long OspTypeId { get; set; }
        public OspType OspType { get; set; }

        public DateTime ExclusionDate { get; set; }

        public DateTime InclusionDate { get; set; }

        // Вторая связь с f031_ermo (родительская)
        [ForeignKey(nameof(ParentIdMo))]
        public long? f031_ermoParentId { get; set; }
        public f031_ermo ParentIdMo { get; set; }

        [ForeignKey(nameof(Parent))]
        public long? ParentId { get; set; }
        public f032_trmo Parent { get; set; }

        public string MoDocumentId { get; set; }
        public MoDocument MoDocument { get; set; }

        public DateTime DateBeg { get; set; }

        public DateTime DateEnd { get; set; }

        public long CommunicationId { get; set; }
        public Communication Communication { get; set; }

        public long BaseDataId { get; set; }
        public BaseData BaseData { get; set; }

    }
}
