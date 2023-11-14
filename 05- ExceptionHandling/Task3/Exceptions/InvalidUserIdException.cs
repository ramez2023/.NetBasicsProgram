using System.Net;

namespace Task3.Exceptions
{
    public class InvalidUserIdException : BaseException
    {
        public InvalidUserIdException(string message)
        {
            Code = -1;
            Message = message;
        }

        public InvalidUserIdException() : 
            this("Invalid userId")
        {

        }
    }
}
