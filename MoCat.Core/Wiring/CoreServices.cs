using System.IO.Abstractions;
using LiteDB;
using Microsoft.Extensions.DependencyInjection;
using MoCat.Core.Components.Notices;
using MoCat.Core.Components.SanityChecks;
using MoCat.Core.Entities;

namespace MoCat.Core.Wiring {
  public static class CoreServices {
    public static void AddTo(IServiceCollection services) {
      services.AddSingleton<IStartup, Startup>();
      services.AddSingleton<IFileSystem, FileSystem>();
      services.AddSingleton<ILiteDatabase, DbConnection>();
      services.AddSingleton<IDbContext, DbContext>();
      services.AddSingleton<INoticeBoard, NoticeBoard>();
      services.AddSingleton<ISanityChecker, SanityChecker>();
    }
  }
}