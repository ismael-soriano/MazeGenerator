using System;
using MazeGenerator.ConsoleApp.PrintService;
using MazeGenerator.Library.Contracts;
using MazeGenerator.Library.Impl;
using MazeGenerator.Library.Impl.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MazeGenerator.ConsoleApp.Helpers
{
    public class ServiceProviderSetup
    {
        public static IServiceProvider BuildServiceProvider()
        {
            return new ServiceCollection()
            .AddLogging()
            .AddSingleton<IMazeConfiguration, MazeConfiguration>()
            .AddSingleton<IMazeService, MazeService>()
            .AddSingleton<IMazeGeneratorApp, MazeGeneratorApp>()
            .AddSingleton<IMazePrinter, MazePrinter>()
            .AddTransient<IMazeGenerator, Library.Impl.MazeGenerator>()
            .AddTransient<IBorderGenerationService, BorderGenerationService>()
            .AddTransient<IExitsGenerationService, ExitsGenerationService>()
            .AddTransient<IPathGenerationService, PathGenerationService>()
            .BuildServiceProvider();
        }
    }
}
