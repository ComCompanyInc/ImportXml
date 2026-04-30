using BackendApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f017_billtypes
{
    public class F17DataDto
    {
        [XmlElement("tf_okato")]
        public string Okato { get; set; }

        [XmlElement("orgType")]
        public EOrgType OrgType { get; set; }

        [XmlElement("billcod")]
        public string F012_TipSchId { get; set; }

        [XmlElement("bill_namp")]
        public string Name { get; set; }

        [XmlElement("bill_namk")]
        public string ShortName { get; set; }

        [XmlElement("datebeg")]
        public string DateBeg { get; set; }

        [XmlElement("dateend")]
        public string? DateEnd { get; set; }

        [XmlElement("IS_PAY")]
        public string BudgetSource { get; set; }
    }
}
