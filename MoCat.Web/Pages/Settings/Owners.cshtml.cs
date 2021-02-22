using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoCat.Core.Entities;
using MoCat.Core.Main.Owners;
using MoCat.Web.Infrastructure;

namespace MoCat.Web.Pages.Settings {
  public class Owners : PageModel, IPageWithTitle {
    public String Title => "Owners";

    private readonly IDbContext _db;

    [BindProperty]
    public IList<Owner> OwnerList { get; set; }
    
    [BindProperty]
    public Owner? NewOwner { get; set; }
    
    
    public Owners(IDbContext db) {
      this._db = db;

      this.OwnerList = this._db.Owners.Values.OrderBy(_ => _.Id).ToList();
    }

    public void OnGet() {
    }

    public IActionResult OnPost() {
      if (!this.ModelState.IsValid) {
        return this.Page();
      }
      // TODO: Call the actual owner update method in API controller.
      return this.RedirectToPage("/Settings/Owners");
    }
  }
}