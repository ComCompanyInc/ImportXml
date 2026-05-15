using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class Person
    {
        public long Id { get; set; }

        [StringLength(40, MinimumLength = 0, ErrorMessage = "Имя не должно превышать 40 символов")]
        public string Name { get; set; }

        [StringLength(40, MinimumLength = 0, ErrorMessage = "Фамилия не должна превышать 40 символов")]
        public string Surname { get; set; }

        [StringLength(40, MinimumLength = 0, ErrorMessage = "Отчество не должно превышать 40 символов")]
        public string Patronymic { get; set; }

        public List<f002_smoEmp> F002_SmoEmps { get; set; } = new List<f002_smoEmp>();
    }
}
