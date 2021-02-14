using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MoCat.Core.Components.Notices;
using MoCat.Core.Components.SanityChecks;
using MoCat.Web.Infrastructure;

namespace MoCat.Web.Components.Filters {
  public class InitSanityCheckFilter : IAsyncResourceFilter {
    /// <summary>
    /// Page models annotated with this will not trigger initialization sanity checks.
    /// Meant for initialization page itself.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class Ignore : Attribute { }

    private readonly ISanityChecker _checker;
    private readonly INoticeBoard _nb;

    public InitSanityCheckFilter(ISanityChecker checker, INoticeBoard nb) {
      this._checker = checker;
      this._nb = nb;
    }

    public async Task OnResourceExecutionAsync(ResourceExecutingContext context, ResourceExecutionDelegate next) {
      IEnumerable<Attribute> attributes = context.ActionDescriptor switch {
        CompiledPageActionDescriptor p => p.ModelTypeInfo.GetCustomAttributes(),
        ControllerActionDescriptor c => c.ControllerTypeInfo.GetCustomAttributes(),
        _ => throw new NotImplementedException(
          $"Unknown controller type: {context.ActionDescriptor.GetType().Name}"
        )
      };

      ISet<SanityCheckKind> failures = this._checker.Run(SanityCheckKind.MainPasswordIsSet);

      if (failures.Count > 0 && attributes.All(a => a.GetType() != typeof(Ignore))) {
        this._nb.Add($"Sanity checks failed: {String.Join(", ", failures)}.");

        context.Result = new RedirectResult(Urls.InitUrl);
      }
      else {
        await next();
      }
    }
  }
}