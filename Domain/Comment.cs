using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Comment:Entity
    {
        public string Content { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public virtual Post Post { get; set; }
        public virtual User User { get; set; }
    }
}
