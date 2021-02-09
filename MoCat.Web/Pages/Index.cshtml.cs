using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoCat.Web.Infrastructure;

namespace MoCat.Web.Pages {
  public class Index : PageModel, IPageWithTitle {
    public String Title => "Home";
    
    public void OnGet() {
      
    }

  }
}