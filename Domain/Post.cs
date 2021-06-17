using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Post:Entity
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public ICollection<PostCategory> PostCategories { get; set; } = new HashSet<PostCategory>();
        public virtual ICollection<Mark> Marks { get; set; } = new HashSet<Mark>();
    }
}
