using Identity.Core;

namespace Identity.Data
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public readonly DbContext _context;

        public UnitOfWorkFactory(DbContext context)
        {
            _context = context;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_context);
        }
    }
}
