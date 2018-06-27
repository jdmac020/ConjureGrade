using System;

namespace ConjureGrade.Exceptions
{
    /// <summary>
    /// The noxious results of what happens when magic goes wrong
    /// </summary>
    public class BadSpellException : Exception
    {
        /// <summary>
        /// The noxious results of what happens when magic goes wrong
        /// </summary>
        public BadSpellException() { }

        /// <summary>
        /// The noxious results of what happens when magic goes wrong
        /// </summary>
        public BadSpellException(string message) : base(message)
        {

        }

        /// <summary>
        /// The noxious results of what happens when magic goes wrong
        /// </summary>
        public BadSpellException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}