using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoCat.Core.Components.Notices;
using MoCat.Core.Wiring;

namespace MoCat.Web.Pages {
  public static class Extensions {
    /// <summary>
    /// Check if a page's model state is valid, and add errors to the notice board if not.
    /// </summary>
    /// <param name="model">Page model to check</param>
    /// <param name="notices">Notice board.</param>
    /// <returns></returns>
    /// <exception cref="ValidationException"></exception>
    public static Boolean ModelStateIsValid(this PageModel model, INoticeBoard notices)
    {
      if (model.ModelState.IsValid)
        return true;

      var errors = new List<String>();
      var memberNames = new List<String>();
      foreach ((String key, ModelStateEntry value) in model.ModelState) {
        memberNames.Add(key);
        errors.AddRange(value.Errors.Select(error => $"{key}: {error.ErrorMessage}"));
      }

      if (Running.InTest)
      {
        throw new ValidationException(
          new ValidationResult(String.Join(Environment.NewLine, errors), memberNames),
          validatingAttribute: null,
          value: null);
      }
      else
      {
        notices.Add(errors.ToArray());
        return false;
      }
    }    
  }
}