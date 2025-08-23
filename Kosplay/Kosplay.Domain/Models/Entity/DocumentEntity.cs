
namespace Kosplay.Domain.Models.Entity
{
    public class DocumentEntity : BaseEntity
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        public virtual ICollection<ProductImagesEntity> Images { get; set; }
    }
}
