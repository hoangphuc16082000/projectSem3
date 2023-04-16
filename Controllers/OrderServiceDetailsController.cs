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
    public class OrderServiceDetailsController : Controller
    {
        private ExcelOnServiceContext db = new ExcelOnServiceContext();

        // GET: OrderServiceDetails
        public ActionResult Index()
        {
            var orderServiceDetails = db.OrderServiceDetails.Include(o => o.OrderService).Include(o => o.Service);
            return View(orderServiceDetails.ToList());
        }

        // GET: OrderServiceDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderServiceDetail orderServiceDetail = db.OrderServiceDetails.Find(id);
            if (orderServiceDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderServiceDetail);
        }

        // GET: OrderServiceDetails/Create
        public ActionResult Create()
        {
            ViewBag.OrderServiceId = new SelectList(db.OrderServices, "Id", "Description");
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "ServiceName");
            return View();
        }

        // POST: OrderServiceDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,OrderServiceId,ServiceId,Price")] OrderServiceDetail orderServiceDetail)
        {
            if (ModelState.IsValid)
            {
                db.OrderServiceDetails.Add(orderServiceDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OrderServiceId = new SelectList(db.OrderServices, "Id", "Description", orderServiceDetail.OrderServiceId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "ServiceName", orderServiceDetail.ServiceId);
            return View(orderServiceDetail);
        }

        // GET: OrderServiceDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderServiceDetail orderServiceDetail = db.OrderServiceDetails.Find(id);
            if (orderServiceDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.OrderServiceId = new SelectList(db.OrderServices, "Id", "Description", orderServiceDetail.OrderServiceId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "ServiceName", orderServiceDetail.ServiceId);
            return View(orderServiceDetail);
        }

        // POST: OrderServiceDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,OrderServiceId,ServiceId,Price")] OrderServiceDetail orderServiceDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderServiceDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OrderServiceId = new SelectList(db.OrderServices, "Id", "Description", orderServiceDetail.OrderServiceId);
            ViewBag.ServiceId = new SelectList(db.Services, "Id", "ServiceName", orderServiceDetail.ServiceId);
            return View(orderServiceDetail);
        }

        // GET: OrderServiceDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OrderServiceDetail orderServiceDetail = db.OrderServiceDetails.Find(id);
            if (orderServiceDetail == null)
            {
                return HttpNotFound();
            }
            return View(orderServiceDetail);
        }

        // POST: OrderServiceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrderServiceDetail orderServiceDetail = db.OrderServiceDetails.Find(id);
            db.OrderServiceDetails.Remove(orderServiceDetail);
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
