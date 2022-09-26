using Hotel.Domain.Commands.Contracts;

namespace Hotel.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T : ICommand
    {
        Task<ICommandResult> Handle(T command);
    }
}