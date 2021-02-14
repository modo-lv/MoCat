using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoCat.Web.Infrastructure;

namespace MoCat.Web.Pages {
  public class UserConfig : PageModel, IPageWithTitle {
    public String Title => "Settings";
    
    public void OnGet() {
      
    }

  }
}