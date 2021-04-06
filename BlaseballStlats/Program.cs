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
