using Hotel.Domain.Commands.Contracts;

namespace Hotel.Domain.Commands
{
    public class GenericCommandResult : ICommandResult
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public object Data { get; set; }

        public GenericCommandResult(string message, bool success, object data)
        {
            Message = message;
            Success = success;
            Data = data;
        }
    }
}