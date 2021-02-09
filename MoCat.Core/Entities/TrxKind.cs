using MoCat.Core.Entities.Db;

namespace MoCat.Core.Entities {
  /// <summary>
  /// Determines what kind of <see cref="Trx"/> is registered.
  /// </summary>
  public enum TrxKind {
    /// <summary>
    /// Trading one asset for another.
    /// </summary>
    Trade,
    /// <summary>
    /// Deposit or withdrawal.
    /// </summary>
    Flow
  }
}