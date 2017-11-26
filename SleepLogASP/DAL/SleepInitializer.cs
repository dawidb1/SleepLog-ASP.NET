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
                new Sleep{note = "przykladowa notatka",rating = new Rating{morningRating=5,eveningRating=6},sleepTime = new SleepTime{startSleep = DateTime.Now,endSleep=DateTime.Now.AddHours(6)} },
                new Sleep{note = "przykladowa notatka",rating = new Rating{morningRating=5,eveningRating=6},sleepTime = new SleepTime{startSleep = DateTime.Now,endSleep=DateTime.Now.AddHours(6)} },
                new Sleep{note = "przykladowa notatka",rating = new Rating{morningRating=5,eveningRating=6},sleepTime = new SleepTime{startSleep = DateTime.Now,endSleep=DateTime.Now.AddHours(6)} },
                new Sleep{note = "przykladowa notatka",rating = new Rating{morningRating=5,eveningRating=6},sleepTime = new SleepTime{startSleep = DateTime.Now,endSleep=DateTime.Now.AddHours(6)} },
                new Sleep{note = "przykladowa notatka",rating = new Rating{morningRating=5,eveningRating=6},sleepTime = new SleepTime{startSleep = DateTime.Now,endSleep=DateTime.Now.AddHours(6)} },
                new Sleep{note = "przykladowa notatka",rating = new Rating{morningRating=5,eveningRating=6},sleepTime = new SleepTime{startSleep = DateTime.Now,endSleep=DateTime.Now.AddHours(6)} },
                new Sleep{note = "przykladowa notatka",rating = new Rating{morningRating=5,eveningRating=6},sleepTime = new SleepTime{startSleep = DateTime.Now,endSleep=DateTime.Now.AddHours(6)} },
                new Sleep{note = "przykladowa notatka",rating = new Rating{morningRating=5,eveningRating=6},sleepTime = new SleepTime{startSleep = DateTime.Now,endSleep=DateTime.Now.AddHours(6)} }
            };
            sleeps.ForEach(s => context.Sleeps.Add(s));
            context.SaveChanges();

        }
    }
}