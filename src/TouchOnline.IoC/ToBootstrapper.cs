using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.Data;

namespace TouchOnline.IoC
{
    public class ToBootstrapper
    {
        public static void Register(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ToContext>(db => db.UseSqlite(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProcessor, Processor>();
            services.AddCqrs();
        }
    }
}
