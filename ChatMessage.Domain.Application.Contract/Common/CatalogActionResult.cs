using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMesssage.Application.Contract.Common
{
    public class ChatMesssageActionResult<T> where T : class
    {
        public T Data { get; set; }
        public bool IsSuccess { get; set; } = true;
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public int Total { get; set; } = 0;
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
    }
}
