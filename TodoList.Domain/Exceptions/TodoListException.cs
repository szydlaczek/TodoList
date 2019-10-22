using System;

namespace TodoList.Domain.Exceptions
{
    public class TodoListException : Exception
    {
        public TodoListException(string message) : base(message)
        {
        }
    }
}