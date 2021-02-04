using LiteDB;

namespace MoCat.Core.Wiring {
  /// <summary>
  /// Pre-request DB access instance.
  /// </summary>
  public class Db : LiteDatabase, IDb {
    public Db() : base(Running.DbPath) { }
  }
}