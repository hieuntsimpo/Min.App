
using Min.App.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Min.App.Repository.Interfaces
{
    public interface IVendorRepository : IGenericRepository<Vendor>
    {
        IEnumerable<Vendor> GetPopularDevelopers(int count);
    }
}
