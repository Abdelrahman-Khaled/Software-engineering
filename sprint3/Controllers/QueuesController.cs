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
    public class QueuesController : Controller
    {
        private Booking_SystemDBEntities1 db = new Booking_SystemDBEntities1();

        // GET: Queues
        public async Task<ActionResult> Index()
        {
            return View(await db.Queues.ToListAsync());
        }

        // GET: Queues/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queue queue = await db.Queues.FindAsync(id);
            if (queue == null)
            {
                return HttpNotFound();
            }
            return View(queue);
        }

        // GET: Queues/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Queues/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,context")] Queue queue)
        {
            if (ModelState.IsValid)
            {
                db.Queues.Add(queue);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(queue);
        }

        // GET: Queues/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queue queue = await db.Queues.FindAsync(id);
            if (queue == null)
            {
                return HttpNotFound();
            }
            return View(queue);
        }

        // POST: Queues/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,context")] Queue queue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(queue).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(queue);
        }

        // GET: Queues/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Queue queue = await db.Queues.FindAsync(id);
            if (queue == null)
            {
                return HttpNotFound();
            }
            return View(queue);
        }

        // POST: Queues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Queue queue = await db.Queues.FindAsync(id);
            db.Queues.Remove(queue);
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
