using Microsoft.EntityFrameworkCore;
//using TestEDX.Business.Services;
using TestEDX.Comunication;
using TestEDX.DataAccess;


namespace TestEDX
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
           services.AddScoped<IPersona,PersonasRepository> ();
            services.AddControllersWithViews();
            services.AddSingleton<ILoggerManager, LoggerManager>();

            return services;
        }


    }
}
