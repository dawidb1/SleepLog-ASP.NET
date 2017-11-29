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
                new Sleep{note = "przykladowa notatka1",rating = new Rating{morningRating=5,eveningRating=6},sleepTime = new SleepTime{startSleep = DateTime.Now.AddDays(-8),endSleep=DateTime.Now.AddHours(6).AddDays(-8)} },
                new Sleep{note = "przykladowa notatka2",rating = new Rating{morningRating=8,eveningRating=5},sleepTime = new SleepTime{startSleep = DateTime.Now.AddDays(-7),endSleep=DateTime.Now.AddHours(7).AddDays(-7)} },
                new Sleep{note = "przykladowa notatka",rating = new Rating{morningRating=5,eveningRating=5},sleepTime = new SleepTime{startSleep = DateTime.Now.AddDays(-6),endSleep=DateTime.Now.AddHours(5).AddDays(-6)} },
                new Sleep{note = "przykladowa notatka3",rating = new Rating{morningRating=7,eveningRating=7},sleepTime = new SleepTime{startSleep = DateTime.Now.AddDays(-5),endSleep=DateTime.Now.AddHours(8).AddDays(-5)} },
                new Sleep{note = "przykladowa notatka4",rating = new Rating{morningRating=3,eveningRating=7},sleepTime = new SleepTime{startSleep = DateTime.Now.AddDays(-4),endSleep=DateTime.Now.AddHours(9).AddDays(-4)} },
                new Sleep{note = "przykladowa notatka5",rating = new Rating{morningRating=9,eveningRating=2},sleepTime = new SleepTime{startSleep = DateTime.Now.AddDays(-3),endSleep=DateTime.Now.AddHours(4).AddDays(-3)} },
                new Sleep{note = "przykladowa notatka6",rating = new Rating{morningRating=2,eveningRating=3},sleepTime = new SleepTime{startSleep = DateTime.Now.AddDays(-2),endSleep=DateTime.Now.AddHours(7).AddDays(-2)} },
                new Sleep{note = "przykladowa notatka7",rating = new Rating{morningRating=4,eveningRating=5},sleepTime = new SleepTime{startSleep = DateTime.Now.AddDays(-1),endSleep=DateTime.Now.AddHours(9).AddDays(-1)} }
            };
            sleeps.ForEach(s => context.Sleeps.Add(s));
            context.SaveChanges();

        }
    }
}