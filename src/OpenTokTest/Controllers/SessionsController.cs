using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OpenTokTest.Models;
using OpenTok;

namespace OpenTokTest.Controllers
{
    public class SessionsController : Controller
    {
        private SessionEntities db = new SessionEntities();

        //
        // GET: /Sessions/

        public ActionResult Index()
        {
            return View(db.SessionList.ToList());
        }

        //
        // GET: /Sessions/Details/5

        public ActionResult Details(int id = 0)
        {
            Sessions sessions = db.SessionList.Find(id);
            if (sessions == null)
            {
                return HttpNotFound();
            }
            return View(sessions);
        }

        //
        // GET: /Sessions/Create

        public ActionResult Create()
        {
            Sessions sessions = new Sessions();
            OpenTokSDK opentok = new OpenTokSDK();
            string sessionId = opentok.CreateSession(Request.ServerVariables["REMOTE_ADDR"]);
            string token = opentok.GenerateToken(sessionId);

            sessions.SessionName = sessionId;
            sessions.SessionToken = token;

            db.SessionList.Add(sessions);
            db.SaveChanges();

            return View(sessions);
        }

        //
        // POST: /Sessions/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sessions sessions)
        {
            if (ModelState.IsValid)
            {
                db.SessionList.Add(sessions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sessions);
        }

        //
        // GET: /Sessions/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Sessions sessions = db.SessionList.Find(id);
            if (sessions == null)
            {
                return HttpNotFound();
            }
            return View(sessions);
        }

        //
        // POST: /Sessions/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sessions sessions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sessions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sessions);
        }

        //
        // GET: /Sessions/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Sessions sessions = db.SessionList.Find(id);
            if (sessions == null)
            {
                return HttpNotFound();
            }
            return View(sessions);
        }

        //
        // POST: /Sessions/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sessions sessions = db.SessionList.Find(id);
            db.SessionList.Remove(sessions);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}