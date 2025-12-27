using System.Collections.Generic;
using System;

namespace TheOneCatBa.Models
{
    public class Blog
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Slug { get; set; }
        public string BlogType { get; set; }
        public string DetailBanner { get; set; }
        public string DetailBannerAlt { get; set; }
        public string PostedAt { get; set; }
        public string Author { get; set; }
        public string Thumbnail { get; set; }
        public string ThumbnailAlt { get; set; }
        public bool Highlighted { get; set; }
        public List<BlogContent> Content { get; set; }
    }

    public class BlogContent
    {
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
