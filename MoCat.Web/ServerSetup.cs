using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MoCat.Core.Wiring;
using MoCat.Web.Components.Filters;
using MoCat.Web.Infrastructure;

namespace MoCat.Web {
  public class ServerSetup {
    /// <summary>
    /// Dependency setup.
    /// </summary>
    public virtual void ConfigureServices(IServiceCollection services) {
      CoreServices.AddTo(services);

      // Basics
      services
        .AddRouting()
        .AddLogging(_ => _
          .AddConsole()
          .AddDebug()
        );

      // Auth
      services
        .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(_ => { _.LoginPath = Urls.LoginUrl; });

      // MVC & pages
      services.AddMvc(cfg => cfg.Filters.Add<InitSanityCheckFilter>());
      services.AddRazorPages(_ => _
        .Conventions.AuthorizeFolder("/")
      );
    }

    /// <summary>
    /// Pre-startup setup.
    /// </summary>
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
      if (!Running.InTest) {
        app.UseDeveloperExceptionPage();
      }

      app.UseStaticFiles();
      app.UseCookiePolicy(new CookiePolicyOptions { HttpOnly = HttpOnlyPolicy.Always });

      // Order matters here, must be routing->auth->endpoints
      app.UseRouting();
      app.UseAuthentication();
      app.UseAuthorization();
      app.UseEndpoints(_ => {
        _.MapRazorPages();
        _.MapControllers();
      });
    }
  }
}