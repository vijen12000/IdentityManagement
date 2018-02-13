//using System;
//using System.Threading.Tasks;
//using Identity.Data;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin;
//using Microsoft.Owin.Security.Cookies;
//using Owin;
//using WebUI._1._0.Core;
//using WebUI._1._0.Core.Model;
//using WebUI._1._0.Core.Service;

//[assembly: OwinStartup(typeof(WebUI._1._0.Startup))]

//namespace WebUI._1._0
//{
//    public partial class Startup
//    {
//        public void Configuration(IAppBuilder app)
//        {
//            const string connectionString= @"Data Source=.\SQLEXPRESS;Initial Catalog=Identity.1.2;User Id=sa;Password=Password@1";
            
//            app.CreatePerOwinContext(() => new DbContext(connectionString));

//            //app.CreatePerOwinContext<UserStore<IdentityUser>>((opt, cont) => new UserStore<IdentityUser>(cont.Get<IdentityDbContext>()));
//            app.CreatePerOwinContext<UserStore<ExtendedUser>>((opt, cont) => new UserStore<ExtendedUser>(cont.Get<ExtendedUserContext>()));
            

//            //app.CreatePerOwinContext<UserManager<IdentityUser>>(
//            //                (opt, cont) => new UserManager<IdentityUser>(cont.Get<UserStore<IdentityUser>>()));

//            app.CreatePerOwinContext<UserManager<ExtendedUser>>(
//                            (opt, cont) =>
//                                {
//                                    var userManager= new UserManager<ExtendedUser>(cont.Get<UserStore<ExtendedUser>>());
//                                    userManager.UserTokenProvider = new DataProtectorTokenProvider<ExtendedUser>(opt.DataProtectionProvider.Create());
//                                    //userManager.EmailService = new EmailService();// Configure Email Service in order to send emails
//                                    return userManager;
//                                 }
//                                );

//            //app.CreatePerOwinContext<SignInManager<IdentityUser, string>>((opt, cont) => new SignInManager<IdentityUser, string>(cont.Get<UserManager<IdentityUser>>(), cont.Authentication));
//            app.CreatePerOwinContext<SignInManager<ExtendedUser, string>>((opt, cont) => new SignInManager<ExtendedUser, string>(cont.Get<UserManager<ExtendedUser>>(), cont.Authentication));

//            //app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

//            app.UseCookieAuthentication(new CookieAuthenticationOptions
//            {
//                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie
//            });

//            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions
//            //{
//            //    ClientId = "",
//            //    ClientSecret = "",
//            //    Caption = "Google"
//            //});
//        }
//    }
//}
