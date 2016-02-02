using BlogTGP.Models.Code_First;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogTGP.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Contact(ContactMsg contact)
        {
            //ViewBag.Message = "Your contact page.";           

            var es = new EmailService();
            var msg = new IdentityMessage
            {
                Subject = "Email from Blog",
                Destination = ConfigurationManager.AppSettings["ContactEmail"],
                Body = "On <<"+ System.DateTimeOffset.Now+ 
                ">> you received a new Contact Form Submission from:" +
                    " (" + contact.EmailAddress + ") msg as follows: \n\n"
            };
            es.SendAsync(msg);

            return RedirectToAction("Index","Posts");
        }
    }
}