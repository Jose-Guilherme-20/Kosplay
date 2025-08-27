
namespace Kosplay.Domain.Models.Entity
{
    public class ProductImagesEntity : BaseEntity
    {
        public int ProductId { get; set; }
        public int DocumentId { get; set; }
        public virtual ProductEntity Product { get; set; }
        public virtual DocumentEntity Document { get; set; }

    }
}
