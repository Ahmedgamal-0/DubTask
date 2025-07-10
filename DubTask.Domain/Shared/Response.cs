using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DubTask.Domain.Shared
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string entityId, string message = null)
        {
            EntityId = entityId;
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }
        public Response(string message, bool succeeded)
        {
            Succeeded = succeeded;
            Message = message;
        }


        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }
        public T Data { get; set; }
        public string EntityId { get; set; }
        public bool IsValidate { get; set; }
    }
}
