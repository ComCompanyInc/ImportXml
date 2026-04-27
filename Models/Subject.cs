using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class Subject
    {
        public long Id { get; set; }

        [StringLength(5, MinimumLength = 5, ErrorMessage = "Код ОКАТО (Okato) - должен содержать 5 символов")]
        public string? Okato { get; set; }

        [StringLength(250, MinimumLength = 0, ErrorMessage = "Наименование субьекта РФ (Name) - не должно превышать 250 символов")]
        public string Name { get; set; }

        List<District> Districts { get; set; } = new List<District>();
    }
}
