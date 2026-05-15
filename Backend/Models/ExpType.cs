using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class ExpType
    {
        public long Id { get; set; }
        
        [StringLength(1500, MinimumLength = 0, ErrorMessage = "Name (в ExpType) не должно превышать 1500 символов")]
        public string Name { get; set; }

        public List<f006_VidExp> F006_VidExps { get; set; } = new List<f006_VidExp>();
    }
}
