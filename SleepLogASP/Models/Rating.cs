using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepLogASP.Models
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int MorningRating { get; set; }
        public int EveningRating { get; set; }
    }
}