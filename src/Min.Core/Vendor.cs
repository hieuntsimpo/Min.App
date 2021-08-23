using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min.App.Core
{
    public class Vendor : AuditEntity<int>
    {
        public string CompanyName { get; set; }
        public string Email { get; set; }
    }
}
