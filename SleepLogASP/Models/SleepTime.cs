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
                
        }
        public SleepTime(DateTime startSleep, DateTime endSleep)
        {
            this.StartSleep = startSleep;
            this.EndSleep = endSleep;
            this.AmountOfSleep = this.EndSleep - this.StartSleep;
            this.DayOfWeek = this.StartSleep.DayOfWeek;
        }
        public SleepTime(SleepTime sleepTime)
        {
            this.StartSleep = sleepTime.StartSleep;
            this.EndSleep = sleepTime.EndSleep;
            this.AmountOfSleep = this.EndSleep - this.StartSleep;
            this.DayOfWeek = this.StartSleep.DayOfWeek;
        }
        public int SleepTimeID { get; set; }
        public DateTime StartSleep { get; set; }
        public DateTime EndSleep { get; set; }
        public TimeSpan AmountOfSleep { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        //public string specialDay { get; set; }
    }
}