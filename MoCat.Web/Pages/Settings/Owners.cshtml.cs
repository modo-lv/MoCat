using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoCat.Web.Infrastructure;

namespace MoCat.Web.Pages.Settings {
  public class Owners : PageModel, IPageWithTitle {
    public String Title => "Owners";
    
    public void OnGet() {
      
    }
  }
}