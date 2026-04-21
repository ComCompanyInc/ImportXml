using BackendApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f002_smo_emp
{

    public class InsCompany
    {
        [XmlElement("TF_OKATO")]
        public string Okato { get; set; }
        
        [XmlElement("smocod")]
        public string SmoCode { get; set; }

        [XmlElement("nam_smop")]
        public string OrgName { get; set; }

        [XmlElement("nam_smok")]
        public string OrgShortName { get; set; }

        [XmlElement("INN")]
        public string Inn { get; set; }

        [XmlElement("Ogrn")]
        public string Ogrn { get; set; }

        [XmlElement("KPP")]
        public string Kpp { get; set; }

        [XmlElement("jurAddress")]
        public JurAddress jurAddress { get; set; }

        // Вложенный класс-контейнер
        public class JurAddress
        {
            [XmlElement("INDEX_J")]
            public string IndexJ { get; set; }

            [XmlElement("ADDR_J")]
            public string AddrJ { get; set; }
        }

        [XmlElement("pstAddress")]
        public PstAddress pstAddress { get; set; }

        // Вложенный класс-контейнер
        public class PstAddress
        {
            [XmlElement("INDEX_F")]
            public string IndexF { get; set; }

            [XmlElement("addr_f")]
            public string AddrF { get; set; }
        }

        [XmlElement("OKOPF")]
        public string Okopf { get; set; }

        [XmlElement("fam_ruk")]
        public string PersonSurname { get; set; }

        [XmlElement("im_ruk")]
        public string PersonName { get; set; }

        [XmlElement("ot_ruk")]
        public string PersonPatronymic { get; set; }

        [XmlElement("Phone")]
        public string Phone { get; set; }

        [XmlElement("Fax")]
        public string Fax { get; set; }

        [XmlElement("hot_line")]
        public string HotLine { get; set; }

        [XmlElement("e_mail")]
        public string Email { get; set; }

        [XmlElement("WWW")]
        public string Site { get; set; }

        [XmlElement("licenziy")]
        public License license { get; set; }

        // Вложенный класс-контейнер
        public class License
        {
            [XmlElement("N_DOC")]
            public string LicNum { get; set; }

            [XmlElement("D_START")]
            public string DStart { get; set; }

            [XmlElement("DATE_E")]
            public string DateE { get; set; }

            [XmlElement("D_TERM")]
            public string DTerm { get; set; }
        }

        [XmlElement("ORG")]
        public EOrgType Org { get; set; }

        [XmlElement("insInclude")]
        public InsInclude insInclude { get; set; }

        // Вложенный класс-контейнер
        public class InsInclude
        {
            [XmlElement("d_begin")]
            public string DBegin { get; set; }

            [XmlElement("d_end")]
            public string DEnd { get; set; }

            [XmlElement("NAME_E")]
            public string NameE { get; set; }

            [XmlElement("NAL_P")]
            public string? NalP { get; set; }
        }

        [XmlElement("insAdvice")]
        public List<InsAdvice> insAdvices { get; set; } = new List<InsAdvice>();

        [XmlElement("D_EDIT")]
        public string DEdit { get; set; }
    }
}
