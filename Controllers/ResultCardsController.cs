using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using UniversityCard.Data;
using UniversityCard.Models;

namespace UniversityCard.Controllers
{
    public class ResultCardsController : Controller
    {
        private UniversityCardContext db = new UniversityCardContext();

        // GET: ResultCards
        public ActionResult Index(string searchString)
        {

            var resultCards = from r in db.ResultCards
                         select r;

            if (!String.IsNullOrEmpty(searchString))
            {
                resultCards = resultCards.Where(s => s.REG_NO.Contains(searchString));
            }

            return View(resultCards);
        }

        // GET: ResultCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultCard resultCard = db.ResultCards.Find(id);
            if (resultCard == null)
            {
                return HttpNotFound();
            }
            return View(resultCard);
        }

        // GET: ResultCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResultCards/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,REG_NO,Father_Name,Semester,University,Department,Program,SGPA,CGPA")] ResultCard resultCard)
        {
            if (ModelState.IsValid)
            {
                db.ResultCards.Add(resultCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(resultCard);
        }

        // GET: ResultCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultCard resultCard = db.ResultCards.Find(id);
            if (resultCard == null)
            {
                return HttpNotFound();
            }
            return View(resultCard);
        }

        // POST: ResultCards/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,REG_NO,Father_Name,Semester,University,Department,Program,SGPA,CGPA")] ResultCard resultCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(resultCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(resultCard);
        }

        // GET: ResultCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ResultCard resultCard = db.ResultCards.Find(id);
            if (resultCard == null)
            {
                return HttpNotFound();
            }
            return View(resultCard);
        }

        // POST: ResultCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ResultCard resultCard = db.ResultCards.Find(id);
            db.ResultCards.Remove(resultCard);
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
