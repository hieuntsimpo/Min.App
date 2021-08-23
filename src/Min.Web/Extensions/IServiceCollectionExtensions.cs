using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Min.App.Biz;
using Min.App.Infrastructure;
using Min.App.Repository;
using Min.App.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Min.App.Web.Extensions
{ 
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext with Scoped lifetime   
            //services.AddDbContext<ApplicationContext>(options =>
            //{
            //    options.UseSqlServer(configuration.GetConnectionString("MinConnection"));
            //});

            services.AddDbContext<ApplicationContext>(opt =>
                opt.UseInMemoryDatabase("MinDB"));

            services.AddScoped<Func<ApplicationContext>>((provider) => () => provider.GetService<ApplicationContext>());
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IVendorRepository, VendorRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddScoped<IProductService,ProductService>()
                .AddScoped<IVendorService, VendorService>(); 
        }
    }
}
