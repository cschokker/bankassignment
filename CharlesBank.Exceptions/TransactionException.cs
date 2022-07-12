using System;

namespace CharlesBank.Exceptions
{
    /// <summary>
    /// Exception class that represents error raised in Transaction class
    /// </summary>
    public class TransactionException : ApplicationException
    {
        /// <summary>
        /// Constructor that initialises exception message
        /// </summary>
        /// <param name="message">exception message</param>
        public TransactionException(string message) : base(message)
        {
        }

        /// <summary>
        /// Constructor that initialises exception message and inner exception
        /// </summary>
        /// <param name="message">exception message</param>
        /// <param name="innerException">inner exception</param>
        public TransactionException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
