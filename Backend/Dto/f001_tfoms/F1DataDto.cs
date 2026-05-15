using BackendApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f001_tfoms
{
    public class F1DataDto
    {
        [XmlElement("tf_kod")]
        public string CodeTf { get; set; }

        [XmlElement("tf_okato")]
        public string Okato { get; set; }

        [XmlElement("tf_ogrn")]
        public string Ogrn { get; set; }

        [XmlElement("name_tfp")]
        public string OrgName { get; set; }

        [XmlElement("name_tfk")]
        public string orgShortName { get; set; }

        [XmlElement("index")]
        public string index { get; set; }

        [XmlElement("address")]
        public string AddressName { get; set; }

        [XmlElement("fam_dir")]
        public string PersonSurame { get; set; }

        [XmlElement("im_dir")]
        public string PersonName { get; set; }

        [XmlElement("ot_dir")]
        public string PersonPatronymic { get; set; }

        [XmlElement("phone")]
        public string Phone { get; set; }
        
        [XmlElement("fax")]
        public string Fax { get; set; }

        [XmlElement("hot_line")]
        public string HotLine { get; set; }

        [XmlElement("e_mail")]
        public string Email { get; set; }

        [XmlElement("kf_tf")]
        public int KfTf { get; set; }

        [XmlElement("www")]
        public string Site { get; set; }

        [XmlElement("MTR")]
        public Mtr MtrData { get; set; }

        public class Mtr
        {
            [XmlElement("bic")]
            public string Bic { get; set; }

            [XmlElement("inn")]
            public string Inn { get; set; }
            
            [XmlElement("kpp")]
            public string Kpp { get; set; }

            [XmlElement("kbk")]
            public string Kbk { get; set; }

            [XmlElement("oktmo")]
            public string Oktmo { get; set; }

            [XmlElement("MTR_POL")]
            public MtrPol MtrPolData;

            public class MtrPol
            {
                [XmlElement("L_NAIM")]
                public string RecieverName { get; set; }

                [XmlElement("L_B")]
                public string RecieverBank { get; set; }

                [XmlElement("L_RS")]
                public string RecieverRs { get; set; }
            }

            [XmlElement("MTR_PL")]
            public MtrPl MtrPlData;

            public class MtrPl
            {
                [XmlElement("T_NAIM")]
                public string SenderName { get; set; }

                [XmlElement("T_B")]
                public string SenderBank { get; set; }

                [XmlElement("T_RS")]
                public string SenderRs { get; set; }
            }
        }

        [XmlElement("d_edit")]
        public string DEdit { get; set; }

        [XmlElement("d_end")]
        public string DEnd { get; set; }

        [XmlElement("d_begin")]
        public string DBegin { get; set; }

        [XmlElement("no_smo")]
        public bool NoSmo { get; set; }
    }
}
