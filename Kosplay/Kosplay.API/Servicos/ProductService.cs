using Kosplay.API.Servicos.Interfaces;
using Kosplay.API.Vmodels.Products;
using Kosplay.Domain.Enum;
using Kosplay.Domain.Interfaces.Repository;
using Kosplay.Domain.Interfaces.UnitOfWork;
using Kosplay.Domain.Models.HttpService;

namespace Kosplay.API.Servicos
{
    public class ProductService(IProductRepository productRepository,
            IIdentityService identityService,
            IUnitOfWork unitOfWork) : IProductService
    {

        public async Task AddProductAsync(RequestCreateProductViewModel request)
        {
            // Validate request
            ValidateRequest(request);

            var userLoggedId = identityService.GetUserId();

            var product = (Domain.Models.Entity.ProductEntity)request;

            product.UserId = int.Parse(userLoggedId);
            product.StatusId = (int)StatusEnum.Created;

            await productRepository.AddAsync(product);

            await unitOfWork.CommitAsync();
        }

        private void ValidateRequest(RequestCreateProductViewModel request)
        {
            // Implement validation logic here
        }
    }

}
