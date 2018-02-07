using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageIdentity.Core
{
    interface IRightsManager
    {     
        IQueryable<TRight> Rights { get; }             
        Task CreateAsync(TRight right);
        Task DeleteAsync(TRight right);        
        Task<TRight> FindByIdAsync(string rightId);
        Task<TRight> FindByNameAsync(string rightName);
        Task<IList<TRight>> GetRightsAsync(TRole role);
        Task<IList<TRight>> GetRightsAsync(TUser user);
        Task<string> GetRightIdAsync(TRight right);
        Task<string> GetRightNameAsync(TRight right);        
        Task RemoveRightAsync(TRight right, TUser user);
        Task RemoveRightAsync(TRight right, TRole role);
        Task<bool> RightExistsAsync(string rightName);        
        Task UpdateAsync(TRight right);                
    }
}
