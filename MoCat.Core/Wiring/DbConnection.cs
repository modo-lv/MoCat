﻿using LiteDB;

namespace MoCat.Core.Wiring {
  /// <summary>
  /// Pre-request DB access instance.
  /// </summary>
  public class DbConnection : LiteDatabase {
    public DbConnection() : base(Running.DbPath) { }
  }
}