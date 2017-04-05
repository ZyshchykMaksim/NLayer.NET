using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.Owin;

namespace NLayer.NET.PL.API.Extensions
{
    /// <summary>
    /// Owin Request extensions.
    /// </summary>
    public static class OwinRequestExtensions
    {
        /// <summary>
        /// Gets the query string request parameters.
        /// </summary>
        /// <param name="request">Owin Request.</param>
        /// <returns>Dictionary of query string parameters.</returns>
        public static Dictionary<string, string> GetQueryParameters(this IOwinRequest request)
        {
            var dictionary = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);

            foreach (var pair in request.Query)
            {
                var value = GetJoinedValue(pair.Value);

                dictionary.Add(pair.Key, value);
            }

            return dictionary;
        }

        /// <summary>
        /// Gets the form body request parameters.
        /// </summary>
        /// <param name="request">Owin Request.</param>
        /// <returns>Dictionary of form body parameters.</returns>
        public static string GetBody(this IOwinRequest request)
        {
            try
            {
                using (StreamReader reader = new StreamReader(request.Body))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Gets the header request parameters.
        /// </summary>
        /// <param name="request">Owin Request.</param>
        /// <returns>Dictionary of header parameters.</returns>
        public static Dictionary<string, string> GetHeaderParameters(this IOwinRequest request)
        {
            return GetHeader(request.Headers);
        }

        /// <summary>
        /// Gets the header response parameters.
        /// </summary>
        /// <param name="response">Owin response.</param>
        /// <returns>Dictionary of header parameters.</returns>
        public static Dictionary<string, string> GetHeaderParameters(this IOwinResponse response)
        {
            return GetHeader(response.Headers);
        }

        private static Dictionary<string, string> GetHeader(IHeaderDictionary headerDictionary)
        {
            var dictionary = new Dictionary<string, string>(StringComparer.CurrentCultureIgnoreCase);

            foreach (var pair in headerDictionary)
            {
                var value = GetJoinedValue(pair.Value);

                dictionary.Add(pair.Key, value);
            }

            return dictionary;
        }

      

        private static string GetJoinedValue(string[] value)
        {
            if (value != null)
                return string.Join(",", value);

            return null;
        }
    }
}