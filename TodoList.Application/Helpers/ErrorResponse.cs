using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Application.Helpers
{
    public class ErrorResponse : Response
    {
        public ErrorCode Error { get; }
        public string ErrorMessage { get; }
        protected ErrorResponse(ErrorCode error, string message)
        {
            Error = error;
            ErrorMessage = message;
        }

        public static ErrorResponse Create(ErrorCode code, string message)
        {
            return new ErrorResponse(code, message);
        }        
    }
}
