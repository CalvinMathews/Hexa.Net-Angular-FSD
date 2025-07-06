using Microsoft.Extensions.Configuration;
using System.IO;

namespace DAL.Models
{
    public static class DatabaseHelper
    {
        public static string GetConStr()
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            return config.GetConnectionString("DefaultConnection");
        }
    }
}
