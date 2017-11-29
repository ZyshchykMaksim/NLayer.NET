using NodaTime;
using NodaTime.TimeZones;
using System;
using System.Linq;

namespace NLayer.Common.Extensions
{
    /// <summary>
    /// DateTimeExtensions.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Get timestamp from 1/1/1970
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static long UnixTimeStampFromDateTime(this DateTime time)
        {
            var dt = TimeZoneInfo.ConvertTimeToUtc(time);
            DateTime epochDate = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan ts = dt - epochDate;

            return (int)ts.TotalSeconds;
        }

        /// <summary>
        /// Gets the short name of the timezone.
        /// </summary>
        /// <param name="timeZoneId">The time zone identifier.</param>
        /// <param name="momentUtc">The moment UTC.</param>
        /// <returns></returns>
        public static string GetShortTimezoneName(this string timeZoneId, DateTime momentUtc)
        {
            if (string.IsNullOrEmpty(timeZoneId))
            {
                throw new ArgumentException(nameof(timeZoneId));
            }

            string tz = DateTimeZoneProviders.Tzdb.Ids.FirstOrDefault(e => e.ToLower() == timeZoneId.ToLower());

            if (string.IsNullOrEmpty(tz))
            {
                throw new ArgumentException(nameof(timeZoneId));
            }

            momentUtc = DateTime.SpecifyKind(momentUtc, DateTimeKind.Utc);

            Instant instant = Instant.FromDateTimeUtc(momentUtc);

            DateTimeZone timezone = DateTimeZoneProviders.Tzdb[tz];

            ZoneInterval zoneInterval = timezone.GetZoneInterval(instant);

            return zoneInterval.Name;
        }

        /// <summary>
        /// Converts the time to UTC (using IANA (Olson) timezone).
        /// </summary>
        /// <param name="local">The local.</param>
        /// <param name="timezone">IANA (Olson) timezone.</param>
        /// <returns></returns>
        public static DateTime ConvertTimeToUtc(this DateTime local, string timezone)
        {
            if (string.IsNullOrEmpty(timezone))
            {
                throw new ArgumentException(nameof(timezone));
            }

            string tz = DateTimeZoneProviders.Tzdb.Ids.FirstOrDefault(e => e.ToLower() == timezone.ToLower());

            if (string.IsNullOrEmpty(tz))
            {
                throw new ArgumentException(nameof(timezone));
            }

            LocalDateTime localDateTime = LocalDateTime.FromDateTime(local);

            DateTimeZone timezoneInfo = DateTimeZoneProviders.Tzdb[tz];

            ZonedDateTime zoned = timezoneInfo.AtLeniently(localDateTime);

            return zoned.ToDateTimeUtc();
        }


        /// <summary>
        /// Converts the time from UTC (using IANA (Olson) timezone).
        /// </summary>
        /// <param name="targetUtc">The target UTC.</param>
        /// <param name="timezone">IANA (Olson) timezone.</param>
        /// <returns></returns>
        public static DateTime ConvertTimeFromUtc(
            this DateTime targetUtc,
            string timezone
        )
        {
            if (string.IsNullOrEmpty(timezone))
            {
                throw new ArgumentException(nameof(timezone));
            }

            string tz = DateTimeZoneProviders.Tzdb.Ids.FirstOrDefault(e => e.ToLower() == timezone.ToLower());

            if (string.IsNullOrEmpty(tz))
            {
                throw new ArgumentException(nameof(timezone));
            }

            targetUtc = DateTime.SpecifyKind(targetUtc, DateTimeKind.Utc);

            Instant instant = Instant.FromDateTimeUtc(targetUtc);

            DateTimeZone zoneInfo = DateTimeZoneProviders.Tzdb[tz];

            ZonedDateTime zoned = instant.InZone(zoneInfo);

            // Removing seconds from the OffSet.
            // More details: https://github.com/nodatime/nodatime/issues/395
            TimeSpan timeSpanOriginal = zoned.Offset.ToTimeSpan();
            TimeSpan timeSpanInWholeMinutes = new TimeSpan(timeSpanOriginal.Hours, timeSpanOriginal.Minutes, 0);

            return new DateTimeOffset(
                zoned.Year,
                zoned.Month,
                zoned.Day,
                zoned.Hour,
                zoned.Minute,
                zoned.Second,
                zoned.Millisecond,
                timeSpanInWholeMinutes).DateTime;
        }
    }
}
