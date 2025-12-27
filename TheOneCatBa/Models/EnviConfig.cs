using Microsoft.Extensions.Configuration;

namespace TheOneCatBa.Models
{
    public class EnviConfig
    {
        public static string CloudbedsClientId { get; set; }
        public static string CloudbedsClientSecret { get; set; }
        public static string CloudbedsRedirectUri { get; set; }
        public static string RefreshToken { get; set; }

        public static void Config(IConfiguration configuration)
        {
            CloudbedsClientId = configuration["CloudbedsConfig:ClientId"];
            CloudbedsClientSecret = configuration["CloudbedsConfig:ClientSecret"];
            CloudbedsRedirectUri = configuration["CloudbedsConfig:RedirectUri"];
            RefreshToken = configuration["CloudbedsConfig:RefreshToken"];
        }
    }
}
