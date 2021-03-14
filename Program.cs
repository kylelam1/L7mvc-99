using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//tinfo200:[2021-03-3-kylelam-dykstra1] - We will need this so we are able to use the directories from the data file
using ContosoUniversity.Data;
//tinfo200:[2021-03-3-kylelam-dykstra1] - Let asp.net works its magic and find out whatever it needs whenver it needs to
using Microsoft.Extensions.DependencyInjection;

namespace ContosoUniversity
{
    public class Program
    {
        public static void Main(string[] args)
        {

            //tinfo200:[2021-03-3-kylelam-dykstra1] - At first, it had the build and run put together. But this code seperates it so we can put the cretDBitnotexits. 
            var host = CreateHostBuilder(args).Build();

            //tinfo200:[2021-03-3-kylelam-dykstra1] - It will look at the db to determine if it is there or not. as the name says, it will create one like a pervious one if it does not exist
            CreateDbIfNotExists(host);

            host.Run();
        }

        //tinfo200:[2021-03-3-kylelam-dykstra1] - The method. It will look at the db to determine if it is there or not. as the name says, it will create one like a pervious one if it does not exist
        //tinfo200:[2021-03-3-kylelam-dykstra1] - To create it, it will create an array and load some test data into there
        private static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    //tinfo200:[2021-03-3-kylelam-dykstra1] - If does not exist, it will call the class, it will then display an error and let the user know
                    var context = services.GetRequiredService<SchoolContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB.");
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
