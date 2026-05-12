using System.Globalization;
using System;

namespace SharpAlert
{
    public static class VersionInfo
    {
        // last build was 1891 before the upgrade to .NET 8
        public static int MajorVersion { get; } = 2;
        public static int MinorVersion { get; } = 2;
        public static bool IsBetaVersion { get; } = false;
        public static string ShortFriendlyVersion
        {
            get
            {
                if (!IsBetaVersion)
                {
                    //return $"SharpAlert | Release v{MajorVersion}.{MinorVersion} (Build {BuildNumber}) | Built on {BuiltOnDate} {BuiltOnTime} ({BuiltTimeZone})";
                    return $"SAlert (Sevyn Fork) v{MajorVersion}.{MinorVersion}";
                }
                else
                {
                    //return $"SharpAlert | Beta v{MajorVersion}.{MinorVersion}-b (Build {BuildNumber}) | Built on {BuiltOnDate} {BuiltOnTime} ({BuiltTimeZone})";
                    return $"SAlert (Sevyn Fork) v{MajorVersion}.{MinorVersion}-b";
                }
            }
        }
        public static string LongFriendlyVersion
        {
            get
            {
                if (!IsBetaVersion)
                {
                    //return $"SharpAlert | Release v{MajorVersion}.{MinorVersion} (Build {BuildNumber}) | Built on {BuiltOnDate} {BuiltOnTime} ({BuiltTimeZone})";
                    return $"SAlert (Sevyn Fork) | Release v{MajorVersion}.{MinorVersion} | Safety is never a non-priority";
                }
                else
                {
                    //return $"SharpAlert | Beta v{MajorVersion}.{MinorVersion}-b (Build {BuildNumber}) | Built on {BuiltOnDate} {BuiltOnTime} ({BuiltTimeZone})";
                    return $"SAlert (Sevyn Fork) | Beta v{MajorVersion}.{MinorVersion}-b | Safety is never a non-priority";
                }
            }
        }

        public static readonly DateTime BetaTimeEnd = DateTime.ParseExact(
            "05/20/2026",
            "M/d/yyyy",
            CultureInfo.InvariantCulture,
            DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal
        );
    }
}
