using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace CourseProjectN.Controllers
{
    public class ItemsController : Controller
    {
        // GET: Items
        [HttpGet]
        [WebMethod]
        public ActionResult Items()
        {
            return View("Items");
        }
    }
}