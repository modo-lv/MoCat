using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MoCat.Core.Components.Auth {
  public interface IAuth {
    /// <summary>
    /// Store/update the main system password.  
    /// </summary>
    /// <param name="password">New password</param>
    /// <returns>Encrypted password as it is stored in database.</returns>
    String SaveMainPassword(String password);

    /// <summary>
    /// Validate password and log in user.
    /// </summary>
    Boolean LoginByPassword(String password);

    ClaimsPrincipal CreateClaimsPrincipal(String authType);
  }
}