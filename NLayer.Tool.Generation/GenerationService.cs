using System;
using System.Threading.Tasks;

namespace NLayer.Tool.Generation
{
    /// <summary>
    /// This class allows you to randomly generate a value of specified length.
    /// </summary>
    public class GenerationService : IGenerationService
    {
        private readonly Random rd = new Random();

        private const string SymbolsDefault = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_";

        #region Implementation of IGenerationService

        /// <summary>
        /// Allows you to randomly generate a value of specified length.
        /// <c>Using symbols : abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_</c>
        /// </summary>
        /// <param name="length">The length a value.</param>
        /// <returns></returns>
        public Task<string> GenerationAsync(int length)
        {
            return Task.Run(() => Generation(SymbolsDefault, length));
        }

        /// <summary>
        /// Allows you to randomly generate a value of specified length.
        /// </summary>
        /// <param name="simbols">The symbols to generate a value.</param>
        /// <param name="length">The length a value.</param>
        /// <returns></returns>
        public Task<string> GenerationAsync(string simbols, int length)
        {
            return Task.Run(() => Generation(simbols, length));
        }

        /// <summary>
        /// Allows you to randomly generate a value of specified length.
        /// <c>Using symbols : abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_</c>
        /// </summary>
        /// <param name="length">The length a value.</param>
        /// <returns></returns>
        public string Generation(int length)
        {
            return Generation(SymbolsDefault, length);
        }

        /// <summary>
        /// Allows you to randomly generate a value of specified length.
        /// </summary>
        /// <param name="symbols">The symbols to generate a value.</param>
        /// <param name="length">The length a value.</param>
        /// <returns></returns>
        public string Generation(string symbols, int length)
        {
            if (string.IsNullOrWhiteSpace(symbols))
            {
                throw new ArgumentNullException(nameof(symbols));
            }

            if (length <= 0)
            {
                throw new ArgumentNullException(nameof(length));
            }

            var chars = new char[length];

            for (var i = 0; i < length; i++)
            {
                chars[i] = symbols[rd.Next(0, symbols.Length)];
            }

            return new string(chars);
        }
        #endregion
    }
}
