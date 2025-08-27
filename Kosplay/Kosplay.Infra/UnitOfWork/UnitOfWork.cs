
using Kosplay.Domain.Interfaces.UnitOfWork;
using Kosplay.Infra.Context;

namespace Kosplay.Infra.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly KosplayDbContext _context;

        public UnitOfWork(KosplayDbContext context)
        {
            _context = context;
        }
        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
