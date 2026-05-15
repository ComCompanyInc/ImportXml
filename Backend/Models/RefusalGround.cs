using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BackendApp.Models
{
    public class RefusalGround
    {
        public long Id { get; set; }

        [StringLength(20, MinimumLength = 0, ErrorMessage = "Длинна основания отказа оплаты не должна превышать 20 символов")]
        public string Name { get; set; }
    }
}
