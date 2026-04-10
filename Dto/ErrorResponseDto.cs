using System;
using System.Collections.Generic;
using System.Text;

namespace BackendApp.Dto
{
    public class ErrorResponseDto
    {
        public String ErrorMessage { get; set; }
        public Object ConflictObject { get; set; }
    }
}
