using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoCat.Core.Components.Notices;

namespace MoCat.Web.Pages.Auth {
  public class Logout : PageModel {
    private readonly INoticeBoard _notices;

    public Logout(INoticeBoard notices) {
      this._notices = notices;
    }

    public async Task<IActionResult> OnGetAsync() {
      await this.HttpContext.SignOutAsync();
      this._notices.Add("Logged out.");
      return this.RedirectToPage("/Index");
    }
  }
}