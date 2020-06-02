using System;

namespace RegistrationService.Exceptions
{
    public class InvalidBirthDateException : Exception
    {
        public InvalidBirthDateException()
        {
            
        }

        public InvalidBirthDateException(string message) : base(message)
        {
            
        }

        public InvalidBirthDateException(string message, Exception innerException) : base(message, innerException)
        {
            
        }
    }
}