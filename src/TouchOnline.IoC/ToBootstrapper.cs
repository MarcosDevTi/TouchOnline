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
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            var conn = @$"Data Source={path}\Dm.db";
            services.AddDbContext<ToContext>(db => db.UseSqlite(conn));
            services.AddScoped<IProcessor, Processor>();
            services.AddCqrs();
        }
    }
}
