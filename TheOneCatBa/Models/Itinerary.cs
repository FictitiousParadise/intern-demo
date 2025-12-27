using System.Collections.Generic;

namespace TheOneCatBa.Models
{
    public class Itinerary
    {
        public string Code { get; set; }
        public string TourCode { get; set; }
        public int Day { get; set; }
        public string DayTitle { get; set; }
        public string DaySubTitle { get; set; }
        public List<ItineraryDetail> ItineraryDetails { get; set; }
    }
}
