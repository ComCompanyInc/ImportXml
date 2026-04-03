using BackendApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Models
{
    public class OrgType
    {
        public long Id { get; set; }
        public EOrgType OrgTypeName { get; set; }

        public List<Organization> Organizations { get; set; } = new List<Organization>();
    }
}
