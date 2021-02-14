using System;
using System.Collections.Generic;
using System.Linq;
using Simpler.NetCore;
using Simpler.NetCore.Text;

namespace MoCat.Core.Components.Notices {
  public interface INoticeBoard {
    /// <summary>
    /// Notices currently on the board.
    /// </summary>
    ICollection<Notice> Notices { get; protected set; }

    /// <summary>
    /// Add a notices to the board.
    /// </summary>
    /// <param name="notices">Notices to add.</param>
    /// <returns>Notices that were added. For persistent notices, if one with the same name already exists on the
    /// board, that will be returned instead.</returns>
    IEnumerable<Notice> Add(params Notice[] notices) {
      return notices.Select(n => {
        Notice? exists = n.Name.IsBlank()
          ? null
          : this.Notices.SingleOrDefault(_ => _.Name == n.Name);
        if (exists == null) {
          this.Notices.Add(n);
        }

        return exists ?? n;
      }).ToHashSet();
    }

    /// <summary>
    /// Add a new transient notice with a given message to this notice board.
    /// </summary>
    /// <param name="message">Message of the notice.</param>
    /// <returns>Added notice.</returns>
    IEnumerable<Notice> Add(params String[] message) {
      return this.Add(message.Select(_ => new Notice(_)).ToArray());
    }

    /// <summary>
    /// Remove (and return) all non-named notices from the board.
    /// Call this to show unread notices to the user and simultaneously remove them from the board. 
    /// </summary>
    /// <returns>List of removed notices.</returns>
    IEnumerable<Notice> RemoveAllTransient() {
      Notice[] transient = this.Notices.Where(_ => _.Name.IsBlank()).ToArray();
      this.Notices = this.Notices.Except(transient).ToHashSet();
      return transient;
    }

    /// <summary>
    /// Remove a persistent (named) notice from the board.
    /// </summary>
    /// <param name="name">Name of the notice to remove.</param>
    /// <returns>Removed notice, or <c>null</c> if there wasn't one.</returns>
    Notice? RemovePersistent(String name) {
      Notice? notice = this.Notices.SingleOrDefault(_ => _.Name == name);
      notice.IfNotNull(n => this.Notices.Remove(n!));
      return notice;
    }
  }
}