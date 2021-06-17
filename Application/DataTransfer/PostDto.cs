using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class PostDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public string ImageSrc { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public IEnumerable<int> CategoryIds { get; set; } = new List<int>();
        public IEnumerable<string> Categories { get; set; } = new List<string>();
        public int? Mark { get; set; }

        public int CommentsCount { get; set; }
        
        public IEnumerable<CommentDto> Comments { get; set; } = new List<CommentDto>();


    }
    
}
