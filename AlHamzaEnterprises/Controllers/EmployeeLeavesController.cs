using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlHamzaEnterprises.Models;

namespace AlHamzaEnterprises.Controllers
{
    public class EmployeeLeavesController : Controller
    {
        private AlHamzaEnterprisesEntities db = new AlHamzaEnterprisesEntities();

        // GET: EmployeeLeaves
        public ActionResult Index()
        {
            var employeeLeaves = db.EmployeeLeaves.Include(e => e.User);
            return View(employeeLeaves.ToList());
        }

        // GET: EmployeeLeaves/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLeave employeeLeave = db.EmployeeLeaves.Find(id);
            if (employeeLeave == null)
            {
                return HttpNotFound();
            }
            return View(employeeLeave);
        }

        // GET: EmployeeLeaves/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: EmployeeLeaves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeLeaveID,DateOfRequest,StartDate,EndDate,Reason,UserID,Status")] EmployeeLeave employeeLeave)
        {
            if (ModelState.IsValid)
            {
                db.EmployeeLeaves.Add(employeeLeave);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", employeeLeave.UserID);
            return View(employeeLeave);
        }

        // GET: EmployeeLeaves/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLeave employeeLeave = db.EmployeeLeaves.Find(id);
            if (employeeLeave == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", employeeLeave.UserID);
            return View(employeeLeave);
        }

        // POST: EmployeeLeaves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeLeaveID,DateOfRequest,StartDate,EndDate,Reason,UserID,Status")] EmployeeLeave employeeLeave)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeLeave).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.Users, "UserID", "UserName", employeeLeave.UserID);
            return View(employeeLeave);
        }

        // GET: EmployeeLeaves/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeLeave employeeLeave = db.EmployeeLeaves.Find(id);
            if (employeeLeave == null)
            {
                return HttpNotFound();
            }
            return View(employeeLeave);
        }

        // POST: EmployeeLeaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeLeave employeeLeave = db.EmployeeLeaves.Find(id);
            db.EmployeeLeaves.Remove(employeeLeave);
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
