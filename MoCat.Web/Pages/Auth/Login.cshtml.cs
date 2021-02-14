using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoCat.Core.Components.Auth;
using MoCat.Core.Components.Notices;
using MoCat.Web.Infrastructure;
using Simpler.NetCore.Text;
using Encryption = BCrypt.Net.BCrypt;

namespace MoCat.Web.Pages.Auth {
  [AllowAnonymous]
  public class Login : PageModel, IPageWithTitle {
    public String Title => "Login";

    private readonly IAuth _auth;
    private readonly INoticeBoard _notices;

    public Login(IAuth auth, INoticeBoard notices) {
      this._auth = auth;
      this._notices = notices;
    }

    [BindProperty]
    public String Password { get; set; } = "";
    
    [BindProperty]
    public String? ReturnUrl { get; set; }

    public async Task<IActionResult> OnPostAsync() {
      // Wrong password
      if (!this._auth.LoginByPassword(this.Password)) {
        this.ModelState.AddModelError("Password", "Invalid username and/or password.");
        this.ModelStateIsValid(this._notices);
        return this.Page();
      }
      
      // Valid login
      await this.HttpContext.SignInAsync(
        CookieAuthenticationDefaults.AuthenticationScheme,
        this._auth.CreateClaimsPrincipal(CookieAuthenticationDefaults.AuthenticationScheme),
        new AuthenticationProperties()
      );

      return this.ReturnUrl.NotBlank() ? this.LocalRedirect(this.ReturnUrl) : this.RedirectToPage("Index");
    }
  }
}