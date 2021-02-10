using Microsoft.Extensions.DependencyInjection;

namespace MoCat.Core.Tests.TestCore {
  public static class TestServices {
    public static IServiceCollection AddTestServices(this IServiceCollection services) {
      return services;
    }
  }
}