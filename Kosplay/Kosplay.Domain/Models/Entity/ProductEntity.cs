namespace Kosplay.Domain.Models.Entity
{
    public class ProductEntity : BaseEntity
    {
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public virtual CategoryEntity Category { get; set; }
        public virtual StatusEntity Status { get; set; }
        public virtual UserEntity User { get; set; }
        public virtual ICollection<ProductImagesEntity> Images { get; set; }
    }
}
