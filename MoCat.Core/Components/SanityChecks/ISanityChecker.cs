using System.Collections.Generic;

namespace MoCat.Core.Components.SanityChecks {
  /// <summary>
  /// Service that makes basic sanity checks of things required for normal functioning.
  /// </summary>
  public interface ISanityChecker {
    /// <summary>
    /// Run sanity checks and return a list of those that have failed.
    /// </summary>
    /// <param name="checks">Checks to run.</param>
    /// <returns>List of sanity checks that have failed.</returns>
    ISet<SanityCheckKind> Run(params SanityCheckKind[] checks);
  }
}