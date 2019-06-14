using System;
using System.Collections.Generic;
using System.Text;

namespace SaleFinder.Domain
{
    public class SaleResult
    {
        public DateTime SaleTime { get; set; }
        public string GroupName { get; set;  }
        public int PageNumber { get; set; }
        public string KeyWord { get; set; }
    }
}
