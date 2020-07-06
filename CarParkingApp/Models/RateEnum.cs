using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarParkingApp.Models
{
    public class RateEnum
    {
        public enum Ratename {
            Early_Bird,
            Night_Rate,
            Weekend_Rate,
            Standard_Rate
        }
        //public enum EarlyBird
        //{
        //    Rate=13,
        //    EntryStartTime = 6,
        //    EntryEndTime = 9,
        //    ExitStartTimeHours = 15,
        //    ExitMinutes=30,
        //    ExitEndTime = 23
        //}
        public static class EarlyBird
        {
            public const float Rate = 13.0f;
            public static readonly TimeSpan EntryStartTime = new TimeSpan(06, 0, 0);
            public static readonly TimeSpan EntryEndTime = new TimeSpan(09, 0, 0);
            public static readonly TimeSpan ExitStartTime = new TimeSpan(15, 30, 0);
            public static readonly TimeSpan ExitEndTime = new TimeSpan(23, 30, 0);

        }

       public static class NightRate
        {
            public const float Rate = 6.50f;
            public static readonly TimeSpan NighEntryStartTime = new TimeSpan(18, 0, 0);
            public static readonly TimeSpan NightEntryEndTime = new TimeSpan(23, 59, 59);
            public static readonly TimeSpan NightExitStartTime = new TimeSpan(15, 30, 0);
            public static readonly TimeSpan NightExitEndTime = new TimeSpan(23, 30, 0);
        }
        public static class WeekEndRate
        {
            public const float rate = 10.00f;
        }
        public static class StandardRate
        {
            public const float One = 5.0f;
            public const float Two = 10.0f;
            public const float Three = 15.0f;
            public const float ThreePluse = 20.0f;
        }
    }
}
