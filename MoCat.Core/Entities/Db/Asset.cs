using System;

namespace MoCat.Core.Entities.Db {
  /// <summary>
  /// A traded asset — crypto or fiat currency
  /// </summary>
  public class Asset {
    /// <summary>
    /// Asset (currency) identifier (code). Must be unique and permanent.
    /// </summary>
    public String Id { get; }

    /// <summary>
    /// Full name of the asset.
    /// </summary>
    public String Name { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="id"><see cref="Id"/></param>
    /// <param name="name"><see cref="Name"/></param>
    public Asset(String id, String name) {
      this.Id = id;
      this.Name = name;
    }
  }
}