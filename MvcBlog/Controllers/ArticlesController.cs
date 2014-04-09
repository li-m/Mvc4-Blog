using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity.Infrastructure;

using MvcBlog.Models;

namespace MvcBlog.Controllers
{
    public class ArticlesController : Controller
    {
        /// <summary>
        /// Context object
        /// </summary>
        MyBlogContainer db = new MyBlogContainer();

        #region +ActionResult List()
        /// <summary>
        /// Display Article List
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            // SQO (standard query operator)
            // query articles
            // lazy load
            //DbQuery<Article> query = (db.Articles.Where(a => true)) as DbQuery<Article>;
            //List<Article> list = db.Articles.Where(a1 => true).ToList();

            // Linq
            List<Article> list = (from a2 in db.Articles where a2.IsDeleted == false select a2).ToList();

            // ViewBag and ViewData are the same thing
            ViewBag.ArticleList = list;
            ViewBag.Title = "MyBlog - Home";

            return View();
        }
        #endregion

        #region +ActionResult Delete(int id)
        /// <summary>
        /// Delete an Article according to its ID
        /// </summary>
        /// <param name="id">Id of the article to be deleted</param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            try
            {
                Article articletobeDel = new Article() { Id = id };
                db.Articles.Attach(articletobeDel);
                db.Articles.Remove(articletobeDel);
                db.SaveChanges();

                return RedirectToAction("List","Articles");
            }
            catch (Exception e)
            {
                return Content("Error: " + e.Message);
            }
        }
        #endregion

        #region +ActionResult Modify(int id)
        /// <summary>
        /// Display the article to be modified
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Modify(int id)
        {
            try
            {
                Article article = (from a in db.Articles where a.Id == id select a).FirstOrDefault();

                ViewBag.Title = "MyBlog - Modify - " + article.Title;
                return View(article);
            }
            catch (Exception e)
            {
                return Content("Error: " + e);
            }
        } 
        #endregion

        #region +ActionResult Modify(Article article)
        /// <summary>
        /// Execute Modify
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Modify(Article article)
        {
            ModelState.Remove("Date");
            ModelState.Remove("IsDeleted");
            if (ModelState.IsValid)
            {
                ModelState.Remove("Date");
                ModelState.Remove("IsDeleted");
                ModelState.Remove("Id");

                try
                {
                    // add entity object into container, retrieve object
                    DbEntityEntry<Article> entry = db.Entry<Article>(article);

                    // set unchanged
                    entry.State = System.Data.Entity.EntityState.Unchanged;

                    // modified properties
                    entry.Property(a => a.Title).IsModified = true;
                    entry.Property(a => a.Content).IsModified = true;

                    // commit
                    db.SaveChanges();
                    return RedirectToAction("Read", "Articles", new { id = article.Id });
                }
                catch (Exception e)
                {
                    return Content("Error: " + e.Message);
                }
            }
            else return View(article);
        } 
        #endregion

        #region +ActionResult Create()
        /// <summary>
        /// Display the page to create an article
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        } 
        #endregion

        #region +ActionResult Create(Article article)
        /// <summary>
        /// Submit an article
        /// </summary>
        /// <param name="article"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(Article article)
        {
            ModelState.Remove("Date");
            ModelState.Remove("IsDeleted");
            ModelState.Remove("Id");

            article.Date = DateTime.Now;
            article.IsDeleted = false;
            if (ModelState.IsValid)
            {
                try
                {
                    db.Articles.Add(article);
                    db.SaveChanges();
                    return RedirectToAction("List", "Articles");
                }
                catch (Exception e)
                {
                    return Content("Error: " + e.Message);
                }
            }

            else return View(article);
        } 
        #endregion

        #region +ActionResult Read(int id)
        /// <summary>
        /// Read an article
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Read(int id)
        {
            try
            {
                Article article = (from a in db.Articles where a.Id == id select a).FirstOrDefault();

                ViewBag.Title = "MyBlog - Read - " + article.Title;
                return View(article);
            }
            catch (Exception e)
            {
                return Content("Error: " + e.Message);
            }
        } 
        #endregion

    }
}
