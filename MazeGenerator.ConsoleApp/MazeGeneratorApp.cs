using System;
using MazeGenerator.ConsoleApp.PrintService;
using MazeGenerator.Library.Contracts;
using MazeGenerator.Library.DTOs;
using Microsoft.Extensions.Logging;

namespace MazeGenerator.ConsoleApp
{
    public class MazeGeneratorApp : IMazeGeneratorApp
    {
        private Maze _maze;
        private readonly ILogger<MazeGeneratorApp> _logger;
        private readonly IMazeConfiguration _mazeConfiguration;
        private readonly IMazeService _mazeService;
        private readonly IMazePrinter _mazePrinter;
        private int _x, _y;

        public MazeGeneratorApp(IMazeConfiguration mazeConfiguration,
            IMazeService mazeService,
            IMazePrinter mazePrinter,
            ILogger<MazeGeneratorApp> logger)
        {
            _mazeConfiguration = mazeConfiguration;
            _mazeService = mazeService;
            _mazePrinter = mazePrinter;
            _logger = logger;
        }

        public void RunApplication()
        {
            try
            {
                GetValues();

                do
                {
                    GenerateMaze();
                    PrintMaze();
                } while (GetMenuOption() == "Y");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error: {ex.Message}");
            }

            Console.ReadLine();
        }

        private string GetMenuOption()
        {
            Console.Write("\nIf you want to generate another Maze insert 'Y': ");
            return Console.ReadLine().ToUpper();
        }

        public void GetValues()
        {
            _x = GetInput("Input the X value: ", _mazeConfiguration.MinValue, _mazeConfiguration.MaxValue);
            _y = GetInput("Input the Y value: ", _mazeConfiguration.MinValue, _mazeConfiguration.MaxValue);
            Console.WriteLine($"Maze dimensions: ({_x}, {_y})\n");
        }

        public void GenerateMaze()
        {
            _logger.LogInformation("Generating maze...");
            _maze = _mazeService.GenerateMaze(_x, _y);
            _logger.LogInformation("Maze Generated");
        }

        public void PrintMaze()
        {
            _logger.LogInformation("Printing maze...");
            _mazePrinter.PrintMaze(_maze);
            _logger.LogInformation("Maze Printed");
        }

        public int GetInput(string message, int minValue, int maxValue)
        {
            int result;

            do
            {
                Console.Write(message);
                int.TryParse(Console.ReadLine(), out result);
                if (result == 0 || result < minValue || result > maxValue)
                    Console.WriteLine($"The value inputed is not valid or is not in range, it must be between {_mazeConfiguration.MinValue} and {_mazeConfiguration.MaxValue}");
            } while (result == 0 || result < minValue || result > maxValue);

            return result;
        }
    }
}
