using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using NLayer.NET.Common.Intarfeces;

namespace NLayer.NET.Common
{
    [DataContract]
    public class Result<T> : IResult<T>
    {
        public Result()
        {
            Errors = new List<Error>();
            InfoMessages = new List<string>();
        }

        /// <summary>
        /// Result
        /// </summary>
        [DataMember]
        public T Value { get; set; }

        /// <summary>
        /// Return true if the operation was successful
        /// </summary>
        [DataMember]
        public bool IsSuccess => !Errors.Any();

        /// <summary>
        /// The list errors
        /// </summary>
        [DataMember]
        public List<Error> Errors { get; set; }

        /// <summary>
        /// The information message
        /// </summary>
        [DataMember]
        public List<string> InfoMessages { get; set; }
    }


    [DataContract]
    public sealed class Error
    {
        [DataMember]
        public int ErrorCode { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }
    }
}
