using Identity.POC.Entities;
using System;
using System.Threading.Tasks;

namespace Identity.POC.Repositories
{
    public interface IRightRepository<TKey, TRight, TUserRight>
        where TKey : IEquatable<TKey>
        where TRight : IdentityRight<TKey>
        where TUserRight : IdentityUserRole<TKey>        
    {
        void Insert(TRight right);

        void Remove(TKey id);

        void Update(TRight role);

        Task<TRight> GetById(TKey id);

        Task<TRight> GetByName(string rightName);
    }
}