using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using SleepLogASP.DAL;
using SleepLogASP.Models;

namespace SleepLogASP.Controllers
{
    public class SleepController : Controller
    {
        private SleepContext db = new SleepContext();

        // GET: Sleep
        public ActionResult Index()
        {
            var sleeps = db.Sleeps.Include(r => r.rating).Include(st => st.sleepTime);
            return View(sleeps);
        }

        // GET: Sleep/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sleep sleep = db.Sleeps.Find(id);
            if (sleep == null)
            {
                return HttpNotFound();
            }
            return View(sleep);
        }

        // GET: Sleep/Create
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CharterColumn()
        {
            ArrayList xValue = new ArrayList();
            ArrayList yValue = new ArrayList();

            var sleeps = db.Sleeps.Include(st => st.sleepTime);

            var xResults = sleeps.Select(x => x.sleepTime.startSleep).ToList();
            var yResults = sleeps.Select(x => x.sleepTime.amountOfSleep).ToList();

            List<DateTime> justDate = new List<DateTime>();

            foreach (DateTime item in xResults)
            {
                justDate.Add(item.Date);
            }
            List<double> doubleAmountOfTime = new List<double>();

            foreach (TimeSpan item in yResults)
            {
                doubleAmountOfTime.Add(item.TotalHours);
            }

            //var yy = int.Parse(yResults);
            justDate.ForEach(date=>xValue.Add(date));
            doubleAmountOfTime.ForEach(amount => yValue.Add(amount));

            new Chart(width: 1200, height: 600, theme: ChartTheme.Green)
                .AddTitle("Ile spałeś?")
                .AddSeries("Default", chartType: "Column", xValue: xValue, yValues: yValue)
                .Write("bmp");

            return null;
        }
        public ActionResult Charter()
        {
            var sleeps = db.Sleeps.Include(st => st.sleepTime);
            List<ChartInfo> chartList = new List<ChartInfo>();

            var dateList = sleeps.Select(x => x.sleepTime.startSleep).ToList();
            var amountOfTimeList = sleeps.Select(x => x.sleepTime.amountOfSleep).ToList();

            //foreach (DateTime item in dateList)
            //{
            //    chartList
            //}
            //List<double> doubleAmountOfTime = new List<double>();

            //foreach (TimeSpan item in amountOfTimeList)
            //{
            //    doubleAmountOfTime.Add(item.TotalHours);
            //}
            for (int i = 0; i < dateList.Count; i++)
            {
                chartList.Add(new ChartInfo(dateList[i].Date, amountOfTimeList[i].TotalHours));
            }
            ViewBag.DATE = dateList.Select(x => x.Date);
            ViewBag.TIME = amountOfTimeList.Select(x => x.TotalHours);
            return View(chartList);
        }

        // POST: Sleep/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "sleepID,sleepTime,rating,note")] Sleep sleep)
        {
            if (ModelState.IsValid)
            {
                db.Sleeps.Add(sleep);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sleep);
        }

        // GET: Sleep/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sleep sleep = db.Sleeps.Find(id);
            if (sleep == null)
            {
                return HttpNotFound();
            }
            return View(sleep);
        }

        // POST: Sleep/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "sleepID,note")] Sleep sleep)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sleep).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sleep);
        }

        // GET: Sleep/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sleep sleep = db.Sleeps.Find(id);
            if (sleep == null)
            {
                return HttpNotFound();
            }
            return View(sleep);
        }

        public ActionResult GoSleep()
        {
            return View();
        }

        // POST: Sleep/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sleep sleep = db.Sleeps.Find(id);
            db.Sleeps.Remove(sleep);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }



    }
}
