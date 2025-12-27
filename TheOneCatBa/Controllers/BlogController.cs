using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Drawing.Printing;
using System;
using TheOneCatBa.Models;
using TheOneCatBa.Services;
using System.Linq;
using TheOneCatBa.Utils;

namespace TheOneCatBa.Controllers
{
    public class BlogController : Controller
    {
        private CloudbedsService cloudbedsService;
        protected BlogService blogService;
        public BlogController(CloudbedsService cloudbedsService, BlogService blogService)
        {
            this.cloudbedsService = cloudbedsService;
            this.blogService = blogService;
        }

        public IActionResult Index(int page = 1, int pageSize = 4)
        {
            List<Blog> listBlog = blogService.GetAll();
            var paginatedBlog = listBlog.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            ViewData["allBlog"] = paginatedBlog;
            ViewData["currentPage"] = page;
            ViewData["totalPages"] = (int)Math.Ceiling((double)listBlog.Count / pageSize);

            ViewData["blogs"] = blogService.GetAll();
            ViewData["page"] = new Models.Page()
            {
                Banner = new Banner()
                {
                    Heading = "Lorem ipsum dolor",
                    SubHeading = "Lorem ipsum dolor sit amet consectetur. Commodo volutpat tellus et ac. Elementum congue sit ",
                    Image = new ImageApp()
                    {
                        Url = "/images/blog/banner-blog.jpg",
                        Alt = "blog-banner"
                    }
                },
            };
            return View();
        }

        public IActionResult Detail(string slug)
        {
            ViewData["rooms"] = cloudbedsService.GetAllRoomType();
            var blog = blogService.GetBySlug(slug);
            ViewData["blog"] = blog;
            ViewData["page"] = new Models.Page()
            {
                Banner = new Banner()
                {
                    Heading = "Title",
                    SubHeading = "Description",
                    Image = new ImageApp()
                    {
                        Url = blog.DetailBanner,
                        Alt = blog.DetailBannerAlt
                    }
                },
            };
            return View();
        }
    }
}
