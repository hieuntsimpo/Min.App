using Min.App.Biz.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min.App.Biz
{
    public interface IProductService
    {
        Task<bool> AddAllEntitiesAsync(ProductDto item);
    }
}
