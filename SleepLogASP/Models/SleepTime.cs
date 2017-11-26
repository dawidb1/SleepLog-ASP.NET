using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepLogASP.Models
{
    public class SleepTime
    {
        public SleepTime()
        {
            amountOfSleep = endSleep - startSleep;
            dayOfWeek = endSleep.DayOfWeek;
            //if (endSleep.Day == DateTime.Today.Day)
            //{
            //    specialDay = "Today";
            //}
            //else if(endSleep.Day == DateTime.Today.AddDays(-1).Day)
            //{
            //    specialDay = "Yesterday";
            //}
        }
        public int SleepTimeID { get; set; }
        public DateTime startSleep { get; set; }
        public DateTime endSleep { get; set; }
        public TimeSpan amountOfSleep { get; set; }
        public DayOfWeek dayOfWeek { get; set; }
        //public string specialDay { get; set; }
    }
}