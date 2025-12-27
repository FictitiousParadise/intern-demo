using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using TheOneCatBa.Models;
using TheOneCatBa.Utils;

namespace TheOneCatBa.Services
{
    
    public class CloudbedsService
    {
        public string GetToken()
        {

            HttpRequestHelper httpRequestHelper = new HttpRequestHelper
            {
                AlwaysMultipartFormData = true
            };

            httpRequestHelper.Parameter.Add("grant_type", "refresh_token");
            httpRequestHelper.Parameter.Add("client_id", EnviConfig.CloudbedsClientId);
            httpRequestHelper.Parameter.Add("client_secret", EnviConfig.CloudbedsClientSecret);
            httpRequestHelper.Parameter.Add("refresh_token", EnviConfig.RefreshToken);

            IRestResponse response = httpRequestHelper.Post("https://hotels.cloudbeds.com/api/v1.1/access_token", "");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<dynamic>(response.Content).access_token;
            else
            {
                string error = (JsonConvert.DeserializeObject(response.Content) as dynamic)?.error_description?.Value;

                throw new ArgumentException("Cloudbeds connection is invalid - " + error);

            }
        }

        public List<CloudbedsRoomType> GetAllRoomType()
        {
            string token = GetToken();

            if (string.IsNullOrWhiteSpace(token))
                return new List<CloudbedsRoomType>();

            HttpRequestHelper httpRequestHelper = new HttpRequestHelper();
            httpRequestHelper.Header.Add("Authorization", "Bearer " + token);

            List<CloudbedsRoomType> cloudbedsRooms = new List<CloudbedsRoomType>();

            string url_guest = "https://api.cloudbeds.com/api/v1.1/getRoomTypes";
            DateTime dateNow = DateTime.Now;
            string startDate = dateNow.AddMonths(2).ToString("yyyy-MM-dd");
            string endDate = dateNow.AddMonths(3).ToString("yyyy-MM-dd");

            IRestResponse response = httpRequestHelper.Get($"{url_guest}?startDate={startDate}&endDate={endDate}&adults=1&detailedRates=true&pageNumber=1&pageSize=100");

            var resp = JsonConvert.DeserializeObject<dynamic>(response.Content);

            cloudbedsRooms.AddRange(JsonConvert.DeserializeObject<List<CloudbedsRoomType>>(JsonConvert.SerializeObject(resp.data)));

            int total = resp.total;

            if (total > 100)
            {
                int loop = total / 100;
                if (total % 100 != 0)
                {
                    for (int i = 2; i <= loop; i++)
                    {
                        IRestResponse response2 = httpRequestHelper.Get($"{url_guest}?startDate={startDate}&endDate={endDate}&adults=1&detailedRates=true&pageNumber={i}&pageSize=100");

                        var jsonRoom2 = JsonConvert.DeserializeObject<dynamic>(response2.Content).data;

                        cloudbedsRooms.AddRange(JsonConvert.DeserializeObject<List<CloudbedsRoomType>>(JsonConvert.SerializeObject(jsonRoom2)));
                    }
                }
                loop += 1;
            }
            int months = 0;
            DateTime startD = DateTime.Parse("2024/05/14 12:00:00 AM");
            foreach (var item in cloudbedsRooms)
            {
                item.slug = DataHelper.CreateSlug(item.roomTypeName);
                item.view = Math.Abs((int)startD.AddMonths(months).Ticks / 10000000);

                if (item.roomRateDetailed?.Count > 0)
                {
                    item.price = item.roomRateDetailed[0].rate;
                }
                months++;
            }

            System.IO.File.WriteAllText("json/rooms.json", JsonConvert.SerializeObject(cloudbedsRooms));

            return cloudbedsRooms;
        }

        public CloudbedsRoomType GetRoomTypeDetail(string slug)
        {
            string roomJsons = System.IO.File.ReadAllText("json/rooms.json");

            List<CloudbedsRoomType> rooms = JsonConvert.DeserializeObject<List<CloudbedsRoomType>>(roomJsons);

            return rooms.FirstOrDefault(x => x.slug.ToLower().Equals(slug.ToLower()));
        }
    }
}
