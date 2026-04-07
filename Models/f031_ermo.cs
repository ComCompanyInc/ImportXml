using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackendApp.Models
{
    public class f031_ermo
    {
        [Key]
        [StringLength(17, MinimumLength = 0, ErrorMessage = "Длинна UIDMO (Id) должна быть от 0 до 17 символов")]
        public string Id { get; set; }

        public long MoDocumentId { get; set; }

        public MoDocument MoDocument { get; set; }

        public long AddressId { get; set; }
        public Address Address { get; set; }

        public DateTime DateBeg { get; set; }

        public DateTime DateEnd { get; set; }

        public long OrganizationId { get; set; }
        public Organization Organization { get; set; }

        // Коллекция для обратной навигации (основная связь)
        [InverseProperty(nameof(f032_trmo.F031_Ermo))]
        public List<f032_trmo> F032_Trmos { get; set; } = new List<f032_trmo>();

        public long BaseDataId { get; set; }
        public BaseData BaseData { get; set; }

        public long DocumentId { get; set; }
        public Document Document { get; set; }

        public long CommunicationId { get; set; }
        public Communication Communication { get; set; }
    }
}
