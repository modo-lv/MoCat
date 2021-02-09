using LiteDB;
using MoCat.Core.Entities.Db;
using MoCat.Core.Wiring;

namespace MoCat.Core.Entities {
  /// <summary>
  /// Main access point for DB storage.
  /// </summary>
  public class DbContext {

    private readonly IDbConnection _dbConnection;
    
    public DbContext(IDbConnection dbConnection) {
      this._dbConnection = dbConnection;
    }

    public ILiteCollection<LedgerEntry> LedgerEntries => this._dbConnection.GetCollection<LedgerEntry>("ledger_entries");
  }
}