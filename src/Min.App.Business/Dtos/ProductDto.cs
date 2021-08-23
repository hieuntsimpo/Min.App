using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min.App.Biz.Dtos
{
    public class ProductDto
    {
        public decimal Cost { get; set; }

        public string ProductName;
        public VendorDto Vendor { get; set; }
    }
}
