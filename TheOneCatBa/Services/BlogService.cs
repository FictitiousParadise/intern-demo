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
    public class BlogService
    {
        public List<Blog> GetAll()
        {
            string blogJsons = System.IO.File.ReadAllText("json/blog.json");
            List<Blog> blogs = JsonConvert.DeserializeObject<List<Blog>>(blogJsons);
            return blogs;
        }

        public Blog GetBySlug(string slug)
        {
            string blogJsons = System.IO.File.ReadAllText("json/blog.json");

            List<Blog> blogs = JsonConvert.DeserializeObject<List<Blog>>(blogJsons);

            return blogs.FirstOrDefault(x => x.Slug.ToLower().Equals(slug.ToLower()));
        }
    }
}
