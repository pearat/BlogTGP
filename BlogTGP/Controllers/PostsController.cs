using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlogTGP.Models;
using BlogTGP.Models.Code_First;
using Microsoft.AspNet.Identity;

namespace BlogTGP.Controllers
{
    [RequireHttps]
    public class PostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Posts
        public ActionResult Admin()
        {
            //var es = new EmailService();
            //var msg = new IdentityMessage();
            //msg.Body = "This is the body of a test message created in PostsController.cs";
            //msg.Subject = "Testing email service from Blog";
            //msg.Destination = "tpeara@gmail.com";
            //es.SendAsync(msg);

            return View(db.Posts.OrderByDescending(p=>p.Created).Take(12).ToList());
        }


        // GET: Posts
        public ActionResult Index()
        {
            return View(db.Posts.OrderByDescending(p => p.Created).Take(12).ToList());
        }


        // GET: Posts/AdminDetails/5
        public ActionResult AdminDetails(string slug)
        {
            if (String.IsNullOrWhiteSpace(slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.FirstOrDefault(p=>p.Slug == slug);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }


        // GET: Posts/AdminDetails/5
        public ActionResult Details(string slug)
        {
            if (String.IsNullOrWhiteSpace(slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.FirstOrDefault(p => p.Slug == slug);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        public ActionResult Post(string slug)
        {
            if (String.IsNullOrWhiteSpace(slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.FirstOrDefault(p => p.Slug == slug);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Posts/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more AdminDetails see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,Title,Body,MediaURL,Category")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.Created = System.DateTimeOffset.Now;
                //..... set slug here ....
                var Slug = StringUtilities.URLFriendly(post.Title);
                if (String.IsNullOrWhiteSpace(Slug))
                {
                    ModelState.AddModelError("Title", "A title is required");
                    return View(post);
                }
                if (db.Posts.Any(p=>p.Slug == Slug))
                {
                    ModelState.AddModelError("Title", "The title must be  unique");
                    return View(post);
                }
                post.Slug = Slug;

                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Admin");
            }

            return View(post);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more AdminDetails see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Created,Updated,Title,Slug,Body,MediaURL,Category")] Post post)
        {
            if (ModelState.IsValid)
            {

                post.Updated = System.DateTimeOffset.Now;
                //..... set slug here ....
                //var Slug = StringUtilities.URLFriendly(post.Title);
                //if (String.IsNullOrWhiteSpace(Slug))
                //{
                //    ModelState.AddModelError("Title", "A title is required");
                //    return View(post);
                //}
                //if (db.Posts.Any(p => p.Slug == Slug))
                //{
                //    ModelState.AddModelError("Title", "The title must be  unique");
                //    return View(post);
                //}
                //post.Slug = Slug;

                //db.Posts.Attach(post);
                //db.Entry(post).Property(p => p.Body).IsModified = true;
                //db.Entry(post).Property("Title").IsModified = true;
                //db.Entry(post).Property(p=>p.Updated).IsModified = true;
                //db.Entry(post).Property(p=>p.MediaURL).IsModified = true;
                //db.SaveChanges();

                db.Entry(post).State = EntityState.Modified;  // modifies entire row
                db.SaveChanges();

                return RedirectToAction("Admin");
            }
            return View(post);
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Admin");
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
