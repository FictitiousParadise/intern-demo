using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;
using TheOneCatBa.Models;

namespace TheOneCatBa.Models
{
    public class Banner
    {
        public string Heading { get; set; }
        public string SubHeading { get; set; }
        public string SubText { get; set; }
        public ImageApp Image { get; set; }
    }
}
