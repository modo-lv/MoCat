using System;
using MoCat.Core.Wiring;

namespace MoCat.Core.Tests.TestCore {
  public class IntegrationTest
  {
    static IntegrationTest() { Running.InTest = true; }

    public IntegrationTest() {
      // Replace default DB & config path
      Running.BaseDir = AppContext.BaseDirectory;
    }
  }}