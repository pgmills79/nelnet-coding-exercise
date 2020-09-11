using Microsoft.Extensions.DependencyInjection;
using NelnetProgrammingExercise.Repositories;
using NelnetProgrammingExercise.Services;
using System;

namespace NelnetProgrammingExercise
{
    class Program
    {

        private static IServiceProvider _serviceProvider;

        static void Main(string[] args)
        {
            //DI (injection)
            RegisterServices();
            IServiceScope scope = _serviceProvider.CreateScope();
            scope.ServiceProvider.GetRequiredService<ConsoleApplication>().Run();
            DisposeServices();
        }

        private static void RegisterServices()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IPersonService, PersonRepository>();
            services.AddSingleton<IPetService, PetRepository>();
            services.AddSingleton<ConsoleApplication>();
            _serviceProvider = services.BuildServiceProvider(true);
        }

        private static void DisposeServices()
        {
            if (_serviceProvider == null)
            {
                return;
            }
            if (_serviceProvider is IDisposable)
            {
                ((IDisposable)_serviceProvider).Dispose();
            }
        }

    }
}
