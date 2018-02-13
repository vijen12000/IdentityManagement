using Identity.Core;
using Identity.Core.Entities;
using Identity.Core.Services;
using Identity.Data;
using Identity.Repositories;
using Microsoft.Practices.Unity;
using System;
using WebUI._1._0.Core;
using WebUI._1._0.Core.Model;

namespace WebUI._1._0
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;

        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {            
            container.RegisterType<DbContext>(new PerRequestLifetimeManager());

            //container.RegisterType<IAnyRepository, AnyRepository>();

            container.RegisterType<IUserRepository<string, IdentityUser, IdentityUserRole<string>, IdentityRoleClaim<string>>, UserRepository<string, IdentityUser, IdentityUserRole<string>, IdentityRoleClaim<string>>>();

            container.RegisterType<IRoleRepository<string, IdentityRole, IdentityUserRole<string>, IdentityRoleClaim<string>>, RoleRepository<string, IdentityRole, IdentityUserRole<string>, IdentityRoleClaim<string>>>();
            container.RegisterType<IUnitOfWorkFactory, UnitOfWorkFactory>();
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            
            container.RegisterType<AppUserManager>(new PerRequestLifetimeManager());
            container.RegisterType<AppSignInManager>(new PerRequestLifetimeManager());
            container.RegisterType<UserStore<string, ExtendedUser, IdentityUserRole<string>, IdentityRoleClaim<string>>>(new PerRequestLifetimeManager());
            container.RegisterType<RoleStore<string, IdentityRole, IdentityUserRole<string>, IdentityRoleClaim<string>>>(new PerRequestLifetimeManager());
        }
    }
}