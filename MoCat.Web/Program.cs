using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MoCat.Core.Wiring;
using IStartup = MoCat.Core.Wiring.IStartup;

namespace MoCat.Web {
  // ReSharper disable once ClassNeverInstantiated.Global
  internal class Program {
    /// <summary>
    /// Main entry/start point of the web app.
    /// </summary>
    public static void Main(String[] args) {
      Bootstrap();

      IHost host = Host
        .CreateDefaultBuilder()
        .ConfigureWebHostDefaults(_ => _
          .UseContentRoot(Directory.GetCurrentDirectory())
          .UseStartup<ServerSetup>()
        )
        .Build();

      // Run startup initializations
      using (IServiceScope scope = host.Services.CreateScope()) {
        IServiceProvider services = scope.ServiceProvider;

        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogInformation("User data: [{Dir}]", Running.BaseDir);

        var initSvc = services.GetRequiredService<IStartup>();

        initSvc.InitBaseDir();
      }

      // Run host
      host.Run();
    }


    /// <summary>
    /// Earliest crucial requirements.
    /// </summary>
    public static void Bootstrap() {
      // BaseDir must be set as early as possible, since a lot of things rely on BasePath()
      if (Running.InDebug) {
        Running.BaseDir = Path.Combine(
          new DirectoryInfo(AppContext.BaseDirectory).Parent!.Parent!.Parent!.Parent!.FullName,
          "MoCat.DebugData"
        );
      }
      else {
        Running.BaseDir = Path.Combine(
          Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
          "MoCat"
        );
      }
    }
  }
}