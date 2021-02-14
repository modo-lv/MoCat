using System;
using Microsoft.AspNetCore.Mvc;
using MoCat.Core.Entities;
using MoCat.Core.Main.Owners;
using MoCat.Web.Main.Owners;

namespace MoCat.Web.Controllers {
  /// <summary>
  /// HTML-form <see cref="Owner"/> management. 
  /// </summary>
  public class OwnersController : Controller {
    private readonly IDbContext _db;
    public OwnersController(IDbContext db) {
      this._db = db;
    }

    /// <summary>
    /// Add/update an owner.
    /// </summary>
    /// <param name="owner"><see cref="OwnerInput"/></param>
    [HttpPost]
    public IActionResult Save([FromForm] OwnerInput owner) {
      if (owner.Id == null)
        throw new NullReferenceException($"{nameof(OwnerInput)}.{nameof(OwnerInput.Id)}");
      
      this._db.Save(new Owner(
        id: owner.Id,
        isActive: owner.IsActive ?? true)
      );
      if (owner.Replace != null) {
        throw new NotImplementedException();
      }

      return this.LocalRedirect(owner.ReturnUrl);
    }
  }
}