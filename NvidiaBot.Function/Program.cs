using Microsoft.Azure.Functions.Worker.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NvidiaBot;
using NvidiaBot.Checkers;

var builder = FunctionsApplication.CreateBuilder(args);
builder.ConfigureFunctionsWebApplication();

builder.Configuration.AddNvidiaBotConfiguration<Program>();
builder.Services
    .AddNvidiaBotServices(builder.Configuration)
    .AddSingleton<IFeInventoryChecker, FeInventoryChecker>()
    .AddSingleton<IProductPageChecker, ProductPageChecker>()
    .AddSingleton<IStoreSearchChecker, StoreSearchChecker>();

await builder.Build().RunAsync();