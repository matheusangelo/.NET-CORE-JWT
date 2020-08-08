using System.Threading.Tasks;
using Login.Domain.Commands.Contracts;

namespace Login.Domain.Handlers.Contracts
{
    public interface IHandler<T> where T: class
    {
        ICommandResult handle(T command);
    }
}