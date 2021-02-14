using System;

namespace MoCat.Core.Main {
  /// <summary>
  /// Asset owner.
  /// </summary>
  public class Owner {
    /// <summary>
    /// Name of the owner, also used as ID.  
    /// </summary>
    public String Id { get; init; }
    
    /// <summary>
    /// Inactive owners cannot be added to new transactions, but are still available in search, filtering etc.  
    /// </summary>
    public Boolean IsActive { get; set; }

    /// <inheritdoc cref="Owner"/>
    /// <param name="id"><see cref="Id"/></param>
    /// <param name="isActive"><see cref="IsActive"/></param>
    public Owner(String id, Boolean isActive = true) {
      this.Id = id;
      this.IsActive = isActive;
    }
  }
}