using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AwMng;

namespace AwMng.Controllers
{
    public class AddressTypesController : Controller
    {
        private AdventureWorks2019Entities db = new AdventureWorks2019Entities();

        // GET: AddressTypes
        [Authorize]
        public ActionResult Index()
        {
            return View(db.AddressType.ToList());
        }

        // GET: AddressTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressType addressType = db.AddressType.Find(id);
            if (addressType == null)
            {
                return HttpNotFound();
            }
            return View(addressType);
        }

        // GET: AddressTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddressTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AddressTypeID,Name,rowguid,ModifiedDate")] AddressType addressType)
        {
            if (ModelState.IsValid)
            {
                db.AddressType.Add(addressType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(addressType);
        }

        // GET: AddressTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressType addressType = db.AddressType.Find(id);
            if (addressType == null)
            {
                return HttpNotFound();
            }
            return View(addressType);
        }

        // POST: AddressTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AddressTypeID,Name,rowguid,ModifiedDate")] AddressType addressType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(addressType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addressType);
        }

        // GET: AddressTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AddressType addressType = db.AddressType.Find(id);
            if (addressType == null)
            {
                return HttpNotFound();
            }
            return View(addressType);
        }

        // POST: AddressTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AddressType addressType = db.AddressType.Find(id);
            db.AddressType.Remove(addressType);
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
