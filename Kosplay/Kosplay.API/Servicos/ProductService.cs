using Kosplay.API.Servicos.Interfaces;
using Kosplay.Domain.Interfaces.Repository;

namespace Kosplay.API.Servicos
{
    public class ProductService(IProductRepository productRepository) : IProductService
    {

        public async Task AddProductAsync()
        {
            await productRepository.AddAsync();
        }
    }

}
