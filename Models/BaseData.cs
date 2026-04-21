using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class BaseData
    {
        public long Id { get; set; }

        [StringLength(5, MinimumLength = 0, ErrorMessage = "Версия документа (Version) - должна быть заполнена в диапазоне от 0 до 5 символов")]
        public string Version { get; set; }
        
        [StringLength(20, MinimumLength = 0, ErrorMessage = "Тип документа (Type) - не должен превышать 20 символов")]
        public string? Type { get; set; }

        public DateTime Date { get; set; }

        public List<f031_ermo> F031_Ermos { get; set; } = new List<f031_ermo>();

        public List<f032_trmo> F032_Trmos { get; set; } = new List<f032_trmo>();

        public List<f002_smoEmp> F002_SmoEmps { get; set; } = new List<f002_smoEmp>();
    }
}
