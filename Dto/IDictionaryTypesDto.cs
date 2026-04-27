using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace BackendApp.Dto
{
    /// <summary>
    /// Dto Класс-каркасс для конкретной реализации в F005 до F009
    /// </summary>
    public interface IDictionaryTypesDto
    {
        long Id { get; set; }
        string Name { get; set; }
        string DateBeg { get; set; }
        string DateEnd { get; set; }
    }
}
