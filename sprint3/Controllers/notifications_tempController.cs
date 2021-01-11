using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sprint3.Models;

namespace sprint3.Controllers
{
    public class notifications_tempController : Controller
    {
        private Booking_SystemDBEntities1 db = new Booking_SystemDBEntities1();

        // GET: notifications_temp
        public async Task<ActionResult> Index()
        {
            return View(await db.notifications_temp.ToListAsync());
        }

        // GET: notifications_temp/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notifications_temp notifications_temp = await db.notifications_temp.FindAsync(id);
            if (notifications_temp == null)
            {
                return HttpNotFound();
            }
            return View(notifications_temp);
        }

        // GET: notifications_temp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: notifications_temp/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,content_text,func")] notifications_temp notifications_temp)
        {
            if (ModelState.IsValid)
            {
                db.notifications_temp.Add(notifications_temp);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(notifications_temp);
        }

        // GET: notifications_temp/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notifications_temp notifications_temp = await db.notifications_temp.FindAsync(id);
            if (notifications_temp == null)
            {
                return HttpNotFound();
            }
            return View(notifications_temp);
        }

        // POST: notifications_temp/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,content_text,func")] notifications_temp notifications_temp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notifications_temp).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(notifications_temp);
        }

        // GET: notifications_temp/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            notifications_temp notifications_temp = await db.notifications_temp.FindAsync(id);
            if (notifications_temp == null)
            {
                return HttpNotFound();
            }
            return View(notifications_temp);
        }

        // POST: notifications_temp/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            notifications_temp notifications_temp = await db.notifications_temp.FindAsync(id);
            db.notifications_temp.Remove(notifications_temp);
            await db.SaveChangesAsync();
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
