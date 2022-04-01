using System.Text.RegularExpressions;

namespace DBAccess
{
    public static class StringExtensions
    {
        public static string ToSnakeCase(this string input)
        {
            if (string.IsNullOrEmpty(input)) { return input; }

            var startUnderscores = Regex.Match(input, @"^_+");
            return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1_$2").ToLower();
        }
    }
}

/*
 ef core setting:

1. 安裝ef core 5.0.14 跟 tools 還有 designs (才能用power shell cli)
2. 安裝Npgsql.EntityFrameworkCore.PostgreSQL
 */