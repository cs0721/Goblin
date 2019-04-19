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
    public class CharactersController : Controller
    {
        private Casts db = new Casts();

        // GET: Characters
        public ActionResult Index()
        {
            var characters = db.Characters.Include(c => c.Actors);
            return View(characters.OrderByDescending(character => character.CharacterName).ToList());
        }

        public ActionResult IndexByUsers()
        {
            var characters = db.Characters.Include(c => c.Actors);
            return View(characters.OrderByDescending(character => character.CharacterName).ToList());
        }

        // GET: Characters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Characters characters = db.Characters.Find(id);
            if (characters == null)
            {
                return HttpNotFound();
            }
            return View(characters);
        }

        public ActionResult DetailsByUsers(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Characters characters = db.Characters.Find(id);
            if (characters == null)
            {
                return HttpNotFound();
            }
            return View(characters);
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            ViewBag.ActorID = new SelectList(db.Actors, "ActorID", "ActorName");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CharacterID,CharacterName,CharacterDescription,CharacterGroup,ActorID")] Characters characters)
        {
            if (string.IsNullOrEmpty(characters.CharacterName))
            {
                ModelState.AddModelError("", "Missing data : Character name is required");
            }
            if (string.IsNullOrEmpty(characters.CharacterDescription))
            {
                ModelState.AddModelError("", "Missing data : Character description is required");
            }
            if (string.IsNullOrEmpty(characters.CharacterGroup))
            {
                ModelState.AddModelError("", "Missing data : Character Group is required");
            }
            if (ModelState.IsValid)
            {
                db.Characters.Add(characters);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ActorID = new SelectList(db.Actors, "ActorID", "ActorName", characters.ActorID);
            return View(characters);
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Characters characters = db.Characters.Find(id);
            if (characters == null)
            {
                return HttpNotFound();
            }
            ViewBag.ActorID = new SelectList(db.Actors, "ActorID", "ActorName", characters.ActorID);
            return View(characters);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CharacterID,CharacterName,CharacterDescription,CharacterGroup,ActorID")] Characters characters)
        {
            if (ModelState.IsValid)
            {
                db.Entry(characters).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ActorID = new SelectList(db.Actors, "ActorID", "ActorName", characters.ActorID);
            return View(characters);
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Characters characters = db.Characters.Find(id);
            if (characters == null)
            {
                return HttpNotFound();
            }
            return View(characters);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Characters characters = db.Characters.Find(id);
            db.Characters.Remove(characters);
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
