using Assignment_Di.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using Microsoft.AspNet.Identity;


namespace Assignment_Di.Controllers
{
    [Authorize]
    public class ImageGalleryController : Controller
    {
        // GET: ImageGallery
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            List<ImageGallery> all = new List<ImageGallery>();

            // Here Cast is our datacontext
            using (Casts db = new Casts())
            {
                all = db.ImageGallery.ToList();
            }
            return View(all);
        }

        [Authorize]
        public ActionResult IndexUserNames()
        {
                string currentUserId = User.Identity.GetUserId();
                List<ImageGallery> selected = new List<ImageGallery>();
                using (Casts dc = new Casts())
                {
                    selected = dc.ImageGallery.Where(m => m.UserName == currentUserId).ToList();
                }
                return View(selected);
        }

        public ActionResult CreateIndividual()
        {
            ImageGallery image = new ImageGallery();
            string currentUserId = User.Identity.GetUserId();
            image.UserName = currentUserId;
            return View(image);
        }

        [HttpPost]
        public ActionResult CreateIndividual(ImageGallery IG)
        {

            if (IG.File.ContentLength > (2 * 1024 * 1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                return View(IG);
            }
            if (!(IG.File.ContentType == "image/jpeg" || IG.File.ContentType == "image/png"))
            {
                ModelState.AddModelError("CustomError", "File type allowed : jpeg and png");
                return View(IG);
            }

            IG.FileName = IG.File.FileName;
            IG.ImageSize = IG.File.ContentLength;

            byte[] data = new byte[IG.File.ContentLength];
            IG.File.InputStream.Read(data, 0, IG.File.ContentLength);

            IG.ImageData = data;
            using (Casts db = new Casts())
            {
                db.ImageGallery.Add(IG);
                db.SaveChanges();
            }
            return RedirectToAction("IndexUserNames");
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(ImageGallery IG)
        {
            // Apply Validation Here

            if (IG.File.ContentLength > (2*1024*1024))
            {
                ModelState.AddModelError("CustomError", "File size must be less than 2 MB");
                return View(IG);
            }
            if (!(IG.File.ContentType == "image/jpeg" || IG.File.ContentType == "image/gif"))
            {
                ModelState.AddModelError("CustomError", "File type allowed : jpeg and gif");
                return View(IG);
            }

            IG.FileName = IG.File.FileName;
            IG.ImageSize = IG.File.ContentLength;

            byte[] data = new byte[IG.File.ContentLength];
            IG.File.InputStream.Read(data, 0, IG.File.ContentLength);

            IG.ImageData = data;
            using (Casts db = new Casts())
            {
                db.ImageGallery.Add(IG);
                db.SaveChanges();
            }
            return RedirectToAction("Gallery");
        }
    }
}