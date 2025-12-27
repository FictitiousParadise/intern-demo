using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TheOneCatBa.Models;
using TheOneCatBa.Services;

namespace TheOneCatBa.Controllers
{
    public class TourController : Controller
    {
        protected TourService tourService;
        public TourController(TourService tourService)
        {
            this.tourService = tourService;
        }
        public IActionResult Index(int page = 1, int pageSize = 6)
        {
            ViewData["tours"] = tourService.GetAll();

            List<Tours> listTours = tourService.GetAll();
            var paginatedTours = listTours.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewData["allTour"] = paginatedTours;
            ViewData["currentPage"] = page;
            ViewData["totalPages"] = (int)Math.Ceiling((double)listTours.Count / pageSize);

            ViewData["page"] = new Models.Page()
            {
                Banner = new Banner()
                {
                    Heading = "Title",
                    SubHeading = "Description",
                    Image = new ImageApp()
                    {
                        Url = "/images/tour/tour-banner.jpg",
                        Alt = "tour-banner"
                    }
                },
            };
            return View();
        }

        public IActionResult Detail(string slug)
        {
            var tour = tourService.GetBySlug(slug);
            ViewData["tour"] = tour;
            ViewData["page"] = new Models.Page()
            {
                Banner = new Banner()
                {
                    Heading = "",
                    SubHeading = "",
                    Image = new ImageApp()
                    {
                        Url = tour.DetailBanner,
                        Alt = tour.DetailBannerAlt
                    }
                },
            };
            return View();
        }
    }
}
