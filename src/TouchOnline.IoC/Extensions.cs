using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TouchOnline.CqrsClient.Contracts;
using TouchOnline.CqrsHandlers;

namespace TouchOnline.IoC
{
    public static class Extensions
    {
        public static void AddCqrs(this IServiceCollection services, Func<AssemblyName, bool> filter = null) =>
            AddCqrs<LessonPresentationQueryHandler>(services, filter);

        public static void AddCqrs<T>(this IServiceCollection services, Func<AssemblyName, bool> filter = null)
        {
            var handlers = new[] { typeof(ICommandHandler<>), typeof(IQueryHandler<,>) };
            bool FilterTrue(AssemblyName a) => true;
            var target = typeof(T).Assembly;

            var assemblies = target.GetReferencedAssemblies()
                .Where(filter ?? FilterTrue)
                .Select(Assembly.Load)
                .ToList();
            assemblies.Add(target);

            var types = from t in assemblies.SelectMany(a => a.GetExportedTypes())
                        from i in t.GetInterfaces()
                        where i.IsConstructedGenericType
                        && handlers.Contains(i.GetGenericTypeDefinition())
                        select new { i, t };

            foreach (var type in types) services.AddScoped(type.i, type.t);
        }
    }
}
