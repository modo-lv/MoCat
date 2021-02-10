using System;

namespace MoCat.Core.Components.SanityChecks {
  /// <summary>
  /// Exception thrown when a sanity check fails.
  /// </summary>
  public class SanityCheckException : Exception {
    /// <summary>
    /// The kind of check that failed.
    /// </summary>
    public SanityCheckKind Kind { get; }

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="kind"><see cref="Kind"/></param>
    /// <param name="message">Optional message. If <c>null</c>, <paramref name="kind"/> will be used.</param>
    public SanityCheckException(SanityCheckKind kind, String? message = null) : base(message ?? kind.ToString()) {
      this.Kind = kind;
    }
  }
}