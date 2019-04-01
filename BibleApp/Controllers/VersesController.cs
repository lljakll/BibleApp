using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BibleApp.Models;
using toasty_railcar.Models;

namespace BibleApp.Controllers
{
    public class VersesController : Controller
    {
        private BibleAppContext db = new BibleAppContext();

        // GET: Verses
        public ActionResult Index(string searchString)
        { 
            var verses = from v in db.Verses
                         select v;

            if (!String.IsNullOrEmpty(searchString))
            {
                verses = verses.Where(s => s.Book.Contains(searchString));
            }
            return View(verses);
        }

        // GET: Verses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verse verse = db.Verses.Find(id);
            if (verse == null)
            {
                return HttpNotFound();
            }
            return View(verse);
        }

        // GET: Verses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Verses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Translation,Testament,Book,Chapter,VerseNumber,VerseText,Related,Notes,UpdatedBy,UpdatedDate")] Verse verse)
        {
            if (ModelState.IsValid)
            {
                db.Verses.Add(verse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(verse);
        }

        // GET: Verses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verse verse = db.Verses.Find(id);
            if (verse == null)
            {
                return HttpNotFound();
            }
            return View(verse);
        }

        // POST: Verses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Translation,Testament,Book,Chapter,VerseNumber,VerseText,Related,Notes,UpdatedBy,UpdatedDate")] Verse verse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(verse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(verse);
        }

        // GET: Verses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Verse verse = db.Verses.Find(id);
            if (verse == null)
            {
                return HttpNotFound();
            }
            return View(verse);
        }

        // POST: Verses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Verse verse = db.Verses.Find(id);
            db.Verses.Remove(verse);
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
