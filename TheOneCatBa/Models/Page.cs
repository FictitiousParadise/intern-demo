using Microsoft.AspNetCore.Mvc;

namespace TheOneCatBa.Models
{
    public class Page
    {
        public Banner Banner { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
    }
}
