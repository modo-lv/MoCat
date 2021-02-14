using System;
using System.Collections.Generic;

namespace MoCat.Core.Entities.Db {
  public class UserConfig : DbDocument {
    /// <summary>
    /// Main password for logging into the app.
    /// </summary>
    public String MainPassword { get; set; } = "";

    /// <summary>
    /// List of active asset owners.
    /// </summary>
    public IList<String> Owners { get; set; } = new List<String>();
  }
}