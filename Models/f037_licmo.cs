using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class f037_licmo
    {
        public long Id { get; set; }

        [StringLength(17, MinimumLength = 0, ErrorMessage = "Длинна UIDMO (F031_ErmoId) должна быть от 0 до 17 символов")]
        public string? F031_ErmoId { get; set; }
        public f031_ermo? F031_Ermo { get; set; }

        public long? OrgDocumentId { get; set; }
        public OrgDocument OrgDocument { get; set; }

        public long? OrganizationId { get; set; }
        public Organization Organization { get; set; }

        [StringLength(17, MinimumLength = 0, ErrorMessage = "Поле UIDMO (F032_TrmoId) должно содержать от 0 до 17 символов")]
        public string? F032_TrmoId { get; set; }
        public f032_trmo? F032_Trmo { get; set; }

        public long LicenseId { get; set; }
        public License License { get; set; }

        public DateTime DateBeg { get; set; }
        public DateTime DateEnd { get; set; }
    }
}
