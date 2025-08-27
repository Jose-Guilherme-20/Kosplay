namespace Kosplay.API.Vmodels.Products
{
    public class RequestCreateProductViewModel
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public List<int> ImageIds { get; set; }

        public static implicit operator Domain.Models.Entity.ProductEntity(RequestCreateProductViewModel model)
        {
            return new Domain.Models.Entity.ProductEntity
            {
                Name = model.Name,
                CategoryId = model.CategoryId
            };
        }
    }
}
