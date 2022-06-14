using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // var builder = WebApplication.CreateBuilder(args);
                    
                    // // Add services to the container.
                    // builder.Services.AddControllers();
                    
                    // // Connect to PostgreSQL Database
                    // var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
                    // builder.Services.AddDbContext<AppDbContext>(options =>
                    //     options.UseNpgsql(connectionString));

                    webBuilder.UseStartup<Startup>();
                });
    }
}
