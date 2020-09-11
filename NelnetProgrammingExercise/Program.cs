using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NelnetProgrammingExercise.Models;
using NelnetProgrammingExercise.Repositories;
using NelnetProgrammingExercise.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NelnetProgrammingExercise
{
    class Program
    {       

        

        static async Task Main(string[] args)
        {

            var host = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<IPersonService, PersonRepository>();
                    services.AddSingleton<IPetService, PetRepository>();
                    services.AddHostedService<ConsoleApplication>();
                })
                .UseConsoleLifetime()
                .Build();


            using (host)
            {
                await host.StartAsync();
                await host.WaitForShutdownAsync();
            }

        }
       
    }
}
