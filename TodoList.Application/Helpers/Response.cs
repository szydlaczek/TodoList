using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Application.Helpers
{
    public class Response
    {
        public object Data { get; }

        public Response(object data)
        {
            Data = data;
        }
    }
}
