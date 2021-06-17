using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DataTransfer
{
    public class PostCreateDto
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public string Content { get; set; }
        public string Description { get; set; }
        public IEnumerable<int> CategoryIds { get; set; } = new List<int>();
        
    }
}
