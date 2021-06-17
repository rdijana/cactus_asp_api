using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
   public class MarkDto
    {
        public int? Id { get; set; }
        public int Value { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
