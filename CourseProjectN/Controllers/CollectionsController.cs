using CourseProjectN.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

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
            LikesContext likesContext = new LikesContext();
            Like like = new Like();
            List<Collections> listCol = context.Collections.ToList();
            List<Like> listLike = likesContext.Like.ToList();
            if (context.Collections.Count() >= 1)
            {
                collections.Id = listCol[listCol.Count - 1].Id + 1;

            }
            else
            {
                collections.Id = 1;

            }
            if(likesContext.Like.Count() >= 1)
            {
                like.Id = listLike[listLike.Count - 1].Id + 1;
            }
            else
            {
                like.Id = 1;
            }
            like.CollectionId = collections.Id;
            like.Count = 0;
            likesContext.Like.Add(like);
            likesContext.SaveChanges();
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
        [WebMethod]
        public void Like()
        {
            bool flag = Convert.ToBoolean(Request.QueryString["flag"]);
            int idCollection = Convert.ToInt32(Request.QueryString["id"]);
            LikesContext likesContext = new LikesContext();
            List<Likes> listLikes = likesContext.Likes.ToList();
            if (flag)
            {
                Likes likes = new Likes();
                if (likesContext.Likes.Count() >= 1)
                {
                    likes.Id = listLikes[listLikes.Count - 1].Id + 1;
                }
                else
                {
                    likes.Id = 1;
                }  
                likes.Collection = idCollection;
                likes.UserId = CurrentUser.Id;
                likesContext.Likes.Add(likes);
                likesContext.SaveChanges();
                int numberOfRowUpdated = likesContext.Database.ExecuteSqlCommand($"UPDATE Likes1 SET Count=Count+1 WHERE CollectionId={idCollection}");
            }
            else
            {
                int numberOfRowDeleted = likesContext.Database.ExecuteSqlCommand("DELETE FROM Likes WHERE Collection=@idCol and UserId=@userId", new SqlParameter("@idCol", idCollection), new SqlParameter("@userId",CurrentUser.Id));
                int numberOfRowUpdated = likesContext.Database.ExecuteSqlCommand($"UPDATE Likes1 SET Count=Count-1 WHERE CollectionId={idCollection}");
            }
            foreach(var item in likesContext.Like)
            {
                if (item.CollectionId == idCollection)
                    Response.Write(item.Count);
            }
            
        }
    }
}