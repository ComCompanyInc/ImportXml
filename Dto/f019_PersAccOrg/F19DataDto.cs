using BackendApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto.f019_PersAccOrg
{
    public class F19DataDto
    {
        [XmlElement("tf_okato")]
        public string TfOkato { get; set; }

        [XmlElement("orgtype")]
        public EOrgType OrgType { get; set; }

        [XmlElement("orgcod")]
        public string OrgCode { get; set; }

        [XmlElement("nam_orgp")]
        public string OrgName { get; set; }

        [XmlElement("nam_orgk")]
        public string OrgNameShort { get; set; }

        [XmlElement("smocod")]
        public string SmoCode { get; set; }
    }
}
