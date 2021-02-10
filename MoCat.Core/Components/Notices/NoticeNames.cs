﻿using System;

namespace MoCat.Core.Components.Notices {
  /// <summary>
  /// Names of persistent notices (see <see cref="Notice.Name"/>).
  /// </summary>
  public static class NoticeNames {
    /// <summary>
    /// Name of the notice to display if the <see cref="UserConfig.GameUserHome"/> is not configured.
    /// </summary>
    public const String MissingGameUserHome = nameof(MissingGameUserHome);
  }
}