using System;

namespace NLayer.Common.Extensions
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
