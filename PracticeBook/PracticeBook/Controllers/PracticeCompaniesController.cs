using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PB.DbContext;
using PB.Entities;
using PracticeBook.DTOs;
using PracticeBook.Models;

namespace PracticeBook.Controllers
{
    public class PracticeCompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PracticeCompanies
        public ActionResult Index()
        {

            Practice practice = new Practice();
            List<Practice> PracticeList = db.Practices.ToList();
            ViewBag.PracticeList = new SelectList(PracticeList, "Id", "Name");
            return View(db.PracticeCompanies.ToList());
        }

        // GET: PracticeCompanies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PracticeCompany practiceCompany = db.PracticeCompanies.Find(id);
            if (practiceCompany == null)
            {
                return HttpNotFound();
            }
            return View(practiceCompany);
        }

        // GET: PracticeCompanies/Create
        public ActionResult Create()
        {
            var practices = db.Practices.ToList();
            List<SelectListItem> practicesList = new List<SelectListItem>();
            foreach(Practice item in practices)
            {
                practicesList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Name.ToString()
                });
            }
            ViewBag.Practice = practicesList;

            var companies = db.Companies.ToList();
            List<SelectListItem> companiesList = new List<SelectListItem>();
            foreach (Company item in companies)
            {
                companiesList.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Name
                });
            }
            ViewBag.Company = companiesList;
            return View();
        }

        // POST: PracticeCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PracticeCompanyEntry entry)
        {
            if (ModelState.IsValid)
            {
                PracticeCompany practiceCompany = new PracticeCompany(
                    entry.Practice,
                    entry.Company,
                    entry.Capacity);

                db.PracticeCompanies.Add(practiceCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entry);
        }

        // GET: PracticeCompanies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PracticeCompany practiceCompany = db.PracticeCompanies.Find(id);
            if (practiceCompany == null)
            {
                return HttpNotFound();
            }
            return View(practiceCompany);
        }

        // POST: PracticeCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Capacity")] PracticeCompany practiceCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(practiceCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(practiceCompany);
        }

        // GET: PracticeCompanies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PracticeCompany practiceCompany = db.PracticeCompanies.Find(id);
            if (practiceCompany == null)
            {
                return HttpNotFound();
            }
            return View(practiceCompany);
        }

        // POST: PracticeCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PracticeCompany practiceCompany = db.PracticeCompanies.Find(id);
            db.PracticeCompanies.Remove(practiceCompany);
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
