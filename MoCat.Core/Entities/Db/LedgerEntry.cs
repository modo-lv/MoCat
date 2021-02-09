using System;

namespace MoCat.Core.Entities.Db {
  /// <summary>
  /// A single entry in double-entry ledger.
  /// </summary>
  public class LedgerEntry {
    /// <summary>
    /// Date and time when the asset change was recorded.
    /// </summary>
    public DateTime Time { get; }
    
    /// <summary>
    /// Asset that was gained/lost.
    /// </summary>
    public String AssetId { get; }
    
    /// <summary>
    /// Amount of asset that was gained/lost.
    /// </summary>
    public Decimal Amount { get; }
    
    /// <summary>
    /// Owner of the asset.
    /// </summary>
    public String Owner { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="time"><see cref="Time"/></param>
    /// <param name="assetId"><see cref="AssetId"/></param>
    /// <param name="amount"><see cref="Amount"/></param>
    /// <param name="owner"><see cref="Owner"/></param>
    public LedgerEntry(DateTime time, String assetId, Decimal amount = 0, String owner = "") {
      this.Time = time;
      this.AssetId = assetId;
      this.Amount = amount;
      this.Owner = owner;
    }
  }
}