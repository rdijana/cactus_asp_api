using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
   public class Mark:Entity
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
        public int Value { get; set; }
        public virtual User User { get; set; }
        public virtual Post Post { get; set; }
    }
}
