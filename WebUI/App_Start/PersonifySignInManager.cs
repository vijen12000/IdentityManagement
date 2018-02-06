using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using WebUI.Models;

namespace WebUI
{
    // Configure the application sign-in manager which is used in this application.
    public class PersonifySignInManager : SignInManager<User, string>
    {
        public PersonifySignInManager(PersonifyUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((PersonifyUserManager)UserManager);
        }

        public static PersonifySignInManager Create(IdentityFactoryOptions<PersonifySignInManager> options, IOwinContext context)
        {
            return new PersonifySignInManager(context.GetUserManager<PersonifyUserManager>(), context.Authentication);
        }
    }
}
