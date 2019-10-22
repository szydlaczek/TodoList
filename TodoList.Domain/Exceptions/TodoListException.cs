using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.Domain.Exceptions
{
    public class TodoListException : Exception
    {

        public TodoListException(string message) : base(message)
        {
        }
    }
}
