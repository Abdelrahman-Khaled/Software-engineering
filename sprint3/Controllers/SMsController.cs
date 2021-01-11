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
using System.Net.Http;

namespace sprint3.Controllers
{
    public class SMsController : Controller
    {
        private Booking_SystemDBEntities1 db = new Booking_SystemDBEntities1();
        // GET: SMs
        public async Task<ActionResult> Index()
        {
            return View(await db.SMS.ToListAsync());
        }

        // GET: SMs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SM sM = await db.SMS.FindAsync(id);
            if (sM == null)
            {
                return HttpNotFound();
            }
            return View(sM);
        }

        
        public async Task<ActionResult> Queue_notificationAsync()
        {
            User user = (User)TempData["user"];
            String request = (String)TempData["request"];
            Data_formatting_layer formater = new Data_formatting_layer();
            SM message = formater.construct_notification_Message(user, request);
            db.SMS.Add(message);
            db.SaveChangesAsync();            
            Queue q = new Queue();
            int id = 0;
            q.context = message.context;
            HttpResponseMessage response = await GlobalVariables.WebApiClient.PostAsJsonAsync("Queues", q);
            foreach (var item in db.Queues)
            {
                if (item.context ==q.context)
                {
                    id = item.id;
                    break;
                }
            }
            TempData["not_id"]=id;
            return RedirectToAction("Index", "Actions");
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: SMs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,context")] SM sM)
        {
            if (ModelState.IsValid)
            {
                db.SMS.Add(sM);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(sM);
        }

        // GET: SMs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SM sM = await db.SMS.FindAsync(id);
            if (sM == null)
            {
                return HttpNotFound();
            }
            return View(sM);
        }

        // POST: SMs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,context")] SM sM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sM).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sM);
        }

        // GET: SMs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SM sM = await db.SMS.FindAsync(id);
            if (sM == null)
            {
                return HttpNotFound();
            }
            return View(sM);
        }

        // POST: SMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            SM sM = await db.SMS.FindAsync(id);
            db.SMS.Remove(sM);
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
