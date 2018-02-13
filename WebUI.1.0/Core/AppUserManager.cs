using Identity.Core.Entities;
using Identity.Core.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebUI._1._0.Core.Model;

namespace WebUI._1._0.Core
{

    public class AppUserManager : UserManager<ExtendedUser, int>
    {
        public AppUserManager(IUserStore<ExtendedUser, int> store)
            : base(store)
        {

        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var container = UnityConfig.GetConfiguredContainer();
            var userStore = container.Resolve<UserStore<int, ExtendedUser, IdentityUserRole<int>, IdentityRoleClaim<int>>>();
            var manager = new AppUserManager(userStore);

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ExtendedUser, int>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };
            
            manager.UserLockoutEnabledByDefault = false;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;
            
            manager.EmailService = new EmailService(); // Not configured, can be implemented when required
            manager.SmsService = new SmsService(); // Not configured, can be implemented when required

            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ExtendedUser, int>(dataProtectionProvider.Create("Icreon Identity Provider"));
            }
            return manager;
        }
    }

    public class AppRoleManager : RoleManager<IdentityRole, int>
    {
        public AppRoleManager(IRoleStore<IdentityRole, int> roleStore)
            : base(roleStore)
        {
        }

        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context)
        {
            var container = UnityConfig.GetConfiguredContainer();
            var roleStore = container.Resolve<RoleStore<int, IdentityRole, IdentityUserRole<int>, IdentityRoleClaim<int>>>();
            return new AppRoleManager(roleStore);
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class AppSignInManager : SignInManager<ExtendedUser, int>
    {
        public AppSignInManager(AppUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ExtendedUser user)
        {
            return user.GenerateUserIdentityAsync((AppUserManager)UserManager);
        }

        public static AppSignInManager Create(IdentityFactoryOptions<AppSignInManager> options, IOwinContext context)
        {
            return new AppSignInManager(context.GetUserManager<AppUserManager>(), context.Authentication);
        }
    }
}