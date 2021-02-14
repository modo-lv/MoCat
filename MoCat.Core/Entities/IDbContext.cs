using System;
using System.Collections.Generic;
using System.Linq;
using LiteDB;
using MoCat.Core.Entities.Db;
using MoCat.Core.Main;

namespace MoCat.Core.Entities {
  public interface IDbContext {
    ILiteDatabase Db { get; }
    
    ILiteCollection<LedgerEntry> LedgerEntries { get; }
    
    UserConfig UserConfig => 
      this.Db.GetCollection<UserConfig>().Query().SingleOrDefault() ?? new UserConfig();

    /// <summary>
    /// All asset owners.
    /// </summary>
    IDictionary<String, Owner> Owners => 
      this.Db.GetCollection<Owner>()
        .FindAll()
        .ToDictionary(_ => _.Id, _ => _);

    /// <summary>
    /// Active asset owners.
    /// </summary>
    IDictionary<String, Owner> ActiveOwners =>
      this.Db.GetCollection<Owner>().Query()
        .Where(_ => _.IsActive)
        .ToEnumerable().ToDictionary(_ => _.Id, _ => _);

    
    
    void Save<T>(Func<T> data) {
      this.Db.GetCollection<T>().Upsert(data());
    }

    void Save<T>(T data) {
      this.Db.GetCollection<T>().Upsert(data);
    }
  }
}