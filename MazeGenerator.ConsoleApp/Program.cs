using System;
using MazeGenerator.ConsoleApp.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace MazeGenerator.ConsoleApp
{
    public class Program
    {

        public static void Main(string[] args)
        {
            var serviceProvider = ServiceProviderSetup.BuildServiceProvider();
            serviceProvider.GetService<ILoggerFactory>().AddSerilog();
            serviceProvider.GetService<ILoggerFactory>().AddFile("Logs/MazeGenerator-{Date}.txt");

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogInformation("Starting application");

            try
            {
                var mazeGeneratorApp = serviceProvider.GetService<IMazeGeneratorApp>();
                mazeGeneratorApp.RunApplication();
            }
            catch (Exception ex)
            {
                logger.LogError($"Error: {ex.Message}");
            }

            logger.LogInformation("Application end");
        }

    }
}
