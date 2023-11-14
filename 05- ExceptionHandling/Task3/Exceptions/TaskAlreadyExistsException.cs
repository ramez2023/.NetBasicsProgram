using System;

namespace Task3.Exceptions
{
    public class TaskAlreadyExistsException : BaseException
    {
        public TaskAlreadyExistsException(string message)
        {
            Code = -3;
            Message = message;
        }

        public TaskAlreadyExistsException() :
            this("The task already exists")
        {

        }
    }
}
