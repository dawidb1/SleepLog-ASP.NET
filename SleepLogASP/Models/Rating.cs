using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepLogASP.Models
{
    public class Rating
    {
        public int RatingID { get; set; }
        public int morningRating { get; set; }
        public int eveningRating { get; set; }
    }
}