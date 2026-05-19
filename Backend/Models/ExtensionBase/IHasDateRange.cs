using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Backend.Models.ExtensionBase
{
    //Интерфейс для сущностей (для реализации унифицированного метода фильтрации по датам)
    public interface IHasDateRange
    {
        public DateTime DateBeg { get; set; }
        public DateTime? DateEnd { get; set; }
    }
}
