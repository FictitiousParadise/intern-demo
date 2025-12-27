using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TheOneCatBa.Models;
using TheOneCatBa.Services;
using TheOneCatBa.Utils;

namespace TheOneCatBa.Controllers
{
    public class HomeController : Controller
    {
        private CloudbedsService cloudbedsService;
        protected TourService tourService;
        public HomeController(CloudbedsService cloudbedsService, TourService tourService)
        {
            this.cloudbedsService = cloudbedsService;
            this.tourService = tourService;
        }

        public IActionResult Index()
        {
            ViewData["rooms"] = cloudbedsService.GetAllRoomType();
            ViewData["tours"] = tourService.GetAll();
            ViewData["page"] = new Models.Page()
            {
                Banner = new Banner()
                {
                    Heading = "Lorem ipsum dolor",
                    SubHeading = "Lorem ipsum dolor sit amet consectetur. Commodo volutpat tellus et ac. Elementum congue sit ",
                    Image = new ImageApp()
                    {
                        Url = "/images/home/home-banner.jpg",
                        Alt = "home-banner"
                    }
                },
            };
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["page"] = new Models.Page()
            {
                Banner = new Banner()
                {
                    Heading = "",
                    SubHeading = "",
                    Image = new ImageApp()
                    {
                        Url = "/images/privacy/privacy-banner.jpg",
                        Alt = "home-banner"
                    }
                },
            };
            return View();
        }

        public IActionResult AboutUs()
        {
            ViewData["page"] = new Models.Page()
            {
                Banner = new Banner()
                {
                    Heading = "About us",
                    SubHeading = "Description",
                    Image = new ImageApp()
                    {
                        Url = "/images/aboutUs/about-us-banner.jpg",
                        Alt = "about-us-banner"
                    }
                },
            };
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
