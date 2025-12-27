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
    public class TourService
    {
        public List<Tours> GetAll()
        {
            string tourJsons = System.IO.File.ReadAllText("json/tours.json");
            List<Tours> tours = JsonConvert.DeserializeObject<List<Tours>>(tourJsons);
            return tours.OrderBy(x => x.Seq).ToList();
        }

        public Tours GetBySlug(string slug)
        {
            string tourJsons = System.IO.File.ReadAllText("json/tours.json");

            List<Tours> tours = JsonConvert.DeserializeObject<List<Tours>>(tourJsons);

            return tours.FirstOrDefault(x => x.Slug.ToLower().Equals(slug.ToLower()));
        }
    }
}
