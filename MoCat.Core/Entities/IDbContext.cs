using LiteDB;
using MoCat.Core.Entities.Db;

namespace MoCat.Core.Entities {
  public interface IDbContext {
    ILiteCollection<LedgerEntry> LedgerEntries { get; }
    
    ILiteCollection<UserConfig> UserConfig { get; }
  }
}