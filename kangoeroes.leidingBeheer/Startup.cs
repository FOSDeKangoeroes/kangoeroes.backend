﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using kangoeroes.core.Data.Context;
using kangoeroes.core.Data.Repositories;
using kangoeroes.core.Data.Repositories.Interfaces;
using kangoeroes.leidingBeheer.Auth;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace kangoeroes.leidingBeheer
{
  public class Startup
  {
    public IConfigurationRoot Configuration { get; }

    public Startup(IHostingEnvironment env)
    {
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true);

      builder.AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      //Te gebruiken database configureren
      services.AddDbContext<ApplicationDbContext>(options => {

        options.UseMySql(Configuration.GetConnectionString("Default"));
      });
      services.AddAutoMapper();

      //Mvc en bijhorende opties configureren
      services.AddMvc().AddJsonOptions(options => {

        //Loops in response worden genegeerd. Bijv: Leiding -> Tak -> Leiding -> Tak -> .. wordt Leiding -> Tak
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

      });

      services.AddOptions();
      //Dependency Injection registreren
      services.AddScoped<ApplicationDbContext>();
      services.AddTransient<ITakRepository, TakRepository>();
      services.AddTransient<ILeidingRepository, LeidingRepository>();

       services.AddSingleton<IConfiguration>(Configuration);
      //services.Configure<Auth0Config>(Configuration.GetSection("Auth0"));
      services.AddScoped<Auth0Helper>();


    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      if (env.IsDevelopment()) {
        app.UseDeveloperExceptionPage();
      }

      loggerFactory.AddConsole(Configuration.GetSection("Logging"));
      loggerFactory.AddDebug();

      app.UseDefaultFiles();
      app.UseStaticFiles();

      app.Use(async (context, next) => {

        await next();
        if (context.Response.StatusCode == 404 &&
            !Path.HasExtension(context.Request.Path.Value) &&
            !context.Request.Path.Value.StartsWith("/api/"))
        {
          context.Request.Path = "/index.html";
          await next();
        }
      });

      app.UseMvcWithDefaultRoute();
    }
  }
}
