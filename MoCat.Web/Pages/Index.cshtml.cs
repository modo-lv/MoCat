using System;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoCat.Core.Components.Notices;
using MoCat.Web.Infrastructure;

namespace MoCat.Web.Pages {
  public class Index : PageModel, IPageWithTitle {
    public Index(INoticeBoard nb) {
      this._nb = nb;
    }
    public String Title => "Home";

    private readonly INoticeBoard _nb;
    
    public void OnGet() {
      /*
      this._nb.Add("Test 1");
      this._nb.Add("Test 2");
      this._nb.Add("Test 3");
      this._nb.Add("Test 4");
      this._nb.Add("Test 5");
      this._nb.Add("Test 6");
    */
    }

  }
}