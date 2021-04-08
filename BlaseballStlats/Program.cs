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
            var garages = controller.GetTeam(Guid.Parse("105bc3ff-1320-4e37-8ef0-8d595cb95dd0")).GetAwaiter().GetResult();
            var lovers = controller.GetTeam("Lovers").GetAwaiter().GetResult();
            var georgians = controller.GetTeam("ATL").GetAwaiter().GetResult();
            var worms = controller.GetTeam("Ohio").GetAwaiter().GetResult();
            var mechanics = controller.GetTeam("Core Mechanics").GetAwaiter().GetResult();
            var teamsSortedByCombinedStars = teams.ToList();
            teamsSortedByCombinedStars.Sort((x, y) => x.AverageActiveCombinedStars.CompareTo(y.AverageActiveCombinedStars));
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
