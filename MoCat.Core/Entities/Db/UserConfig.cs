using System;

namespace MoCat.Core.Entities.Db {
  public class UserConfig : DbDocument {
    public String MainPassword { get; set; } = "";
  }
}