using System;
using System.Collections.Generic;
using System.Text;
using TouchOnline.CqrsClient.Contracts;

namespace TouchOnline.IoC
{
    public class Processor : IProcessor
    {
        private readonly IServiceProvider _provider;

        public Processor(IServiceProvider provider) => _provider = provider;
        public TResult Get<TResult>(IQuery<TResult> query) =>
            GetHandle(typeof(IQueryHandler<,>), query.GetType(), typeof(TResult))
                .Handle((dynamic)query);

        public void Send<TCommand>(TCommand command) where TCommand : ICommand =>
            GetHandle(typeof(ICommandHandler<>), command.GetType())
                .Handle((dynamic)command);

        private dynamic GetHandle(Type handle, params Type[] types) =>
            _provider.GetService(handle.MakeGenericType(types));
    }
}
