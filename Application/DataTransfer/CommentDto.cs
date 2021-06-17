using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class CommentDto
    {
        public int? Id { get; set; }
        public int? UserId { get; set; }
        public int PostId { get; set; }
        public string User { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
