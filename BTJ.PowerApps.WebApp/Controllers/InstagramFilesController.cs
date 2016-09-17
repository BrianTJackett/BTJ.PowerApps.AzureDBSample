using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BTJ.PowerApps.WebApp.Models;

namespace BTJ.PowerApps.WebApp
{
    [Authorize]
    public class InstagramFilesController : Controller
    {
        private BTJPADemoDBSQLEntities db = new BTJPADemoDBSQLEntities();

        // GET: InstagramFiles
        public ActionResult Index()
        {
            return View(db.InstagramFiles.ToList());
        }

        // GET: InstagramFiles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstagramFile instagramFile = db.InstagramFiles.Find(id);
            if (instagramFile == null)
            {
                return HttpNotFound();
            }
            return View(instagramFile);
        }

        // GET: InstagramFiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstagramFiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Filename,Created,CreatedBy,Content")] InstagramFile instagramFile)
        {
            if (ModelState.IsValid)
            {
                db.InstagramFiles.Add(instagramFile);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(instagramFile);
        }

        // GET: InstagramFiles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstagramFile instagramFile = db.InstagramFiles.Find(id);
            if (instagramFile == null)
            {
                return HttpNotFound();
            }
            return View(instagramFile);
        }

        // POST: InstagramFiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Filename,Created,CreatedBy,Content")] InstagramFile instagramFile)
        {
            if (ModelState.IsValid)
            {
                db.Entry(instagramFile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(instagramFile);
        }

        // GET: InstagramFiles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstagramFile instagramFile = db.InstagramFiles.Find(id);
            if (instagramFile == null)
            {
                return HttpNotFound();
            }
            return View(instagramFile);
        }

        // POST: InstagramFiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InstagramFile instagramFile = db.InstagramFiles.Find(id);
            db.InstagramFiles.Remove(instagramFile);
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
