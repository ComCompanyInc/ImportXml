using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Enums
{
    public enum ENalP
    {
        [XmlEnum("1")]
        HAVE_INSURANCE_POLICY = 1,

        [XmlEnum("2")]
        HAVE_NO_INSURANCE_POLICY = 2
    }
}
