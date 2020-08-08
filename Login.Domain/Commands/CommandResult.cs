using Login.Domain.Commands.Contracts;

namespace Login.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(object data, string message, bool success)
        {
            Data = data;
            Message = message;
            Success = success;
        }

        public object Data { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }

    }
}