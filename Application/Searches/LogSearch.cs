using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Searches
{
    public class LogSearch:PagedSearch
    {
        public DateTime? DateMin { get; set; }
        public DateTime? DateMax { get; set; }
    }
}
