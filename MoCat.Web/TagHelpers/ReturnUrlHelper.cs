using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Simpler.NetCore.Text;

/*
 * 
 */
namespace MoCat.Web.TagHelpers {
  /// <summary>
  /// Helper for <c>return-url</c> tag, adding a hidden field to a form to redirect to after submitting.
  /// </summary>
  [HtmlTargetElement("return-url")]
  public class ReturnUrlHelper : TagHelper {
    /// <summary>
    /// Use this page as the return URL, instead of the current page.
    /// </summary>
    [HtmlAttributeName("asp-page")]
    public String? Page { get; set; }

    [HtmlAttributeNotBound]
    [ViewContext]
    public ViewContext? ViewContext { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output) {
      String currentPage = (this.ViewContext?.RouteData.Values["Page"]?.ToString()).Text();

      output.TagName = "input";
      output.Attributes.Add("type", "hidden");
      output.Attributes.Add("name", "ReturnUrl");
      output.Attributes.Add("value", this.Page ?? currentPage);
    }
  }
}