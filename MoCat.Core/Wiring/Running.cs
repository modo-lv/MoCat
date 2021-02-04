using System;
using System.IO;

namespace MoCat.Core.Wiring
{
  /// <summary>
  /// Globally available runtime information.
  /// </summary>
  public class Running
  {
    /// <summary>
    /// Root folder where user-modified content (database, configuration, exports etc.) is stored.
    /// </summary>
    /// <remarks>
    /// In development, should be [MoCat/MoCat.DebugData].
    /// In production, should be [MoCat] in user's application data folder (~/.config on Linux).
    /// </remarks>
    public static String BaseDir = "";

    /// <summary>
    /// Get full path to a given file/folder in the app's base directory.
    /// </summary>
    public static String BasePath(String path) => Path.Combine(BaseDir, path);

    /// <summary>
    /// Full path to the database file;
    /// </summary>
    public static String DbPath => BasePath("MoCat.db");

    /// <summary>
    /// Are we running a debug version of the app?
    /// </summary>
    public static Boolean InDebug =
#if DEBUG
      true;
#else
			false;
#endif

    /// <summary>
    /// Is the app being run in an integration test?
    /// </summary>
    public static Boolean InTest = false;
  }
}