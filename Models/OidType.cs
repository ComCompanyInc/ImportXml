using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class OidType
    {
        public long Id { get; set; }

        [StringLength(1000, MinimumLength = 0, ErrorMessage = "Поле Oid (Name) - должно быть от 0 до 1000 символов")]
        public string Name { get; set; }

        public List<OrgDocument> OrgDocuments = new List<OrgDocument>();
    }
}
