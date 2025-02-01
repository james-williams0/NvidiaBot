using System.Net;
using System.Net.Http.Headers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NvidiaBot;
using Refit;

var builder = Host.CreateApplicationBuilder();
builder.Services
    .AddRefitClient<IFeInventoryClient>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri("https://api.store.nvidia.com");
        c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/javascript"));
        c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*", 0.01));
        c.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-GB"));
        c.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en", 0.5));
        c.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
        c.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
        c.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("br"));
        c.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("zstd"));
        c.DefaultRequestHeaders.Host = "api.store.nvidia.com";
        c.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:134.0) Gecko/20100101 Firefox/134.0");
        c.DefaultRequestHeaders.Referrer = new Uri("https://marketplace.nvidia.com");
        c.DefaultRequestHeaders.Connection.Add("keep-alive");
    });

builder.Services
    .AddRefitClient<IStoreSearchClient>()
    .ConfigureHttpClient(c =>
    {
        c.BaseAddress = new Uri("https://api.nvidia.partners");
        c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/javascript"));
        c.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));
        c.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en-GB"));
        c.DefaultRequestHeaders.AcceptLanguage.Add(new StringWithQualityHeaderValue("en", 0.5));
        c.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
        c.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("deflate"));
        c.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("br"));
        c.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("zstd"));
        c.DefaultRequestHeaders.Host = "api.nvidia.partners";
        c.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:134.0) Gecko/20100101 Firefox/134.0");
        c.DefaultRequestHeaders.Referrer = new Uri("https://marketplace.nvidia.com");
        c.DefaultRequestHeaders.Connection.Add("keep-alive");
    })
    .ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
    {
        AutomaticDecompression = DecompressionMethods.All
    });
builder.Services.AddHostedService<Worker>();
await builder.Build().RunAsync();