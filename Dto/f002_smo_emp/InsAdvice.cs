using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f002_smo_emp
{
    public class InsAdvice
    {
        [XmlElement("YEAR_WORK")]
        public string YearWork { get; set; }

        [XmlElement("DUVED")]
        public string Duved { get; set; }

        [XmlElement("KOL_ZL")]
        public string? KolZl { get; set; }
    }
}
