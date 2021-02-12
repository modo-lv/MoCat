using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using MoCat.Web.Infrastructure;
using MoCat.Web.Tests.TestCore;
using Xunit;

namespace MoCat.Web.Tests.InitTests {
  public class MainPasswordTests : WebIntegrationTest {
    /// <summary>
    /// If there isn't a main password set in the DB, trying to open any page must redirect
    /// to init page instead.
    /// </summary>
    [Fact]
    public async Task IfNoMainPasswordThenRedirectToInitPage()
    {
      // ACT
      HttpResponseMessage response = await this.Client.GetAsync(Urls.LoginUrl);

      // ASSERT
      response.StatusCode.Should().Be(HttpStatusCode.Found);
      response.Headers.Location.Should().Be(Urls.InitUrl);
    }
  }
}