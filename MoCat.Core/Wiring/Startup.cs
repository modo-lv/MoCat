using System.IO.Abstractions;
using Microsoft.Extensions.Logging;

namespace MoCat.Core.Wiring {
  public class Startup : IStartup {
    private readonly ILogger<Startup> _logger;
    private readonly IFileSystem _fs;

    public Startup(ILogger<Startup> logger, IFileSystem fs) {
      this._logger = logger;
      this._fs = fs;
    }


    /// <summary>
    /// Make sure <see cref="Running.BaseDir"/> exists and is accessible.
    /// </summary>
    public void InitBaseDir() {
      if (!this._fs.Directory.Exists(Running.BaseDir)) {
        this._logger.LogInformation($"[{Running.BaseDir}] doesn't exist, creating.");
        this._fs.Directory.CreateDirectory(Running.BaseDir);
      }

      // Just an informative FYI that has to be checked now, because connecting to a DB automatically creates the file.
      if (!this._fs.File.Exists(Running.DbPath)) {
        this._logger.LogInformation($"[{Running.DbPath}] doesn't exist, will be created on first access.");
      }
    }
  }
}