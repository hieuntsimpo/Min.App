using Min.App.Core;
using Min.App.Infrastructure;
using Min.App.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min.App.Repository
{
    public class VendorRepository :GenericRepository<Vendor>, IVendorRepository
    {
        public VendorRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Vendor> GetPopularDevelopers(int count)
        {
            throw new NotImplementedException();
        }
    }
}
