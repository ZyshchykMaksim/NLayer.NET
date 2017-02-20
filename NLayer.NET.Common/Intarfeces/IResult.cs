using System.Collections.Generic;

namespace NLayer.NET.Common.Intarfeces
{
    public interface IResult<T>
    {
        /// <summary>
        /// Result
        /// </summary>
        T Value { get; set; }

        /// <summary>
        /// Return true if the operation was successful
        /// </summary>
        bool IsSuccess { get; }

        /// <summary>
        /// The list errors
        /// </summary>
        List<Error> Errors { get; set; }

        /// <summary>
        /// The information message
        /// </summary>
        List<string> InfoMessages { get; set; }
    }
}
