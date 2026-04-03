using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class Communication
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Телефон обязательно")]
        [StringLength(40, ErrorMessage = "Телефон до 40 символов")]
        [Phone(ErrorMessage = "Некорректный формат телефона")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Факс обязательно")]
        [StringLength(40, ErrorMessage = "Факс до 40 символов")]
        public string Fax { get; set; }

        [Required(ErrorMessage = "Эл. Почта обязательно")]
        [StringLength(40, ErrorMessage = "Эл. Почта до 50 символов")]
        [EmailAddress(ErrorMessage = "Некорректный формат email")]
        public string Email { get; set; }

        [StringLength(40, ErrorMessage = "Телефон горячей линии до 40 символов")]
        [Phone(ErrorMessage = "Некорректный формат телефона горячей линии")]
        public string? HotLine { get; set; }

        [Url(ErrorMessage = "Не корректный формат url сайта")]
        public string? Site { get; set; }

        List<f031_ermo> F031_Ermos { get; set; } = new List<f031_ermo>();
    }
}
