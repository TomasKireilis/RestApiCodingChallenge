using System;

namespace Common
{
    public interface IDateService
    {
        string GetDateInFormat(DateTime time, string pattern);
    }
}