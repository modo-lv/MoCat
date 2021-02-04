using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MoCat.Core.Wiring;

namespace MoCat.Web {
  public class ServerSetup {
    /// <summary>
    /// Dependency setup.
    /// </summary>
    public void ConfigureServices(IServiceCollection services) {
      CoreServices.AddTo(services);

      // Logging
      services.AddLogging(builder => {
        builder
          .AddFilter("MoCat.Web", Running.InDebug ? LogLevel.Debug : LogLevel.Information)
          .AddFilter("Microsoft", LogLevel.Warning)
          .AddFilter("System", LogLevel.Warning)
          .AddConsole()
          .AddDebug();
      });
    }

    /// <summary>
    /// Pre-startup setup.
    /// </summary>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      app.UseStaticFiles();
    }
  }
}