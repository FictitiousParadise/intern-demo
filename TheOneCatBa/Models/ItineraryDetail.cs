using System.Collections.Generic;

namespace TheOneCatBa.Models
{
    public class ItineraryDetail
    {
        public string Code { get; set; }
        public string ItineraryCode { get; set; }
        public string Duration { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<ImageApp> Images { get; set; }
    }
}
