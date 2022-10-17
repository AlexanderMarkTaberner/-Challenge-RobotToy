// Copyright Alexander Mark Taberner - 2022

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToyRobot.Services;
using ToyRobot.Services.Interfaces;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => {
        services.AddLogging();
        services.AddTransient<IInstructionBuilder, InstructionBuilder>();
        services.AddTransient<ISimulation, Simulation>();
        services.AddTransient<ToyRobotSimulation>();

    })
    .Build();

var app = host.Services.GetRequiredService<ToyRobotSimulation>();
app.Execute();
