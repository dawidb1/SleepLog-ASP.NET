using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepLogASP.Models
{
    public class SleepTime
    {
        public SleepTime(DateTime startSleep, DateTime endSleep)
        {
            this.startSleep = startSleep;
            this.endSleep = endSleep;
            this.amountOfSleep = this.endSleep - this.startSleep;
            this.dayOfWeek = this.startSleep.DayOfWeek;
        }
        public SleepTime()
        {
        }
        public int SleepTimeID { get; set; }
        public DateTime startSleep { get; set; }
        public DateTime endSleep { get; set; }
        public TimeSpan amountOfSleep { get; set; }
        public DayOfWeek dayOfWeek { get; set; }
        //public string specialDay { get; set; }
    }
}