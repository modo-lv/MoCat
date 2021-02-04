namespace MoCat.Core.Wiring {
  public interface IStartup {
    /// <summary>
    /// Make sure <see cref="Running.BaseDir"/> exists and is accessible.
    /// </summary>
    void InitBaseDir();
  }
}