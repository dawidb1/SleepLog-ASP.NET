using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net;
using System.Web;
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
            var sleeps = db.Sleeps.Include(r => r.Rating).Include(st => st.SleepTime);
            return View(sleeps);
        }

        // GET: Sleep/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sleeps = db.Sleeps.Include(st => st.SleepTime);
            Sleep sleep = sleeps.Where(x => x.SleepID == id).First();
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

        public ActionResult Stats()
        {
            var sleeps = db.Sleeps.Include(st => st.SleepTime);
            List<ChartInfo> chartList = new List<ChartInfo>();
            foreach (var item in db.SleepTimes)
            {
                chartList.Add(new ChartInfo(item.AmountOfSleep.TotalHours, item.StartSleep.Date));
            }
            return View(chartList);
        }

        // POST: Sleep/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "sleepID,sleepTime,rating,note")] Sleep sleep)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Sleeps.Add(sleep);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(sleep);
        //}
        public ActionResult Create([Bind(Include = "SleepTime,Note")] Sleep sleep)
        {
            using (db)
            {
                db.Sleeps.Add(new Sleep(sleep.SleepTime,sleep.Note));
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //return View(sleep);
        }

        // GET: Sleep/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sleeps = db.Sleeps.Include(st => st.SleepTime);
            Sleep sleep = sleeps.Where(x => x.SleepID == id).First();

            if (sleep == null)
            {
                return HttpNotFound();
            }
            return View(sleep);
        }

        // POST: Sleep/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var sleepToUpdate = db.Sleeps.Find(id);

            //var newSleep = new Sleep(new SleepTime("SleepTime"), );

            if (TryUpdateModel(sleepToUpdate, "",
                new string[] { "Note", "SleepTime" }))
            {
                try
                {
                    sleepToUpdate.SleepTime.SetOtherData();
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (DataException)
                {
                    ModelState.AddModelError("", "blabla");
                }
            }
            //if (TryUpdateModel(sleepTimeToUpdate, "",
            //    new string[] { "StartSleep", "EndSleep" }))
            //{
            //    try
            //    {
            //        db.SaveChanges();
            //        return RedirectToAction("Index");
            //    }
            //    catch (DataException)
            //    {
            //        ModelState.AddModelError("", "blabla");
            //    }
            //}
            return View(sleepToUpdate);
            //if (ModelState.IsValid)
            //{
            //    db.Entry(sleep).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //return View(sleep);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GoSleep([Bind(Include = "sleepID,sleepTime")] Sleep sleep)
        {
            db.Entry(sleep).State = EntityState.Added;
            db.SaveChanges();
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
