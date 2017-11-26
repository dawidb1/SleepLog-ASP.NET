using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepLogASP.Models
{
    public class Sleep
    {
        public int sleepID { get; set; }
        public SleepTime sleepTime { get; set; }
        public Rating rating { get; set; }
        public string note { get; set; }
    }
}