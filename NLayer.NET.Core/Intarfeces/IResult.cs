using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.NET.Core.Intarfeces
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
        /// Return true if the operation has failed
        /// </summary>
        bool IsFailure { get; }

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
