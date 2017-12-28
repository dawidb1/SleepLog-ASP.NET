using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepLogASP.Models
{
    public class Sleep
    {
        public Sleep()
        {
                
        }
        public Sleep(SleepTime sleepTime,string note)
        {
            this.SleepTime = new SleepTime(sleepTime);
            this.Note = note;
        }
        public int SleepID { get; set; }
        public SleepTime SleepTime { get; set; }
        public Rating Rating { get; set; }
        public string Note { get; set; }
    }
}