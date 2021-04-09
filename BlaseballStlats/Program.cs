using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BlaseballStlats.DataControllers;
using BlaseballStlats.Models;
using Newtonsoft.Json;

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
            var chronicler = new ApiControllerChronicler();
            var carmeloBefore = chronicler.GetPlayer(Guid.Parse("c18961e9-ef3f-4954-bd6b-9fe01c615186"), DateTimeOffset.Parse("2021-04-09T02:00:00Z")).GetAwaiter().GetResult();
            var carmeloAfter = chronicler.GetPlayer(Guid.Parse("c18961e9-ef3f-4954-bd6b-9fe01c615186"), DateTimeOffset.Parse("2021-04-09T04:30:00Z")).GetAwaiter().GetResult();
            var carmeloCompare = new PlayerComparison(carmeloAfter, carmeloBefore);
            var carmeloCompareJson = JsonConvert.SerializeObject(carmeloCompare, Formatting.Indented);
            File.WriteAllText("CarmeloComparison.json", carmeloCompareJson);
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
