using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Dto.SearchFilterDto
{
    public class BaseSearchFilterDto
    {
        public string SearchField { get; set; }
        public int page { get; set; }
        public int amountOfElements { get; set; }
    }
}
