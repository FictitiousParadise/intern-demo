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
    public class RoomsController : Controller
    {
        private CloudbedsService cloudbedsService;
        public RoomsController(CloudbedsService cloudbedsService)
        {
            this.cloudbedsService = cloudbedsService;
        }
        public IActionResult Index()
        {
            List<CloudbedsRoomType> rooms = cloudbedsService.GetAllRoomType();
            List<CloudbedsRoomType> privateRooms = new List<CloudbedsRoomType>();
            List<CloudbedsRoomType> sharedRooms = new List<CloudbedsRoomType>();

            foreach (var item in rooms)
            {
                if (item.isPrivate)
                {
                    privateRooms.Add(item);
                }
                else
                {
                    sharedRooms.Add(item);
                }
            }

            ViewData["privateRooms"] = privateRooms;
            ViewData["sharedRooms"] = sharedRooms;
            ViewData["rooms"] = cloudbedsService.GetAllRoomType();
            ViewData["page"] = new Models.Page()
            {
                Banner = new Banner()
                {
                    Heading = "Title",
                    SubHeading = "Description",
                    Image = new ImageApp()
                    {
                        Url = "/images/rooms/banner-rooms.jpg",
                        Alt = "rooms-banner"
                    }
                },
            };
            return View();
        }

        public IActionResult Detail(string slug)
        {
            var rooms = cloudbedsService.GetRoomTypeDetail(slug);
            ViewData["rooms"] = rooms;

            if (rooms.roomTypePhotos != null && rooms.roomTypePhotos.Count > 0)
            {
                ViewData["page"] = new Models.Page()
                {
                    Banner = new Banner()
                    {
                        Heading = "",
                        SubHeading = "",
                        Image = new ImageApp()
                        {
                            Url = rooms.roomTypePhotos[0],
                            Alt = rooms.roomTypePhotos[0]
                        }
                    },
                };
            }
            else
            {
                // Handle the case where roomTypePhotos is empty or null
                ViewData["page"] = new Models.Page()
                {
                    Banner = new Banner()
                    {
                        Heading = "No Image Available",
                        SubHeading = "Room Type Photos Not Found",
                        Image = new ImageApp()
                        {
                            Url = "/images/home/rooms-grid-1.png",
                            Alt = "Default Image"
                        }
                    },
                };
            }

            return View();
        }

    }
}
