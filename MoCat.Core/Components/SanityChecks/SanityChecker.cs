using System;
using System.Collections.Generic;
using System.Linq;
using MoCat.Core.Entities;
using Simpler.NetCore.Text;

namespace MoCat.Core.Components.SanityChecks {
  /// <inheritdoc />
  public class SanityChecker : ISanityChecker {
    private readonly IDbContext _db;
    
    
    /// <summary>
    /// Contains the implementation for each check kind. 
    /// </summary>
    protected readonly IDictionary<SanityCheckKind, Func<Boolean>> Runners;


    /// <summary>
    /// Constructor.
    /// </summary>
    public SanityChecker(IDbContext db) {
      this._db = db;

      // ReSharper disable once ArrangeObjectCreationWhenTypeNotEvident
      this.Runners = new Dictionary<SanityCheckKind, Func<Boolean>> {
        {
          SanityCheckKind.IsPasswordSet, () =>
            (this._db.UserConfig.Query().SingleOrDefault()?.MainPassword).NotBlank()
        }
      };
    }

    
    /// <inheritdoc />
    public ISet<SanityCheckKind> Run(IEnumerable<SanityCheckKind> checks) => 
      checks.Where(check => !this.Runners[check].Invoke()).ToHashSet();
  }
}