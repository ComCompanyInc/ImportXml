using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto
{
    [XmlRoot("packet")] // это корневой элемент в нашем XML
    public class f031_ermoDto
    {
        [XmlElement("zglv")]
        public BaseDataDto BaseData { get; set; }

        [XmlElement("zap")]
        public List<MoDataDto> ZapList { get; set; } = new List<MoDataDto>();
    }
}
