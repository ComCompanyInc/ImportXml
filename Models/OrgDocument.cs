using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class OrgDocument
    {
        [Key] // явно задаем ключ, тк название ключа некорректно для неявной пометки как ключ
        //[StringLength(17, MinimumLength = 17, ErrorMessage = "Реестровый номер МО (MoId) - должно быть 17 символов")]
        public long Id { get; set; }

        //[StringLength(50, MinimumLength = 0, ErrorMessage = "ИП, осуществляющего МД (OidMo) - должно быть от 0 до 50 символов")]
        //public string OidMo { get; set; }

        [StringLength(2, MinimumLength = 2, ErrorMessage = "Код формы собственности МО (Okfs) - должно быть 2 символа")]
        public string Okfs { get; set; }

        //public long? VidMoId { get; set; }
        public long? VidTypeId { get; set; }

        public VidType? VidTypes { get; set; }

        //[StringLength(50, MinimumLength = 0, ErrorMessage = "(OidSpmo) - должно быть от 0 до 50 символов")]
        //public string? OidSpmo { get; set; }

        public OidType? OidTypeMo { get; set; }
        public long? OidTypeMoId { get; set; }

        public OidType? OidTypeSpmo { get; set; }
        public long? OidTypeSpmoId { get; set; }

        public DateTime DateBeg { get; set; }

        public DateTime? DateEnd { get; set; }

        public List<f031_ermo> F031_Ermos = new List<f031_ermo>();
    }
}
