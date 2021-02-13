using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using MoCat.Core.Entities.Db;
using MoCat.Web.Infrastructure;
using MoCat.Web.Tests.TestCore;
using Xunit;
using Encryption = BCrypt.Net.BCrypt;

namespace MoCat.Web.Tests.InitTests {
  public class MainPasswordTests : WebIntegrationTest {
    /// <summary>
    /// If there isn't a main password set in the DB, trying to open any page must redirect
    /// to init page instead.
    /// </summary>
    [Fact]
    public async Task IfNoMainPasswordThenRedirectToInitPage() {
      // ACT
      HttpResponseMessage response = await this.Client.GetAsync(Urls.LoginUrl);

      // ASSERT
      response.StatusCode.Should().Be(HttpStatusCode.Found);
      response.Headers.Location.Should().Be(Urls.InitUrl);
    }

    [Fact]
    public async Task WhenFormSubmittedThenPasswordIsEncryptedAndStored() {
      var input = new { Password = "Test main password" };

      // Create user
      HttpResponseMessage response = await this.Client.PostAsync(
        Urls.InitUrl,
        new FormUrlEncodedContent(input.ToKeyValuePairs()));

      // ASSERT
      response.StatusCode.Should().Be(HttpStatusCode.Found);

      var user = this.Services.GetRequiredService<UserConfig>();
      String encrypted = user.MainPassword;
      encrypted.Should().NotBeEmpty();
      Encryption.Verify(input.Password, encrypted).Should().BeTrue();
    }
  }
}