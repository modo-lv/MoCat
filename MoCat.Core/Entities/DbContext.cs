using LiteDB;
using MoCat.Core.Entities.Db;
using MoCat.Core.Wiring;

namespace MoCat.Core.Entities {
  /// <summary>
  /// Main access point for DB storage.
  /// </summary>
  public class DbContext : IDbContext {
    public ILiteDatabase Db { get; init; }
    
    public DbContext(ILiteDatabase db) {
      this.Db = db;
    }

    public ILiteCollection<LedgerEntry> LedgerEntries => this.Db.GetCollection<LedgerEntry>("ledger_entries");
    public ILiteCollection<UserConfig> UserConfig => this.Db.GetCollection<UserConfig>("user_config");
  }
}