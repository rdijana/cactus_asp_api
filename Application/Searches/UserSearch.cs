using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
   public class UserSearch:PagedSearch
    {
        public IEnumerable<int> UseCases { get; set; } = new List<int>();
    }
}
