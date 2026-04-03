using BackendApp.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class Organization
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Имя организации обязательно")]
        [StringLength(2500, ErrorMessage = "Имя организации до 2500 символов")]
        public string Name { get; set; }

        [StringLength(250, ErrorMessage = "Сокращенное до 250 символов")]
        public string ShortName { get; set; }

        [Range(0, 9999, ErrorMessage = "Количество филиалов заполняется в диапазоне значений до четырехзначного числа")]
        public int? KfTf { get; set; }

        [StringLength(20, MinimumLength = 20, ErrorMessage = "Код бюджетной классификации (Kbk) - должно быть 20 цифр")]
        public String? Kbk { get; set; }

        public bool? NoSmo { get; set; } // 0 - не отображается 1 - отображается

        [StringLength(5, MinimumLength = 5, ErrorMessage = "Универсальный номер организации (OrgCode) - должно быть 5 символов")]
        public string? OrgCode { get; set; }

        [StringLength(6, MinimumLength = 6, ErrorMessage = "Реестровый номер МО (Mcod) - должно быть 6 символов")]
        public string? Mcod { get; set; } // реестровый номер МО - если организация - МО

        [StringLength(5, MinimumLength = 5, ErrorMessage = "Код организационно-правовой нормы (Okopf) - должно быть 5 символов")]
        public string Okopf { get; set; }

        [StringLength(1, MinimumLength = 1, ErrorMessage = "Причина и основание исключения МО (NameE) - должно быть 1 символ")]
        public String? NameE { get; set; }

        public ENalP? NalP { get; set; }

        [StringLength(2, MinimumLength = 2, ErrorMessage = "Ведомственная принадлежность (VedPri) - должна быть 2 символа")]
        public string? VedPri { get; set; }

        public long? OrgTypeId { get; set; }

        public OrgType? OrgType { get; set; }

        public List<f031_ermo> f031_Ermos { get; set; } = new List<f031_ermo>();

        public List<f032_trmo> f032_trmos { get; set; } = new List<f032_trmo>();
    }
}
