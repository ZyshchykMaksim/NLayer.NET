using System;
using System.Runtime.Serialization;

namespace NLayer.HealthCheck.Models.Exceptions
{
    /// <summary>
    /// HealthCheckFailedException.
    /// </summary>
    /// <seealso cref="System.Exception" />
    [Serializable]
    public class HealthCheckFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckFailedException"/> class.
        /// </summary>
        public HealthCheckFailedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckFailedException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public HealthCheckFailedException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckFailedException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="inner">The inner.</param>
        public HealthCheckFailedException(string message, Exception inner) : base(message, inner)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HealthCheckFailedException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        protected HealthCheckFailedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
