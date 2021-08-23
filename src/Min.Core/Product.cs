using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min.App.Core
{
    public class Product : AuditEntity<int>
    {
        public decimal Cost { get; set; }

        public string ProductName;
        public Vendor Vendor { get; set; }
    }
}
