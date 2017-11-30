using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepLogASP.Models
{
    public class ChartInfo
    {
        public ChartInfo(DateTime date, double amountOfTime)
        {
            this.date = date;
            this.amountOfTime = amountOfTime;
        }
        public DateTime date;
        public double amountOfTime;
    }
}