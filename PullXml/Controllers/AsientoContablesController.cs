using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PullXml.Models;

namespace PullXml.Controllers
{
    public class AsientoContablesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AsientoContables
        public ActionResult Index()
        {
            return View(db.PullXmls.ToList());
        }

        // GET: AsientoContables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsientoContable asientoContable = db.PullXmls.Find(id);
            if (asientoContable == null)
            {
                return HttpNotFound();
            }
            return View(asientoContable);
        }

        // GET: AsientoContables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AsientoContables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdAsiento,NoAsiento,DescripcionAsiento,FechaAsiento,CuentaContable,TipoMovimiento,Monto")] AsientoContable asientoContable)
        {
            if (ModelState.IsValid)
            {
                db.PullXmls.Add(asientoContable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(asientoContable);
        }

        // GET: AsientoContables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsientoContable asientoContable = db.PullXmls.Find(id);
            if (asientoContable == null)
            {
                return HttpNotFound();
            }
            return View(asientoContable);
        }

        // POST: AsientoContables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdAsiento,NoAsiento,DescripcionAsiento,FechaAsiento,CuentaContable,TipoMovimiento,Monto")] AsientoContable asientoContable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asientoContable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(asientoContable);
        }

        // GET: AsientoContables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AsientoContable asientoContable = db.PullXmls.Find(id);
            if (asientoContable == null)
            {
                return HttpNotFound();
            }
            return View(asientoContable);
        }

        // POST: AsientoContables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AsientoContable asientoContable = db.PullXmls.Find(id);
            db.PullXmls.Remove(asientoContable);
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
