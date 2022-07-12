using System;

namespace CharlesBank.Exceptions
{
    /// <summary>
    /// Exception class that represents error raised in Account class
    /// </summary>
    public class AccountException : ApplicationException
    {
        /// <summary>
        /// Constructor that initialises exception message
        /// </summary>
        /// <param name="message">exception message</param>
        public AccountException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor that initialises exception message and inner exception
        /// </summary>
        /// <param name="message">exception message</param>
        /// <param name="innerException">inner exception</param>
        public AccountException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
