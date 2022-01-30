using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Options;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

using AnalyseMeAPI.Middlewares;

namespace AnalyseMeAPI.Startup {

  public class App {

    public IConfiguration Configuration {
      get;
    }
    public App(IConfiguration configuration) {
      Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services) {
      services.AddCors(options => {
        options.AddPolicy("CorsPolicy",
          builder => builder
          .AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());
        //.AllowCredentials());
      });

      services.AddControllers();
      services.AddSingleton < IMongoClient, MongoClient > (s => {
        var url = s.GetRequiredService < IConfiguration > ()["DatabaseURL"];
        return new MongoClient(url);
      });

    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      app.UsePathBase(new PathString("/api"));
      app.UseHttpsRedirection();
      app.UseCors("CorsPolicy");

      app.UseMiddleware < CreateSession > ();

      app.UseRouting();
      app.UseEndpoints(endpoints => {
        endpoints.MapControllers();
      });
    }
  }
}