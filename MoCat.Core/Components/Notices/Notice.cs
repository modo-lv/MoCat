using System;

namespace MoCat.Core.Components.Notices {
  /// <summary>
  /// An announcement message that needs to be shown to the user.
  /// </summary>
  public class Notice {
    /// <summary>
    /// Text to display, markdown supported.
    /// </summary>
    public readonly String Message;

    /// <inheritdoc cref="NoticeKind"/>
    public readonly NoticeKind Kind;

    /// <summary>
    /// An optional unique name for the message, making it a singleton.   
    /// </summary>
    /// <remarks>
    /// Only one instance of a singleton (named) message can appear on the board at a time. Attempts to add another
    /// message with the same name as already exists on the board will be ignored. 
    /// </remarks>
    public readonly String Name;

    /// <summary>
    /// Automatically hide the notice after a period of time?
    /// </summary>
    public readonly Boolean AutoHide;

    public Notice(
      String message = "",
      NoticeKind kind = NoticeKind.Information,
      Boolean autoHide = false,
      String name = ""
    ) {
      this.AutoHide = autoHide;
      this.Message = message;
      this.Kind = kind;
      this.Name = name;
    }
  }
}