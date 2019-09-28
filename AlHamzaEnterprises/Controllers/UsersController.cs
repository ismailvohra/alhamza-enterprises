using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AlHamzaEnterprises.Models;
using AlHamzaEnterprises.Extension;
using Microsoft.AspNet.Identity;

namespace AlHamzaEnterprises.Controllers
{
    public class UsersController : Controller
    {
        private AlHamzaEnterprisesEntities db = new AlHamzaEnterprisesEntities();
        private ApplicationDbContext aspdb = new ApplicationDbContext();
    
        // GET: Users
        //[Authorize(Roles = "Employee")]
        public ActionResult Index()
        {
            var userX = new User();
            userX.UserName = User.Identity.Name;
            userX.UserType = User.Identity.GetUserType();
            userX.MobileNo = User.Identity.GetMobileNo();
            userX.Landline = User.Identity.GetLandline();
            userX.CompanyName = User.Identity.GetCompanyName();
            userX.SalesTax_ = User.Identity.GetSalesTaxNo();
            userX.NTN_ = User.Identity.GetNTNNo();
            userX.Designation = User.Identity.GetDesignation();
            userX.BasicSalary = int.Parse(User.Identity.GetBasicSalary().Value);
            userX.HireDate = DateTime.Parse(User.Identity.GetHireDate().Value);
            userX.CurrentEmployee = bool.Parse(User.Identity.GetCurrentEmployee().Value);

            if ((db.Users.Any(x => x.UserName == userX.UserName)) == false)
            {

                db.Users.Add(userX);
                db.SaveChanges();
               
          
            }

            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName,UserType,MobileNo,Landline,CompanyName,SalesTax_,NTN_,Designation,BasicSalary,HireDate,CurrentEmployee")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,UserType,MobileNo,Landline,CompanyName,SalesTax_,NTN_,Designation,BasicSalary,HireDate,CurrentEmployee")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
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
