using System.Collections.Generic;
using System.Linq;

namespace Market.Common.ViewModels
{
    public enum ResponseMessageType
    {
        Error = -1,
        Success = 1,
        Warning = 0
    }
    public record ResponseMessage(string Message, string Type);

    public class ResponseViewModel
    {
        private readonly List<ResponseMessage> _messages;
        public ResponseViewModel()
        {
            _messages = new List<ResponseMessage>();
        }

        public bool IsSuccess { get; private set; }
        public string Message { get => _messages.FirstOrDefault()?.Message; }
        public List<ResponseMessage> Messages { get => _messages; }

        public void Succeed()
        {
            IsSuccess = true;
        }

        public void Failure()
        {
            IsSuccess = false;
        }

        public void AddMessage(string message, ResponseMessageType type = ResponseMessageType.Success)
        {
            _messages.Add(new ResponseMessage(message, type.ToString()));
        }
    }

    public class ResponseViewModel<T> : ResponseViewModel
    {
        public T Entity { get; set; }
    }

    public class ResponseViewModel<T1, T2> : ResponseViewModel<T1>
    {
        public T2 Additional { get; set; }
    }
}
