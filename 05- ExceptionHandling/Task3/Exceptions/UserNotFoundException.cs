using System;

namespace Task3.Exceptions
{
    public class UserNotFoundException : BaseException
    {
        public UserNotFoundException(string message)
        {
            Code = -2;
            Message = message;
        }

        public UserNotFoundException() :
            this("User not found")
        {

        }
    }
}
