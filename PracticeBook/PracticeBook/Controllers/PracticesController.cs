using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using PB.DbContext;
using PB.Entities;
using PracticeBook.DTOs;

namespace PracticeBook.Controllers
{
    [Authorize]
    public class PracticesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Practices
        public ActionResult Index()
        {
            return View(db.Practices.ToList());
        }

        // GET: Practices/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practice practice = db.Practices.Find(id);
            if (practice == null)
            {
                return HttpNotFound();
            }
            return View(practice);
        }

        // GET: Practices/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Practices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PracticeEntry entry)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                // DateTime startDate = DateTime.Parse(string.Format($"{entry.StartDate}"));
                // DateTime endDate = DateTime.Parse(string.Format($"{entry.EndDate}"));
                Practice practice = new Practice(
                    entry.Name,
                    entry.StartDate,
                    entry.EndDate);

                db.Practices.Add(practice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entry);
        }

        // GET: Practices/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practice practice = db.Practices.Find(id);
            if (practice == null)
            {
                return HttpNotFound();
            }
            return View(practice);
        }

        // POST: Practices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Practice entry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entry);
        }

        // GET: Practices/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Practice practice = db.Practices.Find(id);
            if (practice == null)
            {
                return HttpNotFound();
            }
            return View(practice);
        }

        // POST: Practices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Practice practice = db.Practices.Find(id);
            db.Practices.Remove(practice);
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
