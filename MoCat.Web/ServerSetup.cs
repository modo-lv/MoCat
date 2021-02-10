using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MoCat.Core.Wiring;

namespace MoCat.Web {
  public class ServerSetup {
    /// <summary>
    /// Dependency setup.
    /// </summary>
    public virtual void ConfigureServices(IServiceCollection services) {
      CoreServices.AddTo(services);

      services
        // Web server
        .AddRouting()
        .AddLogging(_ => _
          .AddConsole()
          .AddDebug()
        );
      services.AddRazorPages();
    }

    /// <summary>
    /// Pre-startup setup.
    /// </summary>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      app
        .UseStaticFiles()
        .UseRouting()
        .UseEndpoints(_ => {
          _.MapRazorPages();
          _.MapControllers();
        });
    }
  }
}