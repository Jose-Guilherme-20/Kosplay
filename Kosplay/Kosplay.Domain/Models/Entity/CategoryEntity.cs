namespace Kosplay.Domain.Models.Entity
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<ProductEntity> Products { get; set; }
    }
}
