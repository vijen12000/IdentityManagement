using Identity.Core;
using Identity.Core.Entities;
using Identity.Data;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Repositories
{
    public class UserRepository<TKey, TUser, TUserRole, TRoleClaim> : IUserRepository<TKey, TUser, TUserRole, TRoleClaim>
        where TKey : IEquatable<TKey>
        where TUser : IdentityUser<TKey>
        where TUserRole : IdentityUserRole<TKey>
        where TRoleClaim : IdentityRoleClaim<TKey>
    {
        private readonly DbContext _context;
        private readonly IRoleRepository<TKey, IdentityRole<TKey>, TUserRole, TRoleClaim> _roleRepository;
        
        public UserRepository(DbContext context, IRoleRepository<TKey, IdentityRole<TKey>, TUserRole, TRoleClaim> roleRepository)
        {
            _context = context;
            _roleRepository = roleRepository;
        }

        public void AddToRole(TKey id, string roleName)
        {
            var role = _roleRepository.GetByName(roleName);
            if (role == null)
                throw new InvalidOperationException($"Not found role with rolename:{roleName}");
            _context.Execute("insert into UserRoles values (@UserId,@RoleId)", new { UserId = id, RoleId = role.Id });
        }

        public  IQueryable<TUser> GetAll()
        {
            var result=_context.Query<TUser>("select * from Users");
            return result.ToList().AsQueryable<TUser>();
        }

        public async Task<TUser> GetByEmail(string email)
        {
            return await _context.QueryFirstOrDefaultAsync<TUser>("select * from Users where email=@email", new { email = email });
        }

        public async Task<TUser> GetById(TKey id)
        {
            return await _context.QueryFirstOrDefaultAsync<TUser>("select * from Users where id=@id", new { id = id });
        }

        public async Task<TUser> GetByUserLogin(string loginProvider, string providerKey)
        {
            return await _context.QueryFirstOrDefaultAsync<TUser>("select IU.* from Users IU,OAuthUserLogins IL where IU.Id=IL.UserId and IL.LoginProvider=@loginProvider and IL.providerKey=@providerKey", new { loginProvider = loginProvider, providerKey = providerKey });
        }

        public async Task<TUser> GetByUserName(string userName)
        {
            return await _context.QueryFirstOrDefaultAsync<TUser>("select * from Users where username = @userName", new { userName = userName });
        }

        public async Task<IList<Claim>> GetClaimsByUserId(TKey id)
        {
            var result = await _context.QueryAsync("select * from UserClaims where userId=@UserId", new { UserId = id });
            return result?.Select(x => new Claim(x.ClaimType, x.ClaimValue)).ToList();
        }

        public async Task<IList<string>> GetRolesByUserId(TKey id)
        {
            var result = await _context.QueryAsync<string>("select IR.Name from Roles IR,UserRoles IUR where IR.Id=IUR.RoleId and IUR.UserId=@UserId", new { UserId = id });
            return result.ToList();
        }

        public async Task<IList<UserLoginInfo>> GetUserLoginInfoById(TKey id)
        {
            var result = await _context.QueryAsync("select LoginProvider,ProviderKey from OAuthUserLogins  where  UserId=@UserId", new { UserId = id });
            return result?.Select(x => new UserLoginInfo(x.LoginProvicer, x.Providerkey)).ToList();
        }

        public async Task<IList<TUser>> GetUsersByClaim(Claim claim)
        {
            var result = await _context.QueryAsync<TUser>("select IU.* from Users IU,UserClaims IUC where IU.Id=IUC.UserId and IUC.ClaimType=@ClaimType and IUC.ClaimValue=@ClaimValue", new { ClaimType = claim.Type, ClaimValue = claim.Value });
            return result.ToList();
        }

        public async Task<IList<TUser>> GetUsersInRole(string roleName)
        {
            var result = await _context.QueryAsync<TUser>("select IU.* from Users IU,UserRoles IUR,Roles IR where IU.Id=IUR.UserId and IUR.RoleId=IR.Id and IR.Name = '@RoleName'", new { RoleName = roleName });
            return result.ToList();
        }

        public void Insert(TUser user)
        {
            _context.Execute("insert into Users values (@Email,@EmailConfirmed,@PasswordHash,@SecurityStamp,@PhoneNumber,@PhoneNumberConfirmed,@TwoFactorEnabled,@LockoutEndDateUtc,@LockoutEnabled,@AccessFailedCount,@UserName)", user);
        }

        public void InsertClaims(TKey id, IEnumerable<Claim> claims)
        {
            foreach (var claim in claims)
            {
                _context.Execute("insert into UserClaims values (@UserId,@ClaimType,@ClaimValue)", new { UserId = id, ClaimType = claim.Type, ClaimValue = claim.Value });
            }
        }

        public void InsertLoginInfo(TKey id, UserLoginInfo loginInfo)
        {
            _context.Execute("insert into OAuthUserLogins values (@UserId,@LoginProvider,@ProviderKey)", new { UserId = id, LoginProvider = loginInfo.LoginProvider, ProviderKey = loginInfo.ProviderKey });
        }

        public async Task<bool> IsInRole(TKey id, string roleName)
        {
            var result = await _context.QueryAsync("select * from UserRoles IUR,Roles IR where IUR.RoleId=IR.Id and IR.Name='@RoleName' and IUR.UserId=@UserId", new { RoleName = roleName, UserId = id });
            return result?.Count() > 0;
        }

        public void Remove(TKey id)
        {
            _context.Execute("delete from Users where id=@id", new { id = id });
        }

        public void RemoveClaims(TKey id, IEnumerable<Claim> claims)
        {
            foreach (var claim in claims)
            {
                _context.Execute("delete from UserClaims where UserId=@UserId and ClaimType=@ClaimType and ClaimValue=@ClaimValue", new { ClaimType = claim.Type, ClaimValue = claim.Value, UserId = id });
            }
        }

        public void RemoveFromRole(TKey id, string roleName)
        {
            _context.Execute("delete from UserRoles where UserId=@UserId and RoleId in (select Id from Roles where Name=@RoleName)", new { UserId = id, RoleName = roleName });
        }

        public void RemoveLogin(TKey id, string loginProvider, string providerKey)
        {
            _context.Execute("delete from OAuthUserLogins where UserId=@UserId and loginProvider = @LoginProvider, providerKey= @ProviderKey", new { UserId = id, LoginProvider = loginProvider, ProviderKey = providerKey });
        }

        public void Update(TUser user)
        {
            _context.Execute("update Users set Email=@Email,EmailConfirmed=@EmailConfirmed,PasswordHash=@PasswordHash,SecurityStamp=@SecurityStamp,PhoneNumber=@PhoneNumber,PhoneNumberConfirmed=@PhoneNumberConfirmed,TwoFactorEnabled=@TwoFactorEnabled,LockoutEndDateUtc=@LockoutEndDateUtc,LockoutEnabled=@LockoutEnabled,AccessFailedCount=@AccessFailedCount,UserName=@UserName", user);
        }

        public void UpdateClaim(TKey id, Claim oldClaim, Claim newClaim)
        {
            _context.Execute("update UserClaims set ClaimType=@NewClaimType,ClaimValue=@NewClaimValue where UserId=@UserId and ClaimType=@OldClaimType and ClaimValue=@OldClaimValue", new { UserId = id, NewClaimType = newClaim.Type, NewClaimValue = newClaim.Value, OldClaimType = oldClaim.Type, OldClaimValue = oldClaim.Value });
        }
    }
}