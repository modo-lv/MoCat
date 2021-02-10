using LiteDB;
using MoCat.Core.Entities.Db;
using MoCat.Core.Wiring;

namespace MoCat.Core.Entities {
  /// <summary>
  /// Main access point for DB storage.
  /// </summary>
  public class DbContext : IDbContext {

    private readonly ILiteDatabase _dbConnection;
    
    public DbContext(ILiteDatabase dbConnection) {
      this._dbConnection = dbConnection;
    }

    public ILiteCollection<LedgerEntry> LedgerEntries => this._dbConnection.GetCollection<LedgerEntry>("ledger_entries");
    public ILiteCollection<UserConfig> UserConfig => this._dbConnection.GetCollection<UserConfig>("user_config");
  }
}