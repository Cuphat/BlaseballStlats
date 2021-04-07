using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlaseballStlats.DataControllers;

namespace BlaseballStlats
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*/
            var controller = new BlaseballDataController();
            var garages = Guid.Parse("105bc3ff-1320-4e37-8ef0-8d595cb95dd0");
            var teams = controller.GetAllTeams().GetAwaiter().GetResult();
            return;
            /*/

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
