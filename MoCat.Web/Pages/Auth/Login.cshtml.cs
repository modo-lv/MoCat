using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoCat.Web.Infrastructure;

namespace MoCat.Web.Pages.Auth {
  public class Login : PageModel, IPageWithTitle {
    public String Title => "Login";
    
    public void OnGet() {
      
    }

  }
}