using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelBook.Models;

namespace HotelBook.Controllers
{
    public class Hotel_OwnerController : Controller
    {
        private HotelDBEntities db = new HotelDBEntities();

        // GET: Hotel_Owner
        public ActionResult Index()
        {
            return View(db.Hotel_Owner.ToList());
        }

        // GET: Hotel_Owner/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel_Owner hotel_Owner = db.Hotel_Owner.Find(id);
            if (hotel_Owner == null)
            {
                return HttpNotFound();
            }
            return View(hotel_Owner);
        }

        // GET: Hotel_Owner/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotel_Owner/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Owner_id,Account_id,FirstName,LastName,Password,Contact_detail")] Hotel_Owner hotel_Owner)
        {
            if (ModelState.IsValid)
            {
                db.Hotel_Owner.Add(hotel_Owner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotel_Owner);
        }

        // GET: Hotel_Owner/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel_Owner hotel_Owner = db.Hotel_Owner.Find(id);
            if (hotel_Owner == null)
            {
                return HttpNotFound();
            }
            return View(hotel_Owner);
        }

        // POST: Hotel_Owner/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Owner_id,Account_id,FirstName,LastName,Password,Contact_detail")] Hotel_Owner hotel_Owner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotel_Owner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotel_Owner);
        }

        // GET: Hotel_Owner/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Hotel_Owner hotel_Owner = db.Hotel_Owner.Find(id);
            if (hotel_Owner == null)
            {
                return HttpNotFound();
            }
            return View(hotel_Owner);
        }

        // POST: Hotel_Owner/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Hotel_Owner hotel_Owner = db.Hotel_Owner.Find(id);
            db.Hotel_Owner.Remove(hotel_Owner);
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
