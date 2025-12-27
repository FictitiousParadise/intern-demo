using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TheOneCatBa.Models;
using Newtonsoft.Json;
using System;
using TheOneCatBa.Utils;
using TheOneCatBa.Util;
using System.Linq;

namespace TheOneCatBa.Services
{
    public class RoomService
    {
        public List<Rooms> GetAll()
        {
            string roomJsons = System.IO.File.ReadAllText("json/rooms.json");
            List<Rooms> rooms = JsonConvert.DeserializeObject<List<Rooms>>(roomJsons);
            return rooms.OrderBy(x => x.Seq).ToList();
        }

        public Rooms GetBySlug(string slug)
        {
            string roomJsons = System.IO.File.ReadAllText("json/rooms.json");

            List<Rooms> rooms = JsonConvert.DeserializeObject<List<Rooms>>(roomJsons);

            return rooms.FirstOrDefault(x => x.Slug.ToLower().Equals(slug.ToLower()));
        }
    }
}
