using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class Address
    {
        public long Id { get; set; }

        [StringLength(300, MinimumLength = 0, ErrorMessage = "Название адреса (Name) - не должно превышать 300 символов")]
        public string Name { get; set; }

        [StringLength(6, MinimumLength = 6, ErrorMessage = "Код почтового индекса (Index) - должен содержать 6 символов")]
        public string Index { get; set; }

        [StringLength(5, MinimumLength = 5, ErrorMessage = "Код ОКАТО (Okato) - должен содержать 5 символов")]
        public string? Okato { get; set; }

        [StringLength(11, MinimumLength = 11, ErrorMessage = "Код ОКТМО (Oktmo) - должен содержать 11 символов")]
        public string? Oktmo { get; set; }

        [StringLength(36, MinimumLength = 0, ErrorMessage = "Уникальный код адреса МО (AddressCode) - должен быть в диапазоне от 0 до 36 символов")]
        public string AddressCode { get; set; }

        public long? DistrictId { get; set; }
        public District? District { get; set; }

        public List<f031_ermo> F031_Ermos { get; set; } = new List<f031_ermo>();

        public List<f032_trmo> F032_Trmos { get; set; } = new List<f032_trmo>();

        public List<f038_addrmp> F038_Addrmp { get; set; } = new List<f038_addrmp>();
    }
}
