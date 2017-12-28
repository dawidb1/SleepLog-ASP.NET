using SleepLogASP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SleepLogASP.DAL
{
    public class SleepInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<SleepContext>
    {
        protected override void Seed(SleepContext context)
        {
            var sleeps = new List<Sleep>
            {
                new Sleep{Note = "przykladowa notatka1",Rating = new Rating{MorningRating=5,EveningRating=6},SleepTime = new SleepTime(DateTime.Now.AddDays(-8),DateTime.Now.AddHours(6).AddDays(-8))},
                new Sleep{Note = "przykladowa notatka2",Rating = new Rating{MorningRating=8,EveningRating=5},SleepTime = new SleepTime(DateTime.Now.AddDays(-7),DateTime.Now.AddHours(9).AddDays(-7))},
                new Sleep{Note = "przykladowa notatka9",Rating = new Rating{MorningRating=5,EveningRating=5},SleepTime = new SleepTime(DateTime.Now.AddDays(-6),DateTime.Now.AddHours(4).AddDays(-6))},
                new Sleep{Note = "przykladowa notatka3",Rating = new Rating{MorningRating=7,EveningRating=7},SleepTime = new SleepTime(DateTime.Now.AddDays(-5),DateTime.Now.AddHours(6).AddDays(-5))},
                new Sleep{Note = "przykladowa notatka4",Rating = new Rating{MorningRating=3,EveningRating=7},SleepTime = new SleepTime(DateTime.Now.AddDays(-4),DateTime.Now.AddHours(8).AddDays(-4))},
                new Sleep{Note = "przykladowa notatka5",Rating = new Rating{MorningRating=9,EveningRating=2},SleepTime = new SleepTime(DateTime.Now.AddDays(-3),DateTime.Now.AddHours(8).AddDays(-3))},
                new Sleep{Note = "przykladowa notatka6",Rating = new Rating{MorningRating=2,EveningRating=3},SleepTime = new SleepTime(DateTime.Now.AddDays(-2),DateTime.Now.AddHours(5).AddDays(-2))},
                new Sleep{Note = "przykladowa notatka7",Rating = new Rating{MorningRating=4,EveningRating=5},SleepTime = new SleepTime(DateTime.Now.AddDays(-1),DateTime.Now.AddHours(10).AddDays(-1))},
            };
            sleeps.ForEach(s => context.Sleeps.Add(s));
            context.SaveChanges();

        }
    }
}