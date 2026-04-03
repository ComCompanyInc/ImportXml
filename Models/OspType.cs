using BackendApp.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Models
{
    public class OspType
    {
        public long Id { get; set; }

        public EOspType Name { get; set; }

        public List<f032_trmo> F032_Trmos { get; set; } = new List<f032_trmo>();
    }
}
