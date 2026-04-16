using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class OrgName
    {
        public long Id { get; set; }

        [StringLength(4000, MinimumLength = 0, ErrorMessage = "Некорреттная длинна наименования организации")]
        public string Name { get; set; }

        [StringLength(4000, MinimumLength = 0, ErrorMessage = "Некорреттная длинна короткого наименования организации")]
        public string ShortName { get; set; }

        List<Organization> Organizations { get; set; } = new List<Organization>();

        List<f033_spmo> F033_Spmo { get; set; } = new List<f033_spmo>();
    }
}
