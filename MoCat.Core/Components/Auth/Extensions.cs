using System;
using System.Security.Claims;

namespace MoCat.Core.Components.Auth {
  public static class Extensions {
    public static Boolean IsAuthenticated(this ClaimsPrincipal? user) =>
      user?.Identity?.IsAuthenticated ?? false;
  }
}