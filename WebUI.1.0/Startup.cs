using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using WebUI._1._0.Core;
using WebUI._1._0.Core.Model;

[assembly: OwinStartup(typeof(WebUI._1._0.Startup))]

namespace WebUI._1._0
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            const string connectionString= @"Data Source=.\SQLEXPRESS;Initial Catalog=Identity.1.0;User Id=sa;Password=Password@1";
            //app.CreatePerOwinContext(() => new IdentityDbContext(connectionString));
            app.CreatePerOwinContext(() => new ExtendedUserContext(connectionString));

            //app.CreatePerOwinContext<UserStore<IdentityUser>>((opt, cont) => new UserStore<IdentityUser>(cont.Get<IdentityDbContext>()));
            app.CreatePerOwinContext<UserStore<ExtendedUser>>((opt, cont) => new UserStore<ExtendedUser>(cont.Get<ExtendedUserContext>()));
            

            //app.CreatePerOwinContext<UserManager<IdentityUser>>(
            //                (opt, cont) => new UserManager<IdentityUser>(cont.Get<UserStore<IdentityUser>>()));

            app.CreatePerOwinContext<UserManager<ExtendedUser>>(
                            (opt, cont) => new UserManager<ExtendedUser>(cont.Get<UserStore<ExtendedUser>>()));

            //app.CreatePerOwinContext<SignInManager<IdentityUser, string>>((opt, cont) => new SignInManager<IdentityUser, string>(cont.Get<UserManager<IdentityUser>>(), cont.Authentication));
            app.CreatePerOwinContext<SignInManager<ExtendedUser, string>>((opt, cont) => new SignInManager<ExtendedUser, string>(cont.Get<UserManager<ExtendedUser>>(), cont.Authentication));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
            });
        }
    }
}
