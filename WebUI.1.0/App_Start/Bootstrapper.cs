using Identity.Core;
using Identity.Core.Data;
using Identity.Core.Entities;
using Identity.Core.Services;
using Identity.Data;
using Identity.Repositories;
using Ninject;
using Ninject.Web.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebUI._1._0.Core;
using WebUI._1._0.Core.Model;

namespace WebUI._1._0.App_Start
{
    public class Bootstrapper 
    {
        public static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            //Create the bindings
            kernel.Bind<IContext>().To<DbContext>().InScope(s => s.Request);
            kernel.Bind<IUserRepository<int, IdentityUser, IdentityUserRole<int>, IdentityRoleClaim<int>>>().To<UserRepository<int, IdentityUser, IdentityUserRole<int>, IdentityRoleClaim<int>>>();
            kernel.Bind<IRoleRepository<int, IdentityRole, IdentityUserRole<int>, IdentityRoleClaim<int>>>().To<RoleRepository<int, IdentityRole, IdentityUserRole<int>, IdentityRoleClaim<int>>>();

            //kernel.Bind<AppUserManager>(new PerRequestLifetimeManager());
            //container.RegisterType<AppSignInManager>(new PerRequestLifetimeManager());

            kernel.Bind<UserStore<int, ExtendedUser, IdentityUserRole<int>, IdentityRoleClaim<int>>>().InScope(s => s.Request);
            kernel.Bind<RoleStore<int, IdentityRole, IdentityUserRole<int>, IdentityRoleClaim<int>>>(new PerRequestLifetimeManager());

            return kernel;
        }
    }
}