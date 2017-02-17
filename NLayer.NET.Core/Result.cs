using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using NLayer.NET.Core.Intarfeces;

namespace NLayer.NET.Core
{
    [DataContract]
    public class Result<T> : IResult<T>
    {
        public Result()
        {
            Errors = new List<Error>();
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
        /// Return true if the operation has failed
        /// </summary>
        [DataMember]
        public bool IsFailure => Errors.Any();

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
