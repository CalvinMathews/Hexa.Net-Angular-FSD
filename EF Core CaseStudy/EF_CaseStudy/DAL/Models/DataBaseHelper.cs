using Microsoft.Extensions.Configuration;

namespace EventAppDAL.Models
{
    public static class DatabaseHelper
    {
        public static string GetConnectionString()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("AppSettings.json", optional: true, reloadOnChange: true);
            string connectionString = builder.Build().GetConnectionString("EventDBcon");
            return connectionString;
        }
    }
}