using Amazon.Runtime;
using Amazon.S3;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Min.App.Common;
using Min.App.Infrastructure;
using Min.App.Web.Controllers;
using Min.App.Web.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Min.Web
{
    public class Startup
    {
        private readonly IHostEnvironment _hostEnvironment;
        public IConfiguration Configuration
        {
            get;
        }
        public Startup(IConfiguration configuration, IHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            _hostEnvironment = hostEnvironment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IBucketRepository, BucketRepository>();

            if (_hostEnvironment.IsDevelopment())
            {
                var amazonS3 = new AmazonS3Client(new BasicAWSCredentials("abc", "def"), new AmazonS3Config
                {
                    ServiceURL = Consts.S3ServiceUrl,
                    ForcePathStyle = true,
                    UseHttp = true
                });

                services.AddTransient(typeof(IAmazonS3), provider => amazonS3);
            }
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen();
            services
                .AddDatabase(Configuration)
                .AddRepositories()
                .AddServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
