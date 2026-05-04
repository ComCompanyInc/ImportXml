using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f014_oplotk
{
    public class F14DataDto
    {
        [XmlElement("Kod")]
        public int ErrorCode { get; set; }

        [XmlElement("IDVID")]
        public string Idvid { get; set; }

        [XmlElement("Naim")]
        public string RefusalReason { get; set; }

        [XmlElement("Osn")]
        public string RefusalGroundName { get; set; }

        [XmlElement("Komment")]
        public string OfficialComment { get; set; }

        [XmlElement("K_NO")]
        public string CoefNonPay { get; set; }

        [XmlElement("K_SH")]
        public string CoefForfeit { get; set; }

        [XmlElement("KodPG")]
        public string CodePG { get; set; }

        [XmlElement("DATEBEG")]
        public string DateBeg { get; set; }

        [XmlElement("DATEEND")]
        public string? DateEnd { get; set; }
    }
}
