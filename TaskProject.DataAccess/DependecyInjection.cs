using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskProject.DataAccess.Persistance;
using TaskProject.Service.Abstractions.DataAccess;

namespace TaskProject.DataAccess
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddDataAccess(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("Posgres")));

            return services;
        }
    }
}