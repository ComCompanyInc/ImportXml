using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto
{
    [XmlRoot("packet")] // это корневой элемент в нашем XML
    public class DocumentDto<T>
    {
        [XmlElement("zglv")]
        public BaseDataDto BaseData { get; set; }

        [XmlElement("zap")]
        public List<T> ZapList { get; set; } = new List<T>();
    }
}
