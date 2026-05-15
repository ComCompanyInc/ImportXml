using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class VedomType
    {
        public long Id { get; set; }

        [StringLength(254, MinimumLength = 0, ErrorMessage = "Имя типа ведомости (VedomType - Name) не должно превышать 254 символа")]
        public string Name { get; set; }

        public List<f007_Vedom> f007_Vedoms { get; set; } = new List<f007_Vedom>();
    }
}
