using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NvidiaBot;
using NvidiaBot.Checkers;
using NvidiaBot.Clients;
using NvidiaBot.Worker;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration.AddNvidiaBotConfiguration<Program>();
builder.Services
    .AddNvidiaBotServices(builder.Configuration)
    .AddSingleton<IChecker, FeInventoryChecker>()
    .AddSingleton<IChecker, ProductPageChecker>()
    .AddSingleton<IChecker, StoreSearchChecker>()
    .AddHostedService<Worker>()
    .AddTransient<Func<NvidiaOptions, IFeInventoryChecker>>(provider => 
        nvidiaOpts =>
        {
            var feInventoryClient = provider.GetRequiredService<IFeInventoryClient>();
            return new FeInventoryChecker(feInventoryClient, nvidiaOpts);
        })
    .AddTransient<Func<NvidiaOptions, IProductPageChecker>>(provider =>
        nvidiaOpts =>
        {
            var storeSearchClient = provider.GetRequiredService<IStoreSearchClient>();
            return new ProductPageChecker(storeSearchClient, nvidiaOpts);
        })
    .AddTransient<Func<NvidiaOptions, IStoreSearchChecker>>(provider =>
        nvidiaOpts =>
        {
            var storeSearchClient = provider.GetRequiredService<IStoreSearchClient>();
            return new StoreSearchChecker(storeSearchClient, nvidiaOpts);
        });

await builder.Build().RunAsync();
