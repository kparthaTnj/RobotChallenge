// See https://aka.ms/new-console-template for more information
using Service;
using Service.Implementations;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.Design;
using Service.Interfaces;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog;
using ILogger = NLog.ILogger;

// enable logging, DI and red config if any
var services = CreateServices();
//get logger instance
var logger = LogManager.GetCurrentClassLogger();
logger.Info("Service started");



ISimulator app = services.GetRequiredService<ISimulator>();
IRobot robot = services.GetRequiredService<IRobot>();

Invoker invoker = new Invoker(app, robot);
// process command 
var currentDirectory = Directory.GetCurrentDirectory() + "/Inputs.txt";
if (File.Exists(currentDirectory))
{
    string[] commands = File.ReadAllLines(currentDirectory);
    if (commands != null)
    {
        //var r = invoker.ProcessCommand(new string[] { "PLACE 0,5,NORTH", "MOVE", "REPORT" });
        var r = invoker.ProcessCommand(commands);        
        var result = robot.Report();
        Console.WriteLine(result.ToString());
        Console.Read();
    }
}


static ServiceProvider CreateServices()
{
    var configuration = new ConfigurationBuilder()
        .Build();

    var serviceProvider = new ServiceCollection()
        .AddSingleton<ISimulator>(new Simulator())
        .AddSingleton<IRobot>(new Robot())
        .AddTransient<Invoker>()
        .AddLogging(loggingBuilder =>
        {
            // configure Logging with NLog
            loggingBuilder.ClearProviders();
            loggingBuilder.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
            loggingBuilder.AddNLog(configuration);

        })
        .BuildServiceProvider();
    return serviceProvider;
}