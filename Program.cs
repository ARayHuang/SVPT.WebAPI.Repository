using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SVPT.WebAPI.Store.Context;
using SVPT.WebAPI.Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SVPT.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            if (args.Length > 0 && args[0] == "DBInit") 
            {
                using (var scope = host.Services.CreateScope())
                {
                    try
                    {
                        var dbContext = scope.ServiceProvider.GetService<SVTPDbContext>();

                        dbContext.Database.EnsureDeleted();
                        dbContext.Database.EnsureCreated();

                        Fixtures.InitFixtures(dbContext);

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }

            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
