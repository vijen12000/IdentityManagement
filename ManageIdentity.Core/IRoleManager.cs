using System.Linq;
using System.Threading.Tasks;

namespace ManageIdentity.Core
{
    public interface IRoleManager<TRole> where TRole : class
    {
        IdentityErrorDescriber ErrorDescriber { get; set; }
        ILookupNormalizer KeyNormalizer { get; set; }
        ILogger Logger { get; set; }
        IQueryable<TRole> Roles { get; }
        System.Collections.Generic.IList<IRoleValidator<TRole>> RoleValidators { get; }
        bool SupportsQueryableRoles { get; }
        bool SupportsRoleClaims { get; }

        Task<IdentityResult> AddClaimAsync(TRole role, Claim claim);
        Task<IdentityResult> CreateAsync(TRole role);
        Task<IdentityResult> DeleteAsync(TRole role);
        void Dispose();
        Task<TRole> FindByIdAsync(string roleId);
        Task<TRole> FindByNameAsync(string roleName);
        Task<System.Collections.Generic.IList<Claim>> GetClaimsAsync(TRole role);
        Task<string> GetRoleIdAsync(TRole role);
        Task<string> GetRoleNameAsync(TRole role);
        string NormalizeKey(string key);
        Task<IdentityResult> RemoveClaimAsync(TRole role, Claim claim);
        Task<bool> RoleExistsAsync(string roleName);
        Task<IdentityResult> SetRoleNameAsync(TRole role, string name);
        Task<IdentityResult> UpdateAsync(TRole role);
        Task UpdateNormalizedRoleNameAsync(TRole role);
    }
}