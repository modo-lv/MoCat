using System;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MoCat.Core.Entities;

namespace MoCat.Web.Tests.TestCore {
  public class WebIntegrationTest {
    protected readonly TestServer Server;
    protected readonly HttpClient Client;
    protected readonly IServiceProvider Services;
    protected readonly IDbContext Db;

    // ReSharper disable once UnusedMember.Global
    protected WebIntegrationTest() {
      IWebHostBuilder host = WebHost
        .CreateDefaultBuilder<TestServerSetup>(Array.Empty<String>())
        .UseContentRoot(@"..\..\..\..\MoCat.Web");
      this.Server = new TestServer(host);
      this.Services = this.Server.Host.Services;
      this.Db = this.Services.GetRequiredService<IDbContext>();
      this.Client = this.Server.CreateClient();
    }
  }
}