﻿using CellableMVC.Models;
using CellableMVC.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CellableMVC.Helpers;
using System.Web.Configuration;

namespace CellableMVC.Controllers
{
    public class HomeController : Controller
    {
        private CellableEntities db = new CellableEntities();

        private string imageLocation = WebConfigurationManager.AppSettings["ImageLocation"];
        private string webImageLocation = WebConfigurationManager.AppSettings["WebImageLocation"];

        public ActionResult Index()
        {
            // Set the Average Star Rating Stuff
            AvgRating();

            // Get Testimonials
            IList<Testimonial> testimonial = db.Testimonials.Where(x => x.Published == true).ToList();

            var title = db.SystemSettings.Find(18);
            var text = db.SystemSettings.Find(2);
            var body = db.SystemSettings.Find(49);
            var footer = db.SystemSettings.Find(3);
            var Slide1 = db.SystemSettings.Find(4);


            ViewBag.Testimonials = testimonial;
            ViewBag.Title = title.Value;
            ViewBag.Text = text.Value;
            ViewBag.Body = body.Value;
            ViewBag.Footer = footer.Value;

            ViewBag.imageLocation = imageLocation;

            // Get Slide Show Images
            IList<SlideShow> slideShow = db.SlideShows.ToList();

            ViewBag.SlideShow = slideShow;

            var phones = db.Phones.ToList();

            // Reset 'Phone Value' session variable in case user revisit the home page
            Session["Phone Value"] = null;

            return View(phones);
        }

        public ActionResult About()
        {
            // Set the Average Star Rating Stuff
            AvgRating();

            var title = db.SystemSettings.Find(39);
            var text = db.SystemSettings.Find(40);
            var body = db.SystemSettings.Find(49);
            var footer = db.SystemSettings.Find(41);
            var image = db.SystemSettings.Find(42);

            ViewBag.Title = title.Value;
            ViewBag.Text = text.Value;
            ViewBag.Body = body.Value;
            ViewBag.Footer = footer.Value;
            ViewBag.Image = image.Value;

            ViewBag.imageLocation = imageLocation;

            return View();
        }

        public ActionResult Contact()
        {
            // Set the Average Star Rating Stuff
            AvgRating();

            var title = db.SystemSettings.Find(39);
            var address = db.SystemSettings.Find(9);
            var city = db.SystemSettings.Find(11);
            var state = db.SystemSettings.Find(12);
            var zip = db.SystemSettings.Find(13);
            var phone = db.SystemSettings.Find(14);
            var contactEmail = db.SystemSettings.Find(7);
            var adminEmil = db.SystemSettings.Find(8);

            ViewBag.Title = title.Value;
            ViewBag.Address = address.Value;
            ViewBag.City = city.Value;
            ViewBag.State = state.Value;
            ViewBag.Zip = zip.Value;
            ViewBag.Phone = phone.Value;
            ViewBag.ContactEmail = contactEmail.Value;
            ViewBag.AdminEmail = adminEmil.Value;

            ViewBag.imageLocation = imageLocation;

            return View();
        }

        private void AvgRating()
        {
            IList<Testimonial> testimonials = db.Testimonials.ToList();

            int total = testimonials.Count();
            int ratings = 0;
            int avg = 0;

            foreach (var item in testimonials)
            {
                ratings += item.Rating;
            }

            avg = ratings / total;

            Session["AvgStars"] = avg;
            Session["TotalStars"] = total;
        }
    }
}