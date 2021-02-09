using System.Collections.Generic;
using System.Linq;

namespace MoCat.Core.Entities.Db {
  /// <summary>
  /// A transaction.
  /// </summary>
  public class Trx {
    /// <inheritdoc cref="TrxKind"/>
    public TrxKind Kind { get; }

    /// <summary>
    /// Assets gained/lost in this transaction.
    /// </summary>
    public IEnumerable<LedgerEntry> Assets { get; }

    /// <summary>
    /// Fees paid for this transaction.
    /// </summary>
    public IEnumerable<LedgerEntry> Fees { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="kind"><see cref="Kind"/></param>
    /// <param name="assets"><see cref="Assets"/></param>
    /// <param name="fees"><see cref="Fees"/></param>
    public Trx(TrxKind kind, IEnumerable<LedgerEntry>? assets = null, IEnumerable<LedgerEntry>? fees = null) {
      this.Kind = kind;
      this.Assets = assets ?? Enumerable.Empty<LedgerEntry>();
      this.Fees = fees ?? Enumerable.Empty<LedgerEntry>();
    }
  }
}