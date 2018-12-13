using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebsiteAboutSneks.DAL;
using WebsiteAboutSneks.Models;

namespace WebsiteAboutSneks.Controllers
{
    public class SnakesController : Controller
    {
        private SnekContext db = new SnekContext();

        // GET: Snakes
        public ActionResult Index()
        {
            var snakes = db.Snakes.Include(s => s.Breed).Include(s => s.Owner);
            return View(snakes.ToList());
        }

        // GET: Snakes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Snake snake = db.Snakes.Find(id);
            if (snake == null)
            {
                return HttpNotFound();
            }
            return View(snake);
        }

        // GET: Snakes/Create
        public ActionResult Create()
        {
            ViewBag.BreedID = new SelectList(db.Breeds, "BreedID", "BreedDescription");
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "OwnerFirstName");
            return View();
        }

        // POST: Snakes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SnakeID,OwnerID,SnakeName,BreedID,SnakeAge,SnakeTalk,SnakePicture")] Snake snake)
        {
            if (ModelState.IsValid)
            {
                db.Snakes.Add(snake);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BreedID = new SelectList(db.Breeds, "BreedID", "BreedDescription", snake.BreedID);
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "OwnerFirstName", snake.OwnerID);
            return View(snake);
        }

        // GET: Snakes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Snake snake = db.Snakes.Find(id);
            if (snake == null)
            {
                return HttpNotFound();
            }
            ViewBag.BreedID = new SelectList(db.Breeds, "BreedID", "BreedDescription", snake.BreedID);
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "OwnerFirstName", snake.OwnerID);
            return View(snake);
        }

        // POST: Snakes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SnakeID,OwnerID,SnakeName,BreedID,SnakeAge,SnakeTalk,SnakePicture")] Snake snake)
        {
            if (ModelState.IsValid)
            {
                db.Entry(snake).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BreedID = new SelectList(db.Breeds, "BreedID", "BreedDescription", snake.BreedID);
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "OwnerFirstName", snake.OwnerID);
            return View(snake);
        }

        // GET: Snakes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Snake snake = db.Snakes.Find(id);
            if (snake == null)
            {
                return HttpNotFound();
            }
            return View(snake);
        }

        // POST: Snakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Snake snake = db.Snakes.Find(id);
            db.Snakes.Remove(snake);
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
