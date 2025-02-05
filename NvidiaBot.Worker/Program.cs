using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NvidiaBot;
using NvidiaBot.Checkers;
using NvidiaBot.Worker;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddNvidiaBotConfiguration<Program>();
builder.Services
    .AddNvidiaBotServices(builder.Configuration)
    .AddSingleton<IChecker, FeInventoryChecker>()
    .AddSingleton<IChecker, ProductPageChecker>()
    .AddSingleton<IChecker, StoreSearchChecker>()
    .AddHostedService<Worker>();

await builder.Build().RunAsync();
