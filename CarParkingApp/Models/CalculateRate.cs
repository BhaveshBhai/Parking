using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static CarParkingApp.Models.RateEnum;

namespace CarParkingApp.Models
{
    public class CalculateRate
    {
        public string RateCalculate(DateTime startTime, DateTime endTime)
        {
            try
            {
            DayOfWeek dayOfWeek = startTime.DayOfWeek;
            if ((startTime.Date == endTime.Date) || (startTime.Date.AddHours(24).AddMinutes(0).AddSeconds(0) == endTime))
            {
                switch (dayOfWeek)
                {
                    case DayOfWeek.Saturday:
                        if ((startTime.Date == endTime.Date) || (startTime.Date.AddHours(24).AddMinutes(0).AddSeconds(0) == endTime))
                        {
                            int TotalHours = (int)(endTime - startTime).TotalHours;
                           var rate= StandardRateCalculate(TotalHours);
                            return "Weekend Rate is :- " + (rate > WeekEndRate.rate ? WeekEndRate.rate : rate);
                        }
                            break;
                    case DayOfWeek.Sunday:
                        if ((startTime.Date == endTime.Date) || (startTime.Date.AddHours(24).AddMinutes(0).AddSeconds(0) == endTime))
                        {
                            int TotalHours = (int)(endTime - startTime).TotalHours;
                            var rate = StandardRateCalculate(TotalHours);
                            return "Weekend Rate is :- " + (rate > WeekEndRate.rate ? WeekEndRate.rate : rate);
                        }
                        break;
                    default:
                        if (IsEarlyStart(startTime) && IsEarlyEnd(endTime))
                        {
                            return "Early Bird Rate is :- "+ EarlyBird.Rate;
                        }
                        
                        else if ((startTime.Date == endTime.Date) || (startTime.Date.AddHours(24).AddMinutes(0).AddSeconds(0) == endTime))
                        {
                            int TotalHours = (int)(endTime - startTime).TotalHours;
                           return "Standard Rate is :- "+ StandardRateCalculate(TotalHours);
                        }
                        
                            break;
                }
            }
                else if ((endTime.Date == startTime.AddDays(1).Date) && IsNightStart(startTime) && IsNightEndTime(endTime))
                {
                    return "Night Rate is :- " + NightRate.Rate;
                }
                else
                {
                    return "Standard Rate is :-" + (endTime.Date - startTime.Date).Days * StandardRate.ThreePluse;
                }
                return "";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public static float StandardRateCalculate(int TotalHours)
        {
            if (TotalHours > 0 && TotalHours < 1)
            {
                return StandardRate.One;
            }
            else if (TotalHours > 1 && TotalHours < 2)
            {
                return StandardRate.Two;
            }
            else if (TotalHours > 2 && TotalHours < 3)
            {
                return StandardRate.Three;
            }
            else
            {
                return StandardRate.ThreePluse;
            }
        }
        public static bool IsEarlyStart(DateTime startTime)
        {
            return IsBetween(startTime, EarlyBird.EntryStartTime, EarlyBird.EntryEndTime);
        }
        public static bool IsEarlyEnd(DateTime endTime)
        {
            return IsBetween(endTime, EarlyBird.ExitStartTime, EarlyBird.ExitEndTime);
        }
        public static bool IsNightStart(DateTime startTime)
        {
            return IsBetween(startTime, NightRate.NighEntryStartTime, NightRate.NightEntryEndTime);
        }
        public static bool IsNightEndTime(DateTime endTime)
        {
            return IsBetween(endTime, NightRate.NightExitStartTime, NightRate.NightExitEndTime);
        }
        public static bool IsBetween(DateTime now, TimeSpan start, TimeSpan end)
        {
            var time = now.TimeOfDay;
            // If the start time and the end time is in the same day.
            if (start <= end)
                return time >= start && time <= end;
            // The start time and end time is on different days.
            return time >= start || time <= end;
        }
    }

}
