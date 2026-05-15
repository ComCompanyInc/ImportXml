using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class VidType
    {
        public long Id { get; set; }

        [StringLength(1000, MinimumLength = 0, ErrorMessage = "Вид медицинской организации (VidMo) - должна быть от 0 до 1000 символов")]
        public string Name { get; set; }

        public List<OrgDocument> MoDocuments { get; set; } = new List<OrgDocument>();
    }
}
