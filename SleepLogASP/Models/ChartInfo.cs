using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepLogASP.Models
{
    public class ChartInfo
    {
        public ChartInfo(double amountOfHours, DateTime date)
        {
            this.amountOfHours = amountOfHours;
            this.DateJS = (long)date.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds;
        }
        public double amountOfHours { get; set; }
        public long DateJS { get; set; }
    }
}