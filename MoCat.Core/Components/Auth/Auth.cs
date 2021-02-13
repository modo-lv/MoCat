using System;
using Microsoft.Extensions.Logging;
using MoCat.Core.Entities;
using MoCat.Core.Entities.Db;
using Simpler.NetCore;

namespace MoCat.Core.Components.Auth {
  public class Auth : IAuth {
    private readonly IDbContext _db;
    private readonly UserConfig _user;
    private readonly ILogger<Auth> _logger;

    public Auth(IDbContext db, UserConfig user, ILogger<Auth> logger) {
      this._db = db;
      this._user = user;
      this._logger = logger;
    }


    /// <inheritdoc />
    public String SaveMainPassword(String password) {
      String hash = BCrypt.Net.BCrypt.HashPassword(password).ToMaybe().Get;
      this._user.MainPassword = hash;
      this._db.Save(this._user);
      this._logger.LogInformation("Main password updated.");
      return hash;
    }
  }
}