using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BTJ.PowerApps.APIApp.Models;

namespace BTJ.PowerApps.APIApp.Controllers
{
    public class BTJPADemoSocialHitsController : ApiController
    {
        private BTJPADemoDBEntities db = new BTJPADemoDBEntities();

        // GET: api/BTJPADemoSocialHits
        public IQueryable<InstagramFile> GetInstagramFiles()
        {
            return db.InstagramFiles;
        }

        // GET: api/BTJPADemoSocialHits/5
        [ResponseType(typeof(InstagramFile))]
        public IHttpActionResult GetInstagramFile(int id)
        {
            InstagramFile instagramFile = db.InstagramFiles.Find(id);
            if (instagramFile == null)
            {
                return NotFound();
            }

            return Ok(instagramFile);
        }

        // PUT: api/BTJPADemoSocialHits/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutInstagramFile(int id, InstagramFile instagramFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != instagramFile.Id)
            {
                return BadRequest();
            }

            db.Entry(instagramFile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstagramFileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BTJPADemoSocialHits
        [ResponseType(typeof(InstagramFile))]
        public IHttpActionResult PostInstagramFile(InstagramFile instagramFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.InstagramFiles.Add(instagramFile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = instagramFile.Id }, instagramFile);
        }

        // DELETE: api/BTJPADemoSocialHits/5
        [ResponseType(typeof(InstagramFile))]
        public IHttpActionResult DeleteInstagramFile(int id)
        {
            InstagramFile instagramFile = db.InstagramFiles.Find(id);
            if (instagramFile == null)
            {
                return NotFound();
            }

            db.InstagramFiles.Remove(instagramFile);
            db.SaveChanges();

            return Ok(instagramFile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool InstagramFileExists(int id)
        {
            return db.InstagramFiles.Count(e => e.Id == id) > 0;
        }
    }
}