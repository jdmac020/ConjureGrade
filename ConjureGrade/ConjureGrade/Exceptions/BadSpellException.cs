using System;

namespace ConjureGrade.Exceptions
{
    public class BadSpellException : Exception
    {
        public BadSpellException() { }

        public BadSpellException(string message) : base(message)
        {

        }

        public BadSpellException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}