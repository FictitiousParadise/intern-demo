using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheOneCatBa.Models
{
    public class ImageApp
    {
        public string Alt { get; set; }
        public string Url { get; set; }

    }
}
