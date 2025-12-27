using System;
using System.Collections.Generic;

namespace TheOneCatBa.Models
{
    public class RateDetailed
    {
        public DateTime date { get; set; }
        public double rate { get; set; }
        public int adults { get; set; }
        public int kids { get; set; }
    }

    public class CloudbedsRoomType
    {
        public int propertyID { get; set; }
        public int roomTypeID { get; set; }
        public string roomTypeName { get; set; }
        public string roomTypeDescription { get; set; }
        public int maxGuests { get; set; }
        public int adultsIncluded { get; set; }
        public int childrenIncluded { get; set; }
        public List<string> roomTypePhotos { get; set; }
        public int roomRateID { get; set; }
        public float roomRate { get; set; }
        public int roomsAvailable { get; set; }
        public int roomTypeUnits { get; set; }
        public bool isPrivate { get; set; }
        public List<RateDetailed> roomRateDetailed { get; set; }
        public string slug { get; set; }
        public double price { get; set; }
        public int view { get; set; }
    }
}
