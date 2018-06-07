using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using PB.DbContext;
using PB.Entities;
using PracticeBook.DTOs;

namespace PracticeBook.Controllers
{   
    [Authorize]
    public class StudentPracticeCompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StudentPracticeCompanies
        public ActionResult Index()
        {
            return View(db.StudentPracticeCompanies.ToList());
        }

        // GET: StudentPracticeCompanies/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPracticeCompany studentPracticeCompany = db.StudentPracticeCompanies.Find(id);
            if (studentPracticeCompany == null)
            {
                return HttpNotFound();
            }
            return View(studentPracticeCompany);
        }

        // GET: StudentPracticeCompanies/Create
        public ActionResult Create()
        {
            var practices = db.PracticeCompanies.ToList();
            List<SelectListItem> practicesCompaniesList = new List<SelectListItem>();
            foreach (PracticeCompany item in practices)
            {
                practicesCompaniesList.Add(new SelectListItem
                {
                    Text = string.Join("-",item.Practice, item.Company),
                    Value = string.Join("-", item.Practice, item.Company)
                });
            }
            ViewBag.PracticeCompanies = practicesCompaniesList;
            return View();
        }

        // POST: StudentPracticeCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StudentPracticeCompanyEntry entry)
        {
            if (ModelState.IsValid)
            {
                var userId = User.Identity.GetUserId();
                string username = Membership.GetUser(userId).UserName;
                StudentPracticeCompany studentPracComp = new StudentPracticeCompany(
                   entry.PracticeCompanies
                   //,entry.UserId = username
                   );

                db.StudentPracticeCompanies.Add(studentPracComp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entry);
        }

        // GET: StudentPracticeCompanies/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPracticeCompany studentPracticeCompany = db.StudentPracticeCompanies.Find(id);
            if (studentPracticeCompany == null)
            {
                return HttpNotFound();
            }
            return View(studentPracticeCompany);
        }

        // POST: StudentPracticeCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName")] StudentPracticeCompany studentPracticeCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentPracticeCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentPracticeCompany);
        }

        // GET: StudentPracticeCompanies/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentPracticeCompany studentPracticeCompany = db.StudentPracticeCompanies.Find(id);
            if (studentPracticeCompany == null)
            {
                return HttpNotFound();
            }
            return View(studentPracticeCompany);
        }

        // POST: StudentPracticeCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            StudentPracticeCompany studentPracticeCompany = db.StudentPracticeCompanies.Find(id);
            db.StudentPracticeCompanies.Remove(studentPracticeCompany);
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
