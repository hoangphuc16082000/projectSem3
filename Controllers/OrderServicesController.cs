using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ExcelOnServices.Models;

namespace ExcelOnServices.Controllers
{
    [Authorize]
    public class OrderServicesController : Controller
    {
        private ExcelOnServiceContext db = new ExcelOnServiceContext();

        // GET: OrderServices
        public ActionResult Index()
        {
            var orderServices = db.OrderServices.Include(o => o.Customer).Include(o => o.Employee);
            return View(orderServices.ToList());
        }

        // GET: OrderServices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderService orderService = db.OrderServices.Find(id);
            if (orderService == null)
            {
                return HttpNotFound();
            }
            return View(orderService);
        }

        // GET: OrderServices/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Fullname");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Fullname");
            return View();
        }

        // POST: OrderServices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,OrderDate,Description,Total,Paid,Debt,EmployeeId")] OrderService orderService)
        {
            if (ModelState.IsValid)
            {
                db.OrderServices.Add(orderService);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Fullname", orderService.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Fullname", orderService.EmployeeId);
            return View(orderService);
        }

        // GET: OrderServices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderService orderService = db.OrderServices.Find(id);
            if (orderService == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Fullname", orderService.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Fullname", orderService.EmployeeId);
            return View(orderService);
        }

        // POST: OrderServices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,OrderDate,Description,Total,Paid,Debt,EmployeeId")] OrderService orderService)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderService).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "Id", "Fullname", orderService.CustomerId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Fullname", orderService.EmployeeId);
            return View(orderService);
        }

        // GET: OrderServices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderService orderService = db.OrderServices.Find(id);
            if (orderService == null)
            {
                return HttpNotFound();
            }
            return View(orderService);
        }

        // POST: OrderServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderService orderService = db.OrderServices.Find(id);
            db.OrderServices.Remove(orderService);
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
