using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Common
{
    public class DateService : IDateService
    {
        public string GetDateInFormat(DateTime time, string pattern)
        {
            return time.ToString(pattern);
        }
    }
}