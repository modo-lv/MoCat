using System;

namespace MoCat.Web.Main.Owners {
  /// <summary>
  /// Input data for a new/updated owner.
  /// </summary>
  public class OwnerInput : EntityInput {
    public String? Id { get; set; }
    public Boolean? IsActive { get; set; }
    public String? Replace { get; set; }
  }
}