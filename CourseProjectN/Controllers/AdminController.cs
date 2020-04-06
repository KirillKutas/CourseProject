using CourseProjectN.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseProjectN.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }
        public ActionResult Admin()
        {
            ApplicationContext context = new ApplicationContext();
            ViewBag.AllUsers = context.Users.ToList();
            List<string> AllRoles = new List<string>();
            foreach(var user in context.Users.ToList())
            {
                IList<string> roles = new List<string>();
                roles = UserManager.GetRoles(user.Id);
                AllRoles.Add(roles[0]);
            }

            
            ViewBag.AllRoles = AllRoles;

            return View();
        }
    }
}