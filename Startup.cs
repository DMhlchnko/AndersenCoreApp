using AndersenCoreApp.Helpers;
using AndersenCoreApp.Infrastructure.Formatters;
using AndersenCoreApp.Interfaces.Formatters;
using AndersenCoreApp.Interfaces.Helpers;
using AndersenCoreApp.Interfaces.Repositories;
using AndersenCoreApp.Interfaces.Services;
using AndersenCoreApp.Models.Domain;
using AndersenCoreApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace AndersenCoreApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RelationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("RelationConnection")).UseLazyLoadingProxies());

            services.AddTransient<IRelationRepository, RelationRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IRelationAddressRepository, RelationAddressRepository>();
            services.AddScoped<IRelationService, RelationService>();
            services.AddTransient<IRelationHelpers, RelationHelpers>();
            services.AddTransient<IPostalCodeFormatter, PostalCodeFormatter>();
            services.AddAutoMapper(typeof(Startup));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Relation API",
                    Description = "Api for attached db"
                });
            });
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Relation API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
