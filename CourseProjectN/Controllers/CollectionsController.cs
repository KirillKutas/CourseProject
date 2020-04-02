using CourseProjectN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseProjectN.Controllers
{
    public class CollectionsController : Controller
    {
        // GET: Collections
        public ActionResult Collections()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CreateCollectionModel model)
        {
            CollectionContext context = new CollectionContext();
            Models.Collections collections = new Collections();
            List<Collections> listCol = context.Collections.ToList();
            if (context.Collections.Count() >= 1)
            {
                collections.Id = listCol[listCol.Count - 1].Id + 1;
            }
            else
            {
                
            }
            collections.Id = 1;
            collections.ImgUrl = "https://res.cloudinary.com/coursepoject/image/upload/v1585662014/" + model.image + ".jpg";
            collections.Topic = model.Topic;
            collections.Description = model.Description;
            collections.UserId = CurrentUser.Id;
            collections.Name = model.Name;
            context.Collections.Add(collections);
            context.SaveChanges();
            return View("Collections");
        }
        [HttpPost]
        public string Like(HttpContext context)
        {
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            bool flag = Convert.ToBoolean(request.QueryString["flag"]);
            if (flag)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }
    }
}