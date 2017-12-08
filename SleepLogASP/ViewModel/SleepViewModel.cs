using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepLogASP.ViewModel
{
    public class SleepViewModel
    {
        public int SleepID { get; set; }
        public DateTime StartSleep { get; set; }
        public DateTime EndSleep { get; set; }
        public string Note { get; set; }
    }
}