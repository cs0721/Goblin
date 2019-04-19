using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assignment_Di.Models;

namespace Assignment_Di.Controllers
{
    [Authorize]
    public class ActorsController : Controller
    {
        private Casts db = new Casts();

        // GET: Actors
        public ActionResult Index()
        {
            var actors = db.Actors.Include(a => a.Characters);
            return View(actors.OrderBy(a => a.ActorName).OrderBy(a => a.ActorDOB).ToList());
        }

        public ActionResult IndexByUsers()
        {
            var actors = db.Actors.Include(a => a.Characters);
            return View(actors.OrderBy(a => a.ActorName).OrderBy(a => a.ActorDOB).ToList());
        }

        public ActionResult Search(string actorName)
        {
            var actors = from c in db.Actors
                         select c;
            if (!String.IsNullOrEmpty(actorName))
            {

                actors = actors.Where(s => s.ActorName.Contains(actorName));

            }
            return View(actors.OrderBy(a => a.ActorName).OrderBy(a => a.ActorDOB).Take(10).ToList());
        }

        // GET: Actors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actors actors = db.Actors.Find(id);
            if (actors == null)
            {
                return HttpNotFound();
            }
            return View(actors);
        }

        public ActionResult DetailsByUsers(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actors actors = db.Actors.Find(id);
            if (actors == null)
            {
                return HttpNotFound();
            }
            return View(actors);
        }

        // GET: Actors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ActorID,ActorName,ActorDOB,ActorGender,ActorNationality,ActorHeight,ActorWeight,ActorBloodType,ActorStarSign,ActorDebutYear")] Actors actors)
        {
            if (string.IsNullOrEmpty(actors.ActorName))
            {
                ModelState.AddModelError("ActorName", "Missing data : Actor name is required");
            }
            if (string.IsNullOrEmpty(actors.ActorGender))
            {
                ModelState.AddModelError("ActorGender", "Missing data : Actor gender is required");
            }
            if (string.IsNullOrEmpty(actors.ActorNationality))
            {
                ModelState.AddModelError("ActorNationality", "Missing data : Actor nationality is required");
            }
            if (ModelState.IsValid)
            {
                db.Actors.Add(actors);
                db.SaveChanges();
                return RedirectToAction("Created");
            }

            return View(actors);
        }

        // GET: Actors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actors actors = db.Actors.Find(id);
            if (actors == null)
            {
                return HttpNotFound();
            }
            return View(actors);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ActorID,ActorName,ActorDOB,ActorGender,ActorNationality,ActorHeight,ActorWeight,ActorBloodType,ActorStarSign,ActorDebutYear")] Actors actors)
        {
            if (string.IsNullOrEmpty(actors.ActorName))
            {
                ModelState.AddModelError("", "Missing data : Actor name is required");
            }
            if (string.IsNullOrEmpty(actors.ActorGender))
            {
                ModelState.AddModelError("", "Missing data : Actor gender is required");
            }
            if (string.IsNullOrEmpty(actors.ActorNationality))
            {
                ModelState.AddModelError("", "Missing data : Actor nationality is required");
            }
            if (ModelState.IsValid)
            {
                db.Entry(actors).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(actors);
        }

        // GET: Actors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Actors actors = db.Actors.Find(id);
            if (actors == null)
            {
                return HttpNotFound();
            }
            return View(actors);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Actors actors = db.Actors.Find(id);
            db.Actors.Remove(actors);
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

        public ActionResult Created()
        {
            return View();
        }
    }
}
