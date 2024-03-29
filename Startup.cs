using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Net.Http;
using System.Text.Json;
using FoodCatalog.Services;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FoodCatalog
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddResponseCompression();

            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });
            services.AddHttpClient<FoodService>(c =>
            {
                c.BaseAddress = new Uri(Configuration["TacoFoodAddress"]);
            });
            services.AddMemoryCache();
            services.AddMediatR(GetType().Assembly);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IMemoryCache cache, IHttpClientFactory httpClientFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            AddFoodData(cache, httpClientFactory);
        }

        private async void AddFoodData(IMemoryCache cache, IHttpClientFactory httpClientFactory)
        {
            using var client = httpClientFactory.CreateClient();
            var response = await client.GetAsync($"{ Configuration["TacoFoodAddress"]}food");
            var foods = await JsonSerializer.DeserializeAsync<IEnumerable<FoodRequest>>(await response.Content.ReadAsStreamAsync());
            cache.Set("foods", foods);
        }
    }
}
