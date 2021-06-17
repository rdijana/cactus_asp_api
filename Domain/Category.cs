using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Category:Entity
    {
        public string Name { get; set; }
        public virtual ICollection<PostCategory> CategoryPosts { get; set; } = new HashSet<PostCategory>();
    }
}
