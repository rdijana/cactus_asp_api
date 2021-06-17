using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class CommentCreateDto
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string Content { get; set; }
    }
}
