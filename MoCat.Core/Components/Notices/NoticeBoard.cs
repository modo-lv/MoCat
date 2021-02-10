﻿using System.Collections.Generic;

namespace MoCat.Core.Components.Notices {
  /// <inheritdoc />
  public class NoticeBoard : INoticeBoard {
    protected ICollection<Notice> Notices { get; set; }

    /// <inheritdoc />
    ICollection<Notice> INoticeBoard.Notices {
      get => this.Notices;
      set => this.Notices = value;
    }

    public NoticeBoard() {
      this.Notices = new HashSet<Notice>();
    }
  }
}