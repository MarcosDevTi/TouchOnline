using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.Data;

namespace TouchOnline.IoC
{
    public class ToBootstrapper
    {
        public static void Register(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ToContext>(db => db.UseNpgsql(config.GetConnectionString("NpgsqlConnection")));
            services.AddScoped<IProcessor, Processor>();
            services.AddCqrs();
        }
    }
}
