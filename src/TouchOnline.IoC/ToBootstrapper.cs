using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.Data;

namespace TouchOnline.IoC
{
    public class ToBootstrapper
    {
        public static void Register(IServiceCollection services, IConfiguration config)
        {
            //services.AddDbContext<DmContext>(db => db.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ToContext>(db => db.UseSqlite(string.Format("Filename={0}/Dm.db", AppDomain.CurrentDomain.BaseDirectory)));
            services.AddScoped<IProcessor, Processor>();
            services.AddCqrs();
        }
    }
}
