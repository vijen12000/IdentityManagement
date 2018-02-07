using System.Security.Claims;
using System.Threading.Tasks;

namespace ManageIdentity.Core.Infrastructure
{
    public interface ISignInManager<TUser> where TUser : class
    {
        IUserClaimsPrincipalFactory<TUser> ClaimsFactory { get; set; }
        HttpContext Context { get; set; }
        ILogger Logger { get; set; }
        IdentityOptions Options { get; set; }
        UserManager<TUser> UserManager { get; set; }

        Task<bool> CanSignInAsync(TUser user);
        Task<SignInResult> CheckPasswordSignInAsync(TUser user, string password, bool lockoutOnFailure);
        AuthenticationProperties ConfigureExternalAuthenticationProperties(string provider, string redirectUrl, string userId = null);
        Task<ClaimsPrincipal> CreateUserPrincipalAsync(TUser user);
        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent);
        Task<SignInResult> ExternalLoginSignInAsync(string loginProvider, string providerKey, bool isPersistent, bool bypassTwoFactor);
        Task ForgetTwoFactorClientAsync();
        Task<System.Collections.Generic.IEnumerable<AuthenticationScheme>> GetExternalAuthenticationSchemesAsync();
        Task<ExternalLoginInfo> GetExternalLoginInfoAsync(string expectedXsrf = null);
        Task<TUser> GetTwoFactorAuthenticationUserAsync();
        bool IsSignedIn(ClaimsPrincipal principal);
        Task<bool> IsTwoFactorClientRememberedAsync(TUser user);
        Task<SignInResult> PasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task<SignInResult> PasswordSignInAsync(TUser user, string password, bool isPersistent, bool lockoutOnFailure);
        Task RefreshSignInAsync(TUser user);
        Task RememberTwoFactorClientAsync(TUser user);
        Task SignInAsync(TUser user, AuthenticationProperties authenticationProperties, string authenticationMethod = null);
        Task SignInAsync(TUser user, bool isPersistent, string authenticationMethod = null);
        Task SignOutAsync();
        Task<SignInResult> TwoFactorAuthenticatorSignInAsync(string code, bool isPersistent, bool rememberClient);
        Task<SignInResult> TwoFactorRecoveryCodeSignInAsync(string recoveryCode);
        Task<SignInResult> TwoFactorSignInAsync(string provider, string code, bool isPersistent, bool rememberClient);
        Task<IdentityResult> UpdateExternalAuthenticationTokensAsync(ExternalLoginInfo externalLogin);
        Task<TUser> ValidateSecurityStampAsync(ClaimsPrincipal principal);
        Task<bool> ValidateSecurityStampAsync(TUser user, string securityStamp);
        Task<TUser> ValidateTwoFactorSecurityStampAsync(ClaimsPrincipal principal);
    }
}