using CourseProjectN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseProjectN.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            LikesContext likesContext = new LikesContext();
            List<Like> AllLikesCount = likesContext.Like.ToList();
            AllLikesCount = AllLikesCount.OrderByDescending(u => u.Count).ToList();
            CollectionContext collectionContext = new CollectionContext();
            ViewBag.Collections = collectionContext.Collections;
            ViewBag.LikesCount = AllLikesCount;
            ViewBag.Likes = likesContext.Likes;
            ViewBag.Count = likesContext.Likes.Count();
            return View();
        }

    }
}