using System.IO.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace MoCat.Core.Wiring {
  public static class CoreServices {
    public static void AddTo(IServiceCollection services) {
      services.AddSingleton<IStartup, Startup>();
      services.AddSingleton<IFileSystem, FileSystem>();
      services.AddSingleton<IDb, Db>();
    }
  }
}