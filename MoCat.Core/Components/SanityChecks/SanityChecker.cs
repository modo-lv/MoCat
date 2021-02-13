using System;
using System.Collections.Generic;
using System.Linq;
using MoCat.Core.Entities;
using MoCat.Core.Entities.Db;
using Simpler.NetCore.Text;

namespace MoCat.Core.Components.SanityChecks {
  /// <inheritdoc />
  public class SanityChecker : ISanityChecker {
    private readonly IDbContext _db;
    private readonly UserConfig _user;


    /// <summary>
    /// Contains the implementation for each check kind. 
    /// </summary>
    protected readonly IDictionary<SanityCheckKind, Func<Boolean>> Runners;


    /// <summary>
    /// Constructor.
    /// </summary>
    public SanityChecker(IDbContext db, UserConfig user) {
      this._db = db;
      this._user = user;

      // ReSharper disable once ArrangeObjectCreationWhenTypeNotEvident
      this.Runners = new Dictionary<SanityCheckKind, Func<Boolean>> {
        {
          SanityCheckKind.MainPasswordIsSet, () => this._user.MainPassword.NotBlank()
        }
      };
    }


    /// <inheritdoc />
    public ISet<SanityCheckKind> Run(params SanityCheckKind[] checks) =>
      checks.Where(check => !this.Runners[check].Invoke()).ToHashSet();
  }
}