using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using MoCat.Core.Tests.TestCore;

namespace MoCat.Web.Tests.TestCore {
  public class TestServerSetup : ServerSetup {
    public override void ConfigureServices(IServiceCollection services) {
      base.ConfigureServices(services);

      services.AddTestServices();
      
      // Avoid having to deal with CSRF protection in integration tests.
      services.AddRazorPages(_ => _.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute()));
    }
  }
}