namespace TouchOnline.CqrsClient.Contracts
{
    public interface IProcessor
    {
         void Send<TCommand>(TCommand command) where TCommand: ICommand;
         TResult Get<TResult>(IQuery<TResult> query);
    }
}