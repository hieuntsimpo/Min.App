using Min.App.Core;
using Min.App.Infrastructure;
using Min.App.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Min.App.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
       
        public ProductRepository(DbFactory dbFactory) : base(dbFactory)
        {
        }
        public Product AddProduct(Product item)
        {
            this.Add(item);
            return item;
        }
      
    }
}
