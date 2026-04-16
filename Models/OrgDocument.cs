using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BackendApp.Models
{
    public class OrgDocument
    {
        [Key] // явно задаем ключ, тк название ключа некорректно для неявной пометки как ключ
        //[StringLength(17, MinimumLength = 17, ErrorMessage = "Реестровый номер МО (MoId) - должно быть 17 символов")]
        public long Id { get; set; }

        [StringLength(2, MinimumLength = 2, ErrorMessage = "Код формы собственности МО (Okfs) - должно быть 2 символа")]
        public string? Okfs { get; set; }

        public long? VidTypeId { get; set; }

        public VidType? VidTypes { get; set; }

        // Указываем, что это свойство связано с коллекцией MoOrgDocuments в таблице OidType
        [InverseProperty("MoOrgDocuments")]
        public OidType? OidTypeMo { get; set; }
        public long? OidTypeMoId { get; set; }

        // Указываем, что это свойство связано с коллекцией SpmoOrgDocuments в таблице OidType
        [InverseProperty("SpmoOrgDocuments")]
        public OidType? OidTypeSpmo { get; set; }
        public long? OidTypeSpmoId { get; set; }

        public DateTime DateBeg { get; set; }

        public DateTime? DateEnd { get; set; }

        public List<f031_ermo> F031_Ermos { get; set; } = new List<f031_ermo>();

        public List<f037_licmo> F037_Licmos { get; set; } = new List<f037_licmo>();
    }
}
