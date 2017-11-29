using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;

namespace NLayer.Common.Extensions
{
    /// <summary>
    /// Extensions making it easier to get the user name/user id claims off of an identity
    /// </summary>
    public static class IdentityExtensions
    {
        /// <summary>
        /// Return the User Id.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="identity">The identity.</param>
        /// <returns></returns>
        public static T GetUserId<T>(this IIdentity identity) where T : IConvertible
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            var ci = identity as ClaimsIdentity;

            if (ci != null)
            {
                var id = FindFirstValue(ci, "sub");

                if (id != null)
                {
                    return (T)Convert.ChangeType(id, typeof(T), CultureInfo.InvariantCulture);
                }
            }

            return default(T);
        }

        /// <summary>
        /// Gets the name of the user.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">identity</exception>
        public static string GetUserName(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            var ci = identity as ClaimsIdentity;

            if (ci != null)
            {
                return FindFirstValue(ci, "name");
            }

            return null;
        }

        /// <summary>
        /// Gets the user role.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">identity</exception>
        public static string GetUserRole(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            var ci = identity as ClaimsIdentity;

            if (ci != null)
            {
                return FindFirstValue(ci, "role");
            }

            return null;
        }

        /// <summary>
        /// Gets claims values by claim type.
        /// </summary>
        /// <param name="identity">The identity.</param>
        /// <param name="claimType">Type of the claim.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">identity</exception>
        public static IEnumerable<string> GetClaimsValuesByType(this IIdentity identity, string claimType)
        {
            if (identity == null)
            {
                throw new ArgumentNullException(nameof(identity));
            }

            var ci = identity as ClaimsIdentity;

            return ci?.FindAll(claimType).Select(e => e.Value);
        }

        private static string FindFirstValue(ClaimsIdentity identity, string claimType)
        {
            var claim = identity.FindFirst(claimType);

            return claim?.Value;
        }
    }
}
