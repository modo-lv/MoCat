using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MoCat.Core.Components.Auth {
  public interface IAuth {
    /*
    /// <summary>
    /// Attempt to authenticate a given password.
    /// </summary>
    /// <param name="password">Attempted password.</param>
    /// <returns>Authenticated user data if successful, <c>null</c> if the password is wrong.</returns>
    Task<AuthUserModel> LoginByPassword(String password);

    /// <summary>
    /// Create a <see cref="ClaimsPrincipal"/> object from a given user model.
    /// </summary>
    /// <remarks>
    /// Needed by ASP.NET Core authentication mechanism.
    /// </remarks>
    /// <param name="user">User data to include in the principal.</param>
    /// <param name="authenticationType">Authentication type used. <c>null</c> means the user isn't authenticated.</param>
    ClaimsPrincipal CreateClaimsPrincipal(IAuthUserDo user, String authenticationType = null);
    */


    /// <summary>
    /// Store/update the main system password.  
    /// </summary>
    /// <param name="password">New password</param>
    /// <returns>Encrypted password as it is stored in database.</returns>
    String SaveMainPassword(String password);
  }
}