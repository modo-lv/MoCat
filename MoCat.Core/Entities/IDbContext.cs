using System;
using LiteDB;
using MoCat.Core.Entities.Db;

namespace MoCat.Core.Entities {
  public interface IDbContext {
    ILiteDatabase Db { get; }
    
    ILiteCollection<LedgerEntry> LedgerEntries { get; }
    
    UserConfig UserConfig => this.Db.GetCollection<UserConfig>().Query().SingleOrDefault() ?? new UserConfig();

    void Save<T>(Func<T> data) {
      this.Db.GetCollection<T>().Upsert(data());
    }

    void Save<T>(T data) {
      this.Db.GetCollection<T>().Upsert(data);
    }
  }
}