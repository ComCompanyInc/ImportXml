using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class VidMo
    {
        public long Id { get; set; }

        [StringLength(50, MinimumLength = 0, ErrorMessage = "Вид медицинской организации (VidMo) - должна быть от 0 до 1000 символов")]
        public string Name { get; set; }

        public List<MoDocument> MoDocuments { get; set; } = new List<MoDocument>();
    }
}
