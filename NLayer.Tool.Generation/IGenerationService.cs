using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Tool.Generation
{
    /// <summary>
    /// This interface allows you to randomly generate a value of specified length.
    /// </summary>
    public interface IGenerationService
    {
        /// <summary>
        /// Allows you to randomly generate a value of specified length.
        /// <example>Using symbols : abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-</example>
        /// </summary>
        /// <param name="length">The length a value.</param>
        /// <returns></returns>
        string Generation(int length);

        /// <summary>
        /// Allows you to randomly generate a value of specified length.
        /// <example>Using symbols : abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-</example>
        /// </summary>
        /// <param name="length">The length a value.</param>
        /// <returns></returns>
        Task<string> GenerationAsync(int length);

        /// <summary>
        /// Allows you to randomly generate a value of specified length.
        /// </summary>
        /// <param name="simbols">The symbols to generate a value.</param>
        /// <param name="length">The length a value.</param>
        /// <returns></returns>
        string Generation(string simbols, int length);

        /// <summary>
        /// Allows you to randomly generate a value of specified length.
        /// </summary>
        /// <param name="simbols">The symbols to generate a value.</param>
        /// <param name="length">The length a value.</param>
        /// <returns></returns>
        Task<string> GenerationAsync(string simbols, int length);
    }
}
