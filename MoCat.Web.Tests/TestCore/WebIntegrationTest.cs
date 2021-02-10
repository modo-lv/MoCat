using System;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using MoCat.Core.Entities;

namespace MoCat.Web.Tests.TestCore {
  public class WebIntegrationTest {
    protected readonly TestServer Server;
    protected readonly HttpClient Client;
    protected readonly IServiceProvider Services;
    protected readonly IDbContext Db;
    
    // ReSharper disable once UnusedMember.Global
    protected WebIntegrationTest()
    {
      this.Server = new TestServer(
        new WebHostBuilder()
          .UseEnvironment("Testing")
          .UseContentRoot(@"..\..\..\..\MoCat.Web")
          .UseStartup<TestServerSetup>());
      this.Services = this.Server.Host.Services;
      this.Db = this.Services.GetRequiredService<IDbContext>();
      this.Client = this.Server.CreateClient();
    }
  }
}