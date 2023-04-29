using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contracts;
using Repositories.EntityFrameworkCore;
using Services;
using Services.Contracts;

namespace WebAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ECommerceDbContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString("sqlConnection")));
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }

        public static void ConfigureUnitOfWork(this IServiceCollection services) => 
            services.AddScoped<IUnitOfWork, UnitOfWork>();

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductManager>();
        }
    }
}
