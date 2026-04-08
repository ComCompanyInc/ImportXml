using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Enums
{
    public enum EOspType
    {
        [XmlEnum("0")]
        HEADQUARTER = 0, // головная организация

        [XmlEnum("1")]
        SEPARATE_STRUCT_DIVISION = 1, // обособленное структурное подразделение
    }
}
