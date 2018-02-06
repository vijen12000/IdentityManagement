using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personify.Core
{
    public class UserHandler
    {
        private UserManager<IdentityUser> userManager { get; }

        public UserHandler(IUserStore<IdentityUser> userStore)
        {
            userManager = new UserManager<IdentityUser>(userStore);
        }

        public async Task<IdentityResult> CreateAsync(IdentityUser user,string password)
        {
            return await userManager.CreateAsync(user,password);
        }

        //// Summary:
        ////     Returns an IQueryable of users if the store is an IQueryableUserStore
        //public virtual IQueryable<TUser> Users { get; }
                
        ////
        //// Summary:
        ////     Add a user claim
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   claim:        
        //public virtual Task<IdentityResult> AddClaimAsync(TKey userId, Claim claim);
      
        ////
        //// Summary:
        ////     Add a user to a role
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   role:        
        //public virtual Task<IdentityResult> AddToRoleAsync(TKey userId, string role);
        
        ////
        //// Summary:
        ////     Method to add user to multiple roles
        ////
        //// Parameters:
        ////   userId:
        ////     user id
        ////
        ////   roles:
        ////     list of role names        
        //public virtual Task<IdentityResult> AddToRolesAsync(TKey userId, params string[] roles);
        
        //// Summary:
        ////     Change a user password
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   currentPassword:
        ////
        ////   newPassword:        
        //public virtual Task<IdentityResult> ChangePasswordAsync(TKey userId, string currentPassword, string newPassword);
        
        ////
        //// Summary:
        ////     Set a user's phoneNumber with the verification token
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   phoneNumber:
        ////
        ////   token:        
        //public virtual Task<IdentityResult> ChangePhoneNumberAsync(TKey userId, string phoneNumber, string token);
                       
        ////
        //// Summary:
        ////     Delete a user
        ////
        //// Parameters:
        ////   user:        
        //public virtual Task<IdentityResult> DeleteAsync(TUser user);
                
        //public void Dispose();
        ////
        //// Summary:
        ////     Return a user with the specified username and password or null if there is no
        ////     match.
        ////
        //// Parameters:
        ////   userName:
        ////
        ////   password:        
        //public virtual Task<TUser> FindAsync(string userName, string password);
                
        //// Summary:
        ////     Returns the user associated with this login
        //public virtual Task<TUser> FindAsync(UserLoginInfo login);
        
        ////
        //// Summary:
        ////     Find a user by his email
        ////
        //// Parameters:
        ////   email:
        //public virtual Task<TUser> FindByEmailAsync(string email);
        
        ////
        //// Summary:
        ////     Find a user by id
        ////
        //// Parameters:
        ////   userId:
        //public virtual Task<TUser> FindByIdAsync(TKey userId);
        
        ////
        //// Summary:
        ////     Find a user by user name
        ////
        //// Parameters:
        ////   userName:
        //public virtual Task<TUser> FindByNameAsync(string userName);
               
        ////
        //// Summary:
        ////     Get a users's claims
        ////
        //// Parameters:
        ////   userId:        
        //public virtual Task<IList<Claim>> GetClaimsAsync(TKey userId);
        
        ////
        //// Summary:
        ////     Get a user's email
        ////
        //// Parameters:
        ////   userId:        
        //public virtual Task<string> GetEmailAsync(TKey userId);
        
        ////
        //// Summary:
        ////     Gets the logins for a user.
        ////
        //// Parameters:
        ////   userId:        
        //public virtual Task<IList<UserLoginInfo>> GetLoginsAsync(TKey userId);

        ////
        //// Summary:
        ////     Get a user's phoneNumber
        ////
        //// Parameters:
        ////   userId:        
        //public virtual Task<string> GetPhoneNumberAsync(TKey userId);
        
        ////
        //// Summary:
        ////     Returns the roles for the user
        ////
        //// Parameters:
        ////   userId:        
        //public virtual Task<IList<string>> GetRolesAsync(TKey userId);
        
        ////
        //// Summary:
        ////     Returns true if the user is in the specified role
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   role:        
        //public virtual Task<bool> IsInRoleAsync(TKey userId, string role);
       
        //// Summary:
        ////     Remove a user claim
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   claim:        
        //public virtual Task<IdentityResult> RemoveClaimAsync(TKey userId, Claim claim);
        
        ////
        //// Summary:
        ////     Remove a user from a role.
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   role:        
        //public virtual Task<IdentityResult> RemoveFromRoleAsync(TKey userId, string role);
        
        ////
        //// Summary:
        ////     Remove user from multiple roles
        ////
        //// Parameters:
        ////   userId:
        ////     user id
        ////
        ////   roles:
        ////     list of role names        
        //public virtual Task<IdentityResult> RemoveFromRolesAsync(TKey userId, params string[] roles);
        
        ////
        //// Summary:
        ////     Remove a user login
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   login:       
        //public virtual Task<IdentityResult> RemoveLoginAsync(TKey userId, UserLoginInfo login);
        
        ////
        //// Summary:
        ////     Remove a user's password
        ////
        //// Parameters:
        ////   userId:        
        //public virtual Task<IdentityResult> RemovePasswordAsync(TKey userId);
        
        ////
        //// Summary:
        ////     Resets the access failed count for the user to 0
        ////
        //// Parameters:
        ////   userId:        
        //public virtual Task<IdentityResult> ResetAccessFailedCountAsync(TKey userId);
        ////
        //// Summary:
        ////     Reset a user's password using a reset password token
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   token:
        ////
        ////   newPassword:
        //[AsyncStateMachine(typeof(UserManager<,>.< ResetPasswordAsync > d__4f))]
        //[DebuggerStepThrough]
        //public virtual Task<IdentityResult> ResetPasswordAsync(TKey userId, string token, string newPassword);
        ////
        //// Summary:
        ////     Send an email to the user
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   subject:
        ////
        ////   body:
        //[AsyncStateMachine(typeof(UserManager<,>.< SendEmailAsync > d__129))]
        //[DebuggerStepThrough]
        //public virtual Task SendEmailAsync(TKey userId, string subject, string body);
        ////
        //// Summary:
        ////     Send a user a sms message
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   message:
        //[AsyncStateMachine(typeof(UserManager<,>.< SendSmsAsync > d__12f))]
        //[DebuggerStepThrough]
        //public virtual Task SendSmsAsync(TKey userId, string message);
        ////
        //// Summary:
        ////     Set a user's email
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   email:
        //[AsyncStateMachine(typeof(UserManager<,>.< SetEmailAsync > d__be))]
        //[DebuggerStepThrough]
        //public virtual Task<IdentityResult> SetEmailAsync(TKey userId, string email);
        ////
        //// Summary:
        ////     Sets whether lockout is enabled for this user
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   enabled:
        //[AsyncStateMachine(typeof(UserManager<,>.< SetLockoutEnabledAsync > d__13c))]
        //[DebuggerStepThrough]
        //public virtual Task<IdentityResult> SetLockoutEnabledAsync(TKey userId, bool enabled);
        ////
        //// Summary:
        ////     Sets the when a user lockout ends
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   lockoutEnd:
        //[AsyncStateMachine(typeof(UserManager<,>.< SetLockoutEndDateAsync > d__14f))]
        //[DebuggerStepThrough]
        //public virtual Task<IdentityResult> SetLockoutEndDateAsync(TKey userId, DateTimeOffset lockoutEnd);
        ////
        //// Summary:
        ////     Set a user's phoneNumber
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   phoneNumber:
        //[AsyncStateMachine(typeof(UserManager<,>.< SetPhoneNumberAsync > d__d9))]
        //[DebuggerStepThrough]
        //public virtual Task<IdentityResult> SetPhoneNumberAsync(TKey userId, string phoneNumber);
        ////
        //// Summary:
        ////     Set whether a user has two factor authentication enabled
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   enabled:
        //[AsyncStateMachine(typeof(UserManager<,>.< SetTwoFactorEnabledAsync > d__121))]
        //[DebuggerStepThrough]
        //public virtual Task<IdentityResult> SetTwoFactorEnabledAsync(TKey userId, bool enabled);
        ////
        //// Summary:
        ////     Update a user
        ////
        //// Parameters:
        ////   user:
        //[AsyncStateMachine(typeof(UserManager<,>.< UpdateAsync > d__5))]
        //[DebuggerStepThrough]
        //public virtual Task<IdentityResult> UpdateAsync(TUser user);
        ////
        //// Summary:
        ////     Generate a new security stamp for a user, used for SignOutEverywhere functionality
        ////
        //// Parameters:
        ////   userId:
        //[AsyncStateMachine(typeof(UserManager<,>.< UpdateSecurityStampAsync > d__48))]
        //[DebuggerStepThrough]
        //public virtual Task<IdentityResult> UpdateSecurityStampAsync(TKey userId);
        ////
        //// Summary:
        ////     Verify the code is valid for a specific user and for a specific phone number
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   token:
        ////
        ////   phoneNumber:
        //[AsyncStateMachine(typeof(UserManager<,>.< VerifyChangePhoneNumberTokenAsync > d__f4))]
        //[DebuggerStepThrough]
        //public virtual Task<bool> VerifyChangePhoneNumberTokenAsync(TKey userId, string token, string phoneNumber);
        ////
        //// Summary:
        ////     Verify a two factor token with the specified provider
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   twoFactorProvider:
        ////
        ////   token:
        //[AsyncStateMachine(typeof(UserManager<,>.< VerifyTwoFactorTokenAsync > d__10b))]
        //[DebuggerStepThrough]
        //public virtual Task<bool> VerifyTwoFactorTokenAsync(TKey userId, string twoFactorProvider, string token);
        ////
        //// Summary:
        ////     Verify a user token with the specified purpose
        ////
        //// Parameters:
        ////   userId:
        ////
        ////   purpose:
        ////
        ////   token:
        //[AsyncStateMachine(typeof(UserManager<,>.< VerifyUserTokenAsync > d__f9))]
        //[DebuggerStepThrough]
        //public virtual Task<bool> VerifyUserTokenAsync(TKey userId, string purpose, string token);
        ////
        //// Summary:
        ////     When disposing, actually dipose the store
        ////
        //// Parameters:
        ////   disposing:
        //protected virtual void Dispose(bool disposing);
        //[AsyncStateMachine(typeof(UserManager<,>.< UpdatePassword > d__39))]
        //[DebuggerStepThrough]
        //protected virtual Task<IdentityResult> UpdatePassword(IUserPasswordStore<TUser, TKey> passwordStore, TUser user, string newPassword);
        ////
        //// Summary:
        ////     By default, retrieves the hashed password from the user store and calls PasswordHasher.VerifyHashPassword
        ////
        //// Parameters:
        ////   store:
        ////
        ////   user:
        ////
        ////   password:
        //[AsyncStateMachine(typeof(UserManager<,>.< VerifyPasswordAsync > d__3e))]
        //[DebuggerStepThrough]
        //protected virtual Task<bool> VerifyPasswordAsync(IUserPasswordStore<TUser, TKey> store, TUser user, string password);
    }
}
