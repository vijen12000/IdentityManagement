using Identity.Core.Entities;
using Identity.Core.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Practices.Unity;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using WebUI._1._0.Core.Model;

namespace WebUI._1._0.Core
{

    public class AppUserManager : UserManager<ExtendedUser, string>
    {
        public AppUserManager(IUserStore<ExtendedUser, string> store)
            : base(store)
        {

        }

        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            var container = UnityConfig.Container;
            var userStore = container.Resolve<UserStore<string, ExtendedUser, IdentityUserRole<string>, IdentityRoleClaim<string>>>();
                        
            var manager = new AppUserManager(userStore);

            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ExtendedUser, string>(manager)
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
                    new DataProtectorTokenProvider<ExtendedUser, string>(dataProtectionProvider.Create("Icreon Identity Provider"));
            }
            return manager;
        }
    }

    public class AppRoleManager : RoleManager<IdentityRole, string>
    {
        public AppRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
        }

        public static AppRoleManager Create(IdentityFactoryOptions<AppRoleManager> options, IOwinContext context)
        {
            var container = UnityConfig.Container;
            var roleStore = container.Resolve<RoleStore<string, IdentityRole, IdentityUserRole<string>, IdentityRoleClaim<string>>>();            
            return new AppRoleManager(roleStore);
        }
    }
    
    public class AppSignInManager : SignInManager<ExtendedUser, string>
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