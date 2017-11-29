using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Common
{
    /// <summary>
    /// Represents the result of an operation.
    /// </summary>
    public class ResultModel<TResult>
    {
        public ResultModel()
        {
            Succeeded = true;
        }

        private readonly List<string> errors = new List<string>();

        /// <summary>
        /// Flag indicating whether if the operation succeeded or not.
        /// </summary>
        /// <value>True if the operation succeeded, otherwise false.</value>
        public bool Succeeded { get; protected set; }

        /// <summary>
        /// An <see cref="IEnumerable{T}"/> 
        /// that occurred during the identity operation.
        /// </summary>
        /// <value>An <see cref="IEnumerable{T}"/></value>
        public IEnumerable<string> Errors => errors;

        public TResult Result { get; set; }

        /// <summary>
        /// Creates an <see cref="ResultModel{TResult}"/> indicating a failed  operation, with a list of <paramref name="errors"/> if applicable.
        /// </summary>
        /// <param name="errors">An optional array of <see cref="ResultModel{TResult}"/>s which caused the operation to fail.</param>
        /// <returns>An <see cref="ResultModel{TResult}"/> indicating a failed  operation, with a list of <paramref name="errors"/> if applicable.</returns>
        public static ResultModel<TResult> Failed(params string[] errors)
        {
            var result = new ResultModel<TResult> { Succeeded = false };
            if (errors != null)
            {
                result.errors.AddRange(errors);
            }
            return result;
        }

        /// <summary>
        /// Creates an <see cref="ResultModel{TResult}"/> indicating a successful  operation.
        /// </summary>
        /// <returns></returns>
        public static ResultModel<TResult> Successful(TResult result)
        {
            return new ResultModel<TResult>
            {
                Succeeded = true,
                Result = result
            };
        }

        /// <summary>
        /// Converts the value of the current <see cref="ResultModel{TResult}"/> object to its equivalent string representation.
        /// </summary>
        /// <returns>A string representation of the current <see cref="ResultModel{TResult}"/> object.</returns>
        /// <remarks>
        /// If the operation was successful the ToString() will return "Succeeded" otherwise it returned 
        /// "Failed : " followed by a comma delimited list of error codes from its <see cref="Errors"/> collection, if any.
        /// </remarks>
        public override string ToString()
        {
            return Succeeded ? "Succeeded" : $"Failed : {string.Join(Environment.NewLine, Errors)}";
        }
    }
}
