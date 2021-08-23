using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Min.App.Repository.Interfaces
{
    public interface IUnitOfWork 
    {
        Task<int> CommitAsync();
    }
}
