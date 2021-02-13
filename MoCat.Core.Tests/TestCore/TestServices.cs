using LiteDB;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace MoCat.Core.Tests.TestCore {
  public static class TestServices {
    public static IServiceCollection AddTestServices(this IServiceCollection services) {
      services.RemoveAll<ILiteDatabase>();
      services.AddScoped<ILiteDatabase>(_ => new LiteDatabase(":memory:"));
      return services;
    }
  }
}