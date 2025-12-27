using System.Collections.Generic;
using System;

namespace TheOneCatBa.Models
{
    public class Rooms
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string RoomType { get; set; }
        public double PriceVND { get; set; }
        public double UnitRoom { get; set; }
        public double PriceUSD { get; set; }
        public double Discount { get; set; }
        public double FinalPrice
        {
            get
            {
                double priceRoom = PriceUSD;

                if (Discount > 0)
                {
                    if (PercentageDiscount)
                    {
                        priceRoom = Math.Round(PriceUSD - (PriceUSD * Discount / 100.0), 2);
                    }
                    else
                    {
                        priceRoom = PriceUSD - Discount;
                    }
                }

                return priceRoom;
            }
        }
        public string Caption { get; set; }
        public int View { get; set; }
        public int Booked { get; set; }
        public int Seq { get; set; }
        public double Stars { get; set; }
        public bool PercentageDiscount { get; set; }
        public string DetailBanner { get; set; }
        public string DetailBannerAlt { get; set; }
        public string Thumbnail { get; set; }
        public string ThumbnailAlt { get; set; }
        public string ImageMapAlt { get; set; }
        public List<RoomGalleryItem> Gallery { get; set; }
        public string Slug { get; set; }
        public string Highlight { get; set; }
        public List<string> Inclusions { get; set; }
        public List<string> Exclusions { get; set; }
        public string Overview { get; set; }
        public string ShortDescription { get; set; }
        public string Destination { get; set; }
        public string Departure { get; set; }
        public string Transport { get; set; }
        public string Duration { get; set; }
        public bool IsPopular { get; set; }
        public bool IsBestSeller { get; set; }
        public bool IsPublic { get; set; }
        public List<Interiors> Interiors { get; set; }
    }

    public class RoomGalleryItem
    {
        public string Url { get; set; }
        public string Alt { get; set; }
    }

    public class Interiors
    { 
        public string Url { get; set; }
        public string Alt { get; set; }
    }
}
