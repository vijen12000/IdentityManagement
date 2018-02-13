using Identity.POC.Data.Contexts;
using Identity.POC.Entities;
using System;
using System.Threading.Tasks;

namespace Identity.POC.Repositories
{
    public class RightRepository<TKey, TRight, TUserRole, TRoleClaim>//: IRoleRepository<TKey, TRole, TUserRole, TRoleClaim>
       where TKey : IEquatable<TKey>
       where TRight : IdentityRight<TKey>
       where TUserRole : IdentityUserRole<TKey>
       where TRoleClaim : IdentityRoleClaim<TKey>
    {
        private readonly DbContext _context;

        public RightRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<TRight> GetById(TKey id)
        {
            return await _context.QueryFirstOrDefaultAsync<TRight>("select * from IdentityRight where id=@id", new { id = id });
        }

        public async Task<TRight> GetByName(string right)
        {
            return await _context.QueryFirstOrDefaultAsync<TRight>("select * from IdentityRight where Name like '%@id%'", new { Name = right });
        }

        public void Insert(TRight right)
        {
            _context.Execute("insert into IdentityRight values (@Name)", right);
        }

        public void Remove(TKey id)
        {
            _context.Execute("delete from IdentityRight where id=@id", new { id = id });
        }

        public void Update(TRight right)
        {
            _context.Execute("update IdentityRight set name=@Name where id=@Id", right);
        }
    }
}