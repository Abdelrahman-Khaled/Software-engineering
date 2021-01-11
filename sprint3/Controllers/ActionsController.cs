using sprint3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace sprint3.Controllers
{
    public class ActionsController : Controller
    {
        private Booking_SystemDBEntities1 db = new Booking_SystemDBEntities1();
        // GET: Actions
        public async System.Threading.Tasks.Task<ActionResult> Index()
        {
            String to_display="";
            int id = (int)TempData["not_id"];
            foreach (var item in db.Queues)
            {
                if (item.id == id)
                {
                    id = item.id;
                    ViewBag.notify = item.context;
                    break;
                }
            }
            HttpResponseMessage response = await GlobalVariables.WebApiClient.DeleteAsync("Queues/"+id.ToString());
            return View();
        }
    }
}