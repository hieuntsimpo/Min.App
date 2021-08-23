using AutoMapper;
using Min.App.Biz.Dtos;
using Min.App.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Min.App.Biz.MappingConfigurations
{
    public class ProductProfiles : Profile
    {
        public ProductProfiles()
        {
            // Default mapping when property names are same
            CreateMap<Product, ProductDto>();
            CreateMap<Vendor, VendorDto>();
        }
    }
}
