using System;

namespace NLayer.NET.Common.Exceptions
{
    public class ValidationException : Exception
    {
        public string Property { get; protected set; }

        public ValidationException(string message, string prop = "") : base(message)
        {
            this.Property = prop;
        }

    }
}
