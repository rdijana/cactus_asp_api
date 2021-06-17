using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
   public  class PostSearch:PagedSearch
    {
        public IEnumerable<int> CategoryIds { get; set; } = new List<int>();
    }
}
