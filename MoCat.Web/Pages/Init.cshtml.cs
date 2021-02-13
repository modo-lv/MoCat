using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoCat.Core.Components.Auth;
using MoCat.Core.Components.Notices;
using MoCat.Core.Components.SanityChecks;
using MoCat.Web.Components.Filters;
using MoCat.Web.Infrastructure;

namespace MoCat.Web.Pages {
  [InitSanityCheckFilter.Ignore]
  public class Init : PageModel, IPageWithTitle {
    public String Title => "Initial setup";

    private readonly IAuth _auth;
    private readonly INoticeBoard _notices;
    private readonly ISanityChecker _check;

    public Init(IAuth auth, INoticeBoard notices, ISanityChecker check) {
      this._auth = auth;
      this._notices = notices;
      this._check = check;
    }

    [BindProperty]
    public String Password { get; set; }

    public IActionResult OnGet() {
      if (!this._check.Run(SanityChecks.Init).Any()) {
        return this.RedirectToPage("Index");
      }

      return this.Page();
    }
    
    /// <summary>
    /// Set/update main password.
    /// </summary>
    /// <returns></returns>
    public IActionResult OnPost() {
      this._auth.SaveMainPassword(this.Password);
      this._notices.Add("App setup complete.");
      return this.RedirectToPage("Init");
    }
  }
}