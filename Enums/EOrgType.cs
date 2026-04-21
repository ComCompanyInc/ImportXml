using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Enums
{
    public enum EOrgType
    {
        [XmlEnum("0")]
        FOMS = 0,

        [XmlEnum("1")]
        TFOMS = 1,

        [XmlEnum("2")]
        SMO = 2
    }
}
