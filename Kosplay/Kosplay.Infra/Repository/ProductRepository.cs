
using Kosplay.Domain.Interfaces.Repository;
using Kosplay.Domain.Models.Entity;
using Kosplay.Infra.Context;

namespace Kosplay.Infra.Repository
{
    public class ProductRepository : EntityBaseRepository<ProductEntity>, IProductRepository
    {
        private readonly KosplayDbContext _context;
        public ProductRepository(KosplayDbContext context) : base(context)
        {
            _context = context;
        }
    }
}
