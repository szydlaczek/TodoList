using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Application.Helpers
{
    public class SuccessResponse : Response
    {
        public object Data { get; }
        protected SuccessResponse(object data)
        {
            Data = data;
        }

        public static SuccessResponse Create(object data)
        {
            return new SuccessResponse(data);
        }
    }
}
