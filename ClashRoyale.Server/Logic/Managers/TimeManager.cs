using System;
using System.Diagnostics;

namespace ClashRoyale.Server.Managers
{
    internal class TimeManager
    {
        internal static string GetUnixTime => DateTimeOffset.Now.ToUnixTimeSeconds().ToString();

        internal static long GetUnixSeconds => DateTimeOffset.Now.ToUnixTimeSeconds();

        internal static int GetRemainingSeasonTime
        {
            get
            {
                var CurrentYear = DateTime.Now.Year;
                var CurrentMonth = DateTime.Now.Month;

                var EndTime = new DateTime(CurrentYear, CurrentMonth, DateTime.DaysInMonth(CurrentYear, CurrentMonth));

                var SecondsLeft = (int) (((DateTimeOffset) EndTime).ToUnixTimeSeconds() -
                                         DateTimeOffset.Now.ToUnixTimeSeconds());

                Debug.WriteLine("TimeManager::GetRemainingSeasonTime - " + SecondsLeft + " seconds\n");

                return SecondsLeft;
            }
        }
    }
}